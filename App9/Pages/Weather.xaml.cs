using App9.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Notifications;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace App9.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Weather : Page
    {
        public Weather()
        {
            this.InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var location = await LocationManager.GetLocation();

            RootObject myWeather = await OpenWeatherAPIProxy.GetWeather(location.Coordinate.Latitude, location.Coordinate.Longitude);

            // Tile
            var url = String.Format("http://localhost:25580/api/weather?lat={0}&lon={1}", location.Coordinate.Latitude, location.Coordinate.Longitude);
            var tileContent = new Uri(url);
            var interval = PeriodicUpdateRecurrence.HalfHour;
            var updater = TileUpdateManager.CreateTileUpdaterForApplication();
            updater.StartPeriodicUpdate(tileContent, interval);


            res.Text = myWeather.name + " " + myWeather.main.temp + " " + myWeather.weather[0].id;
            if (myWeather.weather[0].id <= 300)
                wetBg.ImageSource = new BitmapImage(new System.Uri("/Assets/thunderstorm2_h.jpeg"));
            else if (myWeather.weather[0].id <= 400)
                wetBg.ImageSource = new BitmapImage(new System.Uri("/Assets/thunderstorm2_h.jpeg"));
            else if (myWeather.weather[0].id <= 500)
                wetBg.ImageSource = new BitmapImage(new Uri(this.BaseUri, "/Assets/thunderstorm2_h.jpeg"));
            else if (myWeather.weather[0].id <= 600)
                wetBg.ImageSource = new BitmapImage(new Uri(this.BaseUri, "/Assets/snow.jpg"));
            else if (myWeather.weather[0].id <= 700)
            {
                switch (myWeather.weather[0].id)
                {
                    case 701:
                        wetBg.ImageSource = new BitmapImage(new Uri(this.BaseUri, "/Assets/thunderstorm2_h.jpeg"));
                        break;
                    case 711:
                        wetBg.ImageSource = new BitmapImage(new Uri(this.BaseUri, "/Assets/thunderstorm2_h.jpeg"));
                        break;
                    case 721:
                        wetBg.ImageSource = new BitmapImage(new Uri(this.BaseUri, "/Assets/thunderstorm2_h.jpeg"));
                        break;
                    case 731:
                        wetBg.ImageSource = new BitmapImage(new Uri(this.BaseUri, "/Assets/thunderstorm2_h.jpeg"));
                        break;
                    case 741:
                        wetBg.ImageSource = new BitmapImage(new Uri(this.BaseUri, "/Assets/thunderstorm2_h.jpeg"));
                        break;
                    case 751:
                        wetBg.ImageSource = new BitmapImage(new Uri(this.BaseUri, "/Assets/thunderstorm2_h.jpeg"));
                        break;
                    case 761:
                        wetBg.ImageSource = new BitmapImage(new Uri(this.BaseUri, "/Assets/thunderstorm2_h.jpeg"));
                        break;
                    case 762:
                        wetBg.ImageSource = new BitmapImage(new Uri(this.BaseUri, "/Assets/thunderstorm2_h.jpeg"));
                        break;
                    case 771:
                        wetBg.ImageSource = new BitmapImage(new Uri(this.BaseUri, "/Assets/thunderstorm2_h.jpeg"));
                        break;
                }
                /*701 mist[[file: 50d.png]]
711 smoke[[file: 50d.png]]
721 haze[[file: 50d.png]]
731 sand, dust whirls[[file:50d.png]]
741	fog[[file:50d.png]]
751	sand[[file:50d.png]]
761	dust[[file:50d.png]]
762	volcanic ash[[file:50d.png]]
771	squalls[[file:50d.png]]
781*/
            }

            else if (myWeather.weather[0].id < 800)
                wetBg.ImageSource = new BitmapImage(new Uri(this.BaseUri, "/Assets/thunderstorm2_h.jpeg"));
            else if (myWeather.weather[0].id < 900)
                wetBg.ImageSource = new BitmapImage(new Uri(this.BaseUri, "/Assets/thunderstorm2_h.jpeg"));
            else
                wetBg.ImageSource = new BitmapImage(new Uri(this.BaseUri, "/Assets/thunderstorm2_h.jpeg"));


        }
    }
}
