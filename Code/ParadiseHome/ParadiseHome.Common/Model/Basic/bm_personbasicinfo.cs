/******************************************
* 模块名称：实体 人员基本信息
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
	/// 实体 人员基本信息
	/// </summary>
	[Description("Primary:ID")]
    [Serializable]
	public partial class bm_personbasicinfo
	{
        #region 构造函数
        /// <summary>
        /// 实体 人员基本信息
        /// </summary>
        public bm_personbasicinfo(){}
        #endregion

        #region 私有变量
        private long _id = long.MinValue;
        private string _name = null;
        private string _sex = null;
        private string _nationality = null;
        private string _origin = null;
        private string _address = null;
        private string _idnumber = null;
        private DateTime _birthday = DateTime.MinValue;
        private string _contactnumber = null;
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
        /// 姓名(NOT NULL)
        /// </summary>
        public string Name
        {
            set{ _name=value;}
            get{return _name;}
        }
        /// <summary>
        /// 性别
        /// </summary>
        public string Sex
        {
            set{ _sex=value;}
            get{return _sex;}
        }
        /// <summary>
        /// 民族
        /// </summary>
        public string Nationality
        {
            set{ _nationality=value;}
            get{return _nationality;}
        }
        /// <summary>
        /// 籍贯
        /// </summary>
        public string Origin
        {
            set{ _origin=value;}
            get{return _origin;}
        }
        /// <summary>
        /// 家庭地址
        /// </summary>
        public string Address
        {
            set{ _address=value;}
            get{return _address;}
        }
        /// <summary>
        /// 身份证号
        /// </summary>
        public string IDNumber
        {
            set{ _idnumber=value;}
            get{return _idnumber;}
        }
        /// <summary>
        /// 出生日期
        /// </summary>
        public DateTime BirthDay
        {
            set{ _birthday=value;}
            get{return _birthday;}
        }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string ContactNumber
        {
            set{ _contactnumber=value;}
            get{return _contactnumber;}
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
        /// 表名 表原信息描述: 人员基本信息
        /// </summary>
        public static readonly string s_TableName =  "bm_personbasicinfo";
        /// <summary>
        /// 信息描述: ID(NOT NULL)
        /// </summary>
        public static readonly string s_ID =  "bm_personbasicinfo┋ID┋System.Int64";
        /// <summary>
        /// 信息描述: 姓名(NOT NULL)
        /// </summary>
        public static readonly string s_Name =  "bm_personbasicinfo┋Name┋System.String";
        /// <summary>
        /// 信息描述: 性别
        /// </summary>
        public static readonly string s_Sex =  "bm_personbasicinfo┋Sex┋System.String";
        /// <summary>
        /// 信息描述: 民族
        /// </summary>
        public static readonly string s_Nationality =  "bm_personbasicinfo┋Nationality┋System.String";
        /// <summary>
        /// 信息描述: 籍贯
        /// </summary>
        public static readonly string s_Origin =  "bm_personbasicinfo┋Origin┋System.String";
        /// <summary>
        /// 信息描述: 家庭地址
        /// </summary>
        public static readonly string s_Address =  "bm_personbasicinfo┋Address┋System.String";
        /// <summary>
        /// 信息描述: 身份证号
        /// </summary>
        public static readonly string s_IDNumber =  "bm_personbasicinfo┋IDNumber┋System.String";
        /// <summary>
        /// 信息描述: 出生日期
        /// </summary>
        public static readonly string s_BirthDay =  "bm_personbasicinfo┋BirthDay┋System.DateTime";
        /// <summary>
        /// 信息描述: 联系电话
        /// </summary>
        public static readonly string s_ContactNumber =  "bm_personbasicinfo┋ContactNumber┋System.String";
        /// <summary>
        /// 信息描述: 备注
        /// </summary>
        public static readonly string s_Comment =  "bm_personbasicinfo┋Comment┋System.String";
        #endregion
	}

    /// <summary>
    /// 人员基本信息实体集
    /// </summary>
    [Serializable]
    public class bm_personbasicinfoS : CollectionBase
    {
        #region 构造函数
        /// <summary>
        /// 人员基本信息实体集
        /// </summary>
        public bm_personbasicinfoS(){}
        #endregion

        #region 属性方法
        /// <summary>
        /// 人员基本信息集合 增加方法
        /// </summary>
        public void Add(bm_personbasicinfo entity)
        {
            this.List.Add(entity);
        }
        /// <summary>
        /// 人员基本信息集合 索引
        /// </summary>
        public bm_personbasicinfo this[int index]
        {
            get { return (bm_personbasicinfo)this.List[index]; }
            set { this.List[index] = value; }
        }
        #endregion
    }
}
