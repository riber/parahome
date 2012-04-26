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
using System.Windows.Shapes;
using System.Collections;

namespace ParadiseHome.Controls
{
    /// <summary>
    /// ThemeWindow.xaml 的交互逻辑
    /// </summary>
    public partial class ThemeWindow : Window
    {
        private MainWindow _mainWin;
        public ThemeWindow()
        {
            InitializeComponent();
        }

        public void Init(MainWindow mainWin)
        {
            this._mainWin = mainWin;
            this.cmbTheme.ItemsSource = _mainWin._themeUris.Keys;

            if (!String.IsNullOrEmpty(_mainWin._curThemeName))
            {
                this.cmbTheme.Text = _mainWin._curThemeName;
            }
        }

        private void cmbTheme_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                ResourceDictionary rd = Application.LoadComponent(_mainWin._themeUris[cmbTheme.SelectedItem.ToString()]) as ResourceDictionary;
                if (null != _mainWin._curThemeRd)
                {
                    App.Current.Resources.MergedDictionaries.Remove(_mainWin._curThemeRd);
                }
                App.Current.Resources.MergedDictionaries.Add(rd);
                _mainWin._curThemeRd = rd;
                _mainWin._curThemeName = cmbTheme.SelectedItem.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
