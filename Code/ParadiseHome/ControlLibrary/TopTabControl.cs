using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace ControlLibrary
{
    public partial class TopTabControl : UserControl
    {
        public TopTabControl()
        {
            InitializeComponent();
        }

        private void TopTabControl_Resize(object sender, EventArgs e)
        {
            tabControl.Left = -1;
            tabControl.Top = 10;
            tabControl.Width = this.Width + 3;
            tabControl.Height = this.Height - 7;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mainTabControl1.AddTab(new TopTabControl(), "text");

        }
    }
}