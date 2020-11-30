using MicroserviceCodeTable.Model;
using NewLife;
using NewLife.Caching;
using NewLife.Log;
using NewLife.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using XCode.DataAccessLayer;

namespace MicroserviceCodeTable.Common
{
    public interface IDbContext
    {
        IEnumerable<CaseCountModel> GetDbContextList(string jobQueueFlag);
        int ReLoadCache(string jobQueueFlag);
    }

    public class MainDbContext : IDbContext
    {
        private readonly FullRedis _redis = new FullRedis();

        public MainDbContext()
        {
            _redis.Log = XTrace.Log;
            _redis.Init("Server=10.127.2.16:7001;Password=123456;Db=0");
        }

        private readonly ICache _cache = MemoryCache.Instance;
        public IEnumerable<CaseCountModel> GetDbContextList(string jobQueueFlag)
        {
            var res = ConvertJobQueueFlagToState(jobQueueFlag);
            var stateList = res.StateList;
            Expression<Func<CaseCountModel, bool>> expression = ex => stateList.Contains(ex.States);

            var key = $"casecount:prd:{res.Level}";
            var time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            var list = new List<CaseCountModel>();
            if (!_redis.ContainsKey(key))
            {
                //排除 dev,uat,peixun,demo4个不统计环境
                foreach (var item in DAL.ConnStrs.Keys.Where(k => k.StartsWith("p") && k!= "p10.127.1.3" && k != "p10.127.1.212" && k != "p10.127.1.38" && k != "p10.127.1.151"))
                {
                    var data = GetCaseCountModelByDbs(item, res.Level)?.ToList();
                    if (data != null && data.Count > 0)
                    {
                        data.ForEach(x => x.CreateDate = time);
                        list.AddRange(data);
                    }
                }
                _redis.Set(key, list.ToJson(), 1800);
            }
            var json = _redis.Get<string>(key);
            var count = JsonConvert.DeserializeObject<List<CaseCountModel>>(json);

            return count.Where(expression.Compile());
        }

        public int ReLoadCache(string jobQueueFlag)
        {
            var res = ConvertJobQueueFlagToState(jobQueueFlag);
            var key = $"casecount:prd:{res.Level}";
            return _redis.Remove(key);
        }

        //private readonly ICache _cache = MemoryCache.Instance;
        //public IEnumerable<CaseCountModel> GetDbContextList(string jobQueueFlag)
        //{
        //    var res = ConvertJobQueueFlagToState(jobQueueFlag);
        //    var stateList = res.StateList;
        //    Expression<Func<CaseCountModel, bool>> expression = ex => stateList.Contains(ex.States);

        //    var list = new List<CaseCountModel>();
        //    if (!_cache.Keys.Contains(res.Level))
        //    {
        //        foreach (var item in DAL.ConnStrs.Keys.Where(k => k.StartsWith("p")))
        //        {
        //            var data = GetCaseCountModelByDbs(item, res.Level)?.ToList();
        //            if (data != null && data.Count > 0) list.AddRange(data);
        //        }
        //        _cache.Set(res.Level, list, 600);
        //    }
        //    var count = _cache.GetList<CaseCountModel>(res.Level);

        //    return count.Where(expression.Compile());
        //}

        private IEnumerable<CaseCountModel> GetCaseCountModelByDbs(string key, string level = "BC")
        {
            string sql = level switch
            {
                "BC" => " SELECT PN.GPPN_COMP_ID AS ENTT_ID,SYSV_CLBC_STS as States,COUNT(1) AS Counts FROM TPA_PROD.dbo.TXEH_CLBC_CLM_BATCH_INFO BC JOIN TPA_PROD.dbo.TXEH_GPPN_PARENT_GROUP_INFO PN ON PN.GPPN_ID=BC.GPGP_KY WHERE BC.CLBC_SENDER_TYPE='P' GROUP BY PN.GPPN_COMP_ID, SYSV_CLBC_STS union " +
                        " SELECT GP.COMP_ID AS ENTT_ID, SYSV_CLBC_STS as States, COUNT(1) AS Counts FROM TPA_PROD.dbo.TXEH_CLBC_CLM_BATCH_INFO BC JOIN TPA_PROD.dbo.TXEH_GPGP_GROUP_INFO GP ON CAST(GP.GPGP_KY AS varchar(10)) = BC.GPGP_KY WHERE BC.CLBC_SENDER_TYPE = 'G' GROUP BY GP.COMP_ID, SYSV_CLBC_STS",
                "AP" => "SELECT PN.GPPN_COMP_ID AS ENTT_ID,SYSV_CLAP_STS as States,COUNT(1) AS Counts FROM TPA_PROD.dbo.TXEH_CLAP_CLM_APPL_INFO AP WITH(NOLOCK) JOIN TPA_PROD.dbo.TXEH_GPPN_PARENT_GROUP_INFO PN WITH(NOLOCK) ON PN.GPPN_ID=CAST(AP.GPGP_KY AS VARCHAR(25)) GROUP BY PN.GPPN_COMP_ID,SYSV_CLAP_STS UNION " +
                          "SELECT GP.COMP_ID AS ENTT_ID,SYSV_CLAP_STS as States,COUNT(1) AS Counts FROM TPA_PROD.dbo.TXEH_CLAP_CLM_APPL_INFO AP WITH(NOLOCK) JOIN TPA_PROD.dbo.TXEH_GPGP_GROUP_INFO GP WITH(NOLOCK) ON GP.GPGP_KY = CAST(AP.GPGP_KY AS VARCHAR(25)) GROUP BY GP.COMP_ID,SYSV_CLAP_STS",
                "VT" => " SELECT GP.COMP_ID AS ENTT_ID,SYSV_CLVT_STS as States,COUNT(1) AS Counts " +
                        " FROM TPA_PROD.dbo.TXEH_CLVT_CLM_VISIT_INFO VT JOIN TPA_PROD.dbo.TXEH_MEME_MEMBER_INFO ME ON ME.MEME_KY = VT.MEME_KY JOIN TPA_PROD.dbo.TXEH_GPGP_GROUP_INFO GP ON GP.GPGP_KY = ME.GPGP_KY GROUP BY GP.COMP_ID ,SYSV_CLVT_STS",
                "IV" => " SELECT GP.COMP_ID AS ENTT_ID,SYSV_CLIV_STS as States,COUNT(1) AS Counts " +
                        " FROM TPA_PROD.dbo.TXEH_CLIV_CLM_INVC_INFO IV JOIN TPA_PROD.dbo.TXEH_MEME_MEMBER_INFO ME ON ME.MEME_KY = IV.MEME_KY JOIN TPA_PROD.dbo.TXEH_GPGP_GROUP_INFO GP ON GP.GPGP_KY = ME.GPGP_KY GROUP BY GP.COMP_ID,SYSV_CLIV_STS",
                "BASEINPUT" => " SELECT GP.COMP_ID AS ENTT_ID,'101300' as States,COUNT(1) AS Counts FROM TPA_PROD.dbo.TXEH_IMIM_IMAGE_INFO I  WITH(NOLOCK) JOIN TPA_PROD.dbo.TXEH_CLAP_CLM_APPL_INFO A WITH(NOLOCK) ON A.CLAP_KY=I.CLAP_KY JOIN TPA_PROD.dbo.TXEH_GPGP_GROUP_INFO GP ON GP.GPGP_KY = A.GPGP_KY LEFT JOIN TPA_PROD.dbo.TXEH_CLIM_CLM_IMAGE_INFO M  WITH(NOLOCK) ON M.IMIM_KY=I.IMIM_KY " +
                            " WHERE I.SYSV_IMIM_STS ='02' AND I.SYSV_IMIM_TYPE2='0I' AND (ISNULL(M.IMIM_KY,0)=0 OR (ISNULL(M.IMIM_KY,0)<>0 AND M.SYSV_CLIM_TYPE = 'CPCP')) GROUP BY GP.COMP_ID " +
                            " UNION ALL SELECT GP.COMP_ID AS ENTT_ID,'101300' as States,COUNT(1) AS Counts FROM TPA_PROD.dbo.TXEH_IMIM_IMAGE_INFO I  WITH(NOLOCK) JOIN TPA_PROD.dbo.TXEH_CLAP_CLM_APPL_INFO A WITH(NOLOCK) ON A.CLAP_KY=I.CLAP_KY JOIN TPA_PROD.dbo.TXEH_GPGP_GROUP_INFO GP ON GP.GPGP_KY = A.GPGP_KY  LEFT JOIN TPA_PROD.dbo.TXEH_CLIM_CLM_IMAGE_INFO M  WITH(NOLOCK) ON M.IMIM_KY=I.IMIM_KY " +
                            " WHERE A.SYSV_CLAP_STS IN ('122','130','131') AND I.SYSV_IMIM_STS NOT IN ('FNL','02') AND I.SYSV_IMIM_TYPE2='0I' AND (ISNULL(M.IMIM_KY,0)=0 OR (ISNULL(M.IMIM_KY,0)<>0 AND M.SYSV_CLIM_TYPE = 'CPCP')) GROUP BY GP.COMP_ID ",
                _ => " select 'not_have_entt_id' as ENTT_ID, SYSV_CLBC_STS as State,count(*) as Counts from TXEH_CLBC_CLM_BATCH_INFO GROUP BY SYSV_CLBC_STS",
            };
            var dal = DAL.Create(key);
            try { return dal.Query<CaseCountModel>(sql); }
            catch (Exception err)
            {
                XTrace.Log.Write(LogLevel.All, err.ToString());
                return null;
            }
        }

        private (string[] StateList, string Level) ConvertJobQueueFlagToState(string jobQueueFlag)
        {
            return jobQueueFlag switch
            {
                "101" => (new[] { "AAAAAAAA" }, "NONE"),
                "102" => (new[] { "AAAAAAAA" }, "NONE"),
                "103" => (new[] { "AAAAAAAA" }, "NONE"),
                "104" => (new[] { "AAAAAAAA" }, "NONE"),
                "105" => (new[] { "AAAAAAAA" }, "NONE"),

                "201" => (new[] { "AAAAAAAA" }, "NONE"),
                "202" => (new[] { "001", "002", "003", "004", "005" }, "BC"),
                "203" => (new[] { "011", "012", "013", "022", "023", "024" }, "BC"),
                "204" => (new[] { "003", "006" }, "BC"),
                "205" => (new[] { "119", "179" }, "BC"),
                "206" => (new[] { "025", "120", "121" }, "AP"),
                "207" => (new[] { "180", "181" }, "VT"),
                "208" => (new[] { "143", "153", "01", "02" }, "AP"),
                "209" => (new[] { "182", "210", "211", "220", "221", "230", "231" }, "AP"),
                "210" => (new[] { "182", "210", "211", "220", "221", "230", "231" }, "AP"),
                "211" => (new[] { "182", "210", "211", "220", "221", "230", "231" }, "AP"),

                "301" => (new[] { "001", "002", "005", "006", "007" }, "BC"),
                "302" => (new[] { "AAAAAAAA" }, "NONE"),

                "401" => (new[] { "AAAAAAAA" }, "NONE"),
                "402" => (new[] { "AAAAAAAA" }, "NONE"),
                "403" => (new[] { "AAAAAAAA" }, "NONE"),

                //case "InitialReview.IRPRO.Modules._08_InvoiceEntry.BaseInfo.BasicInfoInput": return (new[] { "122", "130", "131" }, "IV");
                "501" => (new[] { "101300" }, "BASEINPUT"),
                "502" => (new[] { "140", "141" }, "IV"),
                "503" => (new[] { "150", "151" }, "IV"),
                "504" => (new[] { "160", "161" }, "IV"),
                "505" => (new[] { "AAAAAAAA" }, "NONE"),
                "506" => (new[] { "142", "145" }, "IV"),

                "601" => (new[] { "AAAAAAAA" }, "NONE"),
                _ => (new[] { "AAAAAAAA" }, "BC"),
            };
        }

        private void stest()
        {
            var ic = new FullRedis();
            ic.Init("Server=10.127.2.16:7001;Password=123456;Db=0");

            //var ic = new FullRedis("127.0.0.1:6379", null, 3);
            //var ic = new FullRedis();
            //ic.Server = "127.0.0.1:6379";
            //ic.Db = 3;
            ic.Log = XTrace.Log;
            var a = ic.Cluster.Nodes;

            // 简单操作
            Console.WriteLine("共有缓存对象 {0} 个", ic.Count);



            var hash = ic.GetDictionary<String>("xiong") as RedisHash<String, String>;


            //var dic = new Dictionary<String, String>
            //{
            //    ["aaa"] = "123",
            //    ["bbb"] = "456"
            //};

            var dic = new Dictionary<string, string>
            {
                { "a","111111" },
                { "b","222222" },
                { "c","333333" },
            };
            var rs = hash.HMSet(dic);

            // 字典
            //var dic = ic.GetDictionary<DateTime>("dic");
            //dic.Add("xxx", DateTime.Now);
            //Console.WriteLine(dic["xxx"].ToFullString());

            var reslut = hash.HMGet(new[] { "a", "b" });

            Console.WriteLine("共有缓存对象 {0} 个", ic.Count);
        }
    }


}
