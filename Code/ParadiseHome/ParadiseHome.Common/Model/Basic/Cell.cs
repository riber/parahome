/******************************************
* 模块名称：实体 福位或者住所
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
	/// 实体 福位或者住所
	/// </summary>
	[Description("Primary:ID")]
    [Serializable]
	public partial class Cell
	{
        #region 构造函数
        /// <summary>
        /// 实体 福位或者住所
        /// </summary>
        public Cell(){}
        #endregion

        #region 私有变量
        private long _id = long.MinValue;
        private long _locationid = long.MinValue;
        private string _celltag = null;
        private int _x = int.MinValue;
        private int _y = int.MinValue;
        private int _z = int.MinValue;
        private float _currentprice = float.MinValue;
        private string _state = null;
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
        /// 位置ID(NOT NULL)
        /// </summary>
        public long LocationID
        {
            set{ _locationid=value;}
            get{return _locationid;}
        }
        /// <summary>
        /// 福位标识符
        /// </summary>
        public string CellTag
        {
            set{ _celltag=value;}
            get{return _celltag;}
        }
        public int X
        {
            get { return _x; }
            set { _x = value; }
        }
        public int Y
        {
            get { return _y; }
            set { _y = value; }
        }
        public int Z
        {
            get { return _z; }
            set { _z = value; }
        }
        /// <summary>
        /// 当前价格
        /// </summary>
        public float CurrentPrice
        {
            set{ _currentprice=value;}
            get{return _currentprice;}
        }
        /// <summary>
        /// 福位所处的状态
        /// </summary>
        public string State
        {
            set{ _state=value;}
            get{return _state;}
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
