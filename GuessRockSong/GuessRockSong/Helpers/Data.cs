using System.Collections.Generic;
using System.IO;
using System.Linq;
using GuessRockSong.Interfaces;
using GuessRockSong.Models;
using SQLite;
using SQLiteNetExtensions.Extensions;
using Xamarin.Forms;

namespace GuessRockSong.Helpers
{
    public class Data
    {
        private static string _dbPath = DependencyService.Get<IDBPath>().GetDbPath();

        public static List<Genre> GetData()
        {
            using (SQLiteConnection db = new SQLiteConnection(_dbPath))
            {
                string checkDbExist = db.ExecuteScalar<string>($"SELECT name FROM sqlite_master WHERE type='table' AND name='Genre'");
                if (string.IsNullOrEmpty(checkDbExist))
                {
                    #region Genres

                    db.CreateTable<Genre>();

                    db.Insert(new Genre { Name = "Core" });
                    db.Insert(new Genre { Name = "Metal" });
                    db.Insert(new Genre { Name = "Alternative" });

                    #endregion

                    #region Scores

                    db.CreateTable<Score>();

                    foreach (var genre in db.Table<Genre>())
                        db.Insert(new Score { GenreId = genre.GenreId, GenreName = genre.Name });

                    #endregion

                    #region Bands

                    db.CreateTable<Band>();

                    //////CORE BANDS
                    db.Insert(new Band()
                    {
                        Name = "Asking Alexandria",
                        GenreId = db.Table<Genre>().FirstOrDefault(x1 => x1.Name == "Core").GenreId
                    });
                    db.Insert(new Band()
                    {
                        Name = "Bring Me The Horizon",
                        GenreId = db.Table<Genre>().FirstOrDefault(x1 => x1.Name == "Core").GenreId
                    });
                    db.Insert(new Band()
                    {
                        Name = "Architects",
                        GenreId = db.Table<Genre>().FirstOrDefault(x1 => x1.Name == "Core").GenreId
                    });
                    db.Insert(new Band()
                    {
                        Name = "Our Last Night",
                        GenreId = db.Table<Genre>().FirstOrDefault(x1 => x1.Name == "Core").GenreId
                    });
                    db.Insert(new Band()
                    {
                        Name = "I See Stars",
                        GenreId = db.Table<Genre>().FirstOrDefault(x1 => x1.Name == "Core").GenreId
                    });
                    db.Insert(new Band()
                    {
                        Name = "Adept",
                        GenreId = db.Table<Genre>().FirstOrDefault(x1 => x1.Name == "Core").GenreId
                    });
                    db.Insert(new Band()
                    {
                        Name = "The Amity Affliction",
                        GenreId = db.Table<Genre>().FirstOrDefault(x1 => x1.Name == "Core").GenreId
                    });

                    //////METAL BANDS
                    db.Insert(new Band()
                    {
                        Name = "Accept",
                        GenreId = db.Table<Genre>().FirstOrDefault(x1 => x1.Name == "Metal").GenreId
                    });
                    db.Insert(new Band()
                    {
                        Name = "ACDC",
                        GenreId = db.Table<Genre>().FirstOrDefault(x1 => x1.Name == "Metal").GenreId
                    });
                    db.Insert(new Band()
                    {
                        Name = "Aerosmith",
                        GenreId = db.Table<Genre>().FirstOrDefault(x1 => x1.Name == "Metal").GenreId
                    });
                    db.Insert(new Band()
                    {
                        Name = "Anthrax",
                        GenreId = db.Table<Genre>().FirstOrDefault(x1 => x1.Name == "Metal").GenreId
                    });
                    db.Insert(new Band()
                    {
                        Name = "Black Sabbath",
                        GenreId = db.Table<Genre>().FirstOrDefault(x1 => x1.Name == "Metal").GenreId
                    });
                    db.Insert(new Band()
                    {
                        Name = "Cannibal Corpse",
                        GenreId = db.Table<Genre>().FirstOrDefault(x1 => x1.Name == "Metal").GenreId
                    });
                    db.Insert(new Band()
                    {
                        Name = "Children Of Bodom",
                        GenreId = db.Table<Genre>().FirstOrDefault(x1 => x1.Name == "Metal").GenreId
                    });
                    db.Insert(new Band()
                    {
                        Name = "Guns And Roses",
                        GenreId = db.Table<Genre>().FirstOrDefault(x1 => x1.Name == "Metal").GenreId
                    });
                    db.Insert(new Band()
                    {
                        Name = "Judas Priest",
                        GenreId = db.Table<Genre>().FirstOrDefault(x1 => x1.Name == "Metal").GenreId
                    });
                    db.Insert(new Band()
                    {
                        Name = "Korn",
                        GenreId = db.Table<Genre>().FirstOrDefault(x1 => x1.Name == "Metal").GenreId
                    });
                    db.Insert(new Band()
                    {
                        Name = "Lamb Of God",
                        GenreId = db.Table<Genre>().FirstOrDefault(x1 => x1.Name == "Metal").GenreId
                    });
                    db.Insert(new Band()
                    {
                        Name = "Machine Head",
                        GenreId = db.Table<Genre>().FirstOrDefault(x1 => x1.Name == "Metal").GenreId
                    });
                    db.Insert(new Band()
                    {
                        Name = "Manowar",
                        GenreId = db.Table<Genre>().FirstOrDefault(x1 => x1.Name == "Metal").GenreId
                    });
                    db.Insert(new Band()
                    {
                        Name = "Megadeth",
                        GenreId = db.Table<Genre>().FirstOrDefault(x1 => x1.Name == "Metal").GenreId
                    });
                    db.Insert(new Band()
                    {
                        Name = "Metallica",
                        GenreId = db.Table<Genre>().FirstOrDefault(x1 => x1.Name == "Metal").GenreId
                    });
                    db.Insert(new Band()
                    {
                        Name = "Motorhead",
                        GenreId = db.Table<Genre>().FirstOrDefault(x1 => x1.Name == "Metal").GenreId
                    });
                    db.Insert(new Band()
                    {
                        Name = "Pantera",
                        GenreId = db.Table<Genre>().FirstOrDefault(x1 => x1.Name == "Metal").GenreId
                    });
                    db.Insert(new Band()
                    {
                        Name = "Rammstein",
                        GenreId = db.Table<Genre>().FirstOrDefault(x1 => x1.Name == "Metal").GenreId
                    });
                    db.Insert(new Band()
                    {
                        Name = "Sepultura",
                        GenreId = db.Table<Genre>().FirstOrDefault(x1 => x1.Name == "Metal").GenreId
                    });
                    db.Insert(new Band()
                    {
                        Name = "Skid Row",
                        GenreId = db.Table<Genre>().FirstOrDefault(x1 => x1.Name == "Metal").GenreId
                    });
                    db.Insert(new Band()
                    {
                        Name = "Slayer",
                        GenreId = db.Table<Genre>().FirstOrDefault(x1 => x1.Name == "Metal").GenreId
                    });
                    db.Insert(new Band()
                    {
                        Name = "Slipknot",
                        GenreId = db.Table<Genre>().FirstOrDefault(x1 => x1.Name == "Metal").GenreId
                    });

                    //////ALTERNATIVE BANDS
                    db.Insert(new Band()
                    {
                        Name = "Green Day",
                        GenreId = db.Table<Genre>().FirstOrDefault(x1 => x1.Name == "Alternative").GenreId
                    });
                    db.Insert(new Band()
                    {
                        Name = "Papa Roach",
                        GenreId = db.Table<Genre>().FirstOrDefault(x1 => x1.Name == "Alternative").GenreId
                    });
                    db.Insert(new Band()
                    {
                        Name = "Skillet",
                        GenreId = db.Table<Genre>().FirstOrDefault(x1 => x1.Name == "Alternative").GenreId
                    });
                    db.Insert(new Band()
                    {
                        Name = "Linkin Park",
                        GenreId = db.Table<Genre>().FirstOrDefault(x1 => x1.Name == "Alternative").GenreId
                    });
                    db.Insert(new Band()
                    {
                        Name = "My Chemical Romance",
                        GenreId = db.Table<Genre>().FirstOrDefault(x1 => x1.Name == "Alternative").GenreId
                    });
                    #endregion

                    #region Sounds

                    db.CreateTable<Sound>();

                    ///////////////////////////////////////////////ASKING ALEXANDRIA//////////////////////////////////////////////////
                    db.Insert(new Sound()
                    {
                        Name = "The Black",
                        BandId = db.Table<Band>().FirstOrDefault(x1 => x1.Name == "Asking Alexandria").BandId
                    });
                    db.Insert(new Sound()
                    {
                        Name = "Let It Sleep",
                        BandId = db.Table<Band>().FirstOrDefault(x1 => x1.Name == "Asking Alexandria").BandId
                    });
                    db.Insert(new Sound()
                    {
                        Name = "Closure",
                        BandId = db.Table<Band>().FirstOrDefault(x1 => x1.Name == "Asking Alexandria").BandId
                    });
                    db.Insert(new Sound()
                    {
                        Name = "Someone Somewhere",
                        BandId = db.Table<Band>().FirstOrDefault(x1 => x1.Name == "Asking Alexandria").BandId
                    });

                    ///////////////////////////////////////////////BRING ME THE HORIZON///////////////////////////////////////////////

                    db.Insert(new Sound()
                    {
                        Name = "Sleepwalking",
                        BandId = db.Table<Band>().FirstOrDefault(x1 => x1.Name == "Bring Me The Horizon").BandId
                    });
                    db.Insert(new Sound()
                    {
                        Name = "Can You Feel My Heart",
                        BandId = db.Table<Band>().FirstOrDefault(x1 => x1.Name == "Bring Me The Horizon").BandId
                    });
                    db.Insert(new Sound()
                    {
                        Name = "Go To Hell For Heavens Sake",
                        BandId = db.Table<Band>().FirstOrDefault(x1 => x1.Name == "Bring Me The Horizon").BandId
                    });
                    db.Insert(new Sound()
                    {
                        Name = "The House Of Wolves",
                        BandId = db.Table<Band>().FirstOrDefault(x1 => x1.Name == "Bring Me The Horizon").BandId
                    });
                    //TODO "Go To Hell, For Heavens Sake"

                    ///////////////////////////////////////////////OUR LAST NIGHT///////////////////////////////////////////////
                    db.Insert(new Sound()
                    {
                        Name = "Sunrise",
                        BandId = db.Table<Band>().FirstOrDefault(x1 => x1.Name == "Our Last Night").BandId
                    });
                    db.Insert(new Sound()
                    {
                        Name = "Reality Without You",
                        BandId = db.Table<Band>().FirstOrDefault(x1 => x1.Name == "Our Last Night").BandId
                    });

                    ///////////////////////////////////////////////ARCHITECTS///////////////////////////////////////////////
                    db.Insert(new Sound()
                    {
                        Name = "These Colours Dont Run",
                        BandId = db.Table<Band>().FirstOrDefault(x1 => x1.Name == "Architects").BandId
                    });
                    db.Insert(new Sound()
                    {
                        Name = "Naysayer",
                        BandId = db.Table<Band>().FirstOrDefault(x1 => x1.Name == "Architects").BandId
                    });

                    ///////////////////////////////////////////////I SEE STARS///////////////////////////////////////////////
                    db.Insert(new Sound()
                    {
                        Name = "Mystery Wall",
                        BandId = db.Table<Band>().FirstOrDefault(x1 => x1.Name == "I See Stars").BandId
                    });

                    ///////////////////////////////////////////////ADEPT///////////////////////////////////////////////
                    db.Insert(new Sound()
                    {
                        Name = "An Era Of Treachery",
                        BandId = db.Table<Band>().FirstOrDefault(x1 => x1.Name == "Adept").BandId
                    });
                    db.Insert(new Sound()
                    {
                        Name = "Grow Up Peter Pan",
                        BandId = db.Table<Band>().FirstOrDefault(x1 => x1.Name == "Adept").BandId
                    });
                    db.Insert(new Sound()
                    {
                        Name = "Shark Shark Shark",
                        BandId = db.Table<Band>().FirstOrDefault(x1 => x1.Name == "Adept").BandId
                    });
                    db.Insert(new Sound()
                    {
                        Name = "Sound The Alarm",
                        BandId = db.Table<Band>().FirstOrDefault(x1 => x1.Name == "Adept").BandId
                    });
                    //TODO "Shark!Shark!Shark!"


                    ///////////////////////////////////////////////TheAmityAffliction///////////////////////////////////////////////
                    db.Insert(new Sound()
                    {
                        Name = "FML",
                        BandId = db.Table<Band>().FirstOrDefault(x1 => x1.Name == "The Amity Affliction").BandId
                    });
                    db.Insert(new Sound()
                    {
                        Name = "Fuck The Yankees",
                        BandId = db.Table<Band>().FirstOrDefault(x1 => x1.Name == "The Amity Affliction").BandId
                    });
                    db.Insert(new Sound()
                    {
                        Name = "Geof Sux 666",
                        BandId = db.Table<Band>().FirstOrDefault(x1 => x1.Name == "The Amity Affliction").BandId
                    });
                    db.Insert(new Sound()
                    {
                        Name = "Open Letter",
                        BandId = db.Table<Band>().FirstOrDefault(x1 => x1.Name == "The Amity Affliction").BandId
                    });

                    //////METAL BANDS

                    db.Insert(new Sound()
                    {
                        Name = "Balls To The Walls",
                        BandId = db.Table<Band>().FirstOrDefault(x1 => x1.Name == "Accept").BandId
                    });
                    db.Insert(new Sound()
                    {
                        Name = "Cant Stop Rock N Roll",
                        BandId = db.Table<Band>().FirstOrDefault(x1 => x1.Name == "ACDC").BandId
                    });
                    db.Insert(new Sound()
                    {
                        Name = "Rock The House",
                        BandId = db.Table<Band>().FirstOrDefault(x1 => x1.Name == "ACDC").BandId
                    });
                    db.Insert(new Sound()
                    {
                        Name = "Cryin",
                        BandId = db.Table<Band>().FirstOrDefault(x1 => x1.Name == "Aerosmith").BandId
                    });
                    db.Insert(new Sound()
                    {
                        Name = "Mad House",
                        BandId = db.Table<Band>().FirstOrDefault(x1 => x1.Name == "Anthrax").BandId
                    });
                    db.Insert(new Sound()
                    {
                        Name = "I Am Iron Man",
                        BandId = db.Table<Band>().FirstOrDefault(x1 => x1.Name == "Black Sabbath").BandId
                    });
                    db.Insert(new Sound()
                    {
                        Name = "The Bleeding",
                        BandId = db.Table<Band>().FirstOrDefault(x1 => x1.Name == "Cannibal Corpse").BandId
                    });
                    db.Insert(new Sound()
                    {
                        Name = "Taste Of My Scythe",
                        BandId = db.Table<Band>().FirstOrDefault(x1 => x1.Name == "Children Of Bodom").BandId
                    });
                    db.Insert(new Sound()
                    {
                        Name = "Sex Drugs And Rock N Roll",
                        BandId = db.Table<Band>().FirstOrDefault(x1 => x1.Name == "Guns And Roses").BandId
                    });
                    db.Insert(new Sound()
                    {
                        Name = "Welcome To The Jungle",
                        BandId = db.Table<Band>().FirstOrDefault(x1 => x1.Name == "Guns And Roses").BandId
                    });
                    db.Insert(new Sound()
                    {
                        Name = "Jawbreaker",
                        BandId = db.Table<Band>().FirstOrDefault(x1 => x1.Name == "Judas Priest").BandId
                    });
                    db.Insert(new Sound()
                    {
                        Name = "Liar",
                        BandId = db.Table<Band>().FirstOrDefault(x1 => x1.Name == "Korn").BandId
                    });
                    db.Insert(new Sound()
                    {
                        Name = "Redneck",
                        BandId = db.Table<Band>().FirstOrDefault(x1 => x1.Name == "Lamb Of God").BandId
                    });
                    db.Insert(new Sound()
                    {
                        Name = "The Sentinel",
                        BandId = db.Table<Band>().FirstOrDefault(x1 => x1.Name == "Machine Head").BandId
                    });
                    db.Insert(new Sound()
                    {
                        Name = "Die For Metal",
                        BandId = db.Table<Band>().FirstOrDefault(x1 => x1.Name == "Manowar").BandId
                    });
                    db.Insert(new Sound()
                    {
                        Name = "Kill The King",
                        BandId = db.Table<Band>().FirstOrDefault(x1 => x1.Name == "Megadeth").BandId
                    });
                    db.Insert(new Sound()
                    {
                        Name = "Train Of Consequences",
                        BandId = db.Table<Band>().FirstOrDefault(x1 => x1.Name == "Megadeth").BandId
                    });
                    db.Insert(new Sound()
                    {
                        Name = "Jump In The Fire",
                        BandId = db.Table<Band>().FirstOrDefault(x1 => x1.Name == "Metallica").BandId
                    });
                    db.Insert(new Sound()
                    {
                        Name = "Whiskey In The Jar",
                        BandId = db.Table<Band>().FirstOrDefault(x1 => x1.Name == "Metallica").BandId
                    });
                    db.Insert(new Sound()
                    {
                        Name = "Ace Of Spades",
                        BandId = db.Table<Band>().FirstOrDefault(x1 => x1.Name == "Motorhead").BandId
                    });
                    db.Insert(new Sound()
                    {
                        Name = "Cemetary Gates",
                        BandId = db.Table<Band>().FirstOrDefault(x1 => x1.Name == "Pantera").BandId
                    });
                    db.Insert(new Sound()
                    {
                        Name = "Walk",
                        BandId = db.Table<Band>().FirstOrDefault(x1 => x1.Name == "Pantera").BandId
                    });
                    db.Insert(new Sound()
                    {
                        Name = "Haifisch",
                        BandId = db.Table<Band>().FirstOrDefault(x1 => x1.Name == "Rammstein").BandId
                    });
                    db.Insert(new Sound()
                    {
                        Name = "Reise Reise",
                        BandId = db.Table<Band>().FirstOrDefault(x1 => x1.Name == "Rammstein").BandId
                    });
                    db.Insert(new Sound()
                    {
                        Name = "Propaganda",
                        BandId = db.Table<Band>().FirstOrDefault(x1 => x1.Name == "Sepultura").BandId
                    });
                    db.Insert(new Sound()
                    {
                        Name = "Youth Gone Wild",
                        BandId = db.Table<Band>().FirstOrDefault(x1 => x1.Name == "Skid Row").BandId
                    });
                    db.Insert(new Sound()
                    {
                        Name = "Angel Of Death",
                        BandId = db.Table<Band>().FirstOrDefault(x1 => x1.Name == "Slayer").BandId
                    });
                    db.Insert(new Sound()
                    {
                        Name = "Raining Blood",
                        BandId = db.Table<Band>().FirstOrDefault(x1 => x1.Name == "Slayer").BandId
                    });
                    db.Insert(new Sound()
                    {
                        Name = "People Shit",
                        BandId = db.Table<Band>().FirstOrDefault(x1 => x1.Name == "Slipknot").BandId
                    });
                    db.Insert(new Sound()
                    {
                        Name = "Wait Bleed",
                        BandId = db.Table<Band>().FirstOrDefault(x1 => x1.Name == "Slipknot").BandId
                    });

                    //////ALTERNATIVE BANDS

                    ///////////////////////////////////////////////GREEN DAY///////////////////////////////////////////////
                    db.Insert(new Sound()
                    {
                        Name = "American Idiot",
                        BandId = db.Table<Band>().FirstOrDefault(x1 => x1.Name == "Green Day").BandId
                    });
                    db.Insert(new Sound()
                    {
                        Name = "Boulevard Of Broken Dreams",
                        BandId = db.Table<Band>().FirstOrDefault(x1 => x1.Name == "Green Day").BandId
                    });

                    ///////////////////////////////////////////////SKILLET///////////////////////////////////////////////
                    db.Insert(new Sound()
                    {
                        Name = "Awake And Alive",
                        BandId = db.Table<Band>().FirstOrDefault(x1 => x1.Name == "Skillet").BandId
                    });
                    db.Insert(new Sound()
                    {
                        Name = "Comatose",
                        BandId = db.Table<Band>().FirstOrDefault(x1 => x1.Name == "Skillet").BandId
                    });
                    db.Insert(new Sound()
                    {
                        Name = "Hero",
                        BandId = db.Table<Band>().FirstOrDefault(x1 => x1.Name == "Skillet").BandId
                    });
                    db.Insert(new Sound()
                    {
                        Name = "Monster",
                        BandId = db.Table<Band>().FirstOrDefault(x1 => x1.Name == "Skillet").BandId
                    });
                    db.Insert(new Sound()
                    {
                        Name = "Whispers In The Dark",
                        BandId = db.Table<Band>().FirstOrDefault(x1 => x1.Name == "Skillet").BandId
                    });

                    ///////////////////////////////////////////////PAPA ROACH///////////////////////////////////////////////
                    db.Insert(new Sound()
                    {
                        Name = "Hollywood Whore",
                        BandId = db.Table<Band>().FirstOrDefault(x1 => x1.Name == "Papa Roach").BandId
                    });
                    db.Insert(new Sound()
                    {
                        Name = "Last Resort",
                        BandId = db.Table<Band>().FirstOrDefault(x1 => x1.Name == "Papa Roach").BandId
                    });
                    db.Insert(new Sound()
                    {
                        Name = "Not Listening",
                        BandId = db.Table<Band>().FirstOrDefault(x1 => x1.Name == "Papa Roach").BandId
                    });
                    db.Insert(new Sound()
                    {
                        Name = "Scars",
                        BandId = db.Table<Band>().FirstOrDefault(x1 => x1.Name == "Papa Roach").BandId
                    });
                    db.Insert(new Sound()
                    {
                        Name = "She Loves Me Not",
                        BandId = db.Table<Band>().FirstOrDefault(x1 => x1.Name == "Papa Roach").BandId
                    });

                    ///////////////////////////////////////////////LINKIN PARK///////////////////////////////////////////////
                    db.Insert(new Sound()
                    {
                        Name = "Bleed It Out",
                        BandId = db.Table<Band>().FirstOrDefault(x1 => x1.Name == "Linkin Park").BandId
                    });
                    db.Insert(new Sound()
                    {
                        Name = "In The End",
                        BandId = db.Table<Band>().FirstOrDefault(x1 => x1.Name == "Linkin Park").BandId
                    });
                    db.Insert(new Sound()
                    {
                        Name = "Lost In The Echo",
                        BandId = db.Table<Band>().FirstOrDefault(x1 => x1.Name == "Linkin Park").BandId
                    });
                    db.Insert(new Sound()
                    {
                        Name = "New Divide",
                        BandId = db.Table<Band>().FirstOrDefault(x1 => x1.Name == "Linkin Park").BandId
                    });
                    db.Insert(new Sound()
                    {
                        Name = "Numb",
                        BandId = db.Table<Band>().FirstOrDefault(x1 => x1.Name == "Linkin Park").BandId
                    });

                    ///////////////////////////////////////////////MY CHEMICAL ROMANCE///////////////////////////////////////////////
                    db.Insert(new Sound()
                    {
                        Name = "Famous Last Words",
                        BandId = db.Table<Band>().FirstOrDefault(x1 => x1.Name == "My Chemical Romance").BandId
                    });
                    db.Insert(new Sound()
                    {
                        Name = "Helena",
                        BandId = db.Table<Band>().FirstOrDefault(x1 => x1.Name == "My Chemical Romance").BandId
                    });
                    db.Insert(new Sound()
                    {
                        Name = "Mama",
                        BandId = db.Table<Band>().FirstOrDefault(x1 => x1.Name == "My Chemical Romance").BandId
                    });
                    db.Insert(new Sound()
                    {
                        Name = "The Sharpest Lives",
                        BandId = db.Table<Band>().FirstOrDefault(x1 => x1.Name == "My Chemical Romance").BandId
                    });
                    #endregion

                    return db.GetAllWithChildren<Genre>(x => x.Name != string.Empty, true);
                }
                else
                    return db.GetAllWithChildren<Genre>(x => x.Name != string.Empty, true);
            }
        }

        public static void WriteScore(Score data)
        {
            using (SQLiteConnection db = new SQLiteConnection(_dbPath))
            {
                db.Update(data);
            };
        }

        public static Score GetScore(int genreId)
        {
            using (SQLiteConnection db = new SQLiteConnection(_dbPath))
            {
                return db.Table<Score>().FirstOrDefault(x => x.GenreId == genreId);
            };
        }

        public static List<Score> GetScores()
        {
            using (SQLiteConnection db = new SQLiteConnection(_dbPath))
            {
                return db.Table<Score>().ToList();
            };
        }
    }
}
