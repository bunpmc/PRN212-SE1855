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
using BusinessObjects_EF_IO;
using DataAccessLayer_EF_IO;
using Services_EF_IO;
using System.IO;

namespace WpfApp_EF_IO
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        MyStoreContext context = new MyStoreContext();

        public LoginWindow()
        {
            InitializeComponent();
            RestoreLoginInformation();
        }

        private void RestoreLoginInformation()
        {
            string fileName = "login.txt";
            if(File.Exists(fileName))
            {
                StreamReader reader = new StreamReader(fileName, Encoding.UTF8);
                string line = reader.ReadLine();
                if (line != null)
                {
                    string[] parts = line.Split(';');
                    if (parts.Length == 3 && parts[2] == "True")
                    {
                        txtEmail.Text = parts[0];
                        txtPassword.Password = parts[1];
                        chkLoginSave.IsChecked = bool.Parse(parts[2]);
                    }
                }
                reader.Close();
            }
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string email = txtEmail.Text.Trim();
                string password = txtPassword.Password.Trim();

                IAccountMemberService iAccountMemberService = new AccountMemberService();
                AccountMember accountMember = iAccountMemberService.Login(email, password);
                if (accountMember == null)
                {
                    MessageBox.Show("Invalid email or password.", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    Close();
                    SaveLoginInformation(accountMember, chkLoginSave.IsChecked.Value);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }
        void SaveLoginInformation(AccountMember accountMember, bool saved)
        {
            string data = $"{accountMember.EmailAddress};{accountMember.MemberPassword};{saved}";
            StreamWriter writer = new StreamWriter("login.txt", false, Encoding.UTF8);
            writer.WriteLine(data);
            writer.Close();

        }
    }
}
