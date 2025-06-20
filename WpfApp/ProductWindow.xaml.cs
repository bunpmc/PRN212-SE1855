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
        public ProductWindow()
        {
            InitializeComponent();
            DisplayProducts();
        }

        private void DisplayProducts()
        {
            productService.GenerateSampleDataset();
            lvProduct.ItemsSource = productService.GetProducts();
        }

        private void btnThemSanPham_Click(object sender, RoutedEventArgs e)
        {
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
        }
    }
}
