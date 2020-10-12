using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using XCode.DataAccessLayer;
using MicroserviceCodeTable.Model;
using NewLife.Log;
using Microsoft.Data.SqlClient;

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

        [HttpGet("spsp/{desc}")]
        public async Task<IActionResult> FindAllBySpspDesc(String desc)
            => await Task.FromResult(new JsonResult(TmpSpspSelect.FindAllBySpspDesc(desc).Select(x => new { Id = x.SpspID, Text = x.SpspDesc })));


        [HttpGet("stst/{desc}")]
        public async Task<IActionResult> FindAllByStstDesc(String desc)
            => await Task.FromResult(new JsonResult(TmpStstSelect.FindAllByStstDesc(desc).Select(x => new { Id = x.SpspID, Text = x.SpspDesc })));

        [HttpGet("id/{id}")]
        public async Task<IActionResult> FindById(String id)
            => await Task.FromResult(new JsonResult(TmpStstSelect.FindById(id)));

        [HttpGet("test")]
        public string test()
        {
            TmpStstSelect.Meta.Cache.Clear(nameof(TmpStstSelect));
            return "gogogo";
        }
    }

}
