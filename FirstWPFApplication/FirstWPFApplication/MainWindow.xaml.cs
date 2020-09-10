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

namespace FirstWPFApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            DateTime userAge = new DateTime();
            nowDate = DateTime.Now;
        }

        private void btnCalc_Click(object sender, RoutedEventArgs e)
        {
            string response = $"Hey, {boxName.Text}! You are {userAge} years old!";
            userAge = dateSelectBday()
        }
    }
}
