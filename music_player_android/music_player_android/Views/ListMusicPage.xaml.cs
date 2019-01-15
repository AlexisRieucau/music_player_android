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

namespace music_player_android
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListMusicPage : ContentPage
	{
		public ListMusicPage ()
		{
			InitializeComponent ();

            BindingContext = new ListMusicPageViewModel();

            MyListView.ItemTapped += MyListView_ItemTapped;
		}

        private void MyListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            try
            {
                ((ListMusicPageViewModel)BindingContext).SelectedMusic = null;
                Music selectedMusic = (Music)e.Item;
                Navigation.PushAsync(new DetailMusicPage(selectedMusic), true);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
	}
}