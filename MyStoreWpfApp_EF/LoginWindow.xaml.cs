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

namespace MyStoreWpfApp_EF
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        MyStoreContext _context = new MyStoreContext();
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, RoutedEventArgs e)
        {
            string email = txtEmail.Text;
            string password = txtPassword.Password;

            AccountMember am = _context.AccountMembers
                .FirstOrDefault(a => a.EmailAddress == email && a.MemberPassword == password);

            if(am == null )
            {
                MessageBox.Show("Email or Password is incorrect!", "Failed Login", MessageBoxButton.OK,MessageBoxImage.Asterisk);
                return;
            } else
            {
                if(am.MemberRole == 1)
                {
                    MessageBox.Show("Login as Admin Successfully", "Success Login", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                    AdminWindow adminWindow = new AdminWindow();
                    adminWindow.Show();
                    Close();
                } else if(am.MemberRole == 2)
                {
                    //Staff
                    MessageBox.Show("Login as Staff Successfully", "Success Login", MessageBoxButton.OK, MessageBoxImage.Asterisk);

                }
                else
                {
                    MessageBox.Show("Login as Successfully", "Success Login", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                }
            }
        }
    }
}
