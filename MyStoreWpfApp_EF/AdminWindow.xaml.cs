using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MyStoreWpfApp_EF.Models;
using static Microsoft.EntityFrameworkCore.Query.Internal.ExpressionTreeFuncletizer;

namespace MyStoreWpfApp_EF
{
    /// <summary>
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        MyStoreContext context = new MyStoreContext();
        public AdminWindow()
        {
            InitializeComponent();
            LoadCategoryIntoTreeView();
        }

        private void LoadCategoryIntoTreeView()
        {
            tvCategory.Items.Clear();
            TreeViewItem root = new TreeViewItem();
            root.Header = "Kho Cat Lai";
            tvCategory.Items.Add(root);
            //Dung EF truy van de de lay danh sach Category va nap len cay
            var categories = context.Categories.ToList();
            foreach (var category in categories)
            {
                TreeViewItem cat_node = new TreeViewItem();
                cat_node.Header = category.CategoryName;
                cat_node.Tag = category;
                root.Items.Add(cat_node);

                var products = context.Products.Where(p => p.CategoryId == category.CategoryId).ToList();
                foreach (var product in products)
                {
                    TreeViewItem product_node = new TreeViewItem();
                    product_node.Header = product.ProductName;
                    product_node.Tag = product;
                    cat_node.Items.Add(product_node);
                }
            }
            root.ExpandSubtree();

        }

        private void tvCategory_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (e.NewValue == null)
            {
                return;
            }

            TreeViewItem item = e.NewValue as TreeViewItem;
            Category category = item.Tag as Category;

            if(category != null)
            {
                LoadProductIntoListView(category);
            }

            Product product = item.Tag as Product;  
            if (product != null)
            {
                // var products = new List<Product> {product};
                var products = new List<Product> ();
                products.Add(product);
                lvProduct.ItemsSource = null;
                lvProduct.ItemsSource = products;
            }
            
        }

        private void LoadProductIntoListView(Category category)
        {
            var products = context.Products
                .Where(p => p.CategoryId == category.CategoryId)
                .ToList();
            lvProduct.ItemsSource = null;
            lvProduct.ItemsSource = products;
        }

        private void lvProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count < 0) return;

            Product product = e.AddedItems[0] as Product;
            if (product == null) return;

            DisplayProductDetail(product);
        }

        private void DisplayProductDetail(Product product)
        {
            if (product == null)
            {
                txtMaSanPham.Text = "";
                txtTenSanPham.Text = "";
                txtSoLuong.Text = "";
                txtDonGia.Text = "";
            } else
            {
                txtMaSanPham.Text = product.ProductId + "";
                txtTenSanPham.Text = product.ProductName + "" ;
                txtSoLuong.Text = product.UnitsInStock?.ToString() + "";
                txtDonGia.Text = product.UnitPrice?.ToString() + "";
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            DisplayProductDetail(null);
            txtMaSanPham.Focus();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try {
                //Buoc 1: Tao doi tuong san pham
                //Buoc 2: Phai biet san pham gan vao Danh muc nao
                // Buoc 3: Luu doi tuong
                //Buoc 4: Cap nhat lai giao dien

                Product product = new Product();
                //ID trong db tu dong tang nen khong can gan
                product.ProductName = txtTenSanPham.Text;
                product.UnitsInStock = short.Parse(txtSoLuong.Text);
                product.UnitPrice = decimal.Parse(txtDonGia.Text);

                //Lay Category tu TreeView
                TreeViewItem cate_node_selected = tvCategory.SelectedItem as TreeViewItem;
                if (cate_node_selected == null)
                {
                    MessageBox.Show("Vui long chon danh muc san pham!",
                        "Thong bao luu bi loi",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                Category category = cate_node_selected?.Tag as Category;
                if (cate_node_selected == null || category == null)
                {
                    MessageBox.Show("Vui long chon danh muc san pham!",
                        "Thong bao luu bi loi",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                product.CategoryId = category.CategoryId;
                context.Products.Add(product);
                context.SaveChanges();

                TreeViewItem product_node = new TreeViewItem();
                product_node.Header = product.ProductName;
                product_node.Tag = product;

                cate_node_selected.Items.Add(product_node);

                LoadProductIntoListView(category);
            } catch (Exception ex)
            {
                MessageBox.Show("Loi goi: " + ex.Message,
                    "Loi khi luu san pham",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = int.Parse
                    (txtMaSanPham.Text);
                Product product = context.Products.FirstOrDefault(p => p.ProductId == id);
                if (product == null)
                {
                    MessageBox.Show("Khong tim thay san pham can cap nhat!",
                        "Thong bao cap nhat loi",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                product.ProductName = txtTenSanPham.Text;
                product.UnitsInStock = short.Parse(txtSoLuong.Text);
                product.UnitPrice = decimal.Parse(txtDonGia.Text);

                context.SaveChanges();

                //Cap nhat lai giao dien
                TreeViewItem cate_node_selected = tvCategory.SelectedItem as TreeViewItem;

                if (cate_node_selected != null)
                {
                    Category category = cate_node_selected.Tag as Category;
                    if (category != null)
                    {
                        cate_node_selected.Items.Clear();

                        var products = context.Products
                            .Where(p => p.CategoryId == category.CategoryId)
                            .ToList();
                        foreach (var product_new in products)
                        {
                            TreeViewItem product_node = new TreeViewItem();
                            product_node.Header = product_new.ProductName;
                            product_node.Tag = product_new;
                            cate_node_selected.Items.Add(product_node);
                        }
                        LoadProductIntoListView(category);
                    }
                }
            } catch (Exception ex)
            {
                MessageBox.Show("Loi cap nhat: " + ex.Message,
                    "Loi cap nhat san pham",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    }
}
