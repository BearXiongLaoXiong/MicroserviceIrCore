using NewLife;
using NewLife.Caching;
using NewLife.Data;
using NewLife.Log;
using NewLife.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using XCode;
using XCode.DataAccessLayer;

namespace MicroserviceCodeTable.Model
{
    /// <summary>系统参数</summary>
    public partial class TxehSysvVariableInfo : Entity<TxehSysvVariableInfo>
    {
        #region 对象操作
        static TxehSysvVariableInfo()
        {
#if DEBUG
            _redis.Log = XTrace.Log;
#endif
            _redis.Init("Server=10.127.2.16:7001;Password=123456;Db=0");
            // 过滤器 UserModule、TimeModule、IPModule
        }

        /// <summary>验证数据，通过抛出异常的方式提示验证失败。</summary>
        /// <param name="isNew">是否插入</param>
        public override void Valid(Boolean isNew)
        {
            // 如果没有脏数据，则不需要进行任何处理
            if (!HasDirty) return;

            // 这里验证参数范围，建议抛出参数异常，指定参数名，前端用户界面可以捕获参数异常并聚焦到对应的参数输入框
            if (EnttCompID.IsNullOrEmpty()) throw new ArgumentNullException(nameof(EnttCompID), "公司ID不能为空！");
            if (SysvEntity.IsNullOrEmpty()) throw new ArgumentNullException(nameof(SysvEntity), "实体类别不能为空！");
            if (SysvType.IsNullOrEmpty()) throw new ArgumentNullException(nameof(SysvType), "参数类别不能为空！");
            if (SysvValue.IsNullOrEmpty()) throw new ArgumentNullException(nameof(SysvValue), "参数值不能为空！");
            if (SysvDesc.IsNullOrEmpty()) throw new ArgumentNullException(nameof(SysvDesc), "参数描述不能为空！");
            if (SysvDescEng.IsNullOrEmpty()) throw new ArgumentNullException(nameof(SysvDescEng), "参数描述不能为空！");
            if (SysvClientValue.IsNullOrEmpty()) throw new ArgumentNullException(nameof(SysvClientValue), "SysvClientValue不能为空！");
            if (SysvClientDesc.IsNullOrEmpty()) throw new ArgumentNullException(nameof(SysvClientDesc), "SysvClientDesc不能为空！");

            // 在新插入数据或者修改了指定字段时进行修正

            // 检查唯一索引
            // CheckExist(isNew, __.SysvKy);
        }

        ///// <summary>首次连接数据库时初始化数据，仅用于实体类重载，用户不应该调用该方法</summary>
        //[EditorBrowsable(EditorBrowsableState.Never)]
        //protected internal override void InitData()
        //{
        //    // InitData一般用于当数据表没有数据时添加一些默认数据，该实体类的任何第一次数据库操作都会触发该方法，默认异步调用
        //    if (Meta.Session.Count > 0) return;

        //    if (XTrace.Debug) XTrace.WriteLine("开始初始化TxehSysvVariableInfo[系统参数]数据……");

        //    var entity = new TxehSysvVariableInfo();
        //    entity.SysvKy = 0;
        //    entity.EnttCompID = "abc";
        //    entity.SysvEntity = "abc";
        //    entity.SysvType = "abc";
        //    entity.SysvValue = "abc";
        //    entity.SysvDesc = "abc";
        //    entity.SysvDescEng = "abc";
        //    entity.SysvFilter = "abc";
        //    entity.SysvCat = "abc";
        //    entity.SysvClientValue = "abc";
        //    entity.SysvClientDesc = "abc";
        //    entity.SysvNameFst = "abc";
        //    entity.SysvNameFul = "abc";
        //    entity.Insert();

        //    if (XTrace.Debug) XTrace.WriteLine("完成初始化TxehSysvVariableInfo[系统参数]数据！");
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
        /// <summary>根据参数编号查找</summary>
        /// <param name="sysvKy">参数编号</param>
        /// <returns>实体对象</returns>
        public static TxehSysvVariableInfo FindBySysvKy(Int32 sysvKy)
        {
            if (sysvKy <= 0) return null;

            // 实体缓存
            if (Meta.Session.Count < 1000) return Meta.Cache.Find(e => e.SysvKy == sysvKy);

            // 单对象缓存
            return Meta.SingleCache[sysvKy];

            //return Find(_.SysvKy == sysvKy);
        }
        #endregion

        #region 高级查询

        // Select Count(Id) as Id,Category From TxehSysvVariableInfo Where CreateTime>'2020-01-24 00:00:00' Group By Category Order By Id Desc limit 20
        //static readonly FieldCache<TxehSysvVariableInfo> _CategoryCache = new FieldCache<TxehSysvVariableInfo>(_.Category)
        //{
        //Where = _.CreateTime > DateTime.Today.AddDays(-30) & Expression.Empty
        //};

        ///// <summary>获取类别列表，字段缓存10分钟，分组统计数据最多的前20种，用于魔方前台下拉选择</summary>
        ///// <returns></returns>
        //public static IDictionary<String, String> GetCategoryList() => _CategoryCache.FindAllName();
        #endregion

        #region 业务操作

        static FullRedis _redis = new FullRedis();

        public static string FindAllBySysvKy(string connectionString, string name, string key)
        {
            var cnev = TbehCnevClientEnvironmentInfoToRedisConf.FindDistinctAllFromCache().FirstOrDefault(x => x.CnevID == connectionString);
            if (cnev == null) return null;
            var redisKey = $"{cnev.CncnFlag}:{name}:{nameof(TxehSysvVariableInfo)}";

            var hash = _redis.GetDictionary<string>(redisKey) as RedisHash<String, string>;
            var result = hash.HMGet(new[] { key });

            if (result.Length > 0 && result[0] != null) return result[0];
            else if (!_redis.ContainsKey(redisKey))
            {
                Meta.ConnName = $"p{cnev.CnevIp}";
                //var aa = FindAll()?.OrderBy(x => x.EnttCompID).ThenBy(x => x.SysvEntity).ThenBy(x => x.SysvType).ThenBy(x => x.SysvValue);
                var list = FindAll()?.GroupBy(x => $"{x.EnttCompID?.Trim()}{x.SysvEntity?.Trim()}{x.SysvType?.Trim()}").ToDictionary(x => x.Key, y => y.Select(d => new SysvComboboxItems(d.SysvValue, d.SysvDesc)).ToJson());
                if (list == null || list.Count < 1) return null;
                var rs1 = hash.HMSet(list);
                _redis.SetExpire(redisKey, TimeSpan.FromHours(24));
                return hash.HMGet(new[] { key })[0];
            }
            return "";
        }

        /// <summary>
        /// 仅仅dev uat peixun demo专用 
        /// </summary>
        /// <param name="connectionString">字段只会匹配dev uat peixun demo</param>
        /// <param name="name"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string FindAllByDevSysvKy(string connectionString, string name, string key)
        {
            var sss = TbehCnevClientEnvironmentInfoToRedisConf.FindDistinctAllFromCache();
            //因为dev uat 环境 所以特改为匹配 cncnFlag
            var cnev = TbehCnevClientEnvironmentInfoToRedisConf.FindDistinctAllFromCache().FirstOrDefault(x => x.CncnFlag == connectionString);
            if (cnev == null) return null;
            var redisKey = $"{cnev.CncnFlag}:{name}:{nameof(TxehSysvVariableInfo)}";

            var hash = _redis.GetDictionary<string>(redisKey) as RedisHash<String, string>;
            var result = hash.HMGet(new[] { key });

            if (result.Length > 0 && result[0] != null) return result[0];
            else if (!_redis.ContainsKey(redisKey))
            {
                Meta.ConnName = $"p{cnev.CnevIp}";
                //var aa = FindAll()?.OrderBy(x => x.EnttCompID).ThenBy(x => x.SysvEntity).ThenBy(x => x.SysvType).ThenBy(x => x.SysvValue);
                var list = FindAll()?.GroupBy(x => $"{x.EnttCompID?.Trim()}{x.SysvEntity?.Trim()}{x.SysvType?.Trim()}")
                    .ToDictionary(x => x.Key, y => y.Select(d => new SysvComboboxItems(d.SysvValue, d.SysvDesc)).ToJson());
                if (list == null || list.Count < 1) return null;
                var rs1 = hash.HMSet(list);
                _redis.SetExpire(redisKey, TimeSpan.FromHours(24));
                return hash.HMGet(new[] { key })[0];
            }
            return "";
        }

        #endregion
    }

}