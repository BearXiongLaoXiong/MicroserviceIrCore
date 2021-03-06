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
    public partial class TmpSpspSelect : Entity<TmpSpspSelect>
    {
        #region 对象操作
        static TmpSpspSelect()
        {
            Meta.Cache.Expire = 3600;
            Meta.Cache.FillListMethod = () => FindAll().OrderBy(x => x.SpspDesc.Length).ToList();
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
        }

        ///// <summary>首次连接数据库时初始化数据，仅用于实体类重载，用户不应该调用该方法</summary>
        //[EditorBrowsable(EditorBrowsableState.Never)]
        //protected internal override void InitData()
        //{
        //    // InitData一般用于当数据表没有数据时添加一些默认数据，该实体类的任何第一次数据库操作都会触发该方法，默认异步调用
        //    if (Meta.Session.Count > 0) return;

        //    if (XTrace.Debug) XTrace.WriteLine("开始初始化TmpSpspSelect[TmpSpspSelect]数据……");

        //    var entity = new TmpSpspSelect();
        //    entity.SpspID = "abc";
        //    entity.SpspDesc = "abc";
        //    entity.SpspDescEng = "abc";
        //    entity.SpspNameFst = "abc";
        //    entity.SpspNameFul = "abc";
        //    entity.Insert();

        //    if (XTrace.Debug) XTrace.WriteLine("完成初始化TmpSpspSelect[TmpSpspSelect]数据！");
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

        /// <summary>
        /// spi过滤
        /// </summary>
        private static string[] SpiFilterList = new[] { "SYB", "AIABJ" };

        private static IEnumerable<TmpSpspSelect> SearchKey(IEnumerable<TmpSpspSelect> iEnumerable, string key)
        => iEnumerable == null || string.IsNullOrWhiteSpace(key) ? iEnumerable : iEnumerable.Where(x => x.SpspDesc.Contains(key) || x.SpspNameFst.Contains(key) /*|| x.SpspNameFul.Contains(key)*/);

        /// <summary>根据SpspDesc查找</summary>
        /// <param name="desc">SpspDesc</param>
        /// <returns>实体列表</returns>
        public static IEnumerable<TmpSpspSelect> FindAllBySpspDesc(string dbFlag, string desc)
        {
            if (desc.IsNullOrEmpty() || dbFlag.IsNullOrEmpty()) return null;
            var stringArray = desc.Split(' ');

            IEnumerable<TmpSpspSelect> iEnumerable = Meta.Cache.Entities;
            if (SpiFilterList.Any(x => x.StartsWith(dbFlag)))
                iEnumerable = Meta.Cache.Entities.Where(e => !(e.SpspID ?? "").StartsWith("03"));

            foreach (var s in stringArray.Take(3)) iEnumerable = SearchKey(iEnumerable, s.ToUpper());
            return iEnumerable.Take(30);
            //if (!SpiFilterList.Any(x => x.StartsWith(dbFlag)))
            //    return Meta.Cache.Entities.Where(e => e.SpspDesc.Contains(desc) || e.SpspID.Contains(desc) || e.SpspNameFst.Contains(desc)).Take(50);
            //else
            //    return Meta.Cache.Entities.Where(e => !e.SpspID.StartsWith("03") && (e.SpspDesc.Contains(desc) || e.SpspID.Contains(desc) || e.SpspNameFst.Contains(desc))).Take(50);
            //return Meta.SingleCache.GetItemWithSlaveKey;

            // 实体缓存
            // if (Meta.Session.Count < 1000) return Meta.Cache.FindAll(e => e.SpspDesc == spspDesc);

            // return FindAll(_.SpspDesc == spspDesc);
        }



        public static TmpSpspSelect FindById(String id)
        {
            if (id.IsNullOrEmpty()) return null;
            return Meta.SingleCache[id];
        }
        #endregion

        #region 高级查询
        /// <summary>高级查询</summary>
        /// <param name="spspDesc"></param>
        /// <param name="key">关键字</param>
        /// <param name="page">分页参数信息。可携带统计和数据权限扩展查询等信息</param>
        /// <returns>实体列表</returns>
        public static IList<TmpSpspSelect> Search(String spspDesc, String key, PageParameter page)
        {
            var exp = new WhereExpression();

            if (!spspDesc.IsNullOrEmpty()) exp &= _.SpspDesc == spspDesc;
            if (!key.IsNullOrEmpty()) exp &= _.SpspID.Contains(key) | _.SpspDescEng.Contains(key) | _.SpspNameFst.Contains(key) | _.SpspNameFul.Contains(key);

            return FindAll(exp, page);
        }

        // Select Count(Id) as Id,SpspDesc From TmpSpspSelect Where CreateTime>'2020-01-24 00:00:00' Group By SpspDesc Order By Id Desc limit 20
        // static readonly FieldCache<TmpSpspSelect> _SpspDescCache = new FieldCache<TmpSpspSelect>(_.SpspDesc)
        // {
        //     //Where = _.CreateTime > DateTime.Today.AddDays(-30) & Expression.Empty
        // };

        /// <summary>获取SpspDesc列表，字段缓存10分钟，分组统计数据最多的前20种，用于魔方前台下拉选择</summary>
        /// <returns></returns>
        //public static IDictionary<String, String> GetSpspDescList() => _SpspDescCache.FindAllName();
        #endregion

        #region 业务操作
        #endregion
    }
}