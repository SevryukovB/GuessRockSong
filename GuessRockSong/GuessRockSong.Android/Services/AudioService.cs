using Android.Media;
using Xamarin.Forms;
using GuessRockSong.Droid.Services;
using GuessRockSong.Services;
[assembly: Dependency(typeof(AudioService))]

namespace GuessRockSong.Droid.Services
{
    class AudioService : IAudio
    {
        public AudioService() { }

        private MediaPlayer _mediaPlayer;

        public bool PlayMp3File(string fileName)
        {
            var resourceId = (int)typeof(Resource.Raw).GetField(fileName).GetValue(null);//get id of resource by name
            _mediaPlayer = MediaPlayer.Create(global::Android.App.Application.Context, resourceId);

            _mediaPlayer.Start();
            return true;
        }

        public bool StopMp3File(string fileName)
        {
            _mediaPlayer.Stop();
            return true;
        }
    }
}