using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xamarin.Essentials;
using Acr.UserDialogs;
using Android;
using Android.Support.Design.Widget;
using System.Threading.Tasks;

namespace music_player_android.Droid
{
    [Activity(Label = "music_player_android", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            // init xamarin essentials
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            // init user dialogs
            UserDialogs.Init(this);

            GetStoragePermission();

            LoadApplication(new App());
        }

        void GetStoragePermission()
        {
            string[] PermissionsStorage =
            {
                Manifest.Permission.AccessCoarseLocation,
                Manifest.Permission.AccessFineLocation,
                Manifest.Permission.ReadExternalStorage,
                Manifest.Permission.WriteExternalStorage
            };

            const int RequestStorageId = 0;

            //Finally request permissions with the list of permissions and Id
            RequestPermissions(PermissionsStorage, RequestStorageId);
            
            return;
        }
    }
}