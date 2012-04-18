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
	[Description("Primary:ID")]
    [Serializable]
	public partial class am_sysconfig
	{
        #region 构造函数
        /// <summary>
        /// 实体 系统配置表
        /// </summary>
        public am_sysconfig(){}
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

        #region 公共静态只读属性
        /// <summary>
        /// 表名 表原信息描述: 系统配置表
        /// </summary>
        public static readonly string s_TableName =  "am_sysconfig";
        /// <summary>
        /// 信息描述: ID(NOT NULL)
        /// </summary>
        public static readonly string s_ID =  "am_sysconfig┋ID┋System.Int64";
        /// <summary>
        /// 信息描述: 参数名(NOT NULL)
        /// </summary>
        public static readonly string s_Key =  "am_sysconfig┋Key┋System.String";
        /// <summary>
        /// 信息描述: 参数值
        /// </summary>
        public static readonly string s_Value =  "am_sysconfig┋Value┋System.String";
        /// <summary>
        /// 信息描述: 备注
        /// </summary>
        public static readonly string s_Comment =  "am_sysconfig┋Comment┋System.String";
        #endregion
	}

    /// <summary>
    /// 系统配置表实体集
    /// </summary>
    [Serializable]
    public class am_sysconfigS : CollectionBase
    {
        #region 构造函数
        /// <summary>
        /// 系统配置表实体集
        /// </summary>
        public am_sysconfigS(){}
        #endregion

        #region 属性方法
        /// <summary>
        /// 系统配置表集合 增加方法
        /// </summary>
        public void Add(am_sysconfig entity)
        {
            this.List.Add(entity);
        }
        /// <summary>
        /// 系统配置表集合 索引
        /// </summary>
        public am_sysconfig this[int index]
        {
            get { return (am_sysconfig)this.List[index]; }
            set { this.List[index] = value; }
        }
        #endregion
    }
}
