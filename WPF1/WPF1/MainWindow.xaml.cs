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

namespace WPF1
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

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            EntryForm entryForm = new EntryForm(txtName.Text, txtAddress.Text, Convert.ToInt32(txtZip.Text));
            //EntryForm(txtName.Text, txtAddress.Text, Convert.ToInt32(txtZip.Text))

            listApps.Items.Add(entryForm);
        }

        private void listApps_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
