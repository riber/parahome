/******************************************
* 模块名称：实体 系统配置表
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
	/// 实体 系统配置表
	/// </summary>
    [Description("Primary:ID;TableName:am_sysconfig")]
    [Serializable]
	public partial class Sysconfig
	{
        #region 构造函数
        /// <summary>
        /// 实体 系统配置表
        /// </summary>
        public Sysconfig(){}
        #endregion

        #region 私有变量
        private long _id = long.MinValue;
        private string _key = null;
        private string _value = null;
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
        /// 参数名(NOT NULL)
        /// </summary>
        public string Key
        {
            set{ _key=value;}
            get{return _key;}
        }
        /// <summary>
        /// 参数值
        /// </summary>
        public string Value
        {
            set{ _value=value;}
            get{return _value;}
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
