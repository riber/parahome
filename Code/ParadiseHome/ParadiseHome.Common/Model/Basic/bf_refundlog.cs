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
	[Description("Primary:ID")]
    [Serializable]
	public partial class bf_refundlog
	{
        #region 构造函数
        /// <summary>
        /// 实体 退款记录表
        /// </summary>
        public bf_refundlog(){}
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

        #region 公共静态只读属性
        /// <summary>
        /// 表名 表原信息描述: 退款记录表
        /// </summary>
        public static readonly string s_TableName =  "bf_refundlog";
        /// <summary>
        /// 信息描述: ID(NOT NULL)
        /// </summary>
        public static readonly string s_ID =  "bf_refundlog┋ID┋System.Int64";
        /// <summary>
        /// 信息描述: 关联的捐赠记录表ID(NOT NULL)
        /// </summary>
        public static readonly string s_PurchaseLogID =  "bf_refundlog┋PurchaseLogID┋System.Int64";
        /// <summary>
        /// 信息描述: 退款时间
        /// </summary>
        public static readonly string s_RefundTime =  "bf_refundlog┋RefundTime┋System.DateTime";
        /// <summary>
        /// 信息描述: 退款金额
        /// </summary>
        public static readonly string s_RefundPrice =  "bf_refundlog┋RefundPrice┋System.Single";
        /// <summary>
        /// 信息描述: 经办管理员ID(NOT NULL)
        /// </summary>
        public static readonly string s_OperatorID =  "bf_refundlog┋OperatorID┋System.Int64";
        /// <summary>
        /// 信息描述: 备注
        /// </summary>
        public static readonly string s_Comment =  "bf_refundlog┋Comment┋System.String";
        #endregion
	}

    /// <summary>
    /// 退款记录表实体集
    /// </summary>
    [Serializable]
    public class bf_refundlogS : CollectionBase
    {
        #region 构造函数
        /// <summary>
        /// 退款记录表实体集
        /// </summary>
        public bf_refundlogS(){}
        #endregion

        #region 属性方法
        /// <summary>
        /// 退款记录表集合 增加方法
        /// </summary>
        public void Add(bf_refundlog entity)
        {
            this.List.Add(entity);
        }
        /// <summary>
        /// 退款记录表集合 索引
        /// </summary>
        public bf_refundlog this[int index]
        {
            get { return (bf_refundlog)this.List[index]; }
            set { this.List[index] = value; }
        }
        #endregion
    }
}
