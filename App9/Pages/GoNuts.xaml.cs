using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace App9.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class GoNuts : Page
    {
        public GoNuts()
        {
            this.InitializeComponent();
            MainStage.Navigate(typeof(App9.Pages.Donuts));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainStage.Navigate(typeof(App9.Pages.Donuts));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainStage.Navigate(typeof(App9.Pages.Coffee));
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MainStage.Navigate(typeof(App9.Pages.Schedule));
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            MainStage.Navigate(typeof(App9.Pages.Complete));
        }
    }
}
