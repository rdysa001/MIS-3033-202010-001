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

namespace _P__Classes_3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //This is the list of state abbreviations that the state combo box will use.
            List<string> states = new List<string>()
            {
                "AK", "AL", "AR", "AS", "AZ", "CA", "CO", "CT", "DC", "DE", "FL", "GA", "GU", "HI", "IA", "ID", "IL", "IN", "KS", "KY", "LA", "MA", "MD", "ME", "MI", "MN", "MO", "MP", "MS", "MT", "NC", "ND", "NE", "NH", "NJ", "NM", "NV", "NY", "OH", "OK", "OR", "PA", "PR", "RI", "SC", "SD", "TN", "TX", "UM", "UT", "VA", "VI", "VT", "WA", "WI", "WV", "WY"
            };
            cmbxState.ItemsSource = states;

            
        }

        private void listGrads_DoubleClick(object sender, RoutedEventArgs e)
        {
            
            
        }
        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            //These two bools will let the student be added to the listbox when the conditions are met for them to both be true.
            bool fieldSubmitToList = false;
            bool numSubmitToList = false;
            bool stateSubmitToList = false;

            //These loops pass each textbox control through to check for empty fields.
            //If empty, a red highlight will let the user know the FIRST field they missed.
            //When all boxes pass the test, the fieldSubmitToList bool will be changed to true.
            int n = 0;
            foreach (TextBox control in gridMain.Children.OfType<TextBox>())
            {
                if (string.IsNullOrWhiteSpace(control.Text))
                {
                    control.Background = Brushes.Red;
                    n++;
                }
                else
                {
                    control.Background = Brushes.Transparent;
                }
            }
            //Logical test to see if all the fields passed.
            if (n == 0)
            {
                fieldSubmitToList = true;
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("One or more fields is empty.");
            }

            //This section creates a bool list for the GPA, StNumber, and ZIP code and tests the data type for validity.
            //All bools are added to numParses after each is tested for data-type validity.
            //The list is then checked with .TrueForAll and if it passes, the numSubmitToList bool is changed to true.
            //If any of the entries data-types dont parse, a message window pops up to notify the user.
            int zeroNum = 0;
            double zeroDouble = 0;

            List<bool> numParses = new List<bool>();
            bool gpaGood = double.TryParse(txtGPA.Text, out zeroDouble);
            bool stGood = int.TryParse(txtStNumber.Text, out zeroNum);
            bool zipGood = int.TryParse(txtZip.Text, out zeroNum);
            numParses.Add(gpaGood);
            numParses.Add(stGood);
            numParses.Add(zipGood);

            if (numParses.TrueForAll(x => x))
            {
                //This checks that the user has entered a valid GPA (0.0-4.0).
                if ((Convert.ToDouble(txtGPA.Text)) <= 4 && (Convert.ToDouble(txtGPA.Text) >= 0))
                {
                    numSubmitToList = true;
                }
                else
                {
                    MessageBoxResult result = MessageBox.Show("Please enter a valid GPA (0.0-4.0).");
                }
            }
            if (gpaGood == false)
            {
                MessageBoxResult result = MessageBox.Show("The GPA field must be a number.");
            }
            if (stGood == false)
            {
                MessageBoxResult result = MessageBox.Show("The St. Number field must be a number.");
            }
            if (zipGood == false)
            {
                MessageBoxResult result = MessageBox.Show("The ZIP Code field must be a number.");
            }

            //This section checks that a state has been selected in the state combobox.
            if (cmbxState.SelectedItem is null)
            {
                MessageBoxResult result = MessageBox.Show("You must select a state.");
            }
            else
            {
                stateSubmitToList = true;
            }

            //If all tests (empty fields, parsed numerical fields, state selected, GPA within range) pass,
            //the student and their address are generated and the student infor is added to the list.
            if (fieldSubmitToList && numSubmitToList && stateSubmitToList)
            {
                Address address = new Address(Convert.ToInt32(txtStNumber.Text), txtStName.Text, cmbxState.Text, txtCity.Text, Convert.ToInt32(txtZip.Text));
                Student student = new Student(txtFirst.Text, txtLast.Text, txtMajor.Text, Convert.ToDouble(txtGPA.Text));
                student.Address = address;
                listGrads.Items.Add(student);
            }
        }
    }
}