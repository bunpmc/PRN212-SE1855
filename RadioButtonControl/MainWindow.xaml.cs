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

namespace RadioButtonControl
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnGui_Click(object sender, RoutedEventArgs e)
        {
            string binhChon = "";
            if (radRatTot.IsChecked == true)
            {
                binhChon = radRatTot.Content + "";
            }
            else if (radTot.IsChecked == true) {
                binhChon = radTot.Content + "";
            } else if (radTamDuoc.IsChecked == true)
            {
                binhChon = radTamDuoc.Content + "";
            } else if (radKhongTot.IsChecked == true){
                binhChon = radKhongTot.Content + "";
            }
            string gioiTinh = "";
            if (radNam.IsChecked == true) {
                gioiTinh = radNam.Content + "";
            } else if (radNu.IsChecked == true)
            {
                gioiTinh = radNu.Content + "";

            }

            string info = "Ban binh chon he thong = " + binhChon + Environment.NewLine;
            info += "Gioi tinh cua ban = " + gioiTinh;
            MessageBoxResult ret;
            ret = MessageBox.Show(info, "Moi ban xac nhan", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if(ret == MessageBoxResult.Yes)
            {

            }

        }

        private void btnHuy_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown(); //hoac Close;
        }
    }
}