using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using GuessRockSong.Models;
using GuessRockSong.Services;
using Xamarin.Forms;
using System.Threading.Tasks;
using GuessRockSong.Helpers;
using GuessRockSong.UiHelpers;
using System.Threading;
using GuessRockSong.Controls;

namespace GuessRockSong.ViewModels
{
    public class GamePageViewModel : MainViewModel, INotifyPropertyChanged, IDisposable
    {
        private readonly Random _rand = new Random();
        private List<Sound> _sounds { get; }
        private Command _playTrueAnswerFile { get; set; } = new Command(() => DependencyService.Get<IAudio>().PlayMp3File("TrueAnswer"));

        public ObservableCollection<GameUiHelper> ItemsForDisplay { get; set; } =  new ObservableCollection<GameUiHelper>();
        public ICommand PlayFile { get; set; }
        public ICommand StopPlayFile { get; set; }

        private int _questionsCount = 10;

        public int QuestionsCount
        {
            get => _questionsCount; 
            set
            {
                _questionsCount = value;
                OnPropertyChanged();
            }
        }

        private int _trueAnswers;

        public int TrueAnswers
        {
            get => _trueAnswers; 
            set
            {
                _trueAnswers = value;
                OnPropertyChanged();
            }
        }

        private int _points = 0;

        public int Points
        {
            get => _points;
            set
            {
                _points = value;
                OnPropertyChanged();
            }
        }

        private int _timerValue = 15;

        public int TimerValue
        {
            get => _timerValue;
            set
            {
                _timerValue = value;
                if(_timerValue <= 5)
                    TimerValueColor = Color.FromHex("#f93c6a");
                else if (_timerValue == 15)
                    TimerValueColor = Color.White;
                OnPropertyChanged();
            }
        }

        private Color _timerValueColor = Color.White;

        public Color TimerValueColor
        {
            get => _timerValueColor;
            set
            {
                _timerValueColor = value;
                OnPropertyChanged();
            }
        }

        private bool _showScore = false;

        public bool ShowScore
        {
            get => _showScore;
            set
            {
                _showScore = value;
                OnPropertyChanged();
            }
        }

        public int GenreId { get; set; }

        public GamePageViewModel(GenreUiHelper genre)
        {
            if (genre?.Bands == null)
                return;

            GenreId = genre.GenreId;
            HeaderText = genre.Name;
            GoBackCommand = new Command(BackCommand);

            _sounds = new List<Sound>(genre.Bands.SelectMany(x => x.Sounds));
            
            Start();
        }

        public void Start()
        {
            ExecuteStartCommand();
            FillList();

            var playsound = ItemsForDisplay.FirstOrDefault(x => x.IsTrue).ToString();

            PlayFile = new Command(() => DependencyService.Get<IAudio>().PlayMp3File(playsound.Replace(" ", string.Empty)));
            StopPlayFile = new Command(() => DependencyService.Get<IAudio>().StopMp3File(playsound.Replace(" ", string.Empty)));
            
            PlayFile.Execute(this);
        }

        private async void BackCommand()
        {
            ExecuteStopCommand();
            StopPlayFile?.Execute(this);
            QuestionsCount = 0;
            Dispose();
            await Application.Current.MainPage.Navigation.PopAsync(false);
        }

        public async void CheckAnswer(GameUiHelper item, bool showAnswer)
        {
            StopPlayFile?.Execute(this);

            if (item.IsTrue)
            {
                ++TrueAnswers;
                Points += TimerValue * TimerValue * TrueAnswers;
                _playTrueAnswerFile.Execute(this);
            }

            ExecuteStopCommand();
            
            --QuestionsCount;

            if(showAnswer)
                await Task.Delay(2000);
            
            if (QuestionsCount != 0)
                Start();
            else
            {
                StopPlayFile?.Execute(this);
                ShowScore = true;
            }
        }
        
        private Sound GetSound(List<Sound> cloneSounds, bool isDelete)
        {
            var randomSoundFromBand = cloneSounds[RandomNumberGenerator(cloneSounds.Count)]; // Get random sound

            cloneSounds.Remove(randomSoundFromBand);

            if (isDelete)
                _sounds.Remove(randomSoundFromBand);

            return randomSoundFromBand;
        }
        
        private void FillList()
        {
            ItemsForDisplay.Clear();

            var cloneSounds = new List<Sound>(_sounds);

            var rand = RandomNumberGenerator(4);

            for (int i = 0; i < 5; i++)
            {
                Sound sound;
                if (i != rand)
                {
                    sound = GetSound(cloneSounds, false);
                    ItemsForDisplay.Add(new GameUiHelper { BandName = sound.GetBandName(), SoundName = sound.GetSoundName(), IsTrue = false });
                }
                else
                {
                    sound = GetSound(cloneSounds, true);
                    ItemsForDisplay.Add(new GameUiHelper { BandName = sound.GetBandName(), SoundName = sound.GetSoundName(), IsTrue = true });
                }
            }
        }

        private int RandomNumberGenerator(int length) => _rand.Next(0, length);

        public void Dispose()
        {
            PlayFile = null;
            StopPlayFile = null;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        //TIMER
        private GuessRockSong.Controls.Timer _timer;
        
        private ICommand _startCommand;
        public ICommand StartCommand
        {
            get { return _startCommand ?? (_startCommand = new RelayCommand(ExecuteStartCommand)); }
        }

        private void ExecuteStartCommand()
        {
            if (_timer == null)
                _timer = new GuessRockSong.Controls.Timer(OnTick, null, 1000, 1000);
        }


        private ICommand _stopCommand;
        public ICommand StopCommand
        {
            get { return _stopCommand ?? (_stopCommand = new RelayCommand(ExecuteStopCommand)); }
        }

        private void ExecuteStopCommand()
        {
            TimeLeft = new TimeSpan(0, 0, 15);

            if (_timer == null)
                return;
            
            _timer.Dispose();
            _timer = null;
        }

        private void OnTick(object args)
        {
            TimeLeft = timeLeft.Subtract(new TimeSpan(0, 0, 1));
        }

        private TimeSpan timeLeft = new TimeSpan(0, 0, 15);
        public TimeSpan TimeLeft
        {
            get { return timeLeft; }
            set
            {
                timeLeft = value;
                OnPropertyChanged();
                TimerValue = timeLeft.Seconds;

                if (TimerValue == 0)
                    CheckAnswer(new GameUiHelper { IsTrue = false }, false);
            }
        }
    }
}
