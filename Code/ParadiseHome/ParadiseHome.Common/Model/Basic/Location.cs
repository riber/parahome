/******************************************
* 模块名称：实体 位置结点信息表
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
	/// 实体 位置结点信息表
	/// </summary>
    [Description("Primary:ID;TableName:bm_location")]
    [Serializable]
	public partial class Location
	{
        #region 构造函数
        /// <summary>
        /// 实体 位置结点信息表
        /// </summary>
        public Location(){}
        #endregion

        #region 私有变量
        private long _id = long.MinValue;
        private long _locationtypeid = long.MinValue;
        private long _parentlocationid = long.MinValue;
        private string _name = null;
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
        /// 位置类型ID(NOT NULL)
        /// </summary>
        public long LocationTypeID
        {
            set{ _locationtypeid=value;}
            get{return _locationtypeid;}
        }
        /// <summary>
        /// 父节点ID(NOT NULL)
        /// </summary>
        public long ParentLocationID
        {
            set{ _parentlocationid=value;}
            get{return _parentlocationid;}
        }
        /// <summary>
        /// 位置节点名称
        /// </summary>
        public string Name
        {
            set{ _name=value;}
            get{return _name;}
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
