using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace App9
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            this.Loaded += MainPage_Loaded;
        }

        public Frame FrameContent { get { return this.Content1; } }

        public void SetFrameContent(Type page, object param = null)
        {
            Content1.Navigate(page, param);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var speechRecognitionResult = e.Parameter as Windows.Media.SpeechRecognition.SpeechRecognitionResult;
            if (speechRecognitionResult != null)
            {
                // Get the name of the voice command and the text spoken.
                string voiceCommandName = speechRecognitionResult.RulePath[0];
                string textSpoken = speechRecognitionResult.Text;
                var navigationParameterString = string.Format("Cortana: {0} {1}", voiceCommandName, textSpoken);
                Voice.Text = navigationParameterString;

                if (voiceCommandName == "blankCanvas")
                    Content1.Navigate(typeof(App9.Pages.Cortana), speechRecognitionResult);
            }
            else
            {
                Content1.Navigate(typeof(App9.Pages.InAppPurchase));
            }
        }

        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            Dictionary<string, Type> dic = GetPages();
            Pages.ItemsSource = dic;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            KeyValuePair<string, Type> item = (KeyValuePair<string, Type>)Pages.SelectedItem;
            Content1.Navigate(item.Value);
        }

        private Dictionary<string, Type> GetPages()
        {
            Dictionary<string, Type> dic = new Dictionary<string, Type>();
            Assembly lookIn = this.GetType().GetTypeInfo().Assembly;
            var types = lookIn.DefinedTypes.Where(t => t.IsSubclassOf(typeof(Windows.UI.Xaml.Controls.Page)) && t.Namespace == "App9.Pages");
            foreach(TypeInfo type in types)
            {
                dic.Add(type.Name, type.AsType());
            }
            return dic;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Content1.Navigate(typeof(App9.Pages.CommonControls));
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (Content1.CanGoBack)
                Content1.GoBack();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (Content1.CanGoForward)
                Content1.GoForward();
        }
    }

    public class MyButton : Button
    {
        public MyButton()
        {
            this.Content = "My Fede knapo";
        }
    }
}
