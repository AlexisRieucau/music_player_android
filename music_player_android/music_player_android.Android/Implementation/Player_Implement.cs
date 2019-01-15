using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using music_player_android.Droid.Implementation;
using music_player_android.Interfaces;
using Xamarin.Forms;

[assembly: Dependency(typeof(Player_Implement))]
namespace music_player_android.Droid.Implementation
{
    class Player_Implement : IPlayer
    {

        protected MediaPlayer player;
        protected string trackPlaying = "";
        public void StartPlayer(string filepath)
        {
            
            if (player == null)
            {
                player = new MediaPlayer();
                player.Reset();
                player.SetDataSource(filepath);
                player.Prepare();
                player.Start();
                trackPlaying = filepath;
            }
            else if(trackPlaying == filepath)
            {
                player.Start();
                trackPlaying = filepath;
            }
            else
            {
                player.Reset();
                player.SetDataSource(filepath);
                player.Prepare();
                player.Start();
                trackPlaying = filepath;
            }
        }

        public void PausePlayer()
        {
            if(player.IsPlaying == true)
            {
                player.Pause();
            }
        }

        public void StopPlayer()
        {
            if (player.IsPlaying == false)
            {
                player.Stop();
            }
        }

        public void ReleasePlayer()
        {
            if (player.IsPlaying == true)
            {
                player.Release();
            }
        }
    }
}