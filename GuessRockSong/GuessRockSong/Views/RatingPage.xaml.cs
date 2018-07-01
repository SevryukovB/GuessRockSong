using GuessRockSong.Controls;
using GuessRockSong.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GuessRockSong.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RatingPage : GradientContentPage
	{
		public RatingPage ()
		{
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = new RatingViewModel();
        }
	}
}