using System.Collections.Generic;
using System.Linq;
using TheBoredGamer.Models.BoardGameGeek;
using Xunit;

namespace TheBoredGamer.Models.Tests
{
    public class ModelBuilderTests
    {
        [Fact]
        public void ItemMapsToGameCorrectly()
        {
            //arrange
            var modelBuilder = new ModelBuilder();
            var item = new Item
            {
                Description = "test",
                Id = "123",
                Image = "test.jpg",
                Thumbnail = "thumb.jpg",
                Type = "type",
                Yearpublished = new Yearpublished { Value = "1999" },
                Minplayers = new Minplayers {Value = "2" },
                Minplaytime = new Minplaytime {Value = "15" },
                Minage = new Minage { Value = "5" },
                Maxplaytime = new Maxplaytime { Value = "45" },
                Maxplayers = new Maxplayers { Value = "4" },
                Playingtime = new Playingtime { Value = "25" },
                Name = new List<Name>
                {
                    new Name
                    {
                        Type = "primary",
                        Value = "name1"
                    }
                }
            };

            //act
            var game = modelBuilder.GetGameFromItem(item);

            //assert
            Assert.Equal("test", game.Description);
            Assert.Equal(123, game.BoardGameGeekId);
            Assert.Equal("test.jpg", game.Image);
            Assert.Equal("thumb.jpg", game.Thumbnail);
            Assert.Equal("name1", game.Name);
            Assert.Equal(1999, game.YearPubished);
            Assert.Equal(15, game.MinPlayingTime);
            Assert.Equal(5, game.MinAge);
            Assert.Equal(2, game.MinPlayers);
            Assert.Equal(25, game.PlayingTime);
            Assert.Equal(4, game.MaxPlayers);
            Assert.Equal(45, game.MaxPlayingTime);
        }

        [Fact]
        public void SuggestedNumberPlayersPollMapsToPlayerNumbersCorrectly()
        {
            //arrange
            var modelBuilder = new ModelBuilder();
            var item = new Item
            {
                Poll = new List<Poll>
                {
                    new Poll
                    {
                        Name = "suggested_numplayers",
                        Results = new List<Results>
                        {
                            new Results
                            {
                                Numplayers = "1", 
                                Result = new List<Result>
                                {
                                    new Result
                                    {
                                        Value = "Best",
                                        Numvotes = "123"
                                    },
                                    new Result
                                    {
                                        Value = "Recommended",
                                        Numvotes = "64"
                                    },
                                    new Result
                                    {
                                        Value = "Not Recommended",
                                        Numvotes = "13"
                                    }
                                }
                            },
                            new Results
                            {
                                Numplayers = "2",
                                Result = new List<Result>
                                {
                                    new Result
                                    {
                                        Value = "Best",
                                        Numvotes = "13"
                                    },
                                    new Result
                                    {
                                        Value = "Recommended",
                                        Numvotes = "114"
                                    },
                                    new Result
                                    {
                                        Value = "Not Recommended",
                                        Numvotes = "139"
                                    }
                                }
                            },
                            new Results
                            {
                                Numplayers = "3+",
                                Result = new List<Result>
                                {
                                    new Result
                                    {
                                        Value = "Best",
                                        Numvotes = "3"
                                    },
                                    new Result
                                    {
                                        Value = "Recommended",
                                        Numvotes = "14"
                                    },
                                    new Result
                                    {
                                        Value = "Not Recommended",
                                        Numvotes = "209"
                                    }
                                }
                            }
                        }
                    }
                }
            };

            //act
            var playerNumbers = modelBuilder.GetGameFromItem(item).PlayerNumbers;

            //assert
            Assert.Equal(3, playerNumbers.Count);
            Assert.Equal(64, playerNumbers.SingleOrDefault(x => x.Number == 1)?.RecommendedVotes);
            Assert.Equal(139, playerNumbers.SingleOrDefault(x => x.Number == 2)?.NotRecommendedVotes);
            Assert.Equal(3, playerNumbers.SingleOrDefault(x => x.Number == 3 && x.AndUp)?.BestVotes);
        }

        [Fact]
        public void SuggestedPlayerAgesPollMapsToPlayerNumbersCorrectly()
        {
            //arrange
            var modelBuilder = new ModelBuilder();
            var item = new Item
            {
                Poll = new List<Poll>
                {
                    new Poll
                    {
                        Name = "suggested_playerage",
                        Results = new List<Results>
                        {
                            new Results
                            {
                                Result = new List<Result>
                                {
                                    new Result
                                    {
                                        Value = "1",
                                        Numvotes = "23"
                                    },
                                    new Result
                                    {
                                        Value = "2",
                                        Numvotes = "4"
                                    },
                                    new Result
                                    {
                                        Value = "3",
                                        Numvotes = "13"
                                    },
                                    new Result
                                    {
                                        Value = "3 and up",
                                        Numvotes = "139"
                                    }
                                }
                            }
                        }
                    }
                }
            };

            //act
            var playerAges = modelBuilder.GetGameFromItem(item).PlayerAges;

            //assert
            Assert.Equal(4, playerAges.Count);
            Assert.Equal(23, playerAges.SingleOrDefault(x => x.Age == 1)?.Votes);
            Assert.Equal(139, playerAges.SingleOrDefault(x => x.Age == 3 && x.AndUp)?.Votes);
        }

        [Fact]
        public void LanguageDependencePollMapsToPlayerNumbersCorrectly()
        {
            //arrange
            var modelBuilder = new ModelBuilder();
            var item = new Item
            {
                Poll = new List<Poll>
                {
                    new Poll
                    {
                        Name = "language_dependence",
                        Results = new List<Results>
                        {
                            new Results
                            {
                                Result = new List<Result>
                                {
                                    new Result
                                    {
                                        Value = "1",
                                        Numvotes = "23"
                                    },
                                    new Result
                                    {
                                        Value = "2",
                                        Numvotes = "4"
                                    },
                                    new Result
                                    {
                                        Value = "3",
                                        Numvotes = "13"
                                    },
                                    new Result
                                    {
                                        Value = "3 and up",
                                        Numvotes = "139"
                                    }
                                }
                            }
                        }
                    }
                }
            };

            //act
            var playerAges = modelBuilder.GetGameFromItem(item).PlayerAges;

            //assert
            Assert.Equal(4, playerAges.Count);
            Assert.Equal(23, playerAges.SingleOrDefault(x => x.Age == 1)?.Votes);
            Assert.Equal(139, playerAges.SingleOrDefault(x => x.Age == 3 && x.AndUp)?.Votes);
        }
    }
}



//public List<LanguageDependence> LanguageDependences { get; set; }
//public List<Category> Categories { get; set; }
//public List<Mechanic> Mechanics { get; set; }
//public List<Expansion> Expansions { get; set; }
//public List<Integration> Integrations { get; set; }
//public List<Designer> Designers { get; set; }
//public List<Artist> Artists { get; set; }
//public List<Publisher> Publishers { get; set; }
//public List<Family> Families { get; set; }

