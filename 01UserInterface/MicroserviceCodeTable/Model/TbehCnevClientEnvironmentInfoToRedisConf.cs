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
    [BindTable("TBEH_CNEV_CLIENT_ENVIRONMENT_INFO_TO_REDIS_CONF", Description = "", ConnName = "MSSQLMainMaster", DbType = DatabaseType.SqlServer)]
    public partial class TbehCnevClientEnvironmentInfoToRedisConf : ITbehCnevClientEnvironmentInfoToRedisConf
    {
        #region 属性
        private Int32 _CnevKy;
        /// <summary></summary>
        [DisplayName("CnevKy")]
        [DataObjectField(true, true, false, 10)]
        [BindColumn("CNEV_KY", "", "int")]
        public Int32 CnevKy { get => _CnevKy; set { if (OnPropertyChanging(__.CnevKy, value)) { _CnevKy = value; OnPropertyChanged(__.CnevKy); } } }

        private String _CncnID;
        /// <summary></summary>
        [DisplayName("CncnID")]
        [DataObjectField(false, false, false, 12)]
        [BindColumn("CNCN_ID", "", "varchar(12)")]
        public String CncnID { get => _CncnID; set { if (OnPropertyChanging(__.CncnID, value)) { _CncnID = value; OnPropertyChanged(__.CncnID); } } }

        private String _CnevID;
        /// <summary></summary>
        [DisplayName("CnevID")]
        [DataObjectField(false, false, false, 12)]
        [BindColumn("CNEV_ID", "", "varchar(12)")]
        public String CnevID { get => _CnevID; set { if (OnPropertyChanging(__.CnevID, value)) { _CnevID = value; OnPropertyChanged(__.CnevID); } } }

        private String _CnevIlinkDatabaseName;
        /// <summary></summary>
        [DisplayName("CnevIlinkDatabaseName")]
        [DataObjectField(false, false, false, 15)]
        [BindColumn("CNEV_ILINK_DATABASE_NAME", "", "varchar(15)")]
        public String CnevIlinkDatabaseName { get => _CnevIlinkDatabaseName; set { if (OnPropertyChanging(__.CnevIlinkDatabaseName, value)) { _CnevIlinkDatabaseName = value; OnPropertyChanged(__.CnevIlinkDatabaseName); } } }

        private String _CnevType;
        /// <summary></summary>
        [DisplayName("CnevType")]
        [DataObjectField(false, false, false, 2)]
        [BindColumn("CNEV_TYPE", "", "varchar(2)")]
        public String CnevType { get => _CnevType; set { if (OnPropertyChanging(__.CnevType, value)) { _CnevType = value; OnPropertyChanged(__.CnevType); } } }

        private String _CnevIp;
        /// <summary></summary>
        [DisplayName("CnevIp")]
        [DataObjectField(false, false, false, 155)]
        [BindColumn("CNEV_IP", "", "varchar(155)")]
        public String CnevIp { get => _CnevIp; set { if (OnPropertyChanging(__.CnevIp, value)) { _CnevIp = value; OnPropertyChanged(__.CnevIp); } } }

        private String _CnevUser;
        /// <summary></summary>
        [DisplayName("CnevUser")]
        [DataObjectField(false, false, false, 55)]
        [BindColumn("CNEV_USER", "", "varchar(55)")]
        public String CnevUser { get => _CnevUser; set { if (OnPropertyChanging(__.CnevUser, value)) { _CnevUser = value; OnPropertyChanged(__.CnevUser); } } }

        private String _CnevPassword;
        /// <summary></summary>
        [DisplayName("CnevPassword")]
        [DataObjectField(false, false, false, 155)]
        [BindColumn("CNEV_PASSWORD", "", "varchar(155)")]
        public String CnevPassword { get => _CnevPassword; set { if (OnPropertyChanging(__.CnevPassword, value)) { _CnevPassword = value; OnPropertyChanged(__.CnevPassword); } } }

        private String _CnevSts;
        /// <summary></summary>
        [DisplayName("CnevSts")]
        [DataObjectField(false, false, false, 2)]
        [BindColumn("CNEV_STS", "", "varchar(2)")]
        public String CnevSts { get => _CnevSts; set { if (OnPropertyChanging(__.CnevSts, value)) { _CnevSts = value; OnPropertyChanged(__.CnevSts); } } }

        private String _CnevGetBatchInd;
        /// <summary></summary>
        [DisplayName("CnevGetBatchInd")]
        [DataObjectField(false, false, false, 2)]
        [BindColumn("CNEV_GET_BATCH_IND", "", "varchar(2)")]
        public String CnevGetBatchInd { get => _CnevGetBatchInd; set { if (OnPropertyChanging(__.CnevGetBatchInd, value)) { _CnevGetBatchInd = value; OnPropertyChanged(__.CnevGetBatchInd); } } }

        private String _CnevNextBatchInd;
        /// <summary></summary>
        [DisplayName("CnevNextBatchInd")]
        [DataObjectField(false, false, false, 2)]
        [BindColumn("CNEV_NEXT_BATCH_IND", "", "varchar(2)")]
        public String CnevNextBatchInd { get => _CnevNextBatchInd; set { if (OnPropertyChanging(__.CnevNextBatchInd, value)) { _CnevNextBatchInd = value; OnPropertyChanged(__.CnevNextBatchInd); } } }

        private Int32 _CnevStartNum;
        /// <summary></summary>
        [DisplayName("CnevStartNum")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn("CNEV_START_NUM", "", "int")]
        public Int32 CnevStartNum { get => _CnevStartNum; set { if (OnPropertyChanging(__.CnevStartNum, value)) { _CnevStartNum = value; OnPropertyChanged(__.CnevStartNum); } } }

        private Int32 _CnevEndNum;
        /// <summary></summary>
        [DisplayName("CnevEndNum")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn("CNEV_END_NUM", "", "int")]
        public Int32 CnevEndNum { get => _CnevEndNum; set { if (OnPropertyChanging(__.CnevEndNum, value)) { _CnevEndNum = value; OnPropertyChanged(__.CnevEndNum); } } }

        private DateTime _CnevBatchDtm;
        /// <summary></summary>
        [DisplayName("CnevBatchDtm")]
        [DataObjectField(false, false, false, 3)]
        [BindColumn("CNEV_BATCH_DTM", "", "datetime", Precision = 0, Scale = 3)]
        public DateTime CnevBatchDtm { get => _CnevBatchDtm; set { if (OnPropertyChanging(__.CnevBatchDtm, value)) { _CnevBatchDtm = value; OnPropertyChanged(__.CnevBatchDtm); } } }

        private String _CnevComment;
        /// <summary></summary>
        [DisplayName("CnevComment")]
        [DataObjectField(false, false, false, 555)]
        [BindColumn("CNEV_COMMENT", "", "varchar(555)")]
        public String CnevComment { get => _CnevComment; set { if (OnPropertyChanging(__.CnevComment, value)) { _CnevComment = value; OnPropertyChanged(__.CnevComment); } } }

        private String _CncnFlag;
        /// <summary></summary>
        [DisplayName("CncnFlag")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn("CNCN_FLAG", "", "varchar(10)")]
        public String CncnFlag { get => _CncnFlag; set { if (OnPropertyChanging(__.CncnFlag, value)) { _CncnFlag = value; OnPropertyChanged(__.CncnFlag); } } }
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
                    case __.CnevKy: return _CnevKy;
                    case __.CncnID: return _CncnID;
                    case __.CnevID: return _CnevID;
                    case __.CnevIlinkDatabaseName: return _CnevIlinkDatabaseName;
                    case __.CnevType: return _CnevType;
                    case __.CnevIp: return _CnevIp;
                    case __.CnevUser: return _CnevUser;
                    case __.CnevPassword: return _CnevPassword;
                    case __.CnevSts: return _CnevSts;
                    case __.CnevGetBatchInd: return _CnevGetBatchInd;
                    case __.CnevNextBatchInd: return _CnevNextBatchInd;
                    case __.CnevStartNum: return _CnevStartNum;
                    case __.CnevEndNum: return _CnevEndNum;
                    case __.CnevBatchDtm: return _CnevBatchDtm;
                    case __.CnevComment: return _CnevComment;
                    case __.CncnFlag: return _CncnFlag;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case __.CnevKy: _CnevKy = value.ToInt(); break;
                    case __.CncnID: _CncnID = Convert.ToString(value); break;
                    case __.CnevID: _CnevID = Convert.ToString(value); break;
                    case __.CnevIlinkDatabaseName: _CnevIlinkDatabaseName = Convert.ToString(value); break;
                    case __.CnevType: _CnevType = Convert.ToString(value); break;
                    case __.CnevIp: _CnevIp = Convert.ToString(value); break;
                    case __.CnevUser: _CnevUser = Convert.ToString(value); break;
                    case __.CnevPassword: _CnevPassword = Convert.ToString(value); break;
                    case __.CnevSts: _CnevSts = Convert.ToString(value); break;
                    case __.CnevGetBatchInd: _CnevGetBatchInd = Convert.ToString(value); break;
                    case __.CnevNextBatchInd: _CnevNextBatchInd = Convert.ToString(value); break;
                    case __.CnevStartNum: _CnevStartNum = value.ToInt(); break;
                    case __.CnevEndNum: _CnevEndNum = value.ToInt(); break;
                    case __.CnevBatchDtm: _CnevBatchDtm = value.ToDateTime(); break;
                    case __.CnevComment: _CnevComment = Convert.ToString(value); break;
                    case __.CncnFlag: _CncnFlag = Convert.ToString(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得TbehCnevClientEnvironmentInfoToRedisConf字段信息的快捷方式</summary>
        public partial class _
        {
            /// <summary></summary>
            public static readonly Field CnevKy = FindByName(__.CnevKy);

            /// <summary></summary>

            /// <summary></summary>
            public static readonly Field CncnID = FindByName(__.CncnID);

            /// <summary></summary>
            public static readonly Field CnevID = FindByName(__.CnevID);

            /// <summary></summary>
            public static readonly Field CnevIlinkDatabaseName = FindByName(__.CnevIlinkDatabaseName);

            /// <summary></summary>
            public static readonly Field CnevType = FindByName(__.CnevType);

            /// <summary></summary>
            public static readonly Field CnevIp = FindByName(__.CnevIp);

            /// <summary></summary>
            public static readonly Field CnevUser = FindByName(__.CnevUser);

            /// <summary></summary>
            public static readonly Field CnevPassword = FindByName(__.CnevPassword);

            /// <summary></summary>
            public static readonly Field CnevSts = FindByName(__.CnevSts);

            /// <summary></summary>
            public static readonly Field CnevGetBatchInd = FindByName(__.CnevGetBatchInd);

            /// <summary></summary>
            public static readonly Field CnevNextBatchInd = FindByName(__.CnevNextBatchInd);

            /// <summary></summary>
            public static readonly Field CnevStartNum = FindByName(__.CnevStartNum);

            /// <summary></summary>
            public static readonly Field CnevEndNum = FindByName(__.CnevEndNum);

            /// <summary></summary>
            public static readonly Field CnevBatchDtm = FindByName(__.CnevBatchDtm);

            /// <summary></summary>
            public static readonly Field CnevComment = FindByName(__.CnevComment);

            /// <summary></summary>
            public static readonly Field CncnFlag = FindByName(__.CncnFlag);

            static Field FindByName(String name) => Meta.Table.FindByName(name);
        }

        /// <summary>取得TbehCnevClientEnvironmentInfoToRedisConf字段名称的快捷方式</summary>
        public partial class __
        {
            /// <summary></summary>
            public const String CnevKy = "CnevKy";


            /// <summary></summary>
            public const String CncnID = "CncnID";

            /// <summary></summary>
            public const String CnevID = "CnevID";

            /// <summary></summary>
            public const String CnevIlinkDatabaseName = "CnevIlinkDatabaseName";

            /// <summary></summary>
            public const String CnevType = "CnevType";

            /// <summary></summary>
            public const String CnevIp = "CnevIp";

            /// <summary></summary>
            public const String CnevUser = "CnevUser";

            /// <summary></summary>
            public const String CnevPassword = "CnevPassword";

            /// <summary></summary>
            public const String CnevSts = "CnevSts";

            /// <summary></summary>
            public const String CnevGetBatchInd = "CnevGetBatchInd";

            /// <summary></summary>
            public const String CnevNextBatchInd = "CnevNextBatchInd";

            /// <summary></summary>
            public const String CnevStartNum = "CnevStartNum";

            /// <summary></summary>
            public const String CnevEndNum = "CnevEndNum";

            /// <summary></summary>
            public const String CnevBatchDtm = "CnevBatchDtm";

            /// <summary></summary>
            public const String CnevComment = "CnevComment";

            /// <summary></summary>
            public const String CncnFlag = "CncnFlag";
        }
        #endregion
    }

    /// <summary>接口</summary>
    public partial interface ITbehCnevClientEnvironmentInfoToRedisConf
    {
        #region 属性
        /// <summary></summary>
        Int32 CnevKy { get; set; }

       

        /// <summary></summary>
        String CncnID { get; set; }

        /// <summary></summary>
        String CnevID { get; set; }

        /// <summary></summary>
        String CnevIlinkDatabaseName { get; set; }

        /// <summary></summary>
        String CnevType { get; set; }

        /// <summary></summary>
        String CnevIp { get; set; }

        /// <summary></summary>
        String CnevUser { get; set; }

        /// <summary></summary>
        String CnevPassword { get; set; }

        /// <summary></summary>
        String CnevSts { get; set; }

        /// <summary></summary>
        String CnevGetBatchInd { get; set; }

        /// <summary></summary>
        String CnevNextBatchInd { get; set; }

        /// <summary></summary>
        Int32 CnevStartNum { get; set; }

        /// <summary></summary>
        Int32 CnevEndNum { get; set; }

        /// <summary></summary>
        DateTime CnevBatchDtm { get; set; }

        /// <summary></summary>
        String CnevComment { get; set; }

        /// <summary></summary>
        String CncnFlag { get; set; }
        #endregion

        #region 获取/设置 字段值
        /// <summary>获取/设置 字段值</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        Object this[String name] { get; set; }
        #endregion
    }
}