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
    /// Interaction logic for EditDataPage.xaml
    /// </summary>
    public partial class EditDataPage : Window
    {
        AdoNetProjectEntitie _db = new AdoNetProjectEntitie();
        int ID;
        public EditDataPage(int CustomerID)
        {
            InitializeComponent();
            ID = CustomerID;

            var st = (from m in _db.Customers where m.id == ID select m).First();
            TBName.Text = st.Name;
            TBAddress.Text = st.Address;
            TBPhone.Text = st.Phone;
        }
      

        private void btnClose_Click_1(object sender, RoutedEventArgs e)
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
            Customer updateCustomerDB = (from m in _db.Customers where m.id == ID select m).Single();
            updateCustomerDB.Name = TBName.Text;
            updateCustomerDB.Address = TBAddress.Text;
            updateCustomerDB.Phone = TBPhone.Text;
            _db.SaveChanges();
            MainWindow.datagrid.ItemsSource = _db.Customers.ToList();
            MessageBox.Show("Edit Data Success!", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();
        }
    }
}
