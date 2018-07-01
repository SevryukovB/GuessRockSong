using System.Collections.Generic;
using GuessRockSong.Models;
using GuessRockSong.UiHelpers;
using Xamarin.Forms;

namespace GuessRockSong.ViewModels
{
    public class ChooseGenreViewModel : MainViewModel
    {
        public List<GenreUiHelper> GenresListAdditional { get; set; }

        public ChooseGenreViewModel(List<Genre> listGenres)
        {
            GoBackCommand = new Command(async () => await Application.Current.MainPage.Navigation.PopAsync(false));

            GenresListAdditional = new List<GenreUiHelper>();

            listGenres.ForEach(x => GenresListAdditional.Add(new GenreUiHelper
            {
                GenreId = x.GenreId,
                Name = x.Name,
                Image = new FileImageSource{File = x.Name + ".png" },
                Bands = x.Bands
            }));
        }
    }
}
