using MicroserviceCodeTable.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MicroserviceCodeTable.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CodeTableController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public CodeTableController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public IEnumerable<TmpStstSelect> Get()
        {
            return TmpStstSelect.FindAllByStstDesc("西");
        }
        //[HttpGet]
        //public IEnumerable<WeatherForecast> Get()
        //{
        //    var rng = new Random();
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateTime.Now.AddDays(index),
        //        TemperatureC = rng.Next(-20, 55),
        //        Summary = Summaries[rng.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}

        // [HttpGet("{name}")]
        // public  IList<TmpStstSelect> GetByName(string name)
        // {
        //     return TmpStstSelect.FindByName(name);
        // }

        //[HttpGet("{spspDesc}")]
        //public IList<TmpStstSelect> FindAllBySpspDesc(String spspDesc)
        //{
        //    return TmpStstSelect.FindByName(spspDesc);
        //}

        //[HttpGet("spsp/{dbflag}/{desc}/")]
        [HttpGet("spsp")]
        public async Task<IActionResult> FindAllBySpspDesc(string dbFlag, String desc)
            => await Task.FromResult(new JsonResult(TmpSpspSelect.FindAllBySpspDesc(dbFlag, HttpUtility.UrlDecode(desc, Encoding.UTF8))?.Select(x => new { Id = x.SpspID, Text = x.SpspDesc })));


        [HttpGet("stst")]
        public async Task<IActionResult> FindAllByStstDesc(string dbFlag, String desc)
            => await Task.FromResult(new JsonResult(TmpStstSelect.FindAllByStstDesc(HttpUtility.UrlDecode(desc, Encoding.UTF8))?.Select(x => new { Id = x.SpspID, Text = x.SpspDesc })));

        [HttpGet("hphp")]
        public async Task<IActionResult> FindAllByHphpDesc(string dbFlag, String desc)
            => await Task.FromResult(new JsonResult(TmpHphpSelect.FindAllByHphpDesc(HttpUtility.UrlDecode(desc, Encoding.UTF8))?.Select(x => new { Id = x.HphpID, Text = x.HphpName, Field1 = x.ScctName })));

        [HttpGet("dada")]
        public async Task<IActionResult> FindAllByDadaDesc(string dbFlag, String desc)
            => await Task.FromResult(new JsonResult(TbehDadaDiagInfo.FindAllByDadaDesc(HttpUtility.UrlDecode(desc, Encoding.UTF8))?.Select(x => new { Id = x.DadaID, Text = x.DadaDesc })));


        [HttpGet("id")]
        public async Task<IActionResult> FindById(String id)
            => await Task.FromResult(new JsonResult(TmpStstSelect.FindById(id)));

        [HttpGet("ReLoadCache/{type}/")]
        public string ReLoadCache(string type)
        {
            switch (type)
            {
                case "spsp":
                    TmpSpspSelect.Meta.Cache.Clear(nameof(TmpSpspSelect));
                    TmpSpspSelect.FindAllBySpspDesc("flag", "1");
                    return $"Success 200.{nameof(TmpSpspSelect)}";
                case "stst":
                    TmpStstSelect.Meta.Cache.Clear(nameof(TmpStstSelect));
                    TmpStstSelect.FindAllByStstDesc("1");
                    return $"Success 200.{nameof(TmpStstSelect)}";
                case "hphp":
                    TmpHphpSelect.Meta.Cache.Clear(nameof(TmpHphpSelect));
                    TmpHphpSelect.FindAllByHphpDesc("1");
                    return $"Success 200.{nameof(TmpHphpSelect)}";
                case "dada":
                    TbehDadaDiagInfo.Meta.Cache.Clear(nameof(TbehDadaDiagInfo));
                    TbehDadaDiagInfo.FindAllByDadaDesc("1");
                    return $"Success 200.{nameof(TbehDadaDiagInfo)}";
                default: return "none";
            }
        }

        [HttpGet("test/{a}/{b}")]
        public string test(string a, string b)
        {

            return "(" + a + "-" + b + ")";
        }

        public enum CodeTableTypes
        {
            Spsp,
            Stst,
            Hphp,
            Dada
        }
    }

}
