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
            imgSprite.Source = null;
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

        private info infoAPI;
        public bool showFront = true;

        private void btnGetInfo_Click(object sender, RoutedEventArgs e)
        {
            switch (lstPoke.SelectedItem)
            {
                case null:
                    MessageBox.Show("Please select a Pokemon");
                    break;
                default:
                    Monster selectedMonster = (Monster)lstPoke.SelectedItem;

                    string selectedUrl = selectedMonster.url;
                    using (var client2 = new HttpClient())
                    {
                        string infoSelected = client2.GetStringAsync(selectedUrl).Result;
                        infoAPI = JsonConvert.DeserializeObject<info>(infoSelected);
                    }
                    txtHeight.Text = infoAPI.height.ToString();
                    txtWeight.Text = infoAPI.weight.ToString();

                    Uri uriFront = new Uri(infoAPI.sprites.front_default);
                    Uri uriBack = new Uri(infoAPI.sprites.back_default);
                    BitmapImage pictureFront = new BitmapImage(uriFront);
                    BitmapImage pictureBack = new BitmapImage(uriBack);
                    imgSprite.Source = pictureFront;
                    break;
            }
        }

        private void btnToggle_Click(object sender, RoutedEventArgs e)
        {
            Uri uriFront = new Uri(infoAPI.sprites.front_default);
            Uri uriBack = new Uri(infoAPI.sprites.back_default);
            BitmapImage pictureFront = new BitmapImage(uriFront);
            BitmapImage pictureBack = new BitmapImage(uriBack);
            if (!showFront)
            {
                imgSprite.Source = pictureFront;
            }
            else
            {
                imgSprite.Source = pictureBack;
            }
            showFront = !showFront;
        }
    }
}
