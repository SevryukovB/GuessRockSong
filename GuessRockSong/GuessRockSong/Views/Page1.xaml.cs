
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GuessRockSong.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Page1 : ContentPage
	{
		public Page1 ()
        {
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);
            //Content = new ScoreView();

		}
	}
}