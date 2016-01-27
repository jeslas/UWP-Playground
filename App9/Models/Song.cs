using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Xaml.Media.Imaging;

namespace App9.Models
{
    public class Song
    {
        public string Name { get; set; }
        public string Artist { get; set; }
        public string Album { get; set; }
        public BitmapImage Cover { get; set; }
        public StorageFile File { get; set; }
    }
}
