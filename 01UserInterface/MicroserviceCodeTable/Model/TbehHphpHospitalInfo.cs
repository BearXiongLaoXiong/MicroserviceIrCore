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
    [BindIndex("PK_TBEH_HPHP_HOSPITAL_INFO", true, "HPHP_ID")]
    [BindTable("TBEH_HPHP_HOSPITAL_INFO", Description = "", ConnName = "MSSQLTPAPROD", DbType = DatabaseType.SqlServer)]
    public partial class TbehHphpHospitalInfo : ITbehHphpHospitalInfo
    {
        #region 属性
        private String _HphpID;
        /// <summary></summary>
        [DisplayName("HphpID")]
        [DataObjectField(true, false, false, 16)]
        [BindColumn("HPHP_ID", "", "varchar(16)")]
        public String HphpID { get => _HphpID; set { if (OnPropertyChanging(__.HphpID, value)) { _HphpID = value; OnPropertyChanged(__.HphpID); } } }

        private String _HphpName;
        /// <summary></summary>
        [DisplayName("HphpName")]
        [DataObjectField(false, false, false, 255)]
        [BindColumn("HPHP_NAME", "", "varchar(255)")]
        public String HphpName { get => _HphpName; set { if (OnPropertyChanging(__.HphpName, value)) { _HphpName = value; OnPropertyChanged(__.HphpName); } } }

        private String _HphpAddr;
        /// <summary></summary>
        [DisplayName("HphpAddr")]
        [DataObjectField(false, false, false, 155)]
        [BindColumn("HPHP_ADDR", "", "varchar(155)")]
        public String HphpAddr { get => _HphpAddr; set { if (OnPropertyChanging(__.HphpAddr, value)) { _HphpAddr = value; OnPropertyChanged(__.HphpAddr); } } }

        private String _HphpNameFst;
        /// <summary></summary>
        [DisplayName("HphpNameFst")]
        [DataObjectField(false, false, false, 125)]
        [BindColumn("HPHP_NAME_FST", "", "varchar(125)")]
        public String HphpNameFst { get => _HphpNameFst; set { if (OnPropertyChanging(__.HphpNameFst, value)) { _HphpNameFst = value; OnPropertyChanged(__.HphpNameFst); } } }

        private String _HphpNameFul;
        /// <summary></summary>
        [DisplayName("HphpNameFul")]
        [DataObjectField(false, false, false, 555)]
        [BindColumn("HPHP_NAME_FUL", "", "varchar(555)")]
        public String HphpNameFul { get => _HphpNameFul; set { if (OnPropertyChanging(__.HphpNameFul, value)) { _HphpNameFul = value; OnPropertyChanged(__.HphpNameFul); } } }
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
                    case __.HphpID: return _HphpID;
                   
                    case __.HphpName: return _HphpName;
                  
                    case __.HphpAddr: return _HphpAddr;
                   
                    case __.HphpNameFst: return _HphpNameFst;
                    case __.HphpNameFul: return _HphpNameFul;
                   
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case __.HphpID: _HphpID = Convert.ToString(value); break;
                   
                    case __.HphpName: _HphpName = Convert.ToString(value); break;
                   
                    case __.HphpAddr: _HphpAddr = Convert.ToString(value); break;
                   
                    case __.HphpNameFst: _HphpNameFst = Convert.ToString(value); break;
                    case __.HphpNameFul: _HphpNameFul = Convert.ToString(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得TbehHphpHospitalInfo字段信息的快捷方式</summary>
        public partial class _
        {
            /// <summary></summary>
            public static readonly Field HphpID = FindByName(__.HphpID);

            /// <summary></summary>
            public static readonly Field HphpName = FindByName(__.HphpName);


            /// <summary></summary>
            public static readonly Field HphpAddr = FindByName(__.HphpAddr);


            /// <summary></summary>
            public static readonly Field HphpNameFst = FindByName(__.HphpNameFst);

            /// <summary></summary>
            public static readonly Field HphpNameFul = FindByName(__.HphpNameFul);


            static Field FindByName(String name) => Meta.Table.FindByName(name);
        }

        /// <summary>取得TbehHphpHospitalInfo字段名称的快捷方式</summary>
        public partial class __
        {
            /// <summary></summary>
            public const String HphpID = "HphpID";


            /// <summary></summary>
            public const String HphpName = "HphpName";


            /// <summary></summary>
            public const String HphpAddr = "HphpAddr";


            /// <summary></summary>
            public const String HphpNameFst = "HphpNameFst";

            /// <summary></summary>
            public const String HphpNameFul = "HphpNameFul";

        }
        #endregion
    }

    /// <summary>接口</summary>
    public partial interface ITbehHphpHospitalInfo
    {
        #region 属性
        /// <summary></summary>
        String HphpID { get; set; }


        /// <summary></summary>
        String HphpName { get; set; }

        /// <summary>
        /// <summary></summary>
        String HphpAddr { get; set; }


        /// <summary></summary>
        String HphpNameFst { get; set; }

        /// <summary></summary>
        String HphpNameFul { get; set; }

       
        #endregion

        #region 获取/设置 字段值
        /// <summary>获取/设置 字段值</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        Object this[String name] { get; set; }
        #endregion
    }
}