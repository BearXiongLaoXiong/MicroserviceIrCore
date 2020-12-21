using MicroserviceCodeTable.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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

        [HttpGet("ReLoadCache/{dbFlag}")]
        public int ReLoadCache(string dbFlag) => TbehUscnUserClientInfo.ReLoadCache(dbFlag);
    }
}
