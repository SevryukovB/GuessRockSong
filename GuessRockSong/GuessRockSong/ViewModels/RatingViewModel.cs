using GuessRockSong.Helpers;
using GuessRockSong.UiHelpers;
using System.Collections.Generic;
using Xamarin.Forms;

namespace GuessRockSong.ViewModels
{
    class RatingViewModel : MainViewModel
    {
        public List<RatingUiHelper> RatingList { get; set; } = new List<RatingUiHelper>();
        public RatingViewModel()
        {
            HeaderText = "Rating";
            GoBackCommand = new Command(async () => await Application.Current.MainPage.Navigation.PopAsync(false));


            foreach (var score in Data.GetScores())
                RatingList.Add(new RatingUiHelper { Score = score.Points, Image = score.GenreName + "Rating.png" });
        }
    }
}
