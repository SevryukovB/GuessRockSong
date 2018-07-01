using SQLite;
using SQLiteNetExtensions.Attributes;
using System.Collections.Generic;

namespace GuessRockSong.Models
{
    [Table("Band")]
    public class Band
    {
        [PrimaryKey, AutoIncrement]
        public int BandId { get; set; }

        public string Name { get; set; }

        [ForeignKey(typeof(Genre))]
        public int GenreId { get; set; }

        [ManyToOne]
        public Genre Genre { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Sound> Sounds { get; set; }
    }
}
