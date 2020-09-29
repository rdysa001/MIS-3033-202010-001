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
using Newtonsoft.Json;

namespace PokeApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            string url = @"https://pokeapi.co/api/v2/pokemon?offset=0&limit=1100";
            PokemonNameAPI api;
            using (var client = new HttpClient())
            {
                string json = client.GetStringAsync(url).Result;

                api = JsonConvert.DeserializeObject<PokemonNameAPI>(json);

            }

            foreach (var name in api.results)
            {
                lstPoke.Items.Add(name);
            }
        }

        private void btnGetInfo_Click(object sender, RoutedEventArgs e)
        {
            Monster selectedMonster = (Monster)lstPoke.SelectedItem;
            

            string selectedUrl = selectedMonster.url;
            info infoAPI;
            using (var client2 = new HttpClient())
            {
                string infoSelected = client2.GetStringAsync(selectedUrl).Result;
                infoAPI = JsonConvert.DeserializeObject<info>(infoSelected);
            }
            txtHeight.Text = infoAPI.height.ToString();
            txtWeight.Text = infoAPI.weight.ToString();

            
            Uri uriFront = new Uri(infoAPI.front_default);
            Uri uriBack = new Uri(infoAPI.back_default);
            BitmapImage pictureFront = new BitmapImage(uriFront);
            BitmapImage pictureBack = new BitmapImage(uriBack);

            imgSprite.Source = pictureFront;
        }
    }
}
