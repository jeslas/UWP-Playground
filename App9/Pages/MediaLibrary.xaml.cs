using App9.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace App9.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MediaLibrary : Page
    {
        private ObservableCollection<Song> songs;

        public MediaLibrary()
        {
            this.InitializeComponent();
            this.Loaded += MediaLibrary_Loaded;
        }

        private void MediaLibrary_Loaded(object sender, RoutedEventArgs e)
        {
            StorageFolder folder = KnownFolders.MusicLibrary;
            GetAllFiles(folder, Songs);
        }

        public ObservableCollection<Song> Songs
        {
            get
            {
                if(songs == null)
                    songs = new ObservableCollection<Song>();
                return songs;
            }

            set
            {
                songs = value;
            }
        }

        private async void GetAllFiles(StorageFolder folder, ObservableCollection<Song> songs)
        {
            foreach (StorageFile file in await folder.GetFilesAsync())
            {
                if(file.FileType == ".mp3")
                {
                    var props = await file.Properties.GetMusicPropertiesAsync();
                    var image = await file.GetThumbnailAsync(Windows.Storage.FileProperties.ThumbnailMode.MusicView);
                    var cover = new BitmapImage();
                    cover.SetSource(image);
                    Song song = new Song()
                    {
                        Name = props.Title,
                        Album = props.Album,
                        Artist = props.Artist,
                        Cover = cover,
                        File = file
                    };
                    songs.Add(song);
                }
            }

            foreach (StorageFolder subfolder in await folder.GetFoldersAsync())
            {
                GetAllFiles(subfolder, songs);
            }
        }

        private async void GridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            Song song = e.ClickedItem as Song;
            player.SetSource(await song.File.OpenAsync(FileAccessMode.Read), song.File.ContentType);
            sb1.Begin();
        }

        private void sb1_Completed(object sender, object e)
        {
            player.Stop();
            sb2.Begin();
        }
    }
}
