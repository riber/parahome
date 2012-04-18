/******************************************
* 模块名称：实体 组织结构表
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
	/// 实体 组织结构表
	/// </summary>
	[Description("Primary:ID")]
    [Serializable]
	public partial class am_department
	{
        #region 构造函数
        /// <summary>
        /// 实体 组织结构表
        /// </summary>
        public am_department(){}
        #endregion

        #region 私有变量
        private long _id = long.MinValue;
        private long _parentid = long.MinValue;
        private string _name = null;
        private string _managername = null;
        private string _managerphone = null;
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
        /// 父节点ID(NOT NULL)
        /// </summary>
        public long ParentID
        {
            set{ _parentid=value;}
            get{return _parentid;}
        }
        /// <summary>
        /// 名称(NOT NULL)
        /// </summary>
        public string Name
        {
            set{ _name=value;}
            get{return _name;}
        }
        /// <summary>
        /// 负责人
        /// </summary>
        public string ManagerName
        {
            set{ _managername=value;}
            get{return _managername;}
        }
        /// <summary>
        /// 负责人电话
        /// </summary>
        public string ManagerPhone
        {
            set{ _managerphone=value;}
            get{return _managerphone;}
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
        /// 表名 表原信息描述: 组织结构表
        /// </summary>
        public static readonly string s_TableName =  "am_department";
        /// <summary>
        /// 信息描述: ID(NOT NULL)
        /// </summary>
        public static readonly string s_ID =  "am_department┋ID┋System.Int64";
        /// <summary>
        /// 信息描述: 父节点ID(NOT NULL)
        /// </summary>
        public static readonly string s_ParentID =  "am_department┋ParentID┋System.Int64";
        /// <summary>
        /// 信息描述: 名称(NOT NULL)
        /// </summary>
        public static readonly string s_Name =  "am_department┋Name┋System.String";
        /// <summary>
        /// 信息描述: 负责人
        /// </summary>
        public static readonly string s_ManagerName =  "am_department┋ManagerName┋System.String";
        /// <summary>
        /// 信息描述: 负责人电话
        /// </summary>
        public static readonly string s_ManagerPhone =  "am_department┋ManagerPhone┋System.String";
        /// <summary>
        /// 信息描述: 备注
        /// </summary>
        public static readonly string s_Comment =  "am_department┋Comment┋System.String";
        #endregion
	}

    /// <summary>
    /// 组织结构表实体集
    /// </summary>
    [Serializable]
    public class am_departmentS : CollectionBase
    {
        #region 构造函数
        /// <summary>
        /// 组织结构表实体集
        /// </summary>
        public am_departmentS(){}
        #endregion

        #region 属性方法
        /// <summary>
        /// 组织结构表集合 增加方法
        /// </summary>
        public void Add(am_department entity)
        {
            this.List.Add(entity);
        }
        /// <summary>
        /// 组织结构表集合 索引
        /// </summary>
        public am_department this[int index]
        {
            get { return (am_department)this.List[index]; }
            set { this.List[index] = value; }
        }
        #endregion
    }
}
