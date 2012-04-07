using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Castle.ActiveRecord;
using Castle.ActiveRecord.Framework;
using System.Reflection;
using mylog4net;

namespace Test
{
    static class Program
    {
        //日志记录器
        public static ILog log;
        
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // 查找Castle资料配置 [2/21/2012 lyy]
            IConfigurationSource source = System.Configuration.ConfigurationSettings.GetConfig("activerecord") as IConfigurationSource;
            // Castle初始化 [2/21/2012 lyy]
            Assembly asm = Assembly.Load("BLL");
            ActiveRecordStarter.Initialize(asm, source);

            // 初始化日志 [2/21/2012 lyy]
            // 读取log4net配置信息，并监视配置文件。
            mylog4net.Config.XmlConfigurator.ConfigureAndWatch(new System.IO.FileInfo("mylog4net.config"));
            // 日志记录器
            log = LogManager.GetLogger(typeof(Program));
            //ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // 启动程序 [2/21/2012 lyy]
            Application.Run(new MainForm());

            //IConfigurationSource source = System.Configuration..GetSection("activerecord") as IConfigurationSource;
            //读取log4net配置信息(未指定配置文件则默认从web.config中读取)，初始化log4net环境
            //mylog4net.Config.XmlConfigurator.Configure();
            
        }
    }
}