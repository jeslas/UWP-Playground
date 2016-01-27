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
    public sealed partial class GridChallenge : Page
    {
        public GridChallenge()
        {
            this.InitializeComponent();
            this.Loaded += GridChallenge_Loaded;
        }

        private void GridChallenge_Loaded(object sender, RoutedEventArgs e)
        {
            object o = null;
            bool success = App.propbag.TryGetValue("Name", out o);
            if (success)
                NameVal.Text = (String)o;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            object o = null;
            bool exist = App.propbag.TryGetValue("Name", out o);
            if (exist)
                App.propbag["Name"] = NameVal.Text;
            else
                App.propbag.Add("Name", NameVal.Text);
            Frame.Navigate(typeof(BlankPage1), NameVal.Text);
        }
    }
}
