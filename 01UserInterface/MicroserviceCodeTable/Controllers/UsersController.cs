using MicroserviceCodeTable.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroserviceCodeTable.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpGet("jobchart/{flag}")]
        public async Task<IEnumerable<CaseCountModel>> FindAllBySpspDesc(string flag)
        => await Task.FromResult(new List<CaseCountModel>());

        [HttpGet("FindListByUserId")]
        public string FindListByUserId(string dbFlag, string id) => TbehUscnUserClientInfo.FindListByUserId(dbFlag, id);
    }
}
