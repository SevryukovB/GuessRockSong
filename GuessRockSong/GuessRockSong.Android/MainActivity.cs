using System;
using Android.App;
using Android.Content.PM;
using Android.Views;
using Android.OS;

namespace GuessRockSong.Droid
{
    [Activity(Label = "GuessRockSong", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ScreenOrientation = ScreenOrientation.Portrait,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            AppDomain curDomain = AppDomain.CurrentDomain;
            curDomain.UnhandledException += CurDomain_UnhandledException;
            Window.SetFlags(WindowManagerFlags.Fullscreen, WindowManagerFlags.Fullscreen);//remove top title

            Android.Gms.Ads.MobileAds.Initialize(ApplicationContext, "ca-app-pub-2982635626402476~8718446556");
            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
        }

        private void CurDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            
        }

        public override void OnBackPressed()
        {
            //empty for lock hardware back button
        }
    }
}

