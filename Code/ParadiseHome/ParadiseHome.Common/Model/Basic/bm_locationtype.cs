/******************************************
* 模块名称：实体 位置类型信息表
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
	/// 实体 位置类型信息表
	/// </summary>
	[Description("Primary:ID")]
    [Serializable]
	public partial class bm_locationtype
	{
        #region 构造函数
        /// <summary>
        /// 实体 位置类型信息表
        /// </summary>
        public bm_locationtype(){}
        #endregion

        #region 私有变量
        private long _id = long.MinValue;
        private long _locationdepth = long.MinValue;
        private string _typename = null;
        private string _comment = null;
        private string _locationtypecol = null;
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
        /// 位置深度序号(NOT NULL)
        /// </summary>
        public long LocationDepth
        {
            set{ _locationdepth=value;}
            get{return _locationdepth;}
        }
        /// <summary>
        /// 位置类型名称(NOT NULL)
        /// </summary>
        public string TypeName
        {
            set{ _typename=value;}
            get{return _typename;}
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string Comment
        {
            set{ _comment=value;}
            get{return _comment;}
        }
        /// <summary>
        /// locationtypecol
        /// </summary>
        public string locationtypecol
        {
            set{ _locationtypecol=value;}
            get{return _locationtypecol;}
        }
        #endregion

        #region 公共静态只读属性
        /// <summary>
        /// 表名 表原信息描述: 位置类型信息表
        /// </summary>
        public static readonly string s_TableName =  "bm_locationtype";
        /// <summary>
        /// 信息描述: ID(NOT NULL)
        /// </summary>
        public static readonly string s_ID =  "bm_locationtype┋ID┋System.Int64";
        /// <summary>
        /// 信息描述: 位置深度序号(NOT NULL)
        /// </summary>
        public static readonly string s_LocationDepth =  "bm_locationtype┋LocationDepth┋System.Int64";
        /// <summary>
        /// 信息描述: 位置类型名称(NOT NULL)
        /// </summary>
        public static readonly string s_TypeName =  "bm_locationtype┋TypeName┋System.String";
        /// <summary>
        /// 信息描述: 备注
        /// </summary>
        public static readonly string s_Comment =  "bm_locationtype┋Comment┋System.String";
        /// <summary>
        /// 信息描述: locationtypecol
        /// </summary>
        public static readonly string s_locationtypecol =  "bm_locationtype┋locationtypecol┋System.String";
        #endregion
	}

    /// <summary>
    /// 位置类型信息表实体集
    /// </summary>
    [Serializable]
    public class bm_locationtypeS : CollectionBase
    {
        #region 构造函数
        /// <summary>
        /// 位置类型信息表实体集
        /// </summary>
        public bm_locationtypeS(){}
        #endregion

        #region 属性方法
        /// <summary>
        /// 位置类型信息表集合 增加方法
        /// </summary>
        public void Add(bm_locationtype entity)
        {
            this.List.Add(entity);
        }
        /// <summary>
        /// 位置类型信息表集合 索引
        /// </summary>
        public bm_locationtype this[int index]
        {
            get { return (bm_locationtype)this.List[index]; }
            set { this.List[index] = value; }
        }
        #endregion
    }
}
