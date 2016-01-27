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
    public sealed partial class CommonControls : Page
    {
        public CommonControls()
        {
            this.InitializeComponent();
        }

        private void chk_Tapped(object sender, TappedRoutedEventArgs e)
        {
            chkTxt.Text = chk.IsChecked.ToString();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton rad = (RadioButton)sender;
            radTxt.Text = rad.Content.ToString();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbTxt == null) return;
            ComboBox box = (ComboBox)sender;
            cmbTxt.Text = ((ComboBoxItem)box.SelectedItem).Content.ToString();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItems = lb.Items.Cast<ListBoxItem>()
                .Where(x => x.IsSelected)
                .Select(t => t.Content.ToString())
                .ToArray();

            lbTxt.Text = String.Join(", ", selectedItems);
        }

        private void tgb_Click(object sender, RoutedEventArgs e)
        {
            tgbTxt.Text = tgb.IsChecked.ToString();
        }

        private void tsw_Tapped(object sender, TappedRoutedEventArgs e)
        {
        }

        private void tsw_Toggled(object sender, RoutedEventArgs e)
        {
            tswTxt.Text = tsw.IsOn ? tsw.OnContent.ToString() : tsw.OffContent.ToString();
        }
    }
}
