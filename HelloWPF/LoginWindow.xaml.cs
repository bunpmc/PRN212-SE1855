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

namespace HelloWPF
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnDangNhap_Click(object sender, RoutedEventArgs e)
        {
            //gia vo lam dang nhap
            //Neu thanh cong => MainWindow
            //Neu that bai => Fail
            if(txtUserName.Text == "obama" && txtPassword.Password == "123")
            {
                //mo man hinh MainWindow
                MainWindow mainWindow = new MainWindow();   
                mainWindow.Show();
                Close();
            } else
            {
                MessageBox.Show("Dang nhap that bai", "Loi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
