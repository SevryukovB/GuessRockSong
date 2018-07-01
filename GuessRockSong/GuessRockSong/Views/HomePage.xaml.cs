using GuessRockSong.Controls;
using GuessRockSong.Helpers;
using GuessRockSong.Models;
using GuessRockSong.ViewModels;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GuessRockSong.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : GradientContentPage
    {
        private List<Genre> _listGenres;
        public HomePage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            StartGameBtn.Clicked += LockGrid;
            StartGameBtn2.Clicked += LockGrid;
            RatingBtn.Clicked += LockGrid;
            RatingBtn2.Clicked += LockGrid;

            _listGenres = Data.GetData();//db.Genres.Include(x => x.Bands).ThenInclude(z => z.Sounds).ToList();
            BindingContext = new HomePageViewModel(_listGenres);
        }

        protected override void OnAppearing()
        {
            MainGrid.IsEnabled = true;
        }

        private void LockGrid(object sender, System.EventArgs e)
        {
            MainGrid.IsEnabled = false;
        }
    }
}
