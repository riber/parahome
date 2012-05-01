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
    /// CellEditorDefaultHeader.xaml 的交互逻辑
    /// </summary>
    public partial class CellEditorDefaultHeader : UserControl
    {
        public CellEditorDefaultHeader()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 获取或设置标题的第一部分字符串
        /// </summary>
        public String Header1
        {
            get
            {
                return this.txtHeader1.Text;
            }
            set
            {
                this.txtHeader1.Text = value;
            }
        }

        /// <summary>
        /// 获取或设置标题的第二部分字符串
        /// </summary>
        public String Header2
        {
            get
            {
                return this.txtHeader2.Text;
            }
            set
            {
                this.txtHeader2.Text = value;
            }
        }
    }
}
