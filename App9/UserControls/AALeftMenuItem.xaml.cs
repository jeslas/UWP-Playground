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

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace App9.UserControls
{
    public sealed partial class AALeftMenuItem : UserControl
    {
        public Models.Nav Nav { get { return this.DataContext as Models.Nav; } }
        public AALeftMenuItem()
        {
            this.InitializeComponent();
            this.DataContextChanged += AALeftMenuItem_DataContextChanged;
        }

        private void AALeftMenuItem_DataContextChanged(FrameworkElement sender, DataContextChangedEventArgs args)
        {
            this.Bindings.Update();
        }
    }
}
