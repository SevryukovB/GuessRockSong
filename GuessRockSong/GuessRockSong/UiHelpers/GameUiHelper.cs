using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace GuessRockSong.UiHelpers
{
    public class GameUiHelper : INotifyPropertyChanged
    {
        public string BandName { get; set; }

        public string SoundName { get; set; }

        public bool IsTrue { get; set; }

        private Color _bandTextColor = Color.White;

        public Color BandTextColor
        {
            get => _bandTextColor;
            set
            {
                _bandTextColor = value;
                OnPropertyChanged();
            }
        }

        private Color _soundTextColor = Color.FromHex("#7585a7");

        public Color SoundTextColor
        {
            get => _soundTextColor;
            set
            {
                _soundTextColor = value;
                OnPropertyChanged();
            }
        }

        public override string ToString()
        {
            return BandName + "_" + SoundName;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
