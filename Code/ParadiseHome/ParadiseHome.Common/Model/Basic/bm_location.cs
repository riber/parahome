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
	[Description("Primary:ID")]
    [Serializable]
	public partial class bm_location
	{
        #region 构造函数
        /// <summary>
        /// 实体 位置结点信息表
        /// </summary>
        public bm_location(){}
        #endregion

        #region 私有变量
        private long _id = long.MinValue;
        private long _locationtypeid = long.MinValue;
        private long _parentlocationid = long.MinValue;
        private string _name = null;
        private byte[] _isnumericaltype = null;
        private Int32 _locationvalue = Int32.MinValue;
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
        /// 是否为数值位置类型
        /// </summary>
        public byte[] IsNumericalType
        {
            set{ _isnumericaltype=value;}
            get{return _isnumericaltype;}
        }
        /// <summary>
        /// 位置数值
        /// </summary>
        public Int32 LocationValue
        {
            set{ _locationvalue=value;}
            get{return _locationvalue;}
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
        /// 表名 表原信息描述: 位置结点信息表
        /// </summary>
        public static readonly string s_TableName =  "bm_location";
        /// <summary>
        /// 信息描述: ID(NOT NULL)
        /// </summary>
        public static readonly string s_ID =  "bm_location┋ID┋System.Int64";
        /// <summary>
        /// 信息描述: 位置类型ID(NOT NULL)
        /// </summary>
        public static readonly string s_LocationTypeID =  "bm_location┋LocationTypeID┋System.Int64";
        /// <summary>
        /// 信息描述: 父节点ID(NOT NULL)
        /// </summary>
        public static readonly string s_ParentLocationID =  "bm_location┋ParentLocationID┋System.Int64";
        /// <summary>
        /// 信息描述: 位置节点名称
        /// </summary>
        public static readonly string s_Name =  "bm_location┋Name┋System.String";
        /// <summary>
        /// 信息描述: 是否为数值位置类型
        /// </summary>
        public static readonly string s_IsNumericalType =  "bm_location┋IsNumericalType┋System.Byte[]";
        /// <summary>
        /// 信息描述: 位置数值
        /// </summary>
        public static readonly string s_LocationValue =  "bm_location┋LocationValue┋System.Int32";
        /// <summary>
        /// 信息描述: 备注
        /// </summary>
        public static readonly string s_Comment =  "bm_location┋Comment┋System.String";
        #endregion
	}

    /// <summary>
    /// 位置结点信息表实体集
    /// </summary>
    [Serializable]
    public class bm_locationS : CollectionBase
    {
        #region 构造函数
        /// <summary>
        /// 位置结点信息表实体集
        /// </summary>
        public bm_locationS(){}
        #endregion

        #region 属性方法
        /// <summary>
        /// 位置结点信息表集合 增加方法
        /// </summary>
        public void Add(bm_location entity)
        {
            this.List.Add(entity);
        }
        /// <summary>
        /// 位置结点信息表集合 索引
        /// </summary>
        public bm_location this[int index]
        {
            get { return (bm_location)this.List[index]; }
            set { this.List[index] = value; }
        }
        #endregion
    }
}
