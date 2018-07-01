using Xamarin.Forms;

namespace GuessRockSong.UiHelpers
{
    class RatingUiHelper
    {
        public FileImageSource Image { get; set; }
        
        public double HeightSize { get; set; } = Application.Current.MainPage.Height * 20 / 100;

        public double WidthSize { get; set; } = Application.Current.MainPage.Width * 45 / 100;

        public int Score { get; set; }
    }
}
