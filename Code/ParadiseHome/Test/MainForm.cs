using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ControlLibrary;
using System.Diagnostics;
using DAL;

using BLL;

namespace Test
{
    public partial class MainForm : Form
    {
        private MyStackBtn m_StackBtn;
        public MainForm()
        {
            InitializeComponent();
            //InitPage();
        }
        private void InitPage()
        {
            Point location = new Point(90, 10);
            Size size = new System.Drawing.Size(200, 400);
            List<String> NameList00 = new List<String>(0);
            NameList00.Add("基本信息");
            NameList00.Add("数据中心");
            NameList00.Add("客户中心");
            NameList00.Add("维护中心");

            this.m_StackBtn = new MyStackBtn();
            this.m_StackBtn.BtnCount = NameList00.Count;
            this.m_StackBtn.BtnHeight = 30;
            this.m_StackBtn.SetSize(location, size);

            this.m_StackBtn.InitAllControl();
            this.m_StackBtn.SetBtnName(NameList00);
            this.m_StackBtn.SetButtonClickEvent(this.PageButton_Click);

            List<String> NameList01 = new List<String>(0);
            NameList01.Add("系统设置");
            NameList01.Add("数据库配置");
            NameList01.Add("操作日志");
            this.m_StackBtn.SetTreeNodeName(3, NameList01);
            this.m_StackBtn.SetTreeClickEvent(this.treeView_AfterSelect);

            this.Controls.Add(m_StackBtn);
        }
        private void PageButton_Click(object sender, EventArgs e)
        {
            BlueFaceButton Btn = (BlueFaceButton)sender;
            int iIndex = Btn.TabIndex / 2;
            Trace.WriteLine(Btn.Text);
        }
        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeView Tree = (TreeView)sender;
            if (Tree.SelectedNode != null)
            {
                Trace.WriteLine("select " + Tree.SelectedNode.Text);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //BLL.Users[] user = BLL.Users.FindAll();
            Client[] clients = Client.FindAll();
            BLL.Type[] types = BLL.Type.FindAll();
            BLL.Seat[] seats = Seat.FindAll();
            BLL.Employee[] a2 = Employee.FindAll();
            BLL.Location[] b2 = BLL.Location.FindAll();
            User[] dsa = User.FindAll();
        }

        private void topTabControl1_Load(object sender, EventArgs e)
        {
            //Client[] clients = Client.FindAll();
            //BLL.Type[] types = BLL.Type.FindAll();
            //BLL.Seat[] seats = Seat.FindAll();
            //BLL.Employee[] a2 = Employee.FindAll();
            //BLL.Location[] b2 = BLL.Location.FindAll();
            User[] dsa = User.FindAll();

            UserDAL.VerifyEmpoyee("123","123");
        }
    }
}