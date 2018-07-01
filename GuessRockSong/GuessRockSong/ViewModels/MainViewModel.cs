using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace GuessRockSong.ViewModels
{
    public class MainViewModel
    {
        public ICommand GoBackCommand { get; set; }
        public string HeaderText { get; set; } = "Genres";

        public MainViewModel()
        {
            //GoBackCommand = new Command(async () => await Application.Current.MainPage.Navigation.PopAsync());
        }
    }
}
