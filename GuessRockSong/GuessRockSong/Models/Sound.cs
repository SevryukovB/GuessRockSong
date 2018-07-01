using SQLite;
using SQLiteNetExtensions.Attributes;

namespace GuessRockSong.Models
{
    [Table("Sound")]
    public class Sound
    {
        [PrimaryKey, AutoIncrement]
        public int SoundId { get; set; }

        public string Name { get; set; }

        [ForeignKey(typeof(Band))]
        public int BandId { get; set; }

        [ManyToOne]
        public Band Band { get; set; }

        public override string ToString()
        {
            return Band.Name + " — " + Name;
        }

        public string GetBandName()
        {
            return Band.Name;
        }

        public string GetSoundName()
        {
            return Name;
        }
    }
}
