/******************************************
* 模块名称：实体 购买者或福位捐献者
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
	/// 实体 购买者或福位捐献者
	/// </summary>
    [Description("Primary:ID;TableName:bm_purchaser")]
    [Serializable]
	public partial class Purchaser
	{
        #region 构造函数
        /// <summary>
        /// 实体 购买者或福位捐献者
        /// </summary>
        public Purchaser(){}
        #endregion

        #region 私有变量
        private long _id = long.MinValue;
        private long _basicinfoid = long.MinValue;
        private string _contactname = null;
        private string _contactphone = null;
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
        /// 应急联系人姓名
        /// </summary>
        public string ContactName
        {
            set{ _contactname=value;}
            get{return _contactname;}
        }
        /// <summary>
        /// 应急联系人电话
        /// </summary>
        public string ContactPhone
        {
            set{ _contactphone=value;}
            get{return _contactphone;}
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
