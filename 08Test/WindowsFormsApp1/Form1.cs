using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class 诊疗码测试 : Form
    {
        public 诊疗码测试()
        {
            InitializeComponent();
            listView1.View = View.Details;
        }

        private async void textBox1_TextChanged(object sender, EventArgs e)
        {
            var _source = await GetSpspListByDesc(textBox1.Text.ToUpper(), "YN");

            listView1.BeginUpdate();
            listView1.Items.Clear();
            if (_source != null)
                listView1.Items.AddRange(_source.Select(x => new ListViewItem(new[] { x.Id, x.Text })).ToArray());
            listView1.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            listView1.Columns[1].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            listView1.EndUpdate();
        }



        public async Task<IEnumerable<CodeTableModel>> GetSpspListByDesc(string param, string connectionStringFlag)
        {
            if (string.IsNullOrWhiteSpace(param)) return null;
            var result = await GetStringAsync($"https://ynprd.ensurlink.com.cn:9527/api/codetable/spsp/{connectionStringFlag}/{param}");
            // var result = await HttpClientHelper.GetStringAsync($"{_baseUri}/api/CodeTable/spsp/{param}");
            Console.WriteLine($" param :{param},   result:{result}");
            return JsonConvert.DeserializeObject<dynamic[]>(result).Select(x => new CodeTableModel { Id = x["id"].ToString(), Text = x["text"].ToString() });
        }
        public async Task<string> GetStringAsync(string requestUri)
        {
            //return await httpClient.GetStringAsync(requestUri);
            using (var client = new HttpClient())
                return await client.GetStringAsync(requestUri);
        }

    }

    public class CodeTableModel
    {
        public string Id { get; set; }
        public string Text { get; set; }
    }

}
