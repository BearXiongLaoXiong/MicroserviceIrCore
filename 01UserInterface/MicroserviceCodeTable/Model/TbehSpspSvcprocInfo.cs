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
    [BindIndex("PK_TBEH_SPSP_SVCPROC_INFO", true, "SPSP_ID")]
    [BindTable("TBEH_SPSP_SVCPROC_INFO", Description = "", ConnName = "MSSQLTPAPROD", DbType = DatabaseType.SqlServer)]
    public partial class TbehSpspSvcprocInfo : ITbehSpspSvcprocInfo
    {
        #region 属性
        private String _SpspID;
        /// <summary></summary>
        [DisplayName("SpspID")]
        [DataObjectField(true, false, false, 12)]
        [BindColumn("SPSP_ID", "", "varchar(12)")]
        public String SpspID { get => _SpspID; set { if (OnPropertyChanging(__.SpspID, value)) { _SpspID = value; OnPropertyChanged(__.SpspID); } } }

        
        private String _SpspDesc;
        /// <summary></summary>
        [DisplayName("SpspDesc")]
        [DataObjectField(false, false, false, 555)]
        [BindColumn("SPSP_DESC", "", "varchar(555)")]
        public String SpspDesc { get => _SpspDesc; set { if (OnPropertyChanging(__.SpspDesc, value)) { _SpspDesc = value; OnPropertyChanged(__.SpspDesc); } } }

        private String _SpspDescEng;
        /// <summary></summary>
        [DisplayName("SpspDescEng")]
        [DataObjectField(false, false, false, 555)]
        [BindColumn("SPSP_DESC_ENG", "", "varchar(555)")]
        public String SpspDescEng { get => _SpspDescEng; set { if (OnPropertyChanging(__.SpspDescEng, value)) { _SpspDescEng = value; OnPropertyChanged(__.SpspDescEng); } } }

        private String _SpspNameFst;
        /// <summary></summary>
        [DisplayName("SpspNameFst")]
        [DataObjectField(false, false, false, 155)]
        [BindColumn("SPSP_NAME_FST", "", "varchar(155)")]
        public String SpspNameFst { get => _SpspNameFst; set { if (OnPropertyChanging(__.SpspNameFst, value)) { _SpspNameFst = value; OnPropertyChanged(__.SpspNameFst); } } }

        private String _SpspNameFul;
        /// <summary></summary>
        [DisplayName("SpspNameFul")]
        [DataObjectField(false, false, false, 555)]
        [BindColumn("SPSP_NAME_FUL", "", "varchar(555)")]
        public String SpspNameFul { get => _SpspNameFul; set { if (OnPropertyChanging(__.SpspNameFul, value)) { _SpspNameFul = value; OnPropertyChanged(__.SpspNameFul); } } }
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
                    case __.SpspID: return _SpspID;
                 
                    case __.SpspDesc: return _SpspDesc;
                    case __.SpspDescEng: return _SpspDescEng;
             
                    case __.SpspNameFst: return _SpspNameFst;
                    case __.SpspNameFul: return _SpspNameFul;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case __.SpspID: _SpspID = Convert.ToString(value); break;
              
                    case __.SpspDesc: _SpspDesc = Convert.ToString(value); break;
                    case __.SpspDescEng: _SpspDescEng = Convert.ToString(value); break;
                   
                    case __.SpspNameFst: _SpspNameFst = Convert.ToString(value); break;
                    case __.SpspNameFul: _SpspNameFul = Convert.ToString(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得TbehSpspSvcprocInfo字段信息的快捷方式</summary>
        public partial class _
        {
            /// <summary></summary>
            public static readonly Field SpspID = FindByName(__.SpspID);


            /// <summary></summary>
            public static readonly Field SpspDesc = FindByName(__.SpspDesc);

            /// <summary></summary>
            public static readonly Field SpspDescEng = FindByName(__.SpspDescEng);

           
            /// <summary></summary>
            public static readonly Field SpspNameFst = FindByName(__.SpspNameFst);

            /// <summary></summary>
            public static readonly Field SpspNameFul = FindByName(__.SpspNameFul);

            static Field FindByName(String name) => Meta.Table.FindByName(name);
        }

        /// <summary>取得TbehSpspSvcprocInfo字段名称的快捷方式</summary>
        public partial class __
        {
            /// <summary></summary>
            public const String SpspID = "SpspID";

            /// <summary></summary>
            public const String SpspDesc = "SpspDesc";

            /// <summary></summary>
            public const String SpspDescEng = "SpspDescEng";


            /// <summary></summary>
            public const String SpspNameFst = "SpspNameFst";

            /// <summary></summary>
            public const String SpspNameFul = "SpspNameFul";
        }
        #endregion
    }

    /// <summary>接口</summary>
    public partial interface ITbehSpspSvcprocInfo
    {
        #region 属性
        /// <summary></summary>
        String SpspID { get; set; }

        /// <summary></summary>
        String SpspDesc { get; set; }

        /// <summary></summary>
        String SpspDescEng { get; set; }

        /// <summary></summary>
        String SpspNameFst { get; set; }

        /// <summary></summary>
        String SpspNameFul { get; set; }
        #endregion

        #region 获取/设置 字段值
        /// <summary>获取/设置 字段值</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        Object this[String name] { get; set; }
        #endregion
    }
}