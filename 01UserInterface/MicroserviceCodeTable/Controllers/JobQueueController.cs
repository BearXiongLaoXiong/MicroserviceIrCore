
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MicroserviceCodeTable.Common;
using MicroserviceCodeTable.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NewLife.Caching;
using XCode.DataAccessLayer;

namespace MicroserviceCodeTable.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobQueueController : ControllerBase
    {
        private readonly ICache _cache = MemoryCache.Instance;
        private IDbContext _iDbContext;
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public JobQueueController(ILogger<WeatherForecastController> logger, IDbContext iDbContext)
        {
            _logger = logger;
            _iDbContext = iDbContext;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get(string flag)
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)],
                Ip = "gabao:" + (Request.HttpContext.Connection.LocalIpAddress.MapToIPv4().ToString() + ":" + Request.HttpContext.Connection.LocalPort)
            })
            .ToArray();
        }

        [HttpGet("jobchart/{flag}")]
        public async Task<IEnumerable<CaseCountModel>> FindAllBySpspDesc(string flag)
        => await Task.FromResult(_iDbContext.GetDbContextList(flag)?? new List<CaseCountModel>() {new CaseCountModel() });

    }


}

