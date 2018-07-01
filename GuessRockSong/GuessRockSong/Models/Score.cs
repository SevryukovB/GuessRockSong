
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace GuessRockSong.Models
{
    [Table("Score")]
    public class Score
    {
        [PrimaryKey, AutoIncrement]
        public int ScoreId { get; set; }

        [ForeignKey(typeof(Genre))]
        public int GenreId { get; set; }

        public string GenreName { get; set; }

        public int Points { get; set; } = 0;
    }
}
