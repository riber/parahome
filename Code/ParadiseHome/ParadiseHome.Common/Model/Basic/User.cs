﻿/******************************************
* 模块名称：实体 用户信息表
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
	/// 实体 用户信息表
	/// </summary>
    [Description("Primary:ID;TableName:am_user")]
    [Serializable]
	public partial class User
	{
        #region 构造函数
        /// <summary>
        /// 实体 用户信息表
        /// </summary>
        public User(){}
        #endregion

        #region 私有变量
        private long _id = long.MinValue;
        private long _departmentid = long.MinValue;
        private long _basicinfoid = long.MinValue;
        private string _username = null;
        private string _password = null;
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
        /// 组织ID(NOT NULL)
        /// </summary>
        public long DepartmentID
        {
            set{ _departmentid=value;}
            get{return _departmentid;}
        }
        /// <summary>
        /// 基本信息表ID(NOT NULL)
        /// </summary>
        public long BasicInfoID
        {
            set{ _basicinfoid=value;}
            get{return _basicinfoid;}
        }
        /// <summary>
        /// 用户名(NOT NULL)
        /// </summary>
        public string UserName
        {
            set{ _username=value;}
            get{return _username;}
        }
        /// <summary>
        /// 密码(NOT NULL)
        /// </summary>
        public string Password
        {
            set{ _password=value;}
            get{return _password;}
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
