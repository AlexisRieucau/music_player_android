using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using music_player_android.Droid.Implementation;
using music_player_android.Interfaces;
using Xamarin.Forms;

[assembly: Dependency(typeof(Musics_Implement))]
namespace music_player_android.Droid.Implementation
{
    class Musics_Implement : IMusics
    {
        public string RetrieveID3TagTitle(string filename)
        {
            MediaMetadataRetriever reader = new MediaMetadataRetriever();

            reader.SetDataSource(filename);

            String title = reader.ExtractMetadata(Android.Media.MetadataKey.Title);

            return title;
        }

        public string RetrieveID3TagArtist(string filename)
        {
            MediaMetadataRetriever reader = new MediaMetadataRetriever();

            reader.SetDataSource(filename);

            String artist = reader.ExtractMetadata(Android.Media.MetadataKey.Artist);

            return artist;
        }

        public string RetrieveID3TagAlbum(string filename)
        {
            MediaMetadataRetriever reader = new MediaMetadataRetriever();

            reader.SetDataSource(filename);

            String album = reader.ExtractMetadata(Android.Media.MetadataKey.Album);

            return album;
        }

        public string RetrieveID3TagGenre(string filename)
        {
            MediaMetadataRetriever reader = new MediaMetadataRetriever();

            reader.SetDataSource(filename);

            String genre = reader.ExtractMetadata(Android.Media.MetadataKey.Genre);

            return genre;
        }

        public string RetrieveID3TagDuree(string filename)
        {
            MediaMetadataRetriever reader = new MediaMetadataRetriever();

            reader.SetDataSource(filename);

            double dureeInt = Int32.Parse(reader.ExtractMetadata(Android.Media.MetadataKey.Duration));

            double minutes = dureeInt / 60000;
            double secondes = (minutes - Math.Truncate(minutes))/(100.0/6000.0);

            string duree = (Math.Truncate(minutes)).ToString()+":"+ (Math.Truncate(secondes)).ToString();

            return duree;
        }

        public string RetrieveID3TagAnnee(string filename)
        {
            MediaMetadataRetriever reader = new MediaMetadataRetriever();

            reader.SetDataSource(filename);

            String annee = reader.ExtractMetadata(Android.Media.MetadataKey.Year);
            
            return annee;
        }

        public byte[] RetrieveID3TagFrame(string filename)
        {
            MediaMetadataRetriever reader = new MediaMetadataRetriever();
            System.IO.Stream stream = new MemoryStream();
            byte[] binary;


            reader.SetDataSource(filename);

            Bitmap frameBm = reader.FrameAtTime;

            if (frameBm != null)
            {
                frameBm.Compress(Bitmap.CompressFormat.Jpeg, 100, stream);

                binary = new byte[stream.Length];

                stream.Read(binary, 0, (int)stream.Length);
            }
            else
            {
                Xamarin.Forms.Image img = new Xamarin.Forms.Image { Source = "drawable/noFrame.png" };
                Assembly assembly = Assembly.GetExecutingAssembly();
                Assembly.GetExecutingAssembly().GetManifestResourceNames();
                using (System.IO.Stream s = assembly.GetManifestResourceStream("music_player_android.Droid.Resources.drawable.noFrame.png"))
                {
                    long length = s.Length;
                    binary = new byte[length];
                    s.Read(binary, 0, (int)length);
                }
            }

            return binary;
        }
    }
}