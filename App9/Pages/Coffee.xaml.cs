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
    public sealed partial class Coffee : Page
    {
        public Coffee()
        {
            this.InitializeComponent();
        }

        private string chois1;
        private string chois2;
        private string chois3;

        private void MenuFlyoutItem_Click(object sender, RoutedEventArgs e)
        {
            MenuFlyoutItem x = (MenuFlyoutItem)sender;
            chois1 = x.Text;
            WriteResult();
        }

        private void MenuFlyoutItem_Click_1(object sender, RoutedEventArgs e)
        {
            MenuFlyoutItem x = (MenuFlyoutItem)sender;
            chois2 = x.Text;
            WriteResult();
        }

        private void MenuFlyoutItem_Click_2(object sender, RoutedEventArgs e)
        {
            MenuFlyoutItem x = (MenuFlyoutItem)sender;
            chois3 = x.Text;
            WriteResult();
        }

        private void WriteResult()
        {
            if (!String.IsNullOrEmpty(chois1) && chois1 != "None")
            {
                Result.Text = chois1;
                if (!String.IsNullOrEmpty(chois2) && chois2 != "None")
                    Result.Text += " + " + chois2;
                else
                    Result.Text += String.Empty;
                if (!String.IsNullOrEmpty(chois3) && chois3 != "None")
                    Result.Text += " + " + chois3;
                else
                    Result.Text += String.Empty;

            }
            else
                Result.Text = String.Empty;
        }
    }
}
