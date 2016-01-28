using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
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
    public sealed partial class Cortana : Page
    {
        public Cortana()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

            var speechRecognitionResult = e.Parameter as Windows.Media.SpeechRecognition.SpeechRecognitionResult;
            if (speechRecognitionResult != null)
            {
                string voiceCommandName = speechRecognitionResult.RulePath[0];
                string textSpoken = speechRecognitionResult.Text;

                string spokenColor = "";
                try
                {
                    spokenColor = speechRecognitionResult.SemanticInterpretation.Properties["color"][0];
                }
                catch
                {
                    //
                }

                Windows.UI.Color color;

                switch (spokenColor)
                {
                    case "Red":
                        color = Colors.Red;
                        break;
                    case "Blue":
                        color = Colors.Blue;
                        break;
                    case "Yellow":
                        color = Colors.Yellow;
                        break;
                    case "Green":
                        color = Colors.Green;
                        break;
                    default:
                        color = Colors.Purple;
                        break;
                }

                Grid1.Background = new SolidColorBrush(color);
            }
        }
    }
}
