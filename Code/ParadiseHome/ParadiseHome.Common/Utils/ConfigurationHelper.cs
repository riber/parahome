using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            _sqlDictionary = CreateSQLDictionary("SQLConfig.xml");
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
        private Dictionary<string, string> CreateSQLDictionary(string configFileName)
        {
            
        }
        #endregion
    }

}
