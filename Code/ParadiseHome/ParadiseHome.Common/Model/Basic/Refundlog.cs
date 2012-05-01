/******************************************
* 模块名称：实体 退款记录表
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
	/// 实体 退款记录表
	/// </summary>
    [Description("Primary:ID;TableName:bf_refundlog")]
    [Serializable]
	public partial class Refundlog
	{
        #region 构造函数
        /// <summary>
        /// 实体 退款记录表
        /// </summary>
        public Refundlog(){}
        #endregion

        #region 私有变量
        private long _id = long.MinValue;
        private long _purchaselogid = long.MinValue;
        private DateTime _refundtime = DateTime.MinValue;
        private float _refundprice = float.MinValue;
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
        /// 关联的捐赠记录表ID(NOT NULL)
        /// </summary>
        public long PurchaseLogID
        {
            set{ _purchaselogid=value;}
            get{return _purchaselogid;}
        }
        /// <summary>
        /// 退款时间
        /// </summary>
        public DateTime RefundTime
        {
            set{ _refundtime=value;}
            get{return _refundtime;}
        }
        /// <summary>
        /// 退款金额
        /// </summary>
        public float RefundPrice
        {
            set{ _refundprice=value;}
            get{return _refundprice;}
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
	}
}
