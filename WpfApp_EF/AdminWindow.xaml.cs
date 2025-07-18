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
using BusinessObjects_EF;
using Microsoft.Windows.Themes;
using Services_EF;

namespace WpfApp_EF
{
    /// <summary>
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        IProductService productService = new ProductService();
        ICategoryService categoryService = new CategoryService();

        bool is_loaded_product_completed = false;
        Category selected_category = null;
        public AdminWindow()
        {
            InitializeComponent();
            is_loaded_product_completed = false;
            LoadCategoriesAndProductsIntoTreeView();
            is_loaded_product_completed = true;
        }

        private void LoadCategoriesAndProductsIntoTreeView()
        {
            is_loaded_product_completed = false;
            tvCategory.Items.Clear();

            TreeViewItem root = new TreeViewItem();
            root.Header = "Kho hang Binh Duong";
            tvCategory.Items.Add(root);

            // Load categories from the service
            List<Category> categories = categoryService.GetCategories();

            foreach (Category category in categories)
            {
                TreeViewItem categoryNode = new TreeViewItem();
                categoryNode.Header = category.CategoryName;
                categoryNode.Tag = category;
                root.Items.Add(categoryNode);

                List<Product> products = productService.GetProductByCategoryId(category.CategoryId);
                foreach (Product product in products)
                {
                    TreeViewItem productNode = new TreeViewItem();
                    productNode.Header = product.ProductName;
                    productNode.Tag = product;
                    categoryNode.Items.Add(productNode);
                }
            }
            root.ExpandSubtree();
            is_loaded_product_completed = true;
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtMaSanPham.Clear();
            txtTenSanPham.Clear();
            txtSoLuong.Clear();
            txtDonGia.Clear();
            txtMaSanPham.Focus();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TreeViewItem cate_item = tvCategory.SelectedItem as TreeViewItem;
                if (cate_item == null || selected_category == null)
                {
                    MessageBox.Show("Vui long chon danh muc san pham", "Loi", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                Product product = new Product
                {
                    ProductName = txtTenSanPham.Text,
                    UnitsInStock = short.Parse(txtSoLuong.Text),
                    UnitPrice = decimal.Parse(txtDonGia.Text),
                    CategoryId = selected_category.CategoryId
                };

                bool ret = productService.SaveProduct(product);

                if (ret == true)
                {
                    is_loaded_product_completed = false;
                    MessageBox.Show("Luu san pham thanh cong", "Thong bao", MessageBoxButton.OK, MessageBoxImage.Information);
                    TreeViewItem p_node = new TreeViewItem
                    {
                        Header = product.ProductName,
                        Tag = product
                    };

                    cate_item.Items.Add(p_node);

                    lvProduct.ItemsSource = null;
                    lvProduct.ItemsSource = productService.GetProductByCategoryId(selected_category.CategoryId);
                    is_loaded_product_completed = true;
                }
                else
                {
                    MessageBox.Show("Luu san pham that bai", "Loi", MessageBoxButton.OK, MessageBoxImage.Error);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Loi luu: {ex.Message}", "Loi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            // note: TRY CASE 2 IF THE USER SELECT A PRODUCT AND CLICK UPDATE BUTTON INSTEAD OF CATEGORY NODE
            try
            {
                TreeViewItem cate_item = tvCategory.SelectedItem as TreeViewItem;
                if (cate_item == null || selected_category == null)
                {
                    MessageBox.Show("Vui long chon danh muc san pham", "Loi", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
               
                Product p = new Product
                {
                    ProductId = int.Parse(txtMaSanPham.Text),
                    ProductName = txtTenSanPham.Text,
                    UnitsInStock = short.Parse(txtSoLuong.Text),
                    UnitPrice = decimal.Parse(txtDonGia.Text),
                    CategoryId = selected_category.CategoryId
                };

                bool ret = productService.UpdateProduct(p);
                if (ret == true)
                {
                    is_loaded_product_completed = false;
                    MessageBox.Show("Cap nhat san pham thanh cong", "Thong bao", MessageBoxButton.OK, MessageBoxImage.Information);
                    cate_item.Items.Clear();
                    lvProduct.ItemsSource = null;
                    var products = productService.GetProductByCategoryId(selected_category.CategoryId);
                    foreach (Product product in products)
                    {
                        TreeViewItem productNode = new TreeViewItem
                        {
                            Header = product.ProductName,
                            Tag = product
                        };
                        cate_item.Items.Add(productNode);
                    }
                    lvProduct.ItemsSource = products;
                    is_loaded_product_completed = true;
                }
                else
                {
                    MessageBox.Show("Cap nhat san pham that bai", "Loi", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Loi cap nhat: {ex.Message}", "Loi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaSanPham.Text))
            {
                MessageBox.Show("Vui long chon san pham can xoa", "Loi", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            int productId = int.Parse(txtMaSanPham.Text);
            MessageBoxResult result = MessageBox.Show("Ban co chac chan muon xoa san pham nay?", "Xac nhan xoa", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result != MessageBoxResult.Yes)
            {
                return;
            }
            bool ret = productService.DeleteProduct(productId);
            if(ret == true)
            {
                is_loaded_product_completed = false;
                MessageBox.Show("Xoa san pham thanh cong", "Thong bao", MessageBoxButton.OK, MessageBoxImage.Information);
                TreeViewItem cate_item = tvCategory.SelectedItem as TreeViewItem;
                if (cate_item != null)
                {
                    cate_item.Items.Clear();
                    lvProduct.ItemsSource = null;
                    var products = productService.GetProductByCategoryId(selected_category.CategoryId);
                    foreach (Product product in products)
                    {
                        TreeViewItem productNode = new TreeViewItem
                        {
                            Header = product.ProductName,
                            Tag = product
                        };
                        cate_item.Items.Add(productNode);
                    }
                    lvProduct.ItemsSource = products;
                }
                is_loaded_product_completed = true;
            }
            else
            {
                MessageBox.Show("Xoa san pham that bai", "Loi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void lvProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(is_loaded_product_completed == false) return;

            if (e.AddedItems.Count <= 0) return;
            
            Product selectedProduct = e.AddedItems[0] as Product;

            txtMaSanPham.Text = selectedProduct.ProductId.ToString();
            txtTenSanPham.Text = selectedProduct.ProductName;
            txtSoLuong.Text = selectedProduct.UnitsInStock.Value.ToString();
            txtDonGia.Text = selectedProduct.UnitPrice.Value.ToString();



        }

        private void tvCategory_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            is_loaded_product_completed = false;
            selected_category = null;
            if (e.NewValue == null) return;
            TreeViewItem item = e.NewValue as TreeViewItem;

            if (item == null) return;
            List<Product> products = null;
            object data = item.Tag;

            if (data == null)
            {
                //Nguoi dung nhan vao node goc root (Kho hang Binh Duong)
                //Hien thi san pham cua Danh muc vao ListView
                Category cate = data as Category;
                selected_category = cate;
                products = productService.GetProducts();
            }

            else if (data is Category category)
            {
                //Nguoi dung nhan vao node Danh muc
                products = productService.GetProductByCategoryId(category.CategoryId);
            }
            else if (data is Product)
            {
                //Nguoi dung nhan vao node San pham
                Product product = data as Product;
                products = new List<Product>();
                products.Add(product);
            }
            lvProduct.ItemsSource = null;
            lvProduct.ItemsSource = products;
            is_loaded_product_completed = true;
        }
    }
}
