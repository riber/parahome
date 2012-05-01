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

namespace ParadiseHome.Controls
{
    /// <summary>
    /// TextBlockShape.xaml 的交互逻辑
    /// </summary>
    public partial class TextBlockShape : UserControl
    {
        public TextBlockShape()
        {
            InitializeComponent();
        }

        public void Select()
        {
            rtMain.StrokeThickness = 3;
            rtMain.Stroke = new SolidColorBrush(Colors.Blue);
        }

        public void NotSelect()
        {
            rtMain.StrokeThickness = 2;
            rtMain.Stroke = new SolidColorBrush(Color.FromArgb(0xFF, 0xC1, 0xB0, 0xB0));
        }

        private void UserControl_MouseEnter(object sender, MouseEventArgs e)
        {
            Select();
        }

        private void UserControl_MouseLeave(object sender, MouseEventArgs e)
        {
            NotSelect();
        }
    }
}
