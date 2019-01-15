using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace music_player_android.Interfaces
{
    public interface IMusics
    {
        string RetrieveID3TagTitle(string filename);
        string RetrieveID3TagArtist(string filename);
        string RetrieveID3TagAlbum(string filename);
        string RetrieveID3TagGenre(string filename);
        string RetrieveID3TagDuree(string filename);
        string RetrieveID3TagAnnee(string filename);
        byte[] RetrieveID3TagFrame(string filename);
    }
}
