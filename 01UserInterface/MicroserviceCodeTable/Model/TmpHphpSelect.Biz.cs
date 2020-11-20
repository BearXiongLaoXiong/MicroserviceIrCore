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
    public partial class TmpHphpSelect : Entity<TmpHphpSelect>
    {
        #region 对象操作
        static TmpHphpSelect()
        {
            Meta.Cache.Expire = 3600;

            Meta.Cache.FillListMethod = () => FindAll().OrderBy(x => (x.HphpName ?? "").Length).ToList();
            // 过滤器 UserModule、TimeModule、IPModule
        }

        /// <summary>验证数据，通过抛出异常的方式提示验证失败。</summary>
        /// <param name="isNew">是否插入</param>
        public override void Valid(Boolean isNew)
        {
            // 如果没有脏数据，则不需要进行任何处理
            if (!HasDirty) return;

            // 这里验证参数范围，建议抛出参数异常，指定参数名，前端用户界面可以捕获参数异常并聚焦到对应的参数输入框
            if (HphpID.IsNullOrEmpty()) throw new ArgumentNullException(nameof(HphpID), "HphpID不能为空！");
            if (HphpName.IsNullOrEmpty()) throw new ArgumentNullException(nameof(HphpName), "HphpName不能为空！");
            if (ScctName.IsNullOrEmpty()) throw new ArgumentNullException(nameof(ScctName), "ScctName不能为空！");
            if (HphpNameFst.IsNullOrEmpty()) throw new ArgumentNullException(nameof(HphpNameFst), "HphpNameFst不能为空！");
            if (HphpNameFul.IsNullOrEmpty()) throw new ArgumentNullException(nameof(HphpNameFul), "HphpNameFul不能为空！");

            // 在新插入数据或者修改了指定字段时进行修正
        }

        ///// <summary>首次连接数据库时初始化数据，仅用于实体类重载，用户不应该调用该方法</summary>
        //[EditorBrowsable(EditorBrowsableState.Never)]
        //protected internal override void InitData()
        //{
        //    // InitData一般用于当数据表没有数据时添加一些默认数据，该实体类的任何第一次数据库操作都会触发该方法，默认异步调用
        //    if (Meta.Session.Count > 0) return;

        //    if (XTrace.Debug) XTrace.WriteLine("开始初始化TmpHphpSelect[TmpHphpSelect]数据……");

        //    var entity = new TmpHphpSelect();
        //    entity.HphpID = "abc";
        //    entity.HphpName = "abc";
        //    entity.ScctName = "abc";
        //    entity.HphpNameFst = "abc";
        //    entity.HphpNameFul = "abc";
        //    entity.Insert();

        //    if (XTrace.Debug) XTrace.WriteLine("完成初始化TmpHphpSelect[TmpHphpSelect]数据！");
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

        private static IEnumerable<TmpHphpSelect> SearchKey(IEnumerable<TmpHphpSelect> iEnumerable, string key)
        => iEnumerable == null || string.IsNullOrWhiteSpace(key) ? iEnumerable : iEnumerable.Where(x => (x.HphpName ?? "").Contains(key) || (x.HphpID ?? "").Contains(key) || (x.ScctName ?? "").Contains(key) || (x.HphpNameFst ?? "").Contains(key) || (x.HphpNameFul ?? "").Contains(key));

        public static IEnumerable<TmpHphpSelect> FindAllByHphpDesc(String desc)
        {
            if (desc.IsNullOrEmpty()) return null;

            IEnumerable<TmpHphpSelect> iEnumerable = Meta.Cache.Entities;

            var stringArray = desc.Split(' ');
            foreach (var s in stringArray.Take(3)) iEnumerable = SearchKey(iEnumerable, s.ToUpper());
            return iEnumerable.Take(30);

            //return Meta.Cache.Entities.Where(e => (e.HphpName ?? "").Contains(desc) || (e.HphpID ?? "").Contains(desc) || (e.HphpNameFst ?? "").Contains(desc) || (e.ScctName ?? "").Contains(desc)).Take(50);
            //return Find(_.Name == name);
        }
        #endregion

        #region 高级查询

        // Select Count(Id) as Id,Category From TmpHphpSelect Where CreateTime>'2020-01-24 00:00:00' Group By Category Order By Id Desc limit 20
        //static readonly FieldCache<TmpHphpSelect> _CategoryCache = new FieldCache<TmpHphpSelect>(_.Category)
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