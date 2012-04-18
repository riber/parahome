/******************************************
* 模块名称：实体 购买或者捐赠或者预定记录表
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
	/// 实体 购买或者捐赠或者预定记录表
	/// </summary>
	[Description("Primary:ID")]
    [Serializable]
	public partial class bf_purchaselog
	{
        #region 构造函数
        /// <summary>
        /// 实体 购买或者捐赠或者预定记录表
        /// </summary>
        public bf_purchaselog(){}
        #endregion

        #region 私有变量
        private long _id = long.MinValue;
        private long _cellid = long.MinValue;
        private long _purchaserbasicid = long.MinValue;
        private long _introducerbasicid = long.MinValue;
        private byte[] _ispayed = null;
        private DateTime _paydatedue = DateTime.MinValue;
        private string _gongdecertno = null;
        private float _payedprice = float.MinValue;
        private DateTime _scheduleday = DateTime.MinValue;
        private DateTime _purchaseday = DateTime.MinValue;
        private long _operatorid = long.MinValue;
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
        /// 捐赠福位ID(NOT NULL)
        /// </summary>
        public long CellID
        {
            set{ _cellid=value;}
            get{return _cellid;}
        }
        /// <summary>
        /// 捐赠人基本信息ID(NOT NULL)
        /// </summary>
        public long PurchaserBasicID
        {
            set{ _purchaserbasicid=value;}
            get{return _purchaserbasicid;}
        }
        /// <summary>
        /// 推荐居士基本信息ID(NOT NULL)
        /// </summary>
        public long IntroducerBasicID
        {
            set{ _introducerbasicid=value;}
            get{return _introducerbasicid;}
        }
        /// <summary>
        /// 是否已付款
        /// </summary>
        public byte[] IsPayed
        {
            set{ _ispayed=value;}
            get{return _ispayed;}
        }
        /// <summary>
        /// 付款截止时间
        /// </summary>
        public DateTime PayDateDue
        {
            set{ _paydatedue=value;}
            get{return _paydatedue;}
        }
        /// <summary>
        /// 功德凭证编号
        /// </summary>
        public string GongDeCertNo
        {
            set{ _gongdecertno=value;}
            get{return _gongdecertno;}
        }
        /// <summary>
        /// 捐赠金额
        /// </summary>
        public float PayedPrice
        {
            set{ _payedprice=value;}
            get{return _payedprice;}
        }
        /// <summary>
        /// 预定时间
        /// </summary>
        public DateTime ScheduleDay
        {
            set{ _scheduleday=value;}
            get{return _scheduleday;}
        }
        /// <summary>
        /// 付款时间
        /// </summary>
        public DateTime PurchaseDay
        {
            set{ _purchaseday=value;}
            get{return _purchaseday;}
        }
        /// <summary>
        /// 经办管理员ID(NOT NULL)
        /// </summary>
        public long OperatorID
        {
            set{ _operatorid=value;}
            get{return _operatorid;}
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

        #region 公共静态只读属性
        /// <summary>
        /// 表名 表原信息描述: 购买或者捐赠或者预定记录表
        /// </summary>
        public static readonly string s_TableName =  "bf_purchaselog";
        /// <summary>
        /// 信息描述: ID(NOT NULL)
        /// </summary>
        public static readonly string s_ID =  "bf_purchaselog┋ID┋System.Int64";
        /// <summary>
        /// 信息描述: 捐赠福位ID(NOT NULL)
        /// </summary>
        public static readonly string s_CellID =  "bf_purchaselog┋CellID┋System.Int64";
        /// <summary>
        /// 信息描述: 捐赠人基本信息ID(NOT NULL)
        /// </summary>
        public static readonly string s_PurchaserBasicID =  "bf_purchaselog┋PurchaserBasicID┋System.Int64";
        /// <summary>
        /// 信息描述: 推荐居士基本信息ID(NOT NULL)
        /// </summary>
        public static readonly string s_IntroducerBasicID =  "bf_purchaselog┋IntroducerBasicID┋System.Int64";
        /// <summary>
        /// 信息描述: 是否已付款
        /// </summary>
        public static readonly string s_IsPayed =  "bf_purchaselog┋IsPayed┋System.Byte[]";
        /// <summary>
        /// 信息描述: 付款截止时间
        /// </summary>
        public static readonly string s_PayDateDue =  "bf_purchaselog┋PayDateDue┋System.DateTime";
        /// <summary>
        /// 信息描述: 功德凭证编号
        /// </summary>
        public static readonly string s_GongDeCertNo =  "bf_purchaselog┋GongDeCertNo┋System.String";
        /// <summary>
        /// 信息描述: 捐赠金额
        /// </summary>
        public static readonly string s_PayedPrice =  "bf_purchaselog┋PayedPrice┋System.Single";
        /// <summary>
        /// 信息描述: 预定时间
        /// </summary>
        public static readonly string s_ScheduleDay =  "bf_purchaselog┋ScheduleDay┋System.DateTime";
        /// <summary>
        /// 信息描述: 付款时间
        /// </summary>
        public static readonly string s_PurchaseDay =  "bf_purchaselog┋PurchaseDay┋System.DateTime";
        /// <summary>
        /// 信息描述: 经办管理员ID(NOT NULL)
        /// </summary>
        public static readonly string s_OperatorID =  "bf_purchaselog┋OperatorID┋System.Int64";
        /// <summary>
        /// 信息描述: 备注
        /// </summary>
        public static readonly string s_Comment =  "bf_purchaselog┋Comment┋System.String";
        #endregion
	}

    /// <summary>
    /// 购买或者捐赠或者预定记录表实体集
    /// </summary>
    [Serializable]
    public class bf_purchaselogS : CollectionBase
    {
        #region 构造函数
        /// <summary>
        /// 购买或者捐赠或者预定记录表实体集
        /// </summary>
        public bf_purchaselogS(){}
        #endregion

        #region 属性方法
        /// <summary>
        /// 购买或者捐赠或者预定记录表集合 增加方法
        /// </summary>
        public void Add(bf_purchaselog entity)
        {
            this.List.Add(entity);
        }
        /// <summary>
        /// 购买或者捐赠或者预定记录表集合 索引
        /// </summary>
        public bf_purchaselog this[int index]
        {
            get { return (bf_purchaselog)this.List[index]; }
            set { this.List[index] = value; }
        }
        #endregion
    }
}
