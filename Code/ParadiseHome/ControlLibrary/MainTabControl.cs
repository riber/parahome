using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace ControlLibrary
{
    public partial class MainTabControl : UserControl
    {
        //private TabButtonControl[] btnTab;
        // 可用的数量
        private int _used = 0;

        private List<TabButtonControl> btnTab = new List<TabButtonControl>();
#region 属性
        
#endregion
        public MainTabControl()
        {
            InitializeComponent();

            //this.btnTab = new ControlLibrary.TabButtonControl[4];
            for (int i = 0; i < tabControl.TabCount; i++)
            {
                TabButtonControl tab = new ControlLibrary.TabButtonControl();
                tab.Visible = false;
                this.palTab.Controls.Add(tab);
                this.palTab.Controls.SetChildIndex(tab, 0);
                tab.Click += new System.EventHandler(this.btnTab_Click);
                tab.Location = new System.Drawing.Point(140 * i, 5);
                tab.Size = new System.Drawing.Size(150, 24);
                tab.State = ControlLibrary.ButtonState.Default;
                btnTab.Add(tab);
            }

            //初始化
            InitShow();
        }

        /// <summary>
        /// 添加一个Tab页
        /// </summary>
        /// <param name="ctl">新的页里填充用户自定控制</param>
        public void AddTab(UserControl ctl, string name)
        {
            if (!tabControl.TabPages.ContainsKey(name))
            {
                if (_used == 0)
                {
                    // 没有可用的标签,需要重新创建
                    TabButtonControl tab = new ControlLibrary.TabButtonControl();
                    tab.Visible = false;
                    this.palTab.Controls.Add(tab);
                    this.palTab.Controls.SetChildIndex(tab, 0);
                    tab.Click += new System.EventHandler(this.btnTab_Click);
                    tab.Location = new System.Drawing.Point(140 * btnTab.Count, 5);
                    tab.Size = new System.Drawing.Size(150, 24);
                    tab.State = ControlLibrary.ButtonState.Default;
                    btnTab.Add(tab);
                }
                else
                {
                    _used--;
                }

                TabPage tabPage = new TabPage();
                tabPage.Location = new System.Drawing.Point(4, 21);
                tabPage.Name = name;
                tabPage.Padding = new System.Windows.Forms.Padding(3);
                tabPage.Size = new System.Drawing.Size(330, 180);
                tabPage.TabIndex = 2;
                tabPage.Text = name;
                tabPage.UseVisualStyleBackColor = true;
                tabControl.Controls.Add(tabPage);

                //tabControl.TabPages.Add(name);
                tabControl.TabPages[name].Controls.Add(ctl);
                ctl.Dock = DockStyle.Fill;

            }
            tabControl.SelectTab(name);
            InitShow();
            
        }

        private void palClose_Click(object sender, EventArgs e)
        {
            // 关闭当前的Tab页
            if (tabControl.SelectedIndex >= 0)
            {
                tabControl.TabPages.RemoveAt(tabControl.SelectedIndex);
                btnTab[btnTab.Count - 1 - _used].Visible = false;
                _used++;
                InitShow();
            }
            
        }

        private void palUp_Click(object sender, EventArgs e)
        {
            // 上页
            int index = tabControl.SelectedIndex - 1;
            if (tabControl.SelectedIndex > 0)
            {
                tabControl.SelectTab(index);
                // 显示
                InitShow();
                
            }
        }

        private void palDown_Click(object sender, EventArgs e)
        {
            // 下一页
            int index = tabControl.SelectedIndex + 1;
            if (index < tabControl.TabPages.Count)
            {
                tabControl.SelectTab(index);

                // 显示
                InitShow();
            }
            
        }

        private void InitShow()
        {
            // 显示标识

            for (int i = 0; i < tabControl.TabCount; i++ )
            {
                btnTab[i].Button.Text = tabControl.TabPages[i].Name;
                btnTab[i].State = ButtonState.LeftNotSelect;

            }

            if (tabControl.SelectedIndex > 0)
            {
                btnTab[0].State = ButtonState.Default;
                btnTab[tabControl.SelectedIndex].State = ButtonState.Select;
                if (tabControl.SelectedIndex + 1 < tabControl.TabCount)
                {
                    btnTab[tabControl.SelectedIndex + 1].State = ButtonState.LeftSelect;
                }
            }
            else
            {
                btnTab[0].State = ButtonState.Select;
                btnTab[1].State = ButtonState.LeftSelect;
            }

            for (int i = 0; i < tabControl.TabCount; i++)
            {
                btnTab[i].Visible = true;
                btnTab[i].InitShow();
            }
            palTab.Width = 140 * tabControl.TabCount + 20;

            if (palTab.Width > panel2.Width)
            {
                // 控制面板的位置
                int x = 0;
                if (tabControl.SelectedIndex >= 0)
                {
                    // 选择标签的位置
                    x = 140 * tabControl.SelectedIndex;
                    x = x + palTab.Left;
                    if (x < 0)
                    {
                        // 左移一格
                        palTab.Left += 140;
                    }
                    if (x > this.panel2.Width - 140)
                    {
                        // 右移一格
                        palTab.Left -= 140;
                    }
                }
            }
            else
            {
                palTab.Left = 0;
            }
            
        }

        private void btnTab_Click(object sender, EventArgs e)
        {
            if (sender is TabButtonControl)
            {
                TabButtonControl btn = (TabButtonControl)sender;
                tabControl.SelectTab(btn.Button.Text);
                InitShow();
            }
            //btnTab1.State = ButtonState.Select;
            //btnTab1.InitShow();
        }

        private void MainTabControl_Resize(object sender, EventArgs e)
        {
            tabControl.Left = -1;
            tabControl.Top = 9;
            tabControl.Height = this.Height - 8;
            tabControl.Width = this.Width + 3;
            InitShow();
        }
    }
}
