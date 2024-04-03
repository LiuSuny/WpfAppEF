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
using WpfApp1.EntityAdonetModels;

namespace WpfApp1.Pages
{
    /// <summary>
    /// Interaction logic for AddDataWin.xaml
    /// </summary>
    public partial class AddDataWin : Window
    {
        AdoNetProjectEntitie _db = new AdoNetProjectEntitie();
        public AddDataWin()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void BtnSubmit_Click(object sender, RoutedEventArgs e)
        {
            Customer newCustomer = new Customer()
            {
                Name = TBName.Text,
                Address = TBAddress.Text,
                Phone = TBPhone.Text,
            };
            _db.Customers.Add(newCustomer);
            _db.SaveChanges();
            MainWindow.datagrid.ItemsSource = _db.Customers.ToList();
            MessageBox.Show("Data Submitted!", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();
        }
    }
}
