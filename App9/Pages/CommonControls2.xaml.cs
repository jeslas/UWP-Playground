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
    public sealed partial class CommonControls2 : Page
    {
        public CommonControls2()
        {
            this.InitializeComponent();
        }

        private void Cl_SelectedDatesChanged(CalendarView sender, CalendarViewSelectedDatesChangedEventArgs args)
        {
            var x = sender.SelectedDates.Select(p => p.Date.Month.ToString() + "/" + p.Date.Day.ToString()).ToArray();
            Date.Text = String.Join(", ", x);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            fll.Hide();
        }

        
        private void AutoSuggestBox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            string[] x = new string[] { "Anders", "Andreas", "Ronni", "Ronja" };
            sender.ItemsSource = x.Where(p => p.StartsWith(sender.Text)).ToArray();
        }

        private void Sl_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            SlTxt.Text = ((Slider)sender).Value.ToString();
        }
    }
}
