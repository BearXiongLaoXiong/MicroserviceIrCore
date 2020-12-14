using MicroserviceCodeTable.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroserviceCodeTable.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CommonController : ControllerBase
    {

        private readonly ILogger<WeatherForecastController> _logger;

        public CommonController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }


        [HttpGet("sysv/{con}/{name}/{key}/")]
        public async Task<string> FindDictionaryByValue(string con, string name, string key) => name switch
        {
            "u" => await Task.FromResult(TbehSysvVariableInfo.FindAllBySysvKy(con, name, key)),
            "p" => await Task.FromResult(TxehSysvVariableInfo.FindAllBySysvKy(con, name, key)),
            "m" => await Task.FromResult(TbehSysvVariableInfo.FindAllByMainSysvKy(con, name, key)),
            _ => null
        };

        [HttpGet("devsysv/{con}/{name}/{key}/")]
        public async Task<string> FindDevDictionaryByValue(string con, string name, string key) => name switch
        {
            "u" => await Task.FromResult(TbehSysvVariableInfo.FindAllByDevSysvKy(con, name, key)),
            "p" => await Task.FromResult(TxehSysvVariableInfo.FindAllByDevSysvKy(con, name, key)),
            _ => null
        };
        //=> await Task.FromResult(TxehSysvVariableInfo.FindAllBySysvKy("CB", "t", "ALLMEMESYSV_MEME_REL_CD"));

    }
}
