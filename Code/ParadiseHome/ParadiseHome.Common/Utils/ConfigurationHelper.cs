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

        private string _dbConnectingString;

        public string DBConnectingString
        {
            get
            {
                if (_dbConnectingString == null)
                {
                    // 打桩，从配置文件中读取
                    _dbConnectingString = "Server=127.0.0.1;Database=paradisehomedb;Uid=root;Pwd=9281107;";
                }
                return _dbConnectingString;
            }
        }
    }

}
