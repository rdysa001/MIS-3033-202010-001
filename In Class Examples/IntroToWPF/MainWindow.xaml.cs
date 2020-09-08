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
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace IntroToWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            txtFavoriteColor.Text = string.Empty;
            txtName.Clear();
            btnClickMe.IsEnabled = false;
                  


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string message = $"Hey {txtName.Text} that's cool your favorite color is {txtFavoriteColor.Text}!";
            //var response = MessageBox.Show("You clicked me!", "Enter).MessageBoxButton.YesNoCancel;
            MessageBox.Show(message, "!Welcome to MIS-3033!");
        }

        private void txtKeyDown(object sender, KeyEventArgs e)
        {
            if(ShouldWeEnableTheButton() == true)
            {
                btnClickMe.IsEnabled = true;
            }
            else
            {
                btnClickMe.IsEnabled = ShouldWeEnableTheButton();
            }
        }

        private bool ShouldWeEnableTheButton()
        {
            bool result = false;
            if (txtFavoriteColor.Text != string.Empty && txtName.Text != string.Empty)
            {
                result = true;
            }

            return result;
        }
    }
}
