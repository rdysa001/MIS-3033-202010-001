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
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Collections.Concurrent;

namespace ChuckNorrisJoke
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string joke;
        private JokeAPI jokeAPI;
        public MainWindow()
        {
            InitializeComponent();
            string url = @"https://api.chucknorris.io/jokes/categories";
            List<string> categories = new List<string>();
            using (var client = new HttpClient())
            {
                string json = client.GetStringAsync(url).Result;

                categories = JsonConvert.DeserializeObject<List<string>>(json);
            }
            categories.Insert(0, "All");
            foreach (var item in categories)
            {
                cmboCategory.Items.Add(item);
            }
        }
        private void btnGetJoke_Click(object sender, RoutedEventArgs e)
        {
            if (cmboCategory.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a category.");
            }
            else if (cmboCategory.SelectedItem.ToString() == "All")
            {
                joke = @"https://api.chucknorris.io/jokes/random";
            }
            else
            {
                string category = cmboCategory.Text;
                joke = @"https://api.chucknorris.io/jokes/random?category=" + category;
            }

            using (var client2 = new HttpClient())
            {
                string jokeSelected = client2.GetStringAsync(joke).Result;
                jokeAPI = JsonConvert.DeserializeObject<JokeAPI>(jokeSelected);
            }
            txtJoke.Text = jokeAPI.value.ToString();
        }

        
    }
}
