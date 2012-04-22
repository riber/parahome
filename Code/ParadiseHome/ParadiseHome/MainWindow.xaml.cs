using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ParadiseHome.Pages;
using System.Windows.Controls.Primitives;
using ParadiseHome.Common.Utils;

namespace ParadiseHome
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Title = Constants.MainWinTitle;
        }

        #region 公共属性
        /// <summary>
        /// 获取主窗口状态栏对象的应用
        /// </summary>
        public StatusBar StatusBar
        {
            get
            {
                return this.statusBar1;
            }
        }
        #endregion

        #region 公共方法
        /// <summary>
        /// 在主窗口状态栏显示信息
        /// </summary>
        /// <param name="msgObj">信息对象，可以是任何控件，不仅仅是字符串。</param>
        public void ShowStatusMessage(Object msgObj)
        {
            this.sbiMsg.Content = msgObj;
        }
        #endregion

        /// <summary>
        /// 最顶层导航按钮单击事件处理（所有导航按钮共用）。实现导航功能。
        /// 分两步：1.导航；2.导航完成后传参或其他处理。此为第一步。
        /// </summary>
        private void NavButton_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            this.sbiMsg.Content = String.Format("正在导航到：{0}", btn.Tag);
            this.mainFrame.Navigate(new Uri(btn.Tag.ToString(),UriKind.Relative));
        }

        /// <summary>
        /// 导航第二步。已经导航到相应页面后，给该页面对象传参或设置属性。
        /// </summary>
        private void mainFrame_Navigated(object sender, NavigationEventArgs e)
        {
            BasePage bp = e.Content as BasePage;
            bp.ParentWindow = this;
            this.Title = String.Format("{0} - {1}", bp.Title, Constants.MainWinTitle);
            this.sbiMsg.Content = bp.Title;
        }

        private void btnShowOrHideMenu_Click(object sender, RoutedEventArgs e)
        {
            bool menuVisible = (this.leftMenuContainerGrid.Visibility == Visibility.Visible);
            if (menuVisible)
            {
                //执行隐藏操作
                this.leftMenuContainerGrid.Visibility = System.Windows.Visibility.Collapsed;
                this.imgLeft.Visibility = System.Windows.Visibility.Collapsed;
                this.imgRight.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                //显示
                this.leftMenuContainerGrid.Visibility = System.Windows.Visibility.Visible;
                this.imgLeft.Visibility = System.Windows.Visibility.Visible;
                this.imgRight.Visibility = System.Windows.Visibility.Collapsed;
            }
        }

    }
}
