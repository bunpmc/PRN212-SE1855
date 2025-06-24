using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

using BusinessObject;
using Services;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for ProductWindow.xaml
    /// </summary>
    public partial class ProductWindow : Window
    {
        ProductService productService = new ProductService();
        bool isCompleted = false;
        public ProductWindow()
        {
            InitializeComponent();
            DisplayProducts();
        }

        private void DisplayProducts()
        {
            isCompleted = false;
            productService.GenerateSampleDataset();
            lvProduct.ItemsSource = productService.GetProducts();
            isCompleted = true;
        }

        private void btnThemSanPham_Click(object sender, RoutedEventArgs e)
        {
            isCompleted = false;
            MessageBox.Show("Ban muon them moi san pham");
            Product product = new Product();

            product.Id = int.Parse(txtId.Text);
            product.Name = txtName.Text;
            product.Price = double.Parse(txtPrice.Text);
            product.Quantity = int.Parse(txtQuantity.Text);

            bool ret = productService.SaveProduct(product);

            if(ret)
            {
                lvProduct.ItemsSource = null;
                lvProduct.ItemsSource = productService.GetProducts();
            } else
            {
                MessageBox.Show("Co loi xay ra");
            }
            isCompleted = true;
        }

        private void lvProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (isCompleted == false)
            {
                return; //Cac tac vu thay doi du lieu chua xong
            }

            if (e.AddedItems.Count < 0) {
                return;
            }

            //lay dong du lieu dang chon ra
            //vi ta binding list product nen item la Product:
            Product p = e.AddedItems[0] as Product;
            if(p == null)
            {
                return;
            }

            txtId.Text = p.Id.ToString();
            txtQuantity.Text = p.Quantity.ToString();
            txtName.Text = p.Name.ToString();
            txtPrice.Text = p.Price.ToString();
            
        }

        private void btnSua_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                isCompleted = false;

                int id = int.Parse(txtId.Text);
                string name = txtName.Text;
                double price = double.Parse(txtPrice.Text);
                int quantity = int.Parse(txtQuantity.Text);

                Product p = new Product()
                {
                    Id = id,
                    Name = name,
                    Quantity = quantity,
                    Price = price,
                };

                bool kq = productService.UpdateProduct(p);

                if (kq == true)
                {
                    lvProduct.ItemsSource = null;
                    lvProduct.ItemsSource = productService.GetProducts();
                }

                isCompleted = true;

            } catch(Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult ret = MessageBox.Show("Muon xoa san pham?", "Xac nhan xoa", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (ret == MessageBoxResult.No) {
                return;
            }

            try
            {
                isCompleted = false;

                Product p = new Product();
                p.Id = int.Parse(txtId.Text);

                bool kq = productService.DeleteProduct(p);

                if (kq == true)
                {
                    lvProduct.ItemsSource = null;
                    lvProduct.ItemsSource = productService.GetProducts();
                }
                isCompleted=true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
