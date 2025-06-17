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

namespace ListWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<int> dsDuLieu = new List<int>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            int x = int.Parse(txtGiaTri.Text);
            dsDuLieu.Add(x);
            HienThiDanhSach();
            txtGiaTri.Text = "";
        }
        void HienThiDanhSach()
        {
            _1stDuLieu.Items.Clear();
            for (int i = 0; i < dsDuLieu.Count; i++)
            {
                int x = dsDuLieu[i];
                _1stDuLieu.Items.Add(x);
            }
        }

        private void btnChen_Click(object sender, RoutedEventArgs e)
        {
            int x = int.Parse(txtGiaTriChen.Text);
            int vt = int.Parse(txtViTriChen.Text);
            dsDuLieu.Insert(vt, x);
            HienThiDanhSach();
            txtViTriChen.Text = "";
            txtGiaTriChen.Text = "";
        }

        private void btnSapXepTang_Click(object sender, RoutedEventArgs e)
        {
            dsDuLieu.Sort();
            HienThiDanhSach();
        }

        private void btnSapXepGiam_Click(object sender, RoutedEventArgs e)
        {
            dsDuLieu.Sort();
            dsDuLieu.Reverse();
            HienThiDanhSach();
        }

        private void btnXoa1PhanTu_Click(object sender, RoutedEventArgs e)
        {
            if(_1stDuLieu.SelectedIndex == -1)
            {
                MessageBox.Show("Phai chon phan tu moi xoa duoc", "Thong bao loi", MessageBoxButton.OK);
                return;
            }
            dsDuLieu.RemoveAt(_1stDuLieu.SelectedIndex);
            HienThiDanhSach();
        }

        private void btnXoaNhieuPhanTu_Click(object sender, RoutedEventArgs e)
        {

            if (_1stDuLieu.SelectedIndex == -1)
            {
                MessageBox.Show("Phai chon phan tu moi xoa duoc", "Thong bao loi", MessageBoxButton.OK);
                return;
            }
            while(_1stDuLieu.SelectedItems.Count > 0)
            {
                int data = (int)_1stDuLieu.SelectedItems[0];
                dsDuLieu.Remove(data);
                _1stDuLieu.Items.Remove(data);
            }
        }

        private void btnXoaToanBoPhanTu_Click(object sender, RoutedEventArgs e)
        {
            dsDuLieu.Clear();
            HienThiDanhSach();
        }
    }
}