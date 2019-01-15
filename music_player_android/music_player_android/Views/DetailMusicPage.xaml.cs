using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using music_player_android.Interfaces;
using music_player_android.Resx;
using music_player_android.Views;
using music_player_android.ViewModels;
using music_player_android.Models;


using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace music_player_android.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DetailMusicPage : ContentPage
	{
		public DetailMusicPage (Music music)
		{
			InitializeComponent ();
            BindingContext = new DetailMusicPageViewModel(music);
		}
	}
}