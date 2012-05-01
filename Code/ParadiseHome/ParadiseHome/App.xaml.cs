using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using ParadiseHome.Common.Utils;

namespace ParadiseHome
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        protected override void OnExit(ExitEventArgs e)
        {
            ConfigurationHelper.Instance.SaveCustomConfig();
            base.OnExit(e);
        }
    }
}
