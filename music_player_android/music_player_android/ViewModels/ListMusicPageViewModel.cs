using music_player_android.Resx;
using System;
using System.Collections.Generic;
using System.Text;

using music_player_android.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using System.Threading.Tasks;
using music_player_android.DAL;
using System.Linq;
using System.IO;
using music_player_android.Interfaces;

namespace music_player_android.ViewModels
{
    class ListMusicPageViewModel : BaseViewModel
    {
        public ListMusicPageViewModel()
        {
            Titre = AppResources.listTitle;
            RefreshMusicCommand = new Command(
                async () => await ExecuteRefreshMusicCommand());
            RefreshMusicCommand.Execute(null);
        }

        #region BindableProperties

        private List<Music> listMusic;

        public List<Music> ListMusic
        {
            get { return listMusic; }
            set
            {
                listMusic = value;
                OnPropertyChanged("ListMusic");
            }
        }

        private Music selectedMusic;   

        public Music SelectedMusic
        {
            get { return selectedMusic; }
            set
            {
                selectedMusic = value;
                OnPropertyChanged();
            }
        }

        private string searchText;

        public string SearchText
        {
            get { return searchText; }
            set
            {
                searchText = value;
                OnPropertyChanged();
                //Filtrer la liste
                FilterList(value);
            }
        }

        #endregion

        #region BindableCommands

        public Command RefreshMusicCommand { get; set; }

        private async Task ExecuteRefreshMusicCommand()
        {
            IsBusy = true;
            await SynchronizeDB();
            SearchText = "";
            IsBusy = false;
        }

        #endregion

        #region Methods

        private void FilterList(string filter)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(filter))
                {
                    using (var dbcontext = new MusicDatabase())
                    {
                        ListMusic = dbcontext.MusicTable.OrderBy(x => x.Title).ToList();
                    }
                    return;
                }

                using (var dbcontext = new MusicDatabase())
                {
                    ListMusic = dbcontext.MusicTable.Where(x => x.Title.ToLower().Contains(filter.ToLower())).OrderBy(x => x.Title).ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private async Task SynchronizeDB()
        {
            try
            {
                List<Music> localMusics = new List<Music>();
                string pathToMusic = "/storage/emulated/0/Music/";
                var files = Directory.GetFiles(pathToMusic);
                foreach (var file in files)
                {
                    if (file.Substring(file.Length - 4) == ".mp3")
                    {
                        localMusics.Add(new Music
                                                {
                                                    Title = DependencyService.Get<IMusics>().RetrieveID3TagTitle(file),
                                                    Artist = DependencyService.Get<IMusics>().RetrieveID3TagArtist(file),
                                                    Album = DependencyService.Get<IMusics>().RetrieveID3TagAlbum(file),
                                                    Genre = DependencyService.Get<IMusics>().RetrieveID3TagGenre(file),
                                                    Duree = DependencyService.Get<IMusics>().RetrieveID3TagDuree(file),
                                                    Annee = DependencyService.Get<IMusics>().RetrieveID3TagAnnee(file),
                                                    FilePath = file,
                                                    Frame = DependencyService.Get<IMusics>().RetrieveID3TagFrame(file)
                        });
                    }
                }

                using (var dbcontext = new MusicDatabase())
                {
                    foreach (Music music in localMusics)
                    {
                        if (dbcontext.MusicTable.ToList().Count != 0)
                        {
                            var musicindb = dbcontext.MusicTable.Local.FirstOrDefault(x => x.Title == music.Title);
                            if (musicindb == null)
                            {
                                dbcontext.MusicTable.Add(music);
                            }
                        }
                        else
                        {
                            dbcontext.MusicTable.Add(music);
                        }
                    }

                    await dbcontext.SaveChangesAsync();

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        #endregion
    }
}
