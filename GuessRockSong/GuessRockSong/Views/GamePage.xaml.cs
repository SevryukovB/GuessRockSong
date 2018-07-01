using GuessRockSong.Controls;
using GuessRockSong.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GuessRockSong.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class GamePage : GradientContentPage
	{
        public GamePage (GamePageViewModel gamePageViewModel)
		{
			InitializeComponent ();
		    NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = gamePageViewModel;
		}
    }
}