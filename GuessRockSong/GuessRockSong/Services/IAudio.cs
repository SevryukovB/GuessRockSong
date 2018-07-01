namespace GuessRockSong.Services
{
    public interface IAudio
    {
        bool PlayMp3File(string fileName);
        bool StopMp3File(string fileName);
    }
}
