using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ParadiseHome.Common.Utils;

namespace ParadiseHome.Controls.WinFormControls
{
    public partial class SysSettingForm : Form
    {
        public SysSettingForm()
        {
            InitializeComponent();

            this.colorCmbDefault.SelectedColor = ConfigurationHelper.Instance.DefaultCellBgColor;
            this.colorCmbBooked.SelectedColor = ConfigurationHelper.Instance.BookedCellBgColor;
            this.colorCmbSold.SelectedColor = ConfigurationHelper.Instance.SoldCellBgColor;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            ConfigurationHelper ch = ConfigurationHelper.Instance;
            ch.DefaultCellBgColor = colorCmbDefault.SelectedColor == Color.Black ? Color.Empty : colorCmbDefault.SelectedColor;
            ch.BookedCellBgColor = colorCmbBooked.SelectedColor;
            ch.SoldCellBgColor = colorCmbSold.SelectedColor;

            this.Close();
        }
    }
}
