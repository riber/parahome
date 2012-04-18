/******************************************
* 模块名称：实体 福位使用者
* 当前版本：1.0
* 开发人员：Administrator
* 生成时间：2012-4-17
* 版本历史：此代码由 VB/C#.Net实体代码生成工具(EntitysCodeGenerate 4.4) 自动生成。
* 
******************************************/
using System;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;

namespace ParadiseHome.Common.Model.Basic
{
	/// <summary>
	/// 实体 福位使用者
	/// </summary>
	[Description("Primary:ID")]
    [Serializable]
	public partial class Resident
	{
        #region 构造函数
        /// <summary>
        /// 实体 福位使用者
        /// </summary>
        public Resident(){}
        #endregion

        #region 私有变量
        private long _id = long.MinValue;
        private long _basicinfoid = long.MinValue;
        private long _cellid = long.MinValue;
        private DateTime _deathday = DateTime.MinValue;
        private DateTime _checkinday = DateTime.MinValue;
        private long _purchaserbasicid = long.MinValue;
        private string _relationwithpurchaser = null;
        private string _lifttimeintro = null;
        private string _imagepath = null;
        private string _comment = null;
        #endregion

        #region 公共属性
        /// <summary>
        /// 主键 ID(NOT NULL)
        /// </summary>
        public long ID
        {
            set{ _id=value;}
            get{return _id;}
        }
        /// <summary>
        /// 基本信息ID(NOT NULL)
        /// </summary>
        public long BasicInfoID
        {
            set{ _basicinfoid=value;}
            get{return _basicinfoid;}
        }
        /// <summary>
        /// 福位ID(NOT NULL)
        /// </summary>
        public long CellID
        {
            set{ _cellid=value;}
            get{return _cellid;}
        }
        /// <summary>
        /// 往生时间
        /// </summary>
        public DateTime DeathDay
        {
            set{ _deathday=value;}
            get{return _deathday;}
        }
        /// <summary>
        /// 入住时间
        /// </summary>
        public DateTime CheckInDay
        {
            set{ _checkinday=value;}
            get{return _checkinday;}
        }
        /// <summary>
        /// 捐赠者ID(NOT NULL)
        /// </summary>
        public long PurchaserBasicID
        {
            set{ _purchaserbasicid=value;}
            get{return _purchaserbasicid;}
        }
        /// <summary>
        /// 与捐赠者关系
        /// </summary>
        public string RelationWithPurchaser
        {
            set{ _relationwithpurchaser=value;}
            get{return _relationwithpurchaser;}
        }
        /// <summary>
        /// 生平
        /// </summary>
        public string LiftTimeIntro
        {
            set{ _lifttimeintro=value;}
            get{return _lifttimeintro;}
        }
        /// <summary>
        /// 照片路径
        /// </summary>
        public string ImagePath
        {
            set{ _imagepath=value;}
            get{return _imagepath;}
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string Comment
        {
            set{ _comment=value;}
            get{return _comment;}
        }
        #endregion
	}
}
