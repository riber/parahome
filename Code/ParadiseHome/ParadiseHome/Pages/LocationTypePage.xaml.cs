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
using ParadiseHome.BLL;
using ParadiseHome.Common.Model.Basic;
using ParadiseHome.Controls;
using System.Windows.Media.Animation;

namespace ParadiseHome.Pages
{
    /// <summary>
    /// LocationTypePage.xaml 的交互逻辑
    /// </summary>
    public partial class LocationTypePage : BasePage
    {

        private LocationTypeBLL.OperationMode _operationMode = LocationTypeBLL.OperationMode.None;
        private Locationtype _currentSelectNode;

        public LocationTypePage()
        {
            InitializeComponent();
            //GridLength length = new GridLength(3, GridUnitType.Star);
            //gMain.ColumnDefinitions[2].Width = length;
            LoadAndShowAllNodes();
        }

        private void LoadAndShowAllNodes()
        {
            spContainer.Children.Clear();
            tbCurrentTitle.Text = "未操作";
            txtComment.Text = "";
            txtName.Text = "";

            List<Locationtype> typeNodes = LocationTypeBLL.GetAll();
            if (typeNodes == null || typeNodes.Count == 0)
            {
                // 无元素则可添加初始化菜单
                miInitialAddNode.Visibility = Visibility.Visible;
                return;
            }

            miInitialAddNode.Visibility = Visibility.Collapsed;
            // 利用IComparable接口对实体按深度进行排序
            typeNodes.Sort();

            int index = 0;
            foreach(Locationtype typeNode in typeNodes)
            {
                // 绑定实体属性
                TextBlockShape tbShape = new TextBlockShape();
                tbShape.TextContent.Text = typeNode.TypeName;
                tbShape.Cursor = Cursors.Hand;

                // 构建菜单
                ContextMenu cmtbShape = new ContextMenu();

                MenuItem miDelete = new MenuItem();
                miDelete.Tag = typeNode;
                miDelete.Header = "删除当前结点";
                miDelete.Click += new RoutedEventHandler(miDelete_Click);
                cmtbShape.Items.Add(miDelete);

                MenuItem miInsertAfter = new MenuItem();
                miInsertAfter.Tag = typeNode;
                miInsertAfter.Header = "在后一个位置插入结点";
                miInsertAfter.Click += new RoutedEventHandler(miInsertAfter_Click);
                cmtbShape.Items.Add(miInsertAfter);

                MenuItem miInsertBefore = new MenuItem();
                miInsertBefore.Tag = typeNode;
                miInsertBefore.Header = "在前一个位置插入结点";
                miInsertBefore.Click += new RoutedEventHandler(miInsertBefore_Click);
                cmtbShape.Items.Add(miInsertBefore);

                MenuItem miModify = new MenuItem();
                miModify.Tag = typeNode;
                miModify.Header = "修改当前结点";
                miModify.Click += new RoutedEventHandler(miModify_Click);
                cmtbShape.Items.Add(miModify);

                tbShape.ContextMenu = cmtbShape;
                spContainer.Children.Add(tbShape);

                // 绑定箭头控件
                if (index++ < typeNodes.Count - 1)
                {
                    Arrow arrow = new Arrow();
                    arrow.X1 = 5;
                    arrow.X2 = 5;
                    arrow.Y1 = 0;
                    arrow.Y2 = 30;
                    arrow.HeadWidth = 15;
                    arrow.HeadHeight = 5;
                    arrow.Width = 10;
                    arrow.StrokeThickness = 2;
                    arrow.Stroke = (new SolidColorBrush(Color.FromArgb(0xff, 0x3f, 0x6d, 0x66)));
                    spContainer.Children.Add(arrow);
                }
            }
        }

        void miModify_Click(object sender, RoutedEventArgs e)
        {
            if (sender != null && sender is MenuItem)
            {
                if (((MenuItem)sender).Tag != null && ((MenuItem)sender).Tag is Locationtype)
                {
                    Locationtype typeNode = ((MenuItem)sender).Tag as Locationtype;
                    tbCurrentTitle.Text = "修改结点:" + typeNode.TypeName;
                    txtName.Text = typeNode.TypeName;
                    txtComment.Text = typeNode.Comment;
                    _currentSelectNode = typeNode;
                    _operationMode = LocationTypeBLL.OperationMode.Modify;
                    Storyboard sb = gMain.FindResource("sbShowEditCol") as Storyboard;
                    sb.Begin();
                }
            }
        }

        void miInsertBefore_Click(object sender, RoutedEventArgs e)
        {
            if (sender != null && sender is MenuItem)
            {
                if (((MenuItem)sender).Tag != null && ((MenuItem)sender).Tag is Locationtype)
                {
                    Locationtype typeNode = ((MenuItem)sender).Tag as Locationtype;
                    tbCurrentTitle.Text = "插入到结点:" + typeNode.TypeName + "前";
                    txtName.Text = "";
                    txtComment.Text = "";
                    _currentSelectNode = typeNode;
                    _operationMode = LocationTypeBLL.OperationMode.InsertBefore;
                    Storyboard sb = gMain.FindResource("sbShowEditCol") as Storyboard;
                    sb.Begin();
                }
            }
        }

        void miInsertAfter_Click(object sender, RoutedEventArgs e)
        {
            if (sender != null && sender is MenuItem)
            {
                if (((MenuItem)sender).Tag != null && ((MenuItem)sender).Tag is Locationtype)
                {
                    Locationtype typeNode = ((MenuItem)sender).Tag as Locationtype;
                    tbCurrentTitle.Text = "插入到结点:" + typeNode.TypeName + "后";
                    txtName.Text = "";
                    txtComment.Text = "";
                    _currentSelectNode = typeNode;
                    _operationMode = LocationTypeBLL.OperationMode.InsertAfter;
                    Storyboard sb = gMain.FindResource("sbShowEditCol") as Storyboard;
                    sb.Begin();
                }
            }
        }

        void miDelete_Click(object sender, RoutedEventArgs e)
        {
            if (sender != null && sender is MenuItem)
            {
                if (((MenuItem)sender).Tag != null && ((MenuItem)sender).Tag is Locationtype)
                {
                    Locationtype typeNode = ((MenuItem)sender).Tag as Locationtype;
                    if (MessageBox.Show("你确定要删除结点:" + typeNode.TypeName 
                        + "？", "确认", MessageBoxButton.OKCancel) == MessageBoxResult.OK) ;
                    {
                        LocationTypeBLL.Delete(typeNode);
                        LoadAndShowAllNodes();
                    }
                }
            }
        }

        private void miInitialAddNode_Click(object sender, RoutedEventArgs e)
        {
            tbCurrentTitle.Text = "添加初始化节点";
            _operationMode = LocationTypeBLL.OperationMode.Initial;
            Storyboard sb = gMain.FindResource("sbShowEditCol") as Storyboard;
            sb.Begin();
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            Locationtype typeNode = new Locationtype
            {
                TypeName = txtName.Text,
                Comment = txtComment.Text
            };

            bool oprRes = true;

            switch(_operationMode)
            {
                case LocationTypeBLL.OperationMode.Initial:
                    typeNode.LocationDepth = 0;
                    oprRes = LocationTypeBLL.Insert(typeNode, _operationMode);
                    break;
                case LocationTypeBLL.OperationMode.InsertAfter:
                case LocationTypeBLL.OperationMode.InsertBefore:
                    typeNode.LocationDepth = _currentSelectNode.LocationDepth;
                    oprRes = LocationTypeBLL.Insert(typeNode, _operationMode);
                    break;
                case LocationTypeBLL.OperationMode.Modify:
                    typeNode.ID = _currentSelectNode.ID;
                    typeNode.LocationDepth = _currentSelectNode.LocationDepth;
                    typeNode.locationtypecol = _currentSelectNode.locationtypecol;
                    oprRes = LocationTypeBLL.Update(typeNode);
                    break;
                default:
                    break;
            }

            _operationMode = LocationTypeBLL.OperationMode.None;
            _currentSelectNode = null;
            LoadAndShowAllNodes();
            Storyboard sb = gMain.FindResource("sbHideEditCol") as Storyboard;
            sb.Begin();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            _operationMode = LocationTypeBLL.OperationMode.None;
            _currentSelectNode = null;
            LoadAndShowAllNodes();
            Storyboard sb = gMain.FindResource("sbHideEditCol") as Storyboard;
            sb.Begin();
        }
    }
}
