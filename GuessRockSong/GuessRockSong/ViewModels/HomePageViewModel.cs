using System.Windows.Input;
using GuessRockSong.Models;
using GuessRockSong.Views;
using Xamarin.Forms;

namespace GuessRockSong.ViewModels
{
    public class HomePageViewModel
    {
        public ICommand OpenGenresCommand { get; private set; }
        public ICommand OpenRaitingCommand { get; private set; } = new Command(async () => await Application.Current.MainPage.Navigation.PushAsync(new RatingPage()));

        public HomePageViewModel(System.Collections.Generic.List<Genre> _listGenres)
        {
            OpenGenresCommand = new Command(async () => await Application.Current.MainPage.Navigation.PushAsync(new ChooseGenrePage(_listGenres)));
        }
    }
}
