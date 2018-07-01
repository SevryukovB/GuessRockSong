using SQLite;
using SQLiteNetExtensions.Attributes;
using System.Collections.Generic;

namespace GuessRockSong.Models
{
    [Table("Genre")]
    public class Genre
    {
        [PrimaryKey, AutoIncrement]
        public int GenreId { get; set; }

        public string Name { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Band> Bands { get; set; }
    }
}
