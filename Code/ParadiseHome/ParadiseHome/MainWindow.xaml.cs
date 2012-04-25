using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Navigation;
using ParadiseHome.Pages;
using System.Windows.Controls.Primitives;
using ParadiseHome.Common.Utils;
using System.Windows.Resources;
using System.Windows.Markup;
using System.IO;
using ParadiseHome.Controls;
using System.Reflection;
using System.Windows.Input;

namespace ParadiseHome
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        #region 主题相关成员，可供程序集内部引用
        //主题地址字典
        internal readonly Dictionary<String, Uri> _themeUris = new Dictionary<string, Uri>();
        //当前使用的主题资源
        internal ResourceDictionary _curThemeRd;
        //当前主题名称
        internal String _curThemeName;
        #endregion

        public MainWindow()
        {
            InitializeComponent();
            this.Title = Constants.MainWinTitle;
            //初始化主题地址
            InitTheme();
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

        #region 私有方法
        /// <summary>
        /// 初始化主题信息
        /// </summary>
        private void InitTheme()
        {
            _themeUris.Add("Windows经典", new Uri("/PresentationFramework.Classic, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35;component/themes/classic.xaml", UriKind.Relative));
            _themeUris.Add("XP月光_常规", new Uri("/PresentationFramework.Luna, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35;component/themes/luna.normalcolor.xaml", UriKind.Relative));
            _themeUris.Add("XP月光_家庭", new Uri("/PresentationFramework.Luna, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35;component/themes/luna.homestead.xaml", UriKind.Relative));
            _themeUris.Add("XP月光_金属", new Uri("/PresentationFramework.Luna, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35;component/themes/luna.metallic.xaml", UriKind.Relative));
            _themeUris.Add("XP_Royale", new Uri("/PresentationFramework.Royale, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35;component/themes/royale.normalcolor.xaml", UriKind.Relative));
            _themeUris.Add("Win7_Aero", new Uri("/PresentationFramework.Aero, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35;component/themes/aero.normalcolor.xaml", UriKind.Relative));
            //设置默认主题
            this.SetTheme("Win7_Aero");
        }

        private bool SetTheme(String name)
        {
            try
            {
                ResourceDictionary rd = Application.LoadComponent(_themeUris[name]) as ResourceDictionary;
                if (null != _curThemeRd)
                {
                    App.Current.Resources.MergedDictionaries.Remove(_curThemeRd);
                }
                _curThemeRd = rd;
                App.Current.Resources.MergedDictionaries.Add(rd);
                _curThemeName = name;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            return true;
        }
        #endregion
        #region 导航相关
        /// <summary>
        /// 最顶层导航按钮单击事件处理（所有导航按钮共用）。实现导航功能。
        /// </summary>
        private void NavButton_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            this.OpenTabItem(btn.Tag.ToString());
        }

        /// <summary>
        /// 根据相应信息创建或选中标签页，目前只支持同个程序集内的类的导航。
        /// </summary>
        /// <param name="targetInfoStr">必须满足如下格式：完整类名;标签标题名</param>
        private void OpenTabItem(String targetInfoStr)
        {
            if (!String.IsNullOrEmpty(targetInfoStr))
            {
                try
                {
                    String[] info = targetInfoStr.Split(';', '；');
                    if (info.Length == 2)
                    {
                        bool isExist = TryActivateTabItem(info[0]);
                        if (!isExist)
                        {
                            Assembly asm = Assembly.GetExecutingAssembly();
                            Type t = asm.GetType(info[0]);
                            if (null != t)
                            {
                                Object obj = Activator.CreateInstance(t);
                                TabItem ti = CreateClosableTabItem(info[1], obj);
                                ti.Tag = info[0];
                                tcMainContent.Items.Add(ti);
                                tcMainContent.SelectedItem = ti;
                            }
                            else
                            {
                                MessageBox.Show("程序集中不存在类型" + info[0]);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        String.Format("严重：导航到地址“{0}”失败。{1}", targetInfoStr, ex.Message),
                        "错误", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        /// <summary>
        /// 尝试在tcMainContent中选中指定类名对应的TabItem项
        /// </summary>
        /// <param name="fullClassName">完整类名（作为TabItem的标识）</param>
        /// <returns>true:对应项存在（且已选中为当前项）；false：对应项不存在</returns>
        private bool TryActivateTabItem(String fullClassName)
        {
            try
            {
                foreach (var item in tcMainContent.Items)
                {
                    if ((item as TabItem).Tag.Equals(fullClassName))
                    {
                        tcMainContent.SelectedItem = item;
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return false;
        }

        /// <summary>
        /// 创建可关闭TabItem项，并根据参数设置标题，以及将内容放置于TabItem中。
        /// </summary>
        /// <param name="header">TabItem的标题</param>
        /// <param name="content">TabItem要承载的内容</param>
        /// <returns>生成的TabItem对象</returns>
        private TabItem CreateClosableTabItem(Object header, Object content)
        {
            TabItem ti = new TabItem();
            Grid pnl = new Grid();
            pnl.ColumnDefinitions.Add(new ColumnDefinition());
            ColumnDefinition rightCol = new ColumnDefinition();
            rightCol.Width = GridLength.Auto;
            pnl.ColumnDefinitions.Add(rightCol);

            ContentControl cc = new ContentControl();
            cc.Content = header;
            cc.Tag = ti;
            pnl.Children.Add(cc);
            cc.ToolTip = "双击关闭";
            cc.MouseDoubleClick += new MouseButtonEventHandler(TabItemClosingEventHandler);
            //关闭按钮
            System.Windows.Controls.Button btn = new System.Windows.Controls.Button();
            btn.Background = null;
            btn.BorderBrush = null;
            btn.BorderThickness = new Thickness(0);
            btn.Tag = ti;
            btn.Content = "×";
            btn.ToolTip = "关闭";
            /*
             * 为了与ContentControl的事件统一，所以不使用Button的Click事件，
             * 而Button的MouseLeftButtonDown和MouseLeftButtonUp都是无效的，
             * 所以才使用了PreviewMouseLeftButtonUp。
            */
            btn.PreviewMouseLeftButtonUp += new MouseButtonEventHandler(TabItemClosingEventHandler);
            Grid.SetColumn(btn, 1);
            pnl.Children.Add(btn);
            ti.Header = pnl;

            Frame f = new Frame();
            f.Content = content;
            ti.Content = f;

            return ti;
        }

        /// <summary>
        /// 可关闭TabItem项的关闭处理。
        /// </summary>
        /// <param name="sender">触发事件的对象，其Tag属性需保存了其所在的TabItem对象</param>
        /// <param name="e"></param>
        void TabItemClosingEventHandler(object sender, MouseButtonEventArgs e)
        {
            System.Windows.Controls.Control ctl = sender as System.Windows.Controls.Control;
            tcMainContent.Items.Remove(ctl.Tag);
            e.Handled = true;
        }

        /// <summary>
        /// 树菜单项按键抬起事件，当为Enter键时执行导航处理
        /// </summary>
        /// <param name="sender">树菜单项，Tag属性需包含正确的导航信息</param>
        /// <param name="e"></param>
        private void TreeViewItem_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Control ctl = sender as Control;
                this.OpenTabItem(ctl.Tag.ToString()); 
            }
        }

        /// <summary>
        /// 树菜单项鼠标左键抬起事件，执行导航处理
        /// </summary>
        /// <param name="sender">树菜单项，Tag属性需包含正确的导航信息</param>
        /// <param name="e"></param>
        private void TreeViewItem_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Control ctl = sender as Control;
            this.OpenTabItem(ctl.Tag.ToString()); 
        }

        #endregion

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

        private void miChangeStyle_Click(object sender, RoutedEventArgs e)
        {
            ThemeWindow win = new ThemeWindow();
            win.Init(this);
            win.Show();
        }

    }
}
