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

        #region 公共静态只读属性
        /// <summary>
        /// 表名 表原信息描述: 用户权限关系表
        /// </summary>
        public static readonly string s_TableName =  "af_user_auth";
        /// <summary>
        /// 信息描述: ID(NOT NULL)
        /// </summary>
        public static readonly string s_ID =  "af_user_auth┋ID┋System.Int64";
        /// <summary>
        /// 信息描述: 用户ID(NOT NULL)
        /// </summary>
        public static readonly string s_UserID =  "af_user_auth┋UserID┋System.Int64";
        /// <summary>
        /// 信息描述: 权限ID(NOT NULL)
        /// </summary>
        public static readonly string s_AuthID =  "af_user_auth┋AuthID┋System.Int64";
        #endregion
	}

    /// <summary>
    /// 用户权限关系表实体集
    /// </summary>
    [Serializable]
    public class af_user_authS : CollectionBase
    {
        #region 构造函数
        /// <summary>
        /// 用户权限关系表实体集
        /// </summary>
        public af_user_authS(){}
        #endregion

        #region 属性方法
        /// <summary>
        /// 用户权限关系表集合 增加方法
        /// </summary>
        public void Add(UserAuth entity)
        {
            this.List.Add(entity);
        }
        /// <summary>
        /// 用户权限关系表集合 索引
        /// </summary>
        public UserAuth this[int index]
        {
            get { return (UserAuth)this.List[index]; }
            set { this.List[index] = value; }
        }
        #endregion
    }
}
