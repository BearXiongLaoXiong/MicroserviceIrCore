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
    [BindIndex("PK__TBEH_USC__1889058B31895D4D", true, "USCN_KY")]
    [BindTable("TBEH_USCN_USER_CLIENT_INFO", Description = "", ConnName = "MSSQLPrdMainMaster", DbType = DatabaseType.SqlServer)]
    public partial class TbehUscnUserClientInfo : ITbehUscnUserClientInfo
    {
        #region 属性
        private Int32 _UscnKy;
        /// <summary></summary>
        [DisplayName("UscnKy")]
        [DataObjectField(true, false, false, 10)]
        [BindColumn("USCN_KY", "", "int")]
        public Int32 UscnKy { get => _UscnKy; set { if (OnPropertyChanging(__.UscnKy, value)) { _UscnKy = value; OnPropertyChanged(__.UscnKy); } } }

        private String _UsusID;
        /// <summary></summary>
        [DisplayName("UsusID")]
        [DataObjectField(false, false, false, 50)]
        [BindColumn("USUS_ID", "", "varchar(50)")]
        public String UsusID { get => _UsusID; set { if (OnPropertyChanging(__.UsusID, value)) { _UsusID = value; OnPropertyChanged(__.UsusID); } } }

        private String _CncnID;
        /// <summary></summary>
        [DisplayName("CncnID")]
        [DataObjectField(false, false, false, 12)]
        [BindColumn("CNCN_ID", "", "varchar(12)")]
        public String CncnID { get => _CncnID; set { if (OnPropertyChanging(__.CncnID, value)) { _CncnID = value; OnPropertyChanged(__.CncnID); } } }

        private String _CncnUsusID;
        /// <summary></summary>
        [DisplayName("CncnUsusID")]
        [DataObjectField(false, false, false, 50)]
        [BindColumn("CNCN_USUS_ID", "", "varchar(50)")]
        public String CncnUsusID { get => _CncnUsusID; set { if (OnPropertyChanging(__.CncnUsusID, value)) { _CncnUsusID = value; OnPropertyChanged(__.CncnUsusID); } } }

        private String _UscnType;
        /// <summary></summary>
        [DisplayName("UscnType")]
        [DataObjectField(false, false, false, 2)]
        [BindColumn("USCN_TYPE", "", "varchar(2)")]
        public String UscnType { get => _UscnType; set { if (OnPropertyChanging(__.UscnType, value)) { _UscnType = value; OnPropertyChanged(__.UscnType); } } }

        private String _UscnSts;
        /// <summary></summary>
        [DisplayName("UscnSts")]
        [DataObjectField(false, false, false, 2)]
        [BindColumn("USCN_STS", "", "varchar(2)")]
        public String UscnSts { get => _UscnSts; set { if (OnPropertyChanging(__.UscnSts, value)) { _UscnSts = value; OnPropertyChanged(__.UscnSts); } } }

        private DateTime _UscnEffDt;
        /// <summary></summary>
        [DisplayName("UscnEffDt")]
        [DataObjectField(false, false, false, 3)]
        [BindColumn("USCN_EFF_DT", "", "datetime", Precision = 0, Scale = 3)]
        public DateTime UscnEffDt { get => _UscnEffDt; set { if (OnPropertyChanging(__.UscnEffDt, value)) { _UscnEffDt = value; OnPropertyChanged(__.UscnEffDt); } } }

        private DateTime _UscnEndDt;
        /// <summary></summary>
        [DisplayName("UscnEndDt")]
        [DataObjectField(false, false, false, 3)]
        [BindColumn("USCN_END_DT", "", "datetime", Precision = 0, Scale = 3)]
        public DateTime UscnEndDt { get => _UscnEndDt; set { if (OnPropertyChanging(__.UscnEndDt, value)) { _UscnEndDt = value; OnPropertyChanged(__.UscnEndDt); } } }

        private String _UscnComment;
        /// <summary></summary>
        [DisplayName("UscnComment")]
        [DataObjectField(false, false, false, 555)]
        [BindColumn("USCN_COMMENT", "", "varchar(555)")]
        public String UscnComment { get => _UscnComment; set { if (OnPropertyChanging(__.UscnComment, value)) { _UscnComment = value; OnPropertyChanged(__.UscnComment); } } }
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
                    case __.UscnKy: return _UscnKy;
                    case __.UsusID: return _UsusID;
                    case __.CncnID: return _CncnID;
                    case __.CncnUsusID: return _CncnUsusID;
                    case __.UscnType: return _UscnType;
                    case __.UscnSts: return _UscnSts;
                    case __.UscnEffDt: return _UscnEffDt;
                    case __.UscnEndDt: return _UscnEndDt;
                    case __.UscnComment: return _UscnComment;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case __.UscnKy: _UscnKy = value.ToInt(); break;
                    case __.UsusID: _UsusID = Convert.ToString(value); break;
                    case __.CncnID: _CncnID = Convert.ToString(value); break;
                    case __.CncnUsusID: _CncnUsusID = Convert.ToString(value); break;
                    case __.UscnType: _UscnType = Convert.ToString(value); break;
                    case __.UscnSts: _UscnSts = Convert.ToString(value); break;
                    case __.UscnEffDt: _UscnEffDt = value.ToDateTime(); break;
                    case __.UscnEndDt: _UscnEndDt = value.ToDateTime(); break;
                    case __.UscnComment: _UscnComment = Convert.ToString(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得TbehUscnUserClientInfo字段信息的快捷方式</summary>
        public partial class _
        {
            /// <summary></summary>
            public static readonly Field UscnKy = FindByName(__.UscnKy);

            /// <summary></summary>
            public static readonly Field UsusID = FindByName(__.UsusID);

            /// <summary></summary>
            public static readonly Field CncnID = FindByName(__.CncnID);

            /// <summary></summary>
            public static readonly Field CncnUsusID = FindByName(__.CncnUsusID);

            /// <summary></summary>
            public static readonly Field UscnType = FindByName(__.UscnType);

            /// <summary></summary>
            public static readonly Field UscnSts = FindByName(__.UscnSts);

            /// <summary></summary>
            public static readonly Field UscnEffDt = FindByName(__.UscnEffDt);

            /// <summary></summary>
            public static readonly Field UscnEndDt = FindByName(__.UscnEndDt);

            /// <summary></summary>
            public static readonly Field UscnComment = FindByName(__.UscnComment);

            static Field FindByName(String name) => Meta.Table.FindByName(name);
        }

        /// <summary>取得TbehUscnUserClientInfo字段名称的快捷方式</summary>
        public partial class __
        {
            /// <summary></summary>
            public const String UscnKy = "UscnKy";

            /// <summary></summary>
            public const String UsusID = "UsusID";

            /// <summary></summary>
            public const String CncnID = "CncnID";

            /// <summary></summary>
            public const String CncnUsusID = "CncnUsusID";

            /// <summary></summary>
            public const String UscnType = "UscnType";

            /// <summary></summary>
            public const String UscnSts = "UscnSts";

            /// <summary></summary>
            public const String UscnEffDt = "UscnEffDt";

            /// <summary></summary>
            public const String UscnEndDt = "UscnEndDt";

            /// <summary></summary>
            public const String UscnComment = "UscnComment";
        }
        #endregion
    }

    /// <summary>接口</summary>
    public partial interface ITbehUscnUserClientInfo
    {
        #region 属性
        /// <summary></summary>
        Int32 UscnKy { get; set; }

        /// <summary></summary>
        String UsusID { get; set; }

        /// <summary></summary>
        String CncnID { get; set; }

        /// <summary></summary>
        String CncnUsusID { get; set; }

        /// <summary></summary>
        String UscnType { get; set; }

        /// <summary></summary>
        String UscnSts { get; set; }

        /// <summary></summary>
        DateTime UscnEffDt { get; set; }

        /// <summary></summary>
        DateTime UscnEndDt { get; set; }

        /// <summary></summary>
        String UscnComment { get; set; }
        #endregion

        #region 获取/设置 字段值
        /// <summary>获取/设置 字段值</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        Object this[String name] { get; set; }
        #endregion
    }
}