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
    public sealed partial class GridStackChallenge : Page
    {
        public GridStackChallenge()
        {
            this.InitializeComponent();
            this.Loaded += GridStackChallenge_Loaded;
        }

        private void GridStackChallenge_Loaded(object sender, RoutedEventArgs e)
        {
            Txt1.Text = Helpers.LoremIpsum(40, 50);
            Txt2.Text = Helpers.LoremIpsum(40, 50);
            Txt3.Text = Helpers.LoremIpsum(40, 50);
        }
    }
}
