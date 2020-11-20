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
    public partial class TbehCnevClientEnvironmentInfoToRedisConf : Entity<TbehCnevClientEnvironmentInfoToRedisConf>
    {
        #region 对象操作
        static TbehCnevClientEnvironmentInfoToRedisConf()
        {
            // 累加字段，生成 Update xx Set Count=Count+1234 Where xxx
            //var df = Meta.Factory.AdditionalFields;
            //df.Add(__.CnevStartNum);

            // 过滤器 UserModule、TimeModule、IPModule
        }

        /// <summary>验证数据，通过抛出异常的方式提示验证失败。</summary>
        /// <param name="isNew">是否插入</param>
        public override void Valid(Boolean isNew)
        {
            // 如果没有脏数据，则不需要进行任何处理
            if (!HasDirty) return;

            // 这里验证参数范围，建议抛出参数异常，指定参数名，前端用户界面可以捕获参数异常并聚焦到对应的参数输入框
            if (CncnFlag.IsNullOrEmpty()) throw new ArgumentNullException(nameof(CncnFlag), "CncnFlage不能为空！");
            if (CncnID.IsNullOrEmpty()) throw new ArgumentNullException(nameof(CncnID), "CncnID不能为空！");
            if (CnevID.IsNullOrEmpty()) throw new ArgumentNullException(nameof(CnevID), "CnevID不能为空！");
            if (CnevIlinkDatabaseName.IsNullOrEmpty()) throw new ArgumentNullException(nameof(CnevIlinkDatabaseName), "CnevIlinkDatabaseName不能为空！");
            if (CnevType.IsNullOrEmpty()) throw new ArgumentNullException(nameof(CnevType), "CnevType不能为空！");
            if (CnevIp.IsNullOrEmpty()) throw new ArgumentNullException(nameof(CnevIp), "CnevIp不能为空！");
            if (CnevUser.IsNullOrEmpty()) throw new ArgumentNullException(nameof(CnevUser), "CnevUser不能为空！");
            if (CnevPassword.IsNullOrEmpty()) throw new ArgumentNullException(nameof(CnevPassword), "CnevPassword不能为空！");
            if (CnevSts.IsNullOrEmpty()) throw new ArgumentNullException(nameof(CnevSts), "CnevSts不能为空！");
            if (CnevGetBatchInd.IsNullOrEmpty()) throw new ArgumentNullException(nameof(CnevGetBatchInd), "CnevGetBatchInd不能为空！");
            if (CnevNextBatchInd.IsNullOrEmpty()) throw new ArgumentNullException(nameof(CnevNextBatchInd), "CnevNextBatchInd不能为空！");
            if (CnevComment.IsNullOrEmpty()) throw new ArgumentNullException(nameof(CnevComment), "CnevComment不能为空！");

            // 在新插入数据或者修改了指定字段时进行修正
        }

        ///// <summary>首次连接数据库时初始化数据，仅用于实体类重载，用户不应该调用该方法</summary>
        //[EditorBrowsable(EditorBrowsableState.Never)]
        //protected internal override void InitData()
        //{
        //    // InitData一般用于当数据表没有数据时添加一些默认数据，该实体类的任何第一次数据库操作都会触发该方法，默认异步调用
        //    if (Meta.Session.Count > 0) return;

        //    if (XTrace.Debug) XTrace.WriteLine("开始初始化TbehCnevClientEnvironmentInfoToRedisConf[TbehCnevClientEnvironmentInfoToRedisConf]数据……");

        //    var entity = new TbehCnevClientEnvironmentInfoToRedisConf();
        //    entity.CnevKy = 0;
        //    entity.CncnFlage = "abc";
        //    entity.CncnID = "abc";
        //    entity.CnevID = "abc";
        //    entity.CnevIlinkDatabaseName = "abc";
        //    entity.CnevType = "abc";
        //    entity.CnevIp = "abc";
        //    entity.CnevUser = "abc";
        //    entity.CnevPassword = "abc";
        //    entity.CnevSts = "abc";
        //    entity.CnevGetBatchInd = "abc";
        //    entity.CnevNextBatchInd = "abc";
        //    entity.CnevStartNum = 0;
        //    entity.CnevEndNum = 0;
        //    entity.CnevBatchDtm = DateTime.Now;
        //    entity.CnevComment = "abc";
        //    entity.CncnFlag = "abc";
        //    entity.Insert();

        //    if (XTrace.Debug) XTrace.WriteLine("完成初始化TbehCnevClientEnvironmentInfoToRedisConf[TbehCnevClientEnvironmentInfoToRedisConf]数据！");
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
        /// <summary>根据CnevKy查找</summary>
        /// <param name="cnevKy">CnevKy</param>
        /// <returns>实体对象</returns>
        public static TbehCnevClientEnvironmentInfoToRedisConf FindByCnevKy(Int32 cnevKy)
        {
            if (cnevKy <= 0) return null;

            // 实体缓存
            if (Meta.Session.Count < 1000) return Meta.Cache.Find(e => e.CnevKy == cnevKy);

            // 单对象缓存
            return Meta.SingleCache[cnevKy];

            //return Find(_.CnevKy == cnevKy);
        }

        public static IEnumerable<TbehCnevClientEnvironmentInfoToRedisConf> FindDistinctAllFromCache()
        {
            return Meta.Cache.Entities;
        }
        #endregion

        #region 高级查询

        // Select Count(CnevKy) as CnevKy,Category From TbehCnevClientEnvironmentInfoToRedisConf Where CreateTime>'2020-01-24 00:00:00' Group By Category Order By CnevKy Desc limit 20
        //static readonly FieldCache<TbehCnevClientEnvironmentInfoToRedisConf> _CategoryCache = new FieldCache<TbehCnevClientEnvironmentInfoToRedisConf>(_.Category)
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