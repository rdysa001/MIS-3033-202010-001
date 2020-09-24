using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

namespace JSON___RickAndMorty
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            string url = @"https://rickandmortyapi.com/api/character/";
            RickAndMortyAPI api;
            using (var client = new HttpClient())
            {
                string results = client.GetStringAsync(url).Result;

                api = JsonConvert.DeserializeObject<RickAndMortyAPI>(results);

            }

            foreach (var character in api.results)
            {
                cmboselect.Items.Add(character);
            }
        }

        private void cmboselect_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Character selectedCharacter = (Character)cmboselect.SelectedItem;

            Uri uri = new Uri(selectedCharacter.image);
            BitmapImage picture = new BitmapImage(uri);

            imgChar.Source = picture;
            lblInfo.Content = $"{selectedCharacter.name}";


            //imgChar.Source = new BitmapImage(new Uri(selectedCharacter.image));
        }
    }
}
