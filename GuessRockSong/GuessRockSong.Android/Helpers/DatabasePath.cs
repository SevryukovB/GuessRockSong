using System.IO;
using GuessRockSong.Droid.Helpers;
using GuessRockSong.Interfaces;

[assembly: Xamarin.Forms.Dependency(typeof(DatabasePath))]
namespace GuessRockSong.Droid.Helpers
{
    class DatabasePath : IDBPath
    {
        public DatabasePath()
        {

        }

        public string GetDbPath()
        {
            return Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "GuessMelodySuper39.db");
        }
    }
}