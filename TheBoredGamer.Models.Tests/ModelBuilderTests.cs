using System.Collections.Generic;
using System.Linq;
using TheBoredGamer.Models.BoardGameGeek;
using TheBoredGamer.Models.DAL;
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
            Assert.Equal(1999, game.YearPublished);
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
        public void SuggestedPlayerAgesPollMapsToPlayerAgesCorrectly()
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
        public void LanguageDependencePollMapsToLanguageDependencesCorrectly()
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
                                        Value = "No necessary in-game text",
                                        Numvotes = "10"
                                    },
                                    new Result
                                    {
                                        Value = "Some necessary text - easily memorized or small crib sheet",
                                        Numvotes = "40"
                                    },
                                    new Result
                                    {
                                        Value = "Moderate in-game text - needs crib sheet or paste ups",
                                        Numvotes = "183"
                                    }
                                }
                            }
                        }
                    }
                }
            };

            //act
            var languageDependences = modelBuilder.GetGameFromItem(item).LanguageDependences;

            //assert
            Assert.Equal(3, languageDependences.Count);
            Assert.Equal(10, languageDependences.SingleOrDefault(x => x.Description == "No necessary in-game text")?.Votes);
            Assert.Equal(183, languageDependences.SingleOrDefault(x => x.Description == "Moderate in-game text - needs crib sheet or paste ups")?.Votes);
        }

        [Fact]
        public void CategoryLinksMapToCategoriesCorrectly()
        {
            //arrange
            var modelBuilder = new ModelBuilder();
            var item = new Item
            {
                Link = new List<Link>
                {
                    new Link
                    {
                        Id = "321",
                        Type = "boardgamecategory",
                        Value = "Adventure"
                    },
                    new Link
                    {
                        Id = "91",
                        Type = "boardgamecategory",
                        Value = "Fighting"
                    }
                }
            };

            //act
            var categories = modelBuilder.GetGameFromItem(item).Categories;

            //assert
            Assert.Equal(2, categories.Count);
            Assert.Equal("Adventure", categories.SingleOrDefault(x => x.BoardGameGeekId == 321)?.Name);
            Assert.Equal("Fighting", categories.SingleOrDefault(x => x.BoardGameGeekId == 91)?.Name);
        }

        [Fact]
        public void MechanicLinksMapToMechanicsCorrectly()
        {
            //arrange
            var modelBuilder = new ModelBuilder();
            var item = new Item
            {
                Link = new List<Link>
                {
                    new Link
                    {
                        Id = "21",
                        Type = "boardgamemechanic",
                        Value = "Turn-based"
                    },
                    new Link
                    {
                        Id = "901",
                        Type = "boardgamemechanic",
                        Value = "Grid Movement"
                    }
                }
            };

            //act
            var mechanics = modelBuilder.GetGameFromItem(item).Mechanics;

            //assert
            Assert.Equal(2, mechanics.Count);
            Assert.Equal("Turn-based", mechanics.SingleOrDefault(x => x.BoardGameGeekId == 21)?.Name);
            Assert.Equal("Grid Movement", mechanics.SingleOrDefault(x => x.BoardGameGeekId == 901)?.Name);
        }

        [Fact]
        public void ExpansionLinksMapToExpansionsCorrectly()
        {
            //arrange
            var modelBuilder = new ModelBuilder();
            var item = new Item
            {
                Link = new List<Link>
                {
                    new Link
                    {
                        Id = "121",
                        Type = "boardgameexpansion",
                        Value = "Expansion1"
                    },
                    new Link
                    {
                        Id = "11",
                        Type = "boardgameexpansion",
                        Value = "Expansion2"
                    }
                }
            };

            //act
            var expansions = modelBuilder.GetGameFromItem(item).Expansions;

            //assert
            Assert.Equal(2, expansions.Count);
            Assert.Equal("Expansion1", expansions.SingleOrDefault(x => x.BoardGameGeekId == 121)?.Name);
            Assert.Equal("Expansion2", expansions.SingleOrDefault(x => x.BoardGameGeekId == 11)?.Name);
        }

        [Fact]
        public void IntegrationLinksMapToIntegrationsCorrectly()
        {
            //arrange
            var modelBuilder = new ModelBuilder();
            var item = new Item
            {
                Link = new List<Link>
                {
                    new Link
                    {
                        Id = "1021",
                        Type = "boardgameintegration",
                        Value = "Integration1"
                    },
                    new Link
                    {
                        Id = "171",
                        Type = "boardgameintegration",
                        Value = "Integration2"
                    }
                }
            };

            //act
            var integrations = modelBuilder.GetGameFromItem(item).Integrations;

            //assert
            Assert.Equal(2, integrations.Count);
            Assert.Equal("Integration1", integrations.SingleOrDefault(x => x.BoardGameGeekId == 1021)?.Name);
            Assert.Equal("Integration2", integrations.SingleOrDefault(x => x.BoardGameGeekId == 171)?.Name);
        }

        [Fact]
        public void DesignerLinksMapToDesignersCorrectly()
        {
            //arrange
            var modelBuilder = new ModelBuilder();
            var item = new Item
            {
                Link = new List<Link>
                {
                    new Link
                    {
                        Id = "102",
                        Type = "boardgamedesigner",
                        Value = "Designer1"
                    },
                    new Link
                    {
                        Id = "17",
                        Type = "boardgamedesigner",
                        Value = "Designer2"
                    }
                }
            };

            //act
            var designers = modelBuilder.GetGameFromItem(item).Designers;

            //assert
            Assert.Equal(2, designers.Count);
            Assert.Equal("Designer1", designers.SingleOrDefault(x => x.BoardGameGeekId == 102)?.Name);
            Assert.Equal("Designer2", designers.SingleOrDefault(x => x.BoardGameGeekId == 17)?.Name);
        }

        [Fact]
        public void ArtistLinksMapToArtistsCorrectly()
        {
            //arrange
            var modelBuilder = new ModelBuilder();
            var item = new Item
            {
                Link = new List<Link>
                {
                    new Link
                    {
                        Id = "172",
                        Type = "boardgameartist",
                        Value = "Artist1"
                    },
                    new Link
                    {
                        Id = "317",
                        Type = "boardgameartist",
                        Value = "Artist2"
                    }
                }
            };

            //act
            var artists = modelBuilder.GetGameFromItem(item).Artists;

            //assert
            Assert.Equal(2, artists.Count);
            Assert.Equal("Artist1", artists.SingleOrDefault(x => x.BoardGameGeekId == 172)?.Name);
            Assert.Equal("Artist2", artists.SingleOrDefault(x => x.BoardGameGeekId == 317)?.Name);
        }

        [Fact]
        public void PublisherLinksMapToPublishersCorrectly()
        {
            //arrange
            var modelBuilder = new ModelBuilder();
            var item = new Item
            {
                Link = new List<Link>
                {
                    new Link
                    {
                        Id = "170",
                        Type = "boardgamepublisher",
                        Value = "Publisher1"
                    },
                    new Link
                    {
                        Id = "31",
                        Type = "boardgamepublisher",
                        Value = "Publisher2"
                    }
                }
            };

            //act
            var publishers = modelBuilder.GetGameFromItem(item).Publishers;

            //assert
            Assert.Equal(2, publishers.Count);
            Assert.Equal("Publisher1", publishers.SingleOrDefault(x => x.BoardGameGeekId == 170)?.Name);
            Assert.Equal("Publisher2", publishers.SingleOrDefault(x => x.BoardGameGeekId == 31)?.Name);
        }

        [Fact]
        public void CompilationLinksMapToCompilationsCorrectly()
        {
            //arrange
            var modelBuilder = new ModelBuilder();
            var item = new Item
            {
                Link = new List<Link>
                {
                    new Link
                    {
                        Id = "77",
                        Type = "boardgamecompilation",
                        Value = "Compilation1"
                    },
                    new Link
                    {
                        Id = "3",
                        Type = "boardgamecompilation",
                        Value = "Compilation2"
                    }
                }
            };

            //act
            var compilations = modelBuilder.GetGameFromItem(item).Compilations;

            //assert
            Assert.Equal(2, compilations.Count);
            Assert.Equal("Compilation1", compilations.SingleOrDefault(x => x.BoardGameGeekId == 77)?.Name);
            Assert.Equal("Compilation2", compilations.SingleOrDefault(x => x.BoardGameGeekId == 3)?.Name);
        }

        [Fact]
        public void FamilyLinksMapToFamilysCorrectly()
        {
            //arrange
            var modelBuilder = new ModelBuilder();
            var item = new Item
            {
                Link = new List<Link>
                {
                    new Link
                    {
                        Id = "10",
                        Type = "boardgamefamily",
                        Value = "Family1"
                    },
                    new Link
                    {
                        Id = "381",
                        Type = "boardgamefamily",
                        Value = "Family2"
                    }
                }
            };

            //act
            var families = modelBuilder.GetGameFromItem(item).Families;

            //assert
            Assert.Equal(2, families.Count);
            Assert.Equal("Family1", families.SingleOrDefault(x => x.BoardGameGeekId == 10)?.Name);
            Assert.Equal("Family2", families.SingleOrDefault(x => x.BoardGameGeekId == 381)?.Name);
        }
    }
}

