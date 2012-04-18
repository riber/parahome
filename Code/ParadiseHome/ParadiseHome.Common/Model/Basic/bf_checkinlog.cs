/******************************************
* 模块名称：实体 入住记录表
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
	/// 实体 入住记录表
	/// </summary>
	[Description("Primary:ID")]
    [Serializable]
	public partial class bf_checkinlog
	{
        #region 构造函数
        /// <summary>
        /// 实体 入住记录表
        /// </summary>
        public bf_checkinlog(){}
        #endregion

        #region 私有变量
        private long _id = long.MinValue;
        private long _basicinfoid = long.MinValue;
        private long _cellid = long.MinValue;
        private DateTime _checkindueday = DateTime.MinValue;
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
        /// 入住者基本信息ID(NOT NULL)
        /// </summary>
        public long BasicInfoID
        {
            set{ _basicinfoid=value;}
            get{return _basicinfoid;}
        }
        /// <summary>
        /// 入住福位ID(NOT NULL)
        /// </summary>
        public long CellID
        {
            set{ _cellid=value;}
            get{return _cellid;}
        }
        /// <summary>
        /// 入住截止时间
        /// </summary>
        public DateTime CheckInDueDay
        {
            set{ _checkindueday=value;}
            get{return _checkindueday;}
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
        /// 表名 表原信息描述: 入住记录表
        /// </summary>
        public static readonly string s_TableName =  "bf_checkinlog";
        /// <summary>
        /// 信息描述: ID(NOT NULL)
        /// </summary>
        public static readonly string s_ID =  "bf_checkinlog┋ID┋System.Int64";
        /// <summary>
        /// 信息描述: 入住者基本信息ID(NOT NULL)
        /// </summary>
        public static readonly string s_BasicInfoID =  "bf_checkinlog┋BasicInfoID┋System.Int64";
        /// <summary>
        /// 信息描述: 入住福位ID(NOT NULL)
        /// </summary>
        public static readonly string s_CellID =  "bf_checkinlog┋CellID┋System.Int64";
        /// <summary>
        /// 信息描述: 入住截止时间
        /// </summary>
        public static readonly string s_CheckInDueDay =  "bf_checkinlog┋CheckInDueDay┋System.DateTime";
        /// <summary>
        /// 信息描述: 经办管理员ID(NOT NULL)
        /// </summary>
        public static readonly string s_OperatorID =  "bf_checkinlog┋OperatorID┋System.Int64";
        /// <summary>
        /// 信息描述: 备注
        /// </summary>
        public static readonly string s_Comment =  "bf_checkinlog┋Comment┋System.String";
        #endregion
	}

    /// <summary>
    /// 入住记录表实体集
    /// </summary>
    [Serializable]
    public class bf_checkinlogS : CollectionBase
    {
        #region 构造函数
        /// <summary>
        /// 入住记录表实体集
        /// </summary>
        public bf_checkinlogS(){}
        #endregion

        #region 属性方法
        /// <summary>
        /// 入住记录表集合 增加方法
        /// </summary>
        public void Add(bf_checkinlog entity)
        {
            this.List.Add(entity);
        }
        /// <summary>
        /// 入住记录表集合 索引
        /// </summary>
        public bf_checkinlog this[int index]
        {
            get { return (bf_checkinlog)this.List[index]; }
            set { this.List[index] = value; }
        }
        #endregion
    }
}
