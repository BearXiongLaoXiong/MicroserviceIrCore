using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Serialization;
using NewLife;
using NewLife.Data;
using NewLife.Log;
using NewLife.Model;
using NewLife.Reflection;
using NewLife.Threading;
using NewLife.Web;
using XCode;
using XCode.Cache;
using XCode.Configuration;
using XCode.DataAccessLayer;
using XCode.Membership;

namespace MicroserviceCodeTable.Model
{
    /// <summary></summary>
    public partial class TbehSpspSvcprocInfo : Entity<TbehSpspSvcprocInfo>
    {
        #region 对象操作
        static TbehSpspSvcprocInfo()
        {
            Meta.Cache.Expire = 3600;
            Meta.Cache.FillListMethod = () => FindAll().OrderBy(x => x.SpspDesc.Length).ToList();
            // 累加字段，生成 Update xx Set Count=Count+1234 Where xxx
            //var df = Meta.Factory.AdditionalFields;
            //df.Add(__.DodoKy);

            // 过滤器 UserModule、TimeModule、IPModule
        }

        /// <summary>验证数据，通过抛出异常的方式提示验证失败。</summary>
        /// <param name="isNew">是否插入</param>
        public override void Valid(Boolean isNew)
        {
            // 如果没有脏数据，则不需要进行任何处理
            if (!HasDirty) return;

            // 这里验证参数范围，建议抛出参数异常，指定参数名，前端用户界面可以捕获参数异常并聚焦到对应的参数输入框
            if (SpspID.IsNullOrEmpty()) throw new ArgumentNullException(nameof(SpspID), "SpspID不能为空！");
            
            if (SpspDesc.IsNullOrEmpty()) throw new ArgumentNullException(nameof(SpspDesc), "SpspDesc不能为空！");
            if (SpspDescEng.IsNullOrEmpty()) throw new ArgumentNullException(nameof(SpspDescEng), "SpspDescEng不能为空！");
            
            if (SpspNameFst.IsNullOrEmpty()) throw new ArgumentNullException(nameof(SpspNameFst), "SpspNameFst不能为空！");
            if (SpspNameFul.IsNullOrEmpty()) throw new ArgumentNullException(nameof(SpspNameFul), "SpspNameFul不能为空！");

            // 在新插入数据或者修改了指定字段时进行修正

            // 检查唯一索引
            // CheckExist(isNew, __.SpspID);
        }

        ///// <summary>首次连接数据库时初始化数据，仅用于实体类重载，用户不应该调用该方法</summary>
        //[EditorBrowsable(EditorBrowsableState.Never)]
        //protected internal override void InitData()
        //{
        //    // InitData一般用于当数据表没有数据时添加一些默认数据，该实体类的任何第一次数据库操作都会触发该方法，默认异步调用
        //    if (Meta.Session.Count > 0) return;

        //    if (XTrace.Debug) XTrace.WriteLine("开始初始化TbehSpspSvcprocInfo[TbehSpspSvcprocInfo]数据……");

        //    var entity = new TbehSpspSvcprocInfo();
        //    entity.SpspID = "abc";
        //    entity.SysvSpspType = "abc";
        //    entity.SysvSpspLevel = "abc";
        //    entity.DodoKy = 0;
        //    entity.SpspDesc = "abc";
        //    entity.SpspDescEng = "abc";
        //    entity.RefID = "abc";
        //    entity.RefId2 = "abc";
        //    entity.RefId3 = "abc";
        //    entity.Comment = "abc";
        //    entity.SpspNameFst = "abc";
        //    entity.SpspNameFul = "abc";
        //    entity.Insert();

        //    if (XTrace.Debug) XTrace.WriteLine("完成初始化TbehSpspSvcprocInfo[TbehSpspSvcprocInfo]数据！");
        //}

        ///// <summary>已重载。基类先调用Valid(true)验证数据，然后在事务保护内调用OnInsert</summary>
        ///// <returns></returns>
        //public override Int32 Insert()
        //{
        //    return base.Insert();
        //}

        ///// <summary>已重载。在事务保护范围内处理业务，位于Valid之后</summary>
        ///// <returns></returns>
        //protected override Int32 OnDelete()
        //{
        //    return base.OnDelete();
        //}
        #endregion

        #region 扩展属性
        #endregion

        #region 扩展查询
        /// <summary>根据SpspID查找</summary>
        /// <param name="spspId">SpspID</param>
        /// <returns>实体对象</returns>
        public static TbehSpspSvcprocInfo FindBySpspID(String spspId)
        {
            if (spspId.IsNullOrEmpty()) return null;

            // 实体缓存
            if (Meta.Session.Count < 1000) return Meta.Cache.Find(e => e.SpspID == spspId);

            // 单对象缓存
            return Meta.SingleCache[spspId];

            //return Find(_.SpspID == spspId);
        }

        /// <summary>
        /// spi过滤
        /// </summary>
        private static string[] SpiFilterList = new[] { "SYB", "AIABJ" };
        /// <summary>根据SpspDesc查找</summary>
        /// <param name="desc">SpspDesc</param>
        /// <returns>实体列表</returns>
        public static IEnumerable<TbehSpspSvcprocInfo> FindAllBySpspDesc(string dbFlag, string desc)
        {
            if (desc.IsNullOrEmpty() || dbFlag.IsNullOrEmpty()) return null;
            if (!SpiFilterList.Any(x => x.StartsWith(dbFlag)))
                return Meta.Cache.Entities.Where(e => (e.SpspDesc??"").Contains(desc) || (e.SpspID ?? "").Contains(desc) || (e.SpspNameFst ?? "").Contains(desc)).Take(50);
            else
                return Meta.Cache.Entities.Where(e => !e.SpspID.StartsWith("03") && ((e.SpspDesc ?? "").Contains(desc) || (e.SpspID ?? "").Contains(desc) || (e.SpspNameFst ?? "").Contains(desc))).Take(50);
            //return Meta.SingleCache.GetItemWithSlaveKey;

            // 实体缓存
            // if (Meta.Session.Count < 1000) return Meta.Cache.FindAll(e => e.SpspDesc == spspDesc);

            // return FindAll(_.SpspDesc == spspDesc);
        }
        #endregion

        #region 高级查询

        // Select Count(Id) as Id,Category From TbehSpspSvcprocInfo Where CreateTime>'2020-01-24 00:00:00' Group By Category Order By Id Desc limit 20
        //static readonly FieldCache<TbehSpspSvcprocInfo> _CategoryCache = new FieldCache<TbehSpspSvcprocInfo>(_.Category)
        //{
        //Where = _.CreateTime > DateTime.Today.AddDays(-30) & Expression.Empty
        //};

        ///// <summary>获取类别列表，字段缓存10分钟，分组统计数据最多的前20种，用于魔方前台下拉选择</summary>
        ///// <returns></returns>
        //public static IDictionary<String, String> GetCategoryList() => _CategoryCache.FindAllName();
        #endregion

        #region 业务操作
        #endregion
    }
}