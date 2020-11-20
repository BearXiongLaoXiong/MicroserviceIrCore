using System;
using System.Collections.Generic;
using System.ComponentModel;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace MicroserviceCodeTable.Model
{
    /// <summary></summary>
    [Serializable]
    [DataObject]
    [BindIndex("PK_TBEH_SYSV_VARIABLE_INFO", true, "SYSV_KY")]
    [BindTable("TBEH_SYSV_VARIABLE_INFO", Description = "", ConnName = "MSSQLTPAUSER", DbType = DatabaseType.SqlServer)]
    public partial class TbehSysvVariableInfo : ITbehSysvVariableInfo
    {
        #region 属性
        private Int32 _SysvKy;
        /// <summary></summary>
        [DisplayName("SysvKy")]
        [DataObjectField(true, false, false, 10)]
        [BindColumn("SYSV_KY", "", "int")]
        public Int32 SysvKy { get => _SysvKy; set { if (OnPropertyChanging(__.SysvKy, value)) { _SysvKy = value; OnPropertyChanged(__.SysvKy); } } }

        private String _EnttCompID;
        /// <summary></summary>
        [DisplayName("EnttCompID")]
        [DataObjectField(false, false, false, 12)]
        [BindColumn("ENTT_COMP_ID", "", "varchar(12)")]
        public String EnttCompID { get => _EnttCompID; set { if (OnPropertyChanging(__.EnttCompID, value)) { _EnttCompID = value; OnPropertyChanged(__.EnttCompID); } } }

        private String _SysvEntity;
        /// <summary></summary>
        [DisplayName("SysvEntity")]
        [DataObjectField(false, false, false, 20)]
        [BindColumn("SYSV_ENTITY", "", "varchar(20)")]
        public String SysvEntity { get => _SysvEntity; set { if (OnPropertyChanging(__.SysvEntity, value)) { _SysvEntity = value; OnPropertyChanged(__.SysvEntity); } } }

        private String _SysvType;
        /// <summary></summary>
        [DisplayName("SysvType")]
        [DataObjectField(false, false, false, 25)]
        [BindColumn("SYSV_TYPE", "", "varchar(25)")]
        public String SysvType { get => _SysvType; set { if (OnPropertyChanging(__.SysvType, value)) { _SysvType = value; OnPropertyChanged(__.SysvType); } } }

        private String _SysvValue;
        /// <summary></summary>
        [DisplayName("SysvValue")]
        [DataObjectField(false, false, false, 25)]
        [BindColumn("SYSV_VALUE", "", "varchar(25)")]
        public String SysvValue { get => _SysvValue; set { if (OnPropertyChanging(__.SysvValue, value)) { _SysvValue = value; OnPropertyChanged(__.SysvValue); } } }

        private String _SysvDesc;
        /// <summary></summary>
        [DisplayName("SysvDesc")]
        [DataObjectField(false, false, false, 255)]
        [BindColumn("SYSV_DESC", "", "varchar(255)")]
        public String SysvDesc { get => _SysvDesc; set { if (OnPropertyChanging(__.SysvDesc, value)) { _SysvDesc = value; OnPropertyChanged(__.SysvDesc); } } }

        private String _SysvDescEng;
        /// <summary></summary>
        [DisplayName("SysvDescEng")]
        [DataObjectField(false, false, false, 255)]
        [BindColumn("SYSV_DESC_ENG", "", "varchar(255)")]
        public String SysvDescEng { get => _SysvDescEng; set { if (OnPropertyChanging(__.SysvDescEng, value)) { _SysvDescEng = value; OnPropertyChanged(__.SysvDescEng); } } }

        private String _SysvFilter;
        /// <summary></summary>
        [DisplayName("SysvFilter")]
        [DataObjectField(false, false, false, 4)]
        [BindColumn("SYSV_FILTER", "", "varchar(4)")]
        public String SysvFilter { get => _SysvFilter; set { if (OnPropertyChanging(__.SysvFilter, value)) { _SysvFilter = value; OnPropertyChanged(__.SysvFilter); } } }

        private String _SysvCat;
        /// <summary></summary>
        [DisplayName("SysvCat")]
        [DataObjectField(false, false, false, 4)]
        [BindColumn("SYSV_CAT", "", "varchar(4)")]
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
        /// <summary></summary>
        [DisplayName("SysvNameFst")]
        [DataObjectField(false, false, false, 35)]
        [BindColumn("SYSV_NAME_FST", "", "varchar(35)")]
        public String SysvNameFst { get => _SysvNameFst; set { if (OnPropertyChanging(__.SysvNameFst, value)) { _SysvNameFst = value; OnPropertyChanged(__.SysvNameFst); } } }

        private String _SysvNameFul;
        /// <summary></summary>
        [DisplayName("SysvNameFul")]
        [DataObjectField(false, false, false, 255)]
        [BindColumn("SYSV_NAME_FUL", "", "varchar(255)")]
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
        /// <summary>取得TbehSysvVariableInfo字段信息的快捷方式</summary>
        public partial class _
        {
            /// <summary></summary>
            public static readonly Field SysvKy = FindByName(__.SysvKy);

            /// <summary></summary>
            public static readonly Field EnttCompID = FindByName(__.EnttCompID);

            /// <summary></summary>
            public static readonly Field SysvEntity = FindByName(__.SysvEntity);

            /// <summary></summary>
            public static readonly Field SysvType = FindByName(__.SysvType);

            /// <summary></summary>
            public static readonly Field SysvValue = FindByName(__.SysvValue);

            /// <summary></summary>
            public static readonly Field SysvDesc = FindByName(__.SysvDesc);

            /// <summary></summary>
            public static readonly Field SysvDescEng = FindByName(__.SysvDescEng);

            /// <summary></summary>
            public static readonly Field SysvFilter = FindByName(__.SysvFilter);

            /// <summary></summary>
            public static readonly Field SysvCat = FindByName(__.SysvCat);

            /// <summary></summary>
            public static readonly Field SysvClientValue = FindByName(__.SysvClientValue);

            /// <summary></summary>
            public static readonly Field SysvClientDesc = FindByName(__.SysvClientDesc);

            /// <summary></summary>
            public static readonly Field SysvNameFst = FindByName(__.SysvNameFst);

            /// <summary></summary>
            public static readonly Field SysvNameFul = FindByName(__.SysvNameFul);

            static Field FindByName(String name) => Meta.Table.FindByName(name);
        }

        /// <summary>取得TbehSysvVariableInfo字段名称的快捷方式</summary>
        public partial class __
        {
            /// <summary></summary>
            public const String SysvKy = "SysvKy";

            /// <summary></summary>
            public const String EnttCompID = "EnttCompID";

            /// <summary></summary>
            public const String SysvEntity = "SysvEntity";

            /// <summary></summary>
            public const String SysvType = "SysvType";

            /// <summary></summary>
            public const String SysvValue = "SysvValue";

            /// <summary></summary>
            public const String SysvDesc = "SysvDesc";

            /// <summary></summary>
            public const String SysvDescEng = "SysvDescEng";

            /// <summary></summary>
            public const String SysvFilter = "SysvFilter";

            /// <summary></summary>
            public const String SysvCat = "SysvCat";

            /// <summary></summary>
            public const String SysvClientValue = "SysvClientValue";

            /// <summary></summary>
            public const String SysvClientDesc = "SysvClientDesc";

            /// <summary></summary>
            public const String SysvNameFst = "SysvNameFst";

            /// <summary></summary>
            public const String SysvNameFul = "SysvNameFul";
        }
        #endregion
    }

    /// <summary>接口</summary>
    public partial interface ITbehSysvVariableInfo
    {
        #region 属性
        /// <summary></summary>
        Int32 SysvKy { get; set; }

        /// <summary></summary>
        String EnttCompID { get; set; }

        /// <summary></summary>
        String SysvEntity { get; set; }

        /// <summary></summary>
        String SysvType { get; set; }

        /// <summary></summary>
        String SysvValue { get; set; }

        /// <summary></summary>
        String SysvDesc { get; set; }

        /// <summary></summary>
        String SysvDescEng { get; set; }

        /// <summary></summary>
        String SysvFilter { get; set; }

        /// <summary></summary>
        String SysvCat { get; set; }

        /// <summary></summary>
        String SysvClientValue { get; set; }

        /// <summary></summary>
        String SysvClientDesc { get; set; }

        /// <summary></summary>
        String SysvNameFst { get; set; }

        /// <summary></summary>
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