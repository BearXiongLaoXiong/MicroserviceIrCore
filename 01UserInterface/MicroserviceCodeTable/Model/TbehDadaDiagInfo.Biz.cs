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
    public partial class TbehDadaDiagInfo : Entity<TbehDadaDiagInfo>
    {
        #region 对象操作
        static TbehDadaDiagInfo()
        {
            Meta.Cache.Expire = 3600;

            Meta.Cache.FillListMethod = () => FindAll().OrderBy(x=>x.DadaID).ThenBy(x => x.DadaDesc.Length).ToList();
            // 过滤器 UserModule、TimeModule、IPModule
        }

        /// <summary>验证数据，通过抛出异常的方式提示验证失败。</summary>
        /// <param name="isNew">是否插入</param>
        public override void Valid(Boolean isNew)
        {
            // 如果没有脏数据，则不需要进行任何处理
            if (!HasDirty) return;

            // 这里验证参数范围，建议抛出参数异常，指定参数名，前端用户界面可以捕获参数异常并聚焦到对应的参数输入框
            if (DadaID.IsNullOrEmpty()) throw new ArgumentNullException(nameof(DadaID), "DadaID不能为空！");

            // 在新插入数据或者修改了指定字段时进行修正

            // 检查唯一索引
            // CheckExist(isNew, __.DadaID);
        }

        ///// <summary>首次连接数据库时初始化数据，仅用于实体类重载，用户不应该调用该方法</summary>
        //[EditorBrowsable(EditorBrowsableState.Never)]
        //protected internal override void InitData()
        //{
        //    // InitData一般用于当数据表没有数据时添加一些默认数据，该实体类的任何第一次数据库操作都会触发该方法，默认异步调用
        //    if (Meta.Session.Count > 0) return;

        //    if (XTrace.Debug) XTrace.WriteLine("开始初始化TbehDadaDiagInfo[TbehDadaDiagInfo]数据……");

        //    var entity = new TbehDadaDiagInfo();
        //    entity.DadaID = "abc";
        //    entity.DadaDesc = "abc";
        //    entity.DadaDescEng = "abc";
        //    entity.DadaIDRel = "abc";
        //    entity.SysvDadaType = "abc";
        //    entity.DadaSexInd = "abc";
        //    entity.DadaAgeFrom = "abc";
        //    entity.DadaAgeTo = "abc";
        //    entity.DadaCvtLevel = "abc";
        //    entity.DadaMorbRate = "abc";
        //    entity.DadaIpCost = "abc";
        //    entity.DadaOpCost = "abc";
        //    entity.DadaAnnualVisit = "abc";
        //    entity.DadaExexID = "abc";
        //    entity.DadaAction = "abc";
        //    entity.DadaNameFst = "abc";
        //    entity.DadaNameFul = "abc";
        //    entity.Insert();

        //    if (XTrace.Debug) XTrace.WriteLine("完成初始化TbehDadaDiagInfo[TbehDadaDiagInfo]数据！");
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
        /// <summary>根据DadaID查找</summary>
        /// <param name="dadaId">DadaID</param>
        /// <returns>实体对象</returns>
        public static TbehDadaDiagInfo FindByDadaID(String dadaId)
        {
            if (dadaId.IsNullOrEmpty()) return null;

            // 实体缓存
            if (Meta.Session.Count < 1000) return Meta.Cache.Find(e => e.DadaID == dadaId);

            // 单对象缓存
            return Meta.SingleCache[dadaId];

            //return Find(_.DadaID == dadaId);
        }

        private static IEnumerable<TbehDadaDiagInfo> SearchKey(IEnumerable<TbehDadaDiagInfo> iEnumerable, string key)
        => iEnumerable == null || string.IsNullOrWhiteSpace(key) ? iEnumerable : iEnumerable.Where(x => (x.DadaDesc??"").Contains(key) || (x.DadaID??"").Contains(key) || (x.DadaNameFst ?? "").Contains(key) || (x.DadaNameFul??"").Contains(key));


        public static IEnumerable<TbehDadaDiagInfo> FindAllByDadaDesc(String desc)
        {
            if (desc.IsNullOrEmpty()) return null;
            IEnumerable<TbehDadaDiagInfo> iEnumerable = Meta.Cache.Entities;

            var stringArray = desc.Split(' ');
            foreach (var s in stringArray.Take(3)) iEnumerable = SearchKey(iEnumerable, s.ToUpper());
            return iEnumerable.Take(100);
            //return Meta.Cache.Entities.Where(e => e.DadaDesc.Contains(desc) || e.DadaID.Contains(desc) || (e.DadaNameFst??"").Contains(desc)).Take(100);
            //return Find(_.Name == name);
        }
        #endregion

        #region 高级查询

        // Select Count(Id) as Id,Category From TbehDadaDiagInfo Where CreateTime>'2020-01-24 00:00:00' Group By Category Order By Id Desc limit 20
        //static readonly FieldCache<TbehDadaDiagInfo> _CategoryCache = new FieldCache<TbehDadaDiagInfo>(_.Category)
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