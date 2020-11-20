using System;
using System.Collections.Generic;
using System.ComponentModel;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace MicroserviceCodeTable.Model
{
    /// <summary>系统参数</summary>
    [Serializable]
    [DataObject]
    [Description("系统参数")]
    [BindIndex("PK_TBEH_SYSV_VARIABLE_INFO", true, "SYSV_KY")]
    [BindTable("TXEH_SYSV_VARIABLE_INFO", Description = "系统参数", ConnName = "MSSQLTPAPROD", DbType = DatabaseType.SqlServer)]
    public partial class TxehSysvVariableInfo : ITxehSysvVariableInfo
    {
        #region 属性
        private Int32 _SysvKy;
        /// <summary>参数编号</summary>
        [DisplayName("参数编号")]
        [Description("参数编号")]
        [DataObjectField(true, false, false, 10)]
        [BindColumn("SYSV_KY", "参数编号", "int")]
        public Int32 SysvKy { get => _SysvKy; set { if (OnPropertyChanging(__.SysvKy, value)) { _SysvKy = value; OnPropertyChanged(__.SysvKy); } } }

        private String _EnttCompID;
        /// <summary>公司ID</summary>
        [DisplayName("公司ID")]
        [Description("公司ID")]
        [DataObjectField(false, false, false, 12)]
        [BindColumn("ENTT_COMP_ID", "公司ID", "varchar(12)")]
        public String EnttCompID { get => _EnttCompID; set { if (OnPropertyChanging(__.EnttCompID, value)) { _EnttCompID = value; OnPropertyChanged(__.EnttCompID); } } }

        private String _SysvEntity;
        /// <summary>实体类别</summary>
        [DisplayName("实体类别")]
        [Description("实体类别")]
        [DataObjectField(false, false, false, 20)]
        [BindColumn("SYSV_ENTITY", "实体类别", "varchar(20)")]
        public String SysvEntity { get => _SysvEntity; set { if (OnPropertyChanging(__.SysvEntity, value)) { _SysvEntity = value; OnPropertyChanged(__.SysvEntity); } } }

        private String _SysvType;
        /// <summary>参数类别</summary>
        [DisplayName("参数类别")]
        [Description("参数类别")]
        [DataObjectField(false, false, false, 25)]
        [BindColumn("SYSV_TYPE", "参数类别", "varchar(25)")]
        public String SysvType { get => _SysvType; set { if (OnPropertyChanging(__.SysvType, value)) { _SysvType = value; OnPropertyChanged(__.SysvType); } } }

        private String _SysvValue;
        /// <summary>参数值</summary>
        [DisplayName("参数值")]
        [Description("参数值")]
        [DataObjectField(false, false, false, 25)]
        [BindColumn("SYSV_VALUE", "参数值", "varchar(25)")]
        public String SysvValue { get => _SysvValue; set { if (OnPropertyChanging(__.SysvValue, value)) { _SysvValue = value; OnPropertyChanged(__.SysvValue); } } }

        private String _SysvDesc;
        /// <summary>参数描述</summary>
        [DisplayName("参数描述")]
        [Description("参数描述")]
        [DataObjectField(false, false, false, 255)]
        [BindColumn("SYSV_DESC", "参数描述", "varchar(255)")]
        public String SysvDesc { get => _SysvDesc; set { if (OnPropertyChanging(__.SysvDesc, value)) { _SysvDesc = value; OnPropertyChanged(__.SysvDesc); } } }

        private String _SysvDescEng;
        /// <summary>参数描述(英)</summary>
        [DisplayName("参数描述")]
        [Description("参数描述(英)")]
        [DataObjectField(false, false, false, 255)]
        [BindColumn("SYSV_DESC_ENG", "参数描述(英)", "varchar(255)")]
        public String SysvDescEng { get => _SysvDescEng; set { if (OnPropertyChanging(__.SysvDescEng, value)) { _SysvDescEng = value; OnPropertyChanged(__.SysvDescEng); } } }

        private String _SysvFilter;
        /// <summary>参数过滤</summary>
        [DisplayName("参数过滤")]
        [Description("参数过滤")]
        [DataObjectField(false, false, true, 4)]
        [BindColumn("SYSV_FILTER", "参数过滤", "varchar(4)")]
        public String SysvFilter { get => _SysvFilter; set { if (OnPropertyChanging(__.SysvFilter, value)) { _SysvFilter = value; OnPropertyChanged(__.SysvFilter); } } }

        private String _SysvCat;
        /// <summary>参数大类</summary>
        [DisplayName("参数大类")]
        [Description("参数大类")]
        [DataObjectField(false, false, true, 4)]
        [BindColumn("SYSV_CAT", "参数大类", "varchar(4)")]
        public String SysvCat { get => _SysvCat; set { if (OnPropertyChanging(__.SysvCat, value)) { _SysvCat = value; OnPropertyChanged(__.SysvCat); } } }

        private String _SysvClientValue;
        /// <summary></summary>
        [DisplayName("SysvClientValue")]
        [DataObjectField(false, false, false, 25)]
        [BindColumn("SYSV_CLIENT_VALUE", "", "varchar(25)")]
        public String SysvClientValue { get => _SysvClientValue; set { if (OnPropertyChanging(__.SysvClientValue, value)) { _SysvClientValue = value; OnPropertyChanged(__.SysvClientValue); } } }

        private String _SysvClientDesc;
        /// <summary></summary>
        [DisplayName("SysvClientDesc")]
        [DataObjectField(false, false, false, 255)]
        [BindColumn("SYSV_CLIENT_DESC", "", "varchar(255)")]
        public String SysvClientDesc { get => _SysvClientDesc; set { if (OnPropertyChanging(__.SysvClientDesc, value)) { _SysvClientDesc = value; OnPropertyChanged(__.SysvClientDesc); } } }

        private String _SysvNameFst;
        /// <summary>描述首字母</summary>
        [DisplayName("描述首字母")]
        [Description("描述首字母")]
        [DataObjectField(false, false, true, 35)]
        [BindColumn("SYSV_NAME_FST", "描述首字母", "varchar(35)")]
        public String SysvNameFst { get => _SysvNameFst; set { if (OnPropertyChanging(__.SysvNameFst, value)) { _SysvNameFst = value; OnPropertyChanged(__.SysvNameFst); } } }

        private String _SysvNameFul;
        /// <summary>描述全拼</summary>
        [DisplayName("描述全拼")]
        [Description("描述全拼")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("SYSV_NAME_FUL", "描述全拼", "varchar(255)")]
        public String SysvNameFul { get => _SysvNameFul; set { if (OnPropertyChanging(__.SysvNameFul, value)) { _SysvNameFul = value; OnPropertyChanged(__.SysvNameFul); } } }
        #endregion

        #region 获取/设置 字段值
        /// <summary>获取/设置 字段值</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        public override Object this[String name]
        {
            get
            {
                switch (name)
                {
                    case __.SysvKy: return _SysvKy;
                    case __.EnttCompID: return _EnttCompID;
                    case __.SysvEntity: return _SysvEntity;
                    case __.SysvType: return _SysvType;
                    case __.SysvValue: return _SysvValue;
                    case __.SysvDesc: return _SysvDesc;
                    case __.SysvDescEng: return _SysvDescEng;
                    case __.SysvFilter: return _SysvFilter;
                    case __.SysvCat: return _SysvCat;
                    case __.SysvClientValue: return _SysvClientValue;
                    case __.SysvClientDesc: return _SysvClientDesc;
                    case __.SysvNameFst: return _SysvNameFst;
                    case __.SysvNameFul: return _SysvNameFul;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case __.SysvKy: _SysvKy = value.ToInt(); break;
                    case __.EnttCompID: _EnttCompID = Convert.ToString(value); break;
                    case __.SysvEntity: _SysvEntity = Convert.ToString(value); break;
                    case __.SysvType: _SysvType = Convert.ToString(value); break;
                    case __.SysvValue: _SysvValue = Convert.ToString(value); break;
                    case __.SysvDesc: _SysvDesc = Convert.ToString(value); break;
                    case __.SysvDescEng: _SysvDescEng = Convert.ToString(value); break;
                    case __.SysvFilter: _SysvFilter = Convert.ToString(value); break;
                    case __.SysvCat: _SysvCat = Convert.ToString(value); break;
                    case __.SysvClientValue: _SysvClientValue = Convert.ToString(value); break;
                    case __.SysvClientDesc: _SysvClientDesc = Convert.ToString(value); break;
                    case __.SysvNameFst: _SysvNameFst = Convert.ToString(value); break;
                    case __.SysvNameFul: _SysvNameFul = Convert.ToString(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得系统参数字段信息的快捷方式</summary>
        public partial class _
        {
            /// <summary>参数编号</summary>
            public static readonly Field SysvKy = FindByName(__.SysvKy);

            /// <summary>公司ID</summary>
            public static readonly Field EnttCompID = FindByName(__.EnttCompID);

            /// <summary>实体类别</summary>
            public static readonly Field SysvEntity = FindByName(__.SysvEntity);

            /// <summary>参数类别</summary>
            public static readonly Field SysvType = FindByName(__.SysvType);

            /// <summary>参数值</summary>
            public static readonly Field SysvValue = FindByName(__.SysvValue);

            /// <summary>参数描述</summary>
            public static readonly Field SysvDesc = FindByName(__.SysvDesc);

            /// <summary>参数描述(英)</summary>
            public static readonly Field SysvDescEng = FindByName(__.SysvDescEng);

            /// <summary>参数过滤</summary>
            public static readonly Field SysvFilter = FindByName(__.SysvFilter);

            /// <summary>参数大类</summary>
            public static readonly Field SysvCat = FindByName(__.SysvCat);

            /// <summary></summary>
            public static readonly Field SysvClientValue = FindByName(__.SysvClientValue);

            /// <summary></summary>
            public static readonly Field SysvClientDesc = FindByName(__.SysvClientDesc);

            /// <summary>描述首字母</summary>
            public static readonly Field SysvNameFst = FindByName(__.SysvNameFst);

            /// <summary>描述全拼</summary>
            public static readonly Field SysvNameFul = FindByName(__.SysvNameFul);

            static Field FindByName(String name) => Meta.Table.FindByName(name);
        }

        /// <summary>取得系统参数字段名称的快捷方式</summary>
        public partial class __
        {
            /// <summary>参数编号</summary>
            public const String SysvKy = "SysvKy";

            /// <summary>公司ID</summary>
            public const String EnttCompID = "EnttCompID";

            /// <summary>实体类别</summary>
            public const String SysvEntity = "SysvEntity";

            /// <summary>参数类别</summary>
            public const String SysvType = "SysvType";

            /// <summary>参数值</summary>
            public const String SysvValue = "SysvValue";

            /// <summary>参数描述</summary>
            public const String SysvDesc = "SysvDesc";

            /// <summary>参数描述(英)</summary>
            public const String SysvDescEng = "SysvDescEng";

            /// <summary>参数过滤</summary>
            public const String SysvFilter = "SysvFilter";

            /// <summary>参数大类</summary>
            public const String SysvCat = "SysvCat";

            /// <summary></summary>
            public const String SysvClientValue = "SysvClientValue";

            /// <summary></summary>
            public const String SysvClientDesc = "SysvClientDesc";

            /// <summary>描述首字母</summary>
            public const String SysvNameFst = "SysvNameFst";

            /// <summary>描述全拼</summary>
            public const String SysvNameFul = "SysvNameFul";
        }
        #endregion
    }

    /// <summary>系统参数接口</summary>
    public partial interface ITxehSysvVariableInfo
    {
        #region 属性
        /// <summary>参数编号</summary>
        Int32 SysvKy { get; set; }

        /// <summary>公司ID</summary>
        String EnttCompID { get; set; }

        /// <summary>实体类别</summary>
        String SysvEntity { get; set; }

        /// <summary>参数类别</summary>
        String SysvType { get; set; }

        /// <summary>参数值</summary>
        String SysvValue { get; set; }

        /// <summary>参数描述</summary>
        String SysvDesc { get; set; }

        /// <summary>参数描述(英)</summary>
        String SysvDescEng { get; set; }

        /// <summary>参数过滤</summary>
        String SysvFilter { get; set; }

        /// <summary>参数大类</summary>
        String SysvCat { get; set; }

        /// <summary></summary>
        String SysvClientValue { get; set; }

        /// <summary></summary>
        String SysvClientDesc { get; set; }

        /// <summary>描述首字母</summary>
        String SysvNameFst { get; set; }

        /// <summary>描述全拼</summary>
        String SysvNameFul { get; set; }
        #endregion

        #region 获取/设置 字段值
        /// <summary>获取/设置 字段值</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        Object this[String name] { get; set; }
        #endregion
    }
}