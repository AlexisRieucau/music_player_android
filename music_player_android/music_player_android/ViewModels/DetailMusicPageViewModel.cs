using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using music_player_android.DAL;
using music_player_android.Interfaces;
using music_player_android.Models;
using music_player_android.Views;
using Xamarin.Forms;

namespace music_player_android.ViewModels
{
    class DetailMusicPageViewModel : BaseViewModel
    {
        public DetailMusicPageViewModel(Music music)
        {
            CurrentMusic = music;
            Titre = "Player";

            PlayMusicCommand = new Command(
                async () => await ExecutePlayMusicCommand());

            PauseMusicCommand = new Command(
                async () => await ExecutePauseMusicCommand());

            StopMusicCommand = new Command(
                async () => await ExecuteStopMusicCommand());

            ReleasePlayerCommand = new Command(
                async () => await ExecuteReleasePlayerCommand());
        }

        #region BindableProperties

        private Music currentMusic;

        public Music CurrentMusic
        {
            get { return currentMusic; }
            set
            {
                currentMusic = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region BindableCommands

        public Command PlayMusicCommand { get; set; }

        public Command PauseMusicCommand { get; set; }

        public Command StopMusicCommand { get; set; }

        public Command ReleasePlayerCommand { get; set; }

        #endregion

        #region Methodes

        private async Task ExecutePlayMusicCommand()
        {
            try
            {
                DependencyService.Get<IPlayer>().StartPlayer(CurrentMusic.FilePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private async Task ExecutePauseMusicCommand()
        {
            try
            {
                DependencyService.Get<IPlayer>().PausePlayer();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private async Task ExecuteStopMusicCommand()
        {
            try
            {
                DependencyService.Get<IPlayer>().PausePlayer();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private async Task ExecuteReleasePlayerCommand()
        {
            try
            {
                DependencyService.Get<IPlayer>().PausePlayer();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        #endregion
    }
}
