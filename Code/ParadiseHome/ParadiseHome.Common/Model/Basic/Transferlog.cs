/******************************************
* 模块名称：实体 转赠记录表
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
	/// 实体 转赠记录表
	/// </summary>
	[Description("Primary:ID")]
    [Serializable]
	public partial class Transferlog
	{
        #region 构造函数
        /// <summary>
        /// 实体 转赠记录表
        /// </summary>
        public Transferlog(){}
        #endregion

        #region 私有变量
        private long _id = long.MinValue;
        private long _cellid = long.MinValue;
        private long _frombasicid = long.MinValue;
        private long _tobasicid = long.MinValue;
        private DateTime _occurtime = DateTime.MinValue;
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
        /// 转赠福位ID(NOT NULL)
        /// </summary>
        public long CellID
        {
            set{ _cellid=value;}
            get{return _cellid;}
        }
        /// <summary>
        /// 转赠人基本信息ID(NOT NULL)
        /// </summary>
        public long FromBasicID
        {
            set{ _frombasicid=value;}
            get{return _frombasicid;}
        }
        /// <summary>
        /// 受赠人基本信息ID(NOT NULL)
        /// </summary>
        public long ToBasicID
        {
            set{ _tobasicid=value;}
            get{return _tobasicid;}
        }
        /// <summary>
        /// 转赠时间
        /// </summary>
        public DateTime OccurTime
        {
            set{ _occurtime=value;}
            get{return _occurtime;}
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
