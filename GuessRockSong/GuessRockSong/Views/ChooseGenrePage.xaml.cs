using System.Collections.Generic;
using System.Threading.Tasks;
using GuessRockSong.Controls;
using GuessRockSong.Models;
using GuessRockSong.UiHelpers;
using GuessRockSong.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GuessRockSong.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ChooseGenrePage : GradientContentPage
	{
        public ChooseGenrePage (List<Genre> listGenres)
        {
            InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = new ChooseGenreViewModel(listGenres);
		}

        async void OnItemTapped(object sender, ItemTappedEventArgs e)
	    {
            var item = e.Item as GenreUiHelper;
            if (item == null)
                return;

            var d = (ListView)sender;
            d.IsEnabled = false;
            
            await Application.Current.MainPage.Navigation.PushAsync(new GamePage(new GamePageViewModel(item)), false);

            //await Task.Delay(1000);
            d.IsEnabled = true;
        }
    }
}