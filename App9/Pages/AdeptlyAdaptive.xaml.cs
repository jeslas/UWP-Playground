using App9.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public sealed partial class AdeptlyAdaptive : Page
    {
        private int maxAge = 30;
        public ObservableCollection<Girl> Girls { get; set; }
        public List<Nav> Nav { get; set; }

        public int MaxAge
        {
            get
            {
                return maxAge;
            }

            set
            {
                maxAge = value;
            }
        }

        public AdeptlyAdaptive()
        {
            this.InitializeComponent();
            this.Girls = new ObservableCollection<Girl>();
            this.Girls = Helpers.GetRandomGirls(this.Girls, true, maxAge);
            this.Nav = new List<Nav>()
            {
                new Nav
                {
                    Id = 1,
                    Icon = "&#xE741;",
                    Label = "Maximum age 40"
                },
                new Nav
                {
                    Id = 2,
                    Icon = "&#xE748;",
                    Label = "Maximum age 25"
                }
            };
        }

        private void BtnMenu_Click(object sender, RoutedEventArgs e)
        {
            SpltLeftMenu.IsPaneOpen = !SpltLeftMenu.IsPaneOpen;
        }

        private void GridView_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox lb = (ListBox)sender;
            Nav item = (Nav)lb.SelectedItem;
            if (item.Id == 2)
                maxAge = 25;
            else
                maxAge = 40;
            this.Girls = Helpers.GetRandomGirls(this.Girls, true, maxAge);
        }
    }
}
