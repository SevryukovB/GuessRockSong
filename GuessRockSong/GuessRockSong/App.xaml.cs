using GuessRockSong.Views;
using System;

using Xamarin.Forms;

namespace GuessRockSong
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

            try
            {
                MainPage = new NavigationPage(new HomePage());
                //MainPage = new NavigationPage(new MainPage());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
		}

        //Singleton
        private static App instance;

        public static App GetInstance()
        {
            if (instance == null)
                instance = new App();
            return instance;
        }

        protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
