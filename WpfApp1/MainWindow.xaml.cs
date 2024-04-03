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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.EntityAdonetModels;
using WpfApp1.Pages;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AdoNetProjectEntitie _db = new AdoNetProjectEntitie();

        public static DataGrid datagrid;
        public MainWindow()
        {
            InitializeComponent();
            LoadData();
        }

        public void LoadData()
        {
            DGridCustomer.ItemsSource = _db.Customers.ToList();
            datagrid = DGridCustomer;
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            int ID = (DGridCustomer.SelectedItem as Customer).id;
            EditDataPage editDataPage = new EditDataPage(ID);
            editDataPage.ShowDialog();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            int ID = (DGridCustomer.SelectedItem as Customer).id;
            var deleteCustomer = _db.Customers.Where(m => m.id == ID).Single();
            _db.Customers.Remove(deleteCustomer);
            _db.SaveChanges();
            DGridCustomer.ItemsSource = _db.Customers.ToList();
            MessageBox.Show("Delete Data Success!", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddDataWin addDataWin = new AddDataWin();
            addDataWin.ShowDialog();
        }

        private void TboxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            var result = _db.Customers.Where(x => x.Name.Contains(TboxSearch.Text) || x.Address.Contains(TboxSearch.Text) || x.Phone.Contains(TboxSearch.Text)).ToList();
            DGridCustomer.ItemsSource = result;
        }
    }
}
