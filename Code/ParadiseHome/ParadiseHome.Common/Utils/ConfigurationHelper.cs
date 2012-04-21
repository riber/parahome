using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Reflection;

namespace ParadiseHome.Common.Utils
{
    /// <summary>
    /// 配置文件帮助类
    /// </summary>
    public class ConfigurationHelper
    {
        #region 单实例
        // 主动单实例（饿汉模式）
        private static readonly ConfigurationHelper _instance = new ConfigurationHelper();

        /// <summary>
        /// 单实例对象
        /// </summary>
        public static ConfigurationHelper Instance
        {
            get
            {
                return _instance;
            }
        }
        #endregion

        #region 构造函数
        private ConfigurationHelper()
        {
            // 构造时一次性初始化
            // 打桩，SQL配置文件地址应该从一个更基础的配置文件来读取
            CreateSQLDictionary(@"SQLConfig.xml");
        }
        #endregion

        #region 成员
        private string _dbConnectingString;
        private Dictionary<string, string> _sqlDictionary;
        #endregion

        #region 属性

        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        public string DBConnectingString
        {
            get
            {
                if (_dbConnectingString == null)
                {
                    // 打桩，从配置文件中读取加密字串并解密
                    _dbConnectingString = "Server=127.0.0.1;Database=paradisehomedb;Uid=root;Pwd=9281107;";
                }
                return _dbConnectingString;
            }
        }

        /// <summary>
        /// SQL语句表
        /// </summary>
        public Dictionary<string, string> SqlDictionary
        {
            get { return _sqlDictionary; }
            set { _sqlDictionary = value; }
        }

        #endregion

        #region 私有方法
        private void CreateSQLDictionary(string configFileName)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(configFileName);
                XmlNodeList nodeList = doc.SelectNodes("/root/item");
                _sqlDictionary = new Dictionary<string, string>();
                foreach (XmlNode node in nodeList)
                {
                    _sqlDictionary.Add(node.Attributes["key"].Value, node.Attributes["value"].Value);
                }
            }
            catch
            {
            	
            }
        }
        #endregion

        #region 公共方法
        /// <summary>
        /// 根据配置创建新的SQLExecutor
        /// </summary>
        /// <returns>相应的SQLExecutor对象</returns>
        public object CreateNewSQLExecutor()
        {
            // 打桩，数据库类型应当去配置文件中读取
            string DBType = "MySQL";
            // 打桩，通用的命名空间前缀也应当去配置文件中读取
            string NameSpacePrefix = "ParadiseHome.DAL";
            // 如果所有运行dll都在同一目录下面则可以直接由上述两个属性生成
            string DllFileName = NameSpacePrefix + "." + DBType + ".dll";

            Object obj = null;
            try
            {
                Assembly asm = Assembly.LoadFile(DllFileName);
                obj = asm.CreateInstance(NameSpacePrefix + "." + DBType
                    + ".SQLExecutor", true);
            }
            catch
            {
            	
            }
            return obj;
        }
        #endregion
    }

}
