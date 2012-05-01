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
    [Description("Primary:ID;TableName:am_department")]
    [Serializable]
	public partial class Department
	{
        #region 构造函数
        /// <summary>
        /// 实体 组织结构表
        /// </summary>
        public Department(){}
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
	}
}
