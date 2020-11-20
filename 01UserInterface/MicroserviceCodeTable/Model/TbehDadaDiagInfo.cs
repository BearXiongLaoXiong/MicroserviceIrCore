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
    [BindIndex("PK_TBEH_DADA_DIAG_INFO", true, "DADA_ID")]
    [BindTable("TBEH_DADA_DIAG_INFO", Description = "", ConnName = "MSSQLTPAPROD", DbType = DatabaseType.SqlServer)]
    public partial class TbehDadaDiagInfo : ITbehDadaDiagInfo
    {
        #region 属性
        private String _DadaID;
        /// <summary></summary>
        [DisplayName("DadaID")]
        [DataObjectField(true, false, false, 255)]
        [BindColumn("DADA_ID", "", "nvarchar(255)")]
        public String DadaID { get => _DadaID; set { if (OnPropertyChanging(__.DadaID, value)) { _DadaID = value; OnPropertyChanged(__.DadaID); } } }

        private String _DadaDesc;
        /// <summary></summary>
        [DisplayName("DadaDesc")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("DADA_DESC", "", "nvarchar(255)")]
        public String DadaDesc { get => _DadaDesc; set { if (OnPropertyChanging(__.DadaDesc, value)) { _DadaDesc = value; OnPropertyChanged(__.DadaDesc); } } }

       
        private String _DadaNameFst;
        /// <summary></summary>
        [DisplayName("DadaNameFst")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("DADA_NAME_FST", "", "nvarchar(255)")]
        public String DadaNameFst { get => _DadaNameFst; set { if (OnPropertyChanging(__.DadaNameFst, value)) { _DadaNameFst = value; OnPropertyChanged(__.DadaNameFst); } } }

        private String _DadaNameFul;
        /// <summary></summary>
        [DisplayName("DadaNameFul")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn("DADA_NAME_FUL", "", "nvarchar(255)")]
        public String DadaNameFul { get => _DadaNameFul; set { if (OnPropertyChanging(__.DadaNameFul, value)) { _DadaNameFul = value; OnPropertyChanged(__.DadaNameFul); } } }
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
                    case __.DadaID: return _DadaID;
                    case __.DadaDesc: return _DadaDesc;
                    
                    case __.DadaNameFst: return _DadaNameFst;
                    case __.DadaNameFul: return _DadaNameFul;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case __.DadaID: _DadaID = Convert.ToString(value); break;
                    case __.DadaDesc: _DadaDesc = Convert.ToString(value); break;
                  
                    case __.DadaNameFst: _DadaNameFst = Convert.ToString(value); break;
                    case __.DadaNameFul: _DadaNameFul = Convert.ToString(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得TbehDadaDiagInfo字段信息的快捷方式</summary>
        public partial class _
        {
            /// <summary></summary>
            public static readonly Field DadaID = FindByName(__.DadaID);

            /// <summary></summary>
            public static readonly Field DadaDesc = FindByName(__.DadaDesc);

           

            /// <summary></summary>
            public static readonly Field DadaNameFst = FindByName(__.DadaNameFst);

            /// <summary></summary>
            public static readonly Field DadaNameFul = FindByName(__.DadaNameFul);

            static Field FindByName(String name) => Meta.Table.FindByName(name);
        }

        /// <summary>取得TbehDadaDiagInfo字段名称的快捷方式</summary>
        public partial class __
        {
            /// <summary></summary>
            public const String DadaID = "DadaID";

            /// <summary></summary>
            public const String DadaDesc = "DadaDesc";

           

            /// <summary></summary>
            public const String DadaNameFst = "DadaNameFst";

            /// <summary></summary>
            public const String DadaNameFul = "DadaNameFul";
        }
        #endregion
    }

    /// <summary>接口</summary>
    public partial interface ITbehDadaDiagInfo
    {
        #region 属性
        /// <summary></summary>
        String DadaID { get; set; }

        /// <summary></summary>
        String DadaDesc { get; set; }

       

        /// <summary></summary>
        String DadaNameFst { get; set; }

        /// <summary></summary>
        String DadaNameFul { get; set; }
        #endregion

        #region 获取/设置 字段值
        /// <summary>获取/设置 字段值</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        Object this[String name] { get; set; }
        #endregion
    }
}