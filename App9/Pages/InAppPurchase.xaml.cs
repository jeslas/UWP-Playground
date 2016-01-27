using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Store;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
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
    public sealed partial class InAppPurchase : Page
    {
        LicenseInformation appLicenseInformation;

        public InAppPurchase()
        {
            this.InitializeComponent();
            this.Loaded += InAppPurchase_Loaded;

        
        }

        private async void InAppPurchase_Loaded(object sender, RoutedEventArgs e)
        {
            StorageFolder proxyDataFolder = await Package.Current.InstalledLocation.GetFolderAsync("Data");
            StorageFile proxyFile = await proxyDataFolder.GetFileAsync("WindowsStoreProxy.xml");
            await CurrentAppSimulator.ReloadSimulatorAsync(proxyFile);

            appLicenseInformation = CurrentAppSimulator.LicenseInformation;

            if(appLicenseInformation.ProductLicenses["1"].IsActive)
            {
                RedRect.Visibility = Visibility.Visible;
                BuyBtn.Visibility = Visibility.Collapsed;
            }
            else
            {
                RedRect.Visibility = Visibility.Collapsed;
                BuyBtn.Visibility = Visibility.Visible;
            }
        }

        private async void BuyBtn_Click(object sender, RoutedEventArgs e)
        {
            if(!appLicenseInformation.ProductLicenses["1"].IsActive)
            {
                try
                {
                    PurchaseResults res = await CurrentAppSimulator.RequestProductPurchaseAsync("1");
                    if (res.Status == ProductPurchaseStatus.Succeeded)
                    {
                        RedRect.Visibility = Visibility.Visible;
                        BuyBtn.Visibility = Visibility.Collapsed;
                    }
                }
                catch(Exception ex)
                {

                }
            }
        }
    }
}
