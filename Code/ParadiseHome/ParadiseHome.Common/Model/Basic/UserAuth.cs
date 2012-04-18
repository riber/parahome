/******************************************
* 模块名称：实体 用户权限关系表
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
	/// 实体 用户权限关系表
	/// </summary>
	[Description("Primary:ID")]
    [Serializable]
	public partial class UserAuth
	{
        #region 构造函数
        /// <summary>
        /// 实体 用户权限关系表
        /// </summary>
        public UserAuth(){}
        #endregion

        #region 私有变量
        private long _id = long.MinValue;
        private long _userid = long.MinValue;
        private long _authid = long.MinValue;
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
        /// 用户ID(NOT NULL)
        /// </summary>
        public long UserID
        {
            set{ _userid=value;}
            get{return _userid;}
        }
        /// <summary>
        /// 权限ID(NOT NULL)
        /// </summary>
        public long AuthID
        {
            set{ _authid=value;}
            get{return _authid;}
        }
        #endregion
	}
}
