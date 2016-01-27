using App9.Models;
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
    public sealed partial class AdeptlyAdaptive : UserControl
    {
        public Girl Girl { get { return this.DataContext as Girl; } }
        public AdeptlyAdaptive()
        {
            this.InitializeComponent();
            this.DataContextChanged += AdeptlyAdaptive_DataContextChanged;
        }

        private void AdeptlyAdaptive_DataContextChanged(FrameworkElement sender, DataContextChangedEventArgs args)
        {
            this.Bindings.Update();
        }
    }
}
