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

namespace WPF_Classes_2
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
            Toy newToy = new Toy();

            bool emptyBox = false;
            bool doubleBox = false;
            int n = 0;
            foreach (TextBox textBox in gridMain.Children.OfType<TextBox>())
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    n++;
                }
            }
            if (n==0)
            {
                emptyBox = true;
            }
            else
            {
                MessageBoxResult messageBoxResult = MessageBox.Show("One or more fields are empty.");
            }

            double t = 0;
            bool doubleCheck = double.TryParse(txtPrice.Text, out t);
            if (doubleCheck)
            {
                doubleBox = true;
            }
            else
            {
                MessageBoxResult messageBoxResult = MessageBox.Show("Price should be a double.");
            }

            if (emptyBox && doubleBox)
            {
                newToy.Manufacturer = txtManufacturer.Text;
                newToy.Name = txtName.Text;
                newToy.Price = Convert.ToDouble(txtPrice.Text);

                lstToys.Items.Add(newToy);
            }
        }

        private void lstToys_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Toy selectedToy = (Toy)lstToys.SelectedItem;
            MessageBoxResult messageBoxResult = MessageBox.Show(selectedToy.GetAisle());
        }
    }
}
