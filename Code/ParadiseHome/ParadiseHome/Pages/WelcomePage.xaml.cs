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
using ParadiseHome.Controls;
using ParadiseHome.Common.Utils;

namespace ParadiseHome.Pages
{
    /// <summary>
    /// WelcomePage.xaml 的交互逻辑
    /// </summary>
    public partial class WelcomePage : Page
    {
        public WelcomePage()
        {
            InitializeComponent();
            TestCellEditor();
        }

        private void TestCellEditor()
        {
            IList<Cell> datas = new List<Cell>();
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Cell c = new Cell();
                    c.Y = i + 1;
                    c.Z = j + 1;
                    c.State = ((i + j) % 3 == 0) ? CellState.Default : ((i + j) % 3 == 1) ? CellState.Booked : CellState.Sold;
                    c.CellTag = String.Format("{0}{1}", c.Y, c.Z);
                    datas.Add(c);
                }

            }
            try
            {
                this.cellEditor1.FillDatas(datas);
                CellEditorDefaultHeader header = new CellEditorDefaultHeader();
                header.Header1 = "福满堂";
                header.Header2 = "第一排";
                this.cellEditor1.Header = header;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
