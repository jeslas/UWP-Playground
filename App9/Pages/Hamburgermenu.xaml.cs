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
    public sealed partial class Hamburgermenu : Page
    {
        public Hamburgermenu()
        {
            this.InitializeComponent();
            this.Loaded += Hamburgermenu_Loaded;
        }

        private void Hamburgermenu_Loaded(object sender, RoutedEventArgs e)
        {
            MainStage.Navigate(typeof(App9.Pages.RelativePanel));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            splt.IsPaneOpen = !splt.IsPaneOpen;
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(RelativePanel.IsSelected)
            {
                MainStage.Navigate(typeof(App9.Pages.RelativePanel));
            }
            else if(RoundImage.IsSelected)
            {
                MainStage.Navigate(typeof(App9.Pages.RoundImage));
            }
            else
            {
                MainStage.Navigate(typeof(App9.Pages.CommonControls));
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (MainStage.CanGoBack)
                MainStage.GoBack();
        }

        private void MainStage_Navigated(object sender, NavigationEventArgs e)
        {
            BackBtn.Visibility = MainStage.CanGoBack ? Visibility.Visible : Visibility.Collapsed;

            Type t = MainStage.CurrentSourcePageType;
            if (t == typeof(App9.Pages.RoundImage))
            {
                MainTitle.Text = "Round Image";
                RoundImage.IsSelected = true;
            }
            else if (t == typeof(App9.Pages.CommonControls))
            {
                MainTitle.Text = "Common Controls";
                CommonControls.IsSelected = true;
            }
            else
            {
                RelativePanel.IsSelected = true;
                MainTitle.Text = "Relative Panel";
            }
        }
    }
}
