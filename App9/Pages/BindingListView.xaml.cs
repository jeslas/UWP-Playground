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
    public sealed partial class BindingListView : Page
    {
        public ObservableCollection<Girl> Girls { get; set; }
        public BindingListView()
        {
            this.InitializeComponent();
            this.Girls = new ObservableCollection<Girl>(Helpers.GetGirls());
        }

        private void GridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            Girl g = e.ClickedItem as Girl;
            ResultTxt.Text = g.Name;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Girls.Add(new Girl() { Name = NameTxt.Text, Age = Int32.Parse(AgeTxt.Text), Image = ImageTxt.Text });
        }
    }
}
