using MicroserviceCodeTable.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XCode.DataAccessLayer;

namespace MicroserviceCodeTable.Common.Middleware
{
    /// <summary>
    /// 加载master数据库链接
    /// </summary>
    public static class InitializeDbConnectionStringCacheMiddleware
    {
        public static void InitializeDbConnectionString(this IServiceCollection services)
        {
            var allDbList = TbehCnevClientEnvironmentInfoToRedisConf.FindDistinctAllFromCache();
            var dbList = allDbList.Distinct(new DbCompareByIp());
            foreach (var item in dbList)
            { 
                DAL.AddConnStr($"u{item.CnevIp}", $"Server={item.CnevIp};Database=TPA_USER;User ID={item.CnevUser};Password={item.CnevPassword};", null, "MsSql");
                DAL.AddConnStr($"p{item.CnevIp}", $"Server={item.CnevIp};Database=TPA_PROD;User ID={item.CnevUser};Password={item.CnevPassword};", null, "MsSql");

            }
        }
        //private readonly RequestDelegate _next;
        //public InitializeDbConnectionStringCacheMiddleware(RequestDelegate next)=> _next = next;
        //public async Task InvokeAsync(HttpContext context)
        //{
        //    var allDbList = TbehCnevClientEnvironmentInfo.FindDistinctAllFromCache();
        //    var dbList = allDbList.Distinct(new DbCompareByIp());
        //     foreach (var item in dbList)
        //            DAL.AddConnStr(item.CnevIp, $"Server={item.CnevIp};Database=TPA_PROD;User ID={item.CnevUser};Password={item.CnevPassword};", null, "MsSql");
        //    await _next(context);
        //}
    }

    public class DbCompareByIp : IEqualityComparer<TbehCnevClientEnvironmentInfoToRedisConf>
    {
        public bool Equals(TbehCnevClientEnvironmentInfoToRedisConf x, TbehCnevClientEnvironmentInfoToRedisConf y) => (x == null || y == null) ? false : x.CnevIp == y.CnevIp;
        public int GetHashCode(TbehCnevClientEnvironmentInfoToRedisConf obj) => obj == null ? 0 : obj.CnevIp.GetHashCode();

    }

    //public static class IApplicationBuilderExtension
    //{
    //    public static IApplicationBuilder UseInitializeDbConnectionStringCacheMiddleware(this IApplicationBuilder builder)
    //    => builder.UseMiddleware<InitializeDbConnectionStringCacheMiddleware>();
    //}
}
