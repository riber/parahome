using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Reflection;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace ParadiseHome.Common.Utils
{
    /// <summary>
    /// 配置文件帮助类
    /// </summary>
    public class ConfigurationHelper
    {
        #region 成员，需要先初始化的静态成员必须放在单实例对象前面
        private string _dbConnectingString;
        private Dictionary<string, string> _sqlDictionary;
        //用户自定义配置的内容存放类对象
        private CustomConfig _customCfg;
        private static readonly string CustomCfgBinaryFileName = "CustomConfig.dat";
        #endregion

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

            ReadCustomConfig();
        }
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
                    _dbConnectingString = "Server=127.0.0.1;Database=paradisehomedb;Uid=root;Pwd=sa;";
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

        /// <summary>
        /// 获取或设置默认单元格背景颜色（未售福位）
        /// </summary>
        public Color DefaultCellBgColor
        {
            get
            {
                return _customCfg.defaultCellBgColor;
            }
            set
            {
                _customCfg.defaultCellBgColor = value;
            }
        }

        /// <summary>
        /// 获取或设置已定福位单元格背景颜色
        /// </summary>
        public Color BookedCellBgColor
        {
            get
            {
                return (_customCfg.bookedCellBgColor == Color.Empty) ? Color.Yellow : _customCfg.bookedCellBgColor;
            }
            set
            {
                _customCfg.bookedCellBgColor = value;
            }
        }

        /// <summary>
        /// 获取或设置已售福位单元格背景颜色
        /// </summary>
        public Color SoldCellBgColor
        {
            get
            {
                return (_customCfg.soldCellBgColor == Color.Empty) ? Color.Red : _customCfg.soldCellBgColor;
            }
            set
            {
                _customCfg.soldCellBgColor = value;
            }
        }
        #endregion

        #region 私有方法
        private void CreateSQLDictionary(string configFileName)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), configFileName));
                XmlNodeList nodeList = doc.SelectNodes("/root/item");
                _sqlDictionary = new Dictionary<string, string>();
                foreach (XmlNode node in nodeList)
                {
                    _sqlDictionary.Add(node.Attributes["key"].Value, node.Attributes["value"].Value);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "错误");
            }
        }
        
        /// <summary>
        /// 构造函数中调用，读取客户自定义配置内容
        /// </summary>
        private void ReadCustomConfig()
        {
            try
            {
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream(CustomCfgBinaryFileName, FileMode.Open, FileAccess.Read, FileShare.Read);
                _customCfg = (CustomConfig)formatter.Deserialize(stream);
                stream.Close();
            }
            catch (Exception ex)
            {
                //log
            }
            if (null == _customCfg)
            {
                _customCfg = new CustomConfig();
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
                // 获得当前运行路径
                Assembly currentAsm = Assembly.GetExecutingAssembly();
                // 获得dll路径
                Assembly asm = Assembly.LoadFile(Path.Combine(Path.GetDirectoryName(currentAsm.Location), DllFileName));
                obj = asm.CreateInstance(NameSpacePrefix + "." + DBType
                    + ".SQLExecutor", true);
            }
            catch
            {
            	
            }
            return obj;
        }

        /// <summary>
        /// 根据福位状态获取单元格的背景色
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public Color GetBackColor(CellState state)
        {
            switch (state)
            {
                case CellState.Default:
                    return DefaultCellBgColor;
                case CellState.Booked:
                    return BookedCellBgColor;
                case CellState.Sold:
                    return SoldCellBgColor;
                default:
                    return DefaultCellBgColor;
            }
        }

        /// <summary>
        /// 保存用户自定义配置内容（不是保存到数据库的统一配置）
        /// </summary>
        /// <returns>是否成功</returns>
        public bool SaveCustomConfig()
        {
            try
            {
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream(CustomCfgBinaryFileName, FileMode.Create, FileAccess.Write, FileShare.None);
                formatter.Serialize(stream, _customCfg);
                stream.Close();
            }
            catch (Exception)
            {
                //log
                return false;
            }
            return true;
        }
        #endregion

        #region 私有类
        /// <summary>
        /// 客户自定义设置内容类，本身不提供外部访问，而由ConfigurationHelper类提供访问。
        /// </summary>
        [Serializable]
        private class CustomConfig
        {
            public Color soldCellBgColor = Color.Empty;
            public Color bookedCellBgColor = Color.Empty;
            public Color defaultCellBgColor = Color.Empty;
        }
        #endregion
    }

}
