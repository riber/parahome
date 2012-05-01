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
using ParadiseHome.Common.Model.Basic;
using System.Windows.Forms;
using ParadiseHome.Common.Utils;

namespace ParadiseHome.Controls
{
    /// <summary>
    /// CellEditor.xaml 的交互逻辑
    /// </summary>
    public partial class CellEditor : System.Windows.Controls.UserControl
    {
        #region 依赖项属性
        /// <summary>
        /// 依赖项属性：控件的标题
        /// </summary>
        public static readonly DependencyProperty HeaderProperty = DependencyProperty.Register(
            "Header",
            typeof(Object),
            typeof(CellEditor),
            new FrameworkPropertyMetadata("",
                FrameworkPropertyMetadataOptions.AffectsParentMeasure,
                new PropertyChangedCallback(OnHeaderChanged)));

        private static void OnHeaderChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((CellEditor)d).OnHeaderChanged(e.NewValue);
        }

        private void OnHeaderChanged(Object newValue)
        {
            this.pnlHeader.Content = newValue;
        }
        #endregion

        #region 属性
        /// <summary>
        /// 获取或设置标题对象（可以是控件）
        /// </summary>
        public Object Header
        {
            get
            {
                return GetValue(HeaderProperty);
            }
            set
            {
                SetValue(HeaderProperty, value);
            }
        } 
        #endregion

        private ContextMenuStrip _menuStrip = null;

        public CellEditor()
        {
            InitializeComponent();
            _menuStrip = CreateContextMenuStrip();
            if (null != _menuStrip)
            {
                this.dgvCells.ContextMenuStrip = _menuStrip;
            }
        }

        /// <summary>
        /// 填充要显示的数据
        /// </summary>
        /// <param name="datas">福位对象列表</param>
        public void FillDatas(IList<Cell> datas)
        {
            if (null == datas)
            {
                throw new ArgumentNullException("datas");
            }
            if (datas.Count == 0)
            {
                return;
            }
            //自动查询最大行、列值（必须满足假设：Y、Z均为从1开始的连续数
            int colCount = datas.Max(cell => cell.Z);
            int rowCount = datas.Max(cell => cell.Y);
            if (colCount < 1 || rowCount < 1)
            {
                return;
            }
            //先清空原有的
            this.dgvCells.Rows.Clear();
            this.dgvCells.Columns.Clear();


            //创建列、行
            for (int i = 0; i < colCount; i++)
            {
                DataGridViewColumn col = new DataGridViewTextBoxColumn();
                col.HeaderText = String.Format("{0:D2}号", i + 1);           //列标题
                col.SortMode = DataGridViewColumnSortMode.NotSortable;      //不让用户排序
                this.dgvCells.Columns.Add(col);
            }
            for (int i = 0; i < rowCount; i++)
            {
                dgvCells.Rows.Add();
                dgvCells.Rows[i].HeaderCell.Value = String.Format("第{0}层", i + 1);
            }

            foreach (Cell item in datas)
            {
                DataGridViewCell cell = dgvCells[item.Z - 1, item.Y - 1];
                cell.Value = item.CellTag;
                cell.Tag = item;
                //设置背景颜色
                cell.Style.BackColor = ConfigurationHelper.Instance.GetBackColor(item.State);
            }
            dgvCells.Refresh();
        }

        #region 私有方法及事件处理
        protected ContextMenuStrip CreateContextMenuStrip()
        {
            ContextMenuStrip cms = new ContextMenuStrip();

            ToolStripMenuItem mi = new ToolStripMenuItem("示例菜单项");
            mi.Click += new EventHandler(OnMenuItemClick);
            cms.Items.Add(mi);

            return cms;
        }

        void OnMenuItemClick(object sender, EventArgs e)
        {
            String msg = String.Empty;
            if (dgvCells.SelectedCells.Count == 1)
            {
                msg = String.Format("当前选中的单元格为：行{0}列{1}，其值为：{2}", dgvCells.SelectedCells[0].RowIndex, dgvCells.SelectedCells[0].ColumnIndex, dgvCells.SelectedCells[0].Value); 
            }
            else
            {
                msg = "当前选中单元格个数不是1";
            }
            System.Windows.MessageBox.Show(msg);
        }
        
        private void dgvCells_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.ColumnIndex > -1 && e.RowIndex > -1)
            {
                dgvCells.CurrentCell = dgvCells[e.ColumnIndex, e.RowIndex];
            }
        }
        #endregion

    }
}
