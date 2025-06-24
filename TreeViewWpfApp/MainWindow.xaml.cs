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
using TreeViewWpfApp.model;
namespace TreeViewWpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Dictionary<int, Category> categories = SampleDataset.GenerateDataset();
        public MainWindow()
        {
            InitializeComponent();
            DisplayDatasetOnTreeView();
        }

        private void DisplayDatasetOnTreeView()
        {
            tvCategory.Items.Clear();
            //tao goc cay truoc hoac khong tao 
            TreeViewItem root = new TreeViewItem();
            root.Header = "Kho hang Binh Duong";
            tvCategory.Items.Add(root);

            //vong lap so 1 nap danh muc
            foreach (KeyValuePair<int, Category> item in categories) {
                Category cate = item.Value;
                //tao node
                TreeViewItem node = new TreeViewItem();
                node.Header = cate.ToString();

                //dua node cate vao goc cay (root)
                root.Items.Add(node);

                //vong lap so 2 de nap product len node Danh muc:
                foreach (KeyValuePair<int, Product> subitem in cate.Products) { 
                    Product product = subitem.Value;

                    TreeViewItem pnode = new TreeViewItem();
                    pnode.Header = product.ToString();
                    node.Items.Add(pnode);
                }
            }
        }
    }
}