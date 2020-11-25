using System;
using System.Configuration;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class TencentCloudApi
    {
        private readonly string _bucketName = ConfigurationManager.AppSettings["BucketName"];
        private readonly string _appId = ConfigurationManager.AppSettings["AppId"];
        private readonly string _secretId = ConfigurationManager.AppSettings["SecretID"];
        private readonly string _secretKey = ConfigurationManager.AppSettings["SecretKey"];
        private readonly string _region = "shanghai";
        private string Host(string bucketName, string appId) => $"{bucketName}-{appId}.cos.ap-{_region}.myqcloud.com";
        private string Url(string bucketName, string appId) => $"http://{Host(bucketName, appId)}";
        private Log logger = new();

        public TencentCloudApi() { }
        public string SetBucketAndAppId(string fullPath, out string bucketName, out string appId)
        {
            //fullPath = "http://pic2wx-1251750657.cos.ap-shanghai.myqcloud.com/0e504d15389902527577a995c.jpg";
            bucketName = _bucketName;
            appId = _appId;
            var absolutePath = "";
            try
            {
                var uri = new Uri(fullPath);
                absolutePath = uri.AbsolutePath;
                var domain = uri.Host.Split('-');
                if (domain.Length < 2) return "";

                bucketName = domain[0];
                appId = domain[1].Split('.')[0];
            }
            catch {/* ignored */}

            return absolutePath;
        }
        public async Task<bool> GetAsync(string fullPath, string savePath)
        {
            var fileName = SetBucketAndAppId(fullPath, out string bucketName, out string appId);
            if (string.IsNullOrEmpty(fileName)) return false;

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Host = Host(bucketName, appId);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", GetSignature(_secretId, _secretKey, Method.Get, fileName));
                var cts = new CancellationTokenSource();
                cts.CancelAfter(60000);
                using (var response = await client.GetAsync(Url(bucketName, appId) + fileName, cts.Token))
                {
                    logger.Info($"GetAsync【===】StatusCode:{response.StatusCode}; IsSuccessStatusCode :{response.IsSuccessStatusCode}; Response:{response.RequestMessage} ");
                    if (response.IsSuccessStatusCode)
                    {
                        var byteArray = await response.Content.ReadAsByteArrayAsync();
                        File.WriteAllBytes(savePath, byteArray);
                        logger.Info($"GetAsync【===】byteArrayLength:{byteArray.Length}");
                    }
                    return response.IsSuccessStatusCode;
                }
            }
        }

        public string GetSignature(string secretId, string secretKey, Method method, string fileName)
        {
            var time1 = (DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000000;
            var time2 = (DateTime.Now.AddDays(10).ToUniversalTime().Ticks - 621355968000000000) / 10000000;

            var qKeyTime = $"{time1};{time2}";
            var httpMethod = method.ToString().ToLower();
            var httpUrl = fileName;
            var httpParameters = "";
            var httpHeaders = "";
            var q_sign_algorithm = "sha1";
            var qSignTime = qKeyTime;

            var signKey = Hashhmac(qKeyTime, secretKey);
            var httpString = $"{httpMethod}\n{httpUrl}\n{httpParameters}\n{httpHeaders}\n";
            var sha1EdHttpString = Sha1(httpString);
            var stringToSign = $"{q_sign_algorithm}\n{qSignTime}\n{sha1EdHttpString}\n";
            var signature = Hashhmac(stringToSign, signKey);

            var authorization =
                $"q-sign-algorithm=sha1" +
                $"&q-ak={secretId}" +
                $"&q-sign-time={qKeyTime}" +
                $"&q-key-time={qKeyTime}" +
                $"&q-header-list=" +
                $"&q-url-param-list=" +
                $"&q-signature={signature}";
            return authorization;
        }
        private string Hashhmac(string signatureString, string secretKey)
        {
            HMACSHA1 hmac = new HMACSHA1(Encoding.UTF8.GetBytes(secretKey));
            hmac.Initialize();
            byte[] buffer = Encoding.UTF8.GetBytes(signatureString);
            return BitConverter.ToString(hmac.ComputeHash(buffer)).Replace("-", "").ToLower();
        }
        public string Sha1(string data)
        {
            var temp1 = Encoding.UTF8.GetBytes(data);
            var sha = new SHA1CryptoServiceProvider();
            var temp2 = sha.ComputeHash(temp1);
            sha.Clear();
            // 注意， 不能用这个
            // string output = Convert.ToBase64String(temp2);// 不能直接转换成base64string
            var output = BitConverter.ToString(temp2);
            output = output.Replace("-", "");
            output = output.ToLower();
            return output;
        }
    }

    public enum Method
    {
        Get,
        Put
    }

    public class Log
    {
        public void Info(string log)
        {
            Console.WriteLine(log);
        }
    }
}
