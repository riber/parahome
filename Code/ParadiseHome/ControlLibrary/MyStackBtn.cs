using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace ControlLibrary
{
    public partial class MyStackBtn : UserControl
    {
        public MyStackBtn()
        {
            InitializeComponent();
            this.m_BasePanel = new Panel();
        }
        public Panel m_BasePanel;
        public List<Panel> m_ListPanel;
        public List<TreeView> m_ListTreeView;
        public List<BlueFaceButton> m_ListButton;
        private List<PointState> m_ListButtonState;
        private int m_ButtonWidth = 120;
        private int m_ButtonHeight = 30;
        private int m_PanelWidth = 0;
        private int m_PanelHeight = 0;
        private int m_Index = 0;
        private int m_BtnCount = 0;
        private int m_BtnGap;
        private Point m_PanelPoint;
        private Point m_BtnPoint;
        public int m_iInit=0;
        static private int s_StateBack = 0;
        static private int s_StateBackGoing = 1;
        static private int s_StateFar = 2;
        static private int s_StateFarGoing = 3;
        
        public void SetSize(Point location,Size size)
        {
            this.Location = location;
            this.Size = size;
            int Gap = 5;
            Point newPoint = new Point(Gap,Gap);
            Size newSize = new Size(size.Width - Gap*2, size.Height - Gap*2);
            this.m_BasePanel.Location = newPoint;
            this.m_BasePanel.Size = newSize;
        }
        public void SetBtnName(List<String> NameList)
        {
            int i = 0;
            if (NameList.Count < m_BtnCount)
            {
                return;
            }
            for (i = 0; i < m_BtnCount; i++)
            {
                m_ListButton[i].Text = NameList[i];
            }
            Invalidate();
        }
        public void InitAllControl()
        {
            int i = 0;
            int iTabSeq = 0;
            string strID = "";

            m_ListPanel = new List<Panel>(0);
            m_ListButton = new List<BlueFaceButton>(0);
            m_ListButtonState = new List<PointState>(0);
            m_ListTreeView = new List<TreeView>(0);

            m_BtnGap = 2;
            m_PanelPoint = new Point(0,0);
            m_BtnPoint = new Point(1,m_BtnGap);
            m_ButtonWidth = this.m_BasePanel.Size.Width - (m_BtnPoint.X) * 2;
            m_Index = m_BtnCount - 1;
            m_PanelWidth = this.m_BasePanel.Size.Width;
            m_PanelHeight = this.m_BasePanel.Size.Height;
            for (i=0;i<m_BtnCount;i++)
            {
                BlueFaceButton NewBtn = new BlueFaceButton();
                Panel NewPanel = new Panel();
                Point NewPoint = new Point(m_PanelPoint.X + m_BtnPoint.X,
                            m_PanelPoint.Y + m_BtnPoint.Y + i * (m_ButtonHeight + m_BtnGap));
                PointState NewState = new PointState(NewPoint);
                

                strID = Convert.ToString(i + 1);

                NewBtn.Location = NewPoint;
                NewBtn.Name = "button" + strID;
                NewBtn.Size = new System.Drawing.Size(m_ButtonWidth, m_ButtonHeight);
                NewBtn.TabIndex = iTabSeq++;
                NewBtn.Text = NewBtn.Name;
                NewBtn.UseVisualStyleBackColor = true;
                NewBtn.BackColor = Color.Gray;
                NewBtn.Click += new System.EventHandler(this.button_Click);

                NewPanel.Location = m_PanelPoint;
                NewPanel.Name = "panel" + strID;
                NewPanel.Size = new System.Drawing.Size(m_PanelWidth, m_PanelHeight);
                NewPanel.TabIndex = iTabSeq++;

                this.m_BasePanel.Controls.Add(NewBtn);
                this.m_BasePanel.Controls.Add(NewPanel);
                //this.Controls.Add(NewBtn);
                //this.Controls.Add(NewPanel);
                m_ListPanel.Add(NewPanel);
                m_ListButton.Add(NewBtn);
                m_ListButtonState.Add(NewState);
            }
            m_BasePanel.SendToBack();
            this.Controls.Add(m_BasePanel);
            AddTree();

            for (i = 0; i < m_BtnCount; i++)
            {
                m_ListButton[i].BringToFront();
                m_ListPanel[i].Visible = false;
            }
            
            for (i = 0; i < m_BtnCount; i++)
            {
                int iTmp = (100 + (i * 50)) % 255;
                m_ListPanel[i].BackColor = Color.FromArgb(217, 220, 230);
            }
            m_ListPanel[m_Index].Visible = true;
            //SetPanelContent();
        }
        void SetBackBtn(int Index)
        {
            int X = 0;
            int YBack = 0;
            X = m_BtnPoint.X + m_PanelPoint.X;
            YBack = m_ListButtonState[Index].m_Pos.Y;
            m_ListButton[Index].SetBounds(X,YBack,m_ButtonWidth,m_ButtonHeight);
        }
        void SetFarBtn(int Index)
        {
            int X = 0;
            int YFar = 0;
            X = m_BtnPoint.X + m_PanelPoint.X;
            YFar = m_PanelHeight + m_PanelPoint.Y - 
                        (m_BtnCount - Index)*(m_ButtonHeight + m_BtnGap);
            m_ListButton[Index].SetBounds(X, YFar, m_ButtonWidth, m_ButtonHeight);
        }
        public void SetButtonClickEvent(EventHandler target)
        {
            int i = 0;
            for (i = 0; i < m_BtnCount; i++)
            {
                m_ListButton[i].Click += target;
            }
        }
        public void SetTreeClickEvent(TreeViewEventHandler target)
        {
            int i = 0;
            for (i = 0; i < m_BtnCount; i++)
            {
                m_ListTreeView[i].AfterSelect += target;
            }
        }
        public void SetPanelContent()
        {
            int i = 0;
            int iTabSeq = 10;
            Label NewLabel;
            Point NewPoint;

            for (i = 0; i < m_BtnCount; i++)
            {
                NewLabel = new Label();
                NewPoint = new Point(m_ListButton[i].Left + i,
                            m_ListButton[i].Bottom + i * 10);
                NewLabel.Location = NewPoint;
                NewLabel.Name = "Label " + Convert.ToString(i + 10);
                NewLabel.Size = new System.Drawing.Size(m_ButtonWidth, m_ButtonHeight);
                NewLabel.TabIndex = iTabSeq++;
                NewLabel.Text = NewLabel.Name;
                
                //NewBtn.SendToBack();
                m_ListPanel[i].Controls.Add(NewLabel);
            }
            
        }
        public void AddTree()
        {
            int i = 0;
            int j = 0;
            ImageList IList = new ImageList();
            TreeNode NewNode;

            IList.Images.Add(Image.FromFile("..\\..\\..\\file\\images\\lableImage3.gif"));

            for (i = 0; i < m_BtnCount; i++)
            {
                TreeView NewTreeView = new TreeView();
                for (j = 0; j < 5;j++ )
                {
                    NewNode = new TreeNode();
                    NewNode.Text = "Index " + Convert.ToString(j);
                    NewTreeView.Nodes.Add(NewNode);
                }
                
                NewTreeView.Location = new Point(0, 30);
                NewTreeView.BackColor = Color.FromArgb(217, 220, 230);
                //Tree.ShowRootLines = false;
                NewTreeView.ShowLines = false;
                NewTreeView.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular,
                        GraphicsUnit.Point, ((byte)(134)));

                NewTreeView.ImageList = IList;
                NewTreeView.ImageIndex = 0;
                NewTreeView.SelectedImageIndex = 0;
                NewTreeView.ItemHeight = 25;

                AddControl(i, NewTreeView, 0, 0, m_PanelWidth, m_PanelHeight);
                m_ListTreeView.Add(NewTreeView);
            }
        }
        public void SetTreeNodeName(int Index,List<String> NameList)
        {
            int i = 0;
            int j=0;
            for (j = 0; j < m_ListTreeView[Index].Nodes.Count; j++)
            {
                if (j < NameList.Count)
                {
                    m_ListTreeView[Index].Nodes[j].Text = NameList[j];
                }
            }
            Invalidate();
        }
        public void AddControl(int Index,Control What,int x,int y,int width,int height)
        {
            Point NewPoint;

            NewPoint = new Point(m_ListButton[Index].Left+ x,m_ListButton[Index].Bottom + y);
            What.Location = NewPoint;
            What.Size = new System.Drawing.Size(width, height);

            m_ListPanel[Index].Controls.Add(What);
        }
        private void button_Click(object sender, EventArgs e)
        {
            BlueFaceButton Btn = (BlueFaceButton)sender;
            int iIndex = Btn.TabIndex/2;
            int i=0;
            int iState=0;
            int iValidate = 0;

            m_Index = iIndex;
            for (i = 0; i < m_BtnCount; i++)
            {
                if (i != iIndex)
                {
                    m_ListPanel[i].Visible = false;
                }
            }
            m_ListPanel[iIndex].Visible = true;
            m_ListPanel[iIndex].BringToFront();
            for (i = 0; i < m_BtnCount; i++)
            {
                m_ListButton[i].BringToFront();
            }
            
            for (i = 0; i < iIndex; i++)
            {
                iState = m_ListButtonState[i].m_State;
                if (iState!=s_StateBack)
                {
                    m_ListButtonState[i].m_State = s_StateBackGoing;
                    iValidate = 1;
                }
            }
            for (i = iIndex + 1; i < m_BtnCount; i++)
            {
                iState = m_ListButtonState[i].m_State;
                if (iState != s_StateFar)
                {
                    m_ListButtonState[i].m_State = s_StateFarGoing;
                    iValidate = 1;
                }
            }
            if (m_ListButtonState[iIndex].m_State == s_StateFar)
            {
                m_ListButtonState[iIndex].m_State = s_StateBackGoing;
                iValidate = 1;
            }
            if (iValidate==1)
            {
                Invalidate();
            }
            //Trace.WriteLine(Convert.ToString(iIndex));
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Pen RedPen = new Pen(Color.MediumBlue, 5);
            e.Graphics.DrawRectangle(RedPen, 0, 0, this.Size.Width, this.Size.Height);
            //Pen BlackPen = new Pen(Color.Black, 2);
            //e.Graphics.DrawRectangle(BlackPen, this.m_BasePanel.Location.X, this.m_BasePanel.Location.Y,
            //                this.m_BasePanel.Size.Width, this.m_BasePanel.Size.Height);

            int i = 0;
            int iState = 0;
            for (i = 0; i < m_BtnCount; i++)
            {
                iState = m_ListButtonState[i].m_State;
                if (iState == s_StateFarGoing)
                {
                    SetFarBtn(i);
                    m_ListButtonState[i].m_State = s_StateFar;
                }
                else if (iState == s_StateBackGoing)
                {
                    SetBackBtn(i);
                    m_ListButtonState[i].m_State = s_StateBack;
                }
            }
        }
        [Category("参数设置"), Description("按钮宽度")]
        [Browsable(true)]
        public int BtnWidth
        {
            get
            {
                return m_ButtonWidth;
            }
            set
            {
                m_ButtonWidth = value;
            }
        }
        [Category("参数设置"), Description("按钮高度")]
        [Browsable(true)]
        public int BtnHeight
        {
            get
            {
                return m_ButtonHeight;
            }
            set
            {
                m_ButtonHeight = value;
            }
        }
        [Category("参数设置"), Description("页面宽度")]
        [Browsable(true)]
        public int PanelWidth
        {
            get
            {
                return m_PanelWidth;
            }
            set
            {
                m_PanelWidth = value;
            }
        }
        [Category("参数设置"), Description("页面高度")]
        [Browsable(true)]
        public int PageHeight
        {
            get
            {
                return m_PanelHeight;
            }
            set
            {
                m_PanelHeight = value;
            }
        }
        [Category("参数设置"), Description("页面数")]
        [Browsable(true)]
        public int BtnCount
        {
            get
            {
                return m_BtnCount;
            }
            set
            {
                m_BtnCount = value;
            }
        }
        [Category("参数设置"), Description("按钮间隔")]
        [Browsable(true)]
        public int BtnGap
        {
            get
            {
                return m_BtnGap;
            }
            set
            {
                m_BtnGap = value;
            }
        }
        [Category("参数设置"), Description("按钮起始坐标")]
        [Browsable(true)]
        public Point BtnPoint
        {
            get
            {
                return m_BtnPoint;
            }
            set
            {
                m_BtnPoint = value;
            }
        }

        public class PointState
        {
            public Point m_Pos;
            public int m_State;
            public PointState()
            {
                m_Pos = new Point(0,0);
                m_State = s_StateBack;
            }
            public PointState(Point Pt)
            {
                m_Pos = Pt;
                m_State = s_StateBack;
            }
        }
    }
    
}