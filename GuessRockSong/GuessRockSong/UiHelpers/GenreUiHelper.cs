using GuessRockSong.Models;
using System.Collections.Generic;
using Xamarin.Forms;

namespace GuessRockSong.UiHelpers
{
    public class GenreUiHelper
    {
        public int GenreId { get; set; }

        public string Name { get; set; }

        public List<Band> Bands { get; set; }

        public FileImageSource Image { get; set; }

        //set height for rows in list in 29% for all devices
        public double RowSize { get; set; } = Application.Current.MainPage.Height * 28.7 / 100;
    }
}
