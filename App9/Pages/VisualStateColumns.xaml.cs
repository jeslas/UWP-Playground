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
    public sealed partial class VisualStateColumns : Page
    {
        public VisualStateColumns()
        {
            this.InitializeComponent();
            Lipsum1.Text = Helpers.LoremIpsum(50, 80);
            Lipsum2.Text = Helpers.LoremIpsum(20, 100);
            Lipsum3.Text = Helpers.LoremIpsum(40, 90);
        }
    }
}
