using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Xml.Serialization;
using NLog;
using TheBoredGamer.DAL;
using TheBoredGamer.Models;
using TheBoredGamer.Models.BoardGameGeek;
using TheBoredGamer.Models.DAL;

namespace TheBoredGamer.Scraper
{
    public class Program
    {
        private static GameRepository _gameRepository;
        private static ArtistRepository _artistRepository;
        private static CategoryRepository _categoryRepository;
        private static CompilationRepository _compilationRepository;
        private static DesignerRepository _designerRepository;
        private static ExpansionRepository _expansionRepository;
        private static LanguageDependenceRepository _languageDependenceRepository;
        private static FamilyRepository _familyRepository;
        private static IntegrationRepository _integrationRepository;
        private static PlayerNumberRepository _playerNumberRepository;
        private static PlayerAgeRepository _playerAgeRepository;
        private static MechanicRepository _mechanicRepository;
        private static PublisherRepository _publisherRepository;
        private static List<PlayerAge> _playerAges;
        private static List<Artist> _artists;
        private static List<Category> _categories;
        private static List<Compilation> _compilations;
        private static List<Designer> _designers;
        private static List<Expansion> _expansions;
        private static List<Family> _families;
        private static List<Integration> _integrations;
        private static List<LanguageDependence> _languageDependences;
        private static List<Mechanic> _mechanics;
        private static List<Publisher> _publishers;
        private static List<PlayerNumber> _playerNumbers;
        private const string BaseApiUrl = "https://www.boardgamegeek.com/xmlapi2/thing?id={0}";

        private static void Main(string[] args)
        {
            ConfigureLogger();

            var serializer = new XmlSerializer(typeof(Items));
            var itemsList = new List<Items>();
            var logger = LogManager.GetCurrentClassLogger();

            for (var bggId = 1; bggId <= 10; bggId++)
            {
                var httpRequest = (HttpWebRequest)WebRequest.Create(string.Format(BaseApiUrl, bggId));

                try
                {
                    var response = (HttpWebResponse) httpRequest.GetResponse();

                    //todo handle http status codes

                    var responseStream = response.GetResponseStream();

                    itemsList.Add((Items) serializer.Deserialize(responseStream));
                    responseStream?.Close();
                }
                catch (Exception exception)
                {
                    logger.Log(LogLevel.Error, exception, $"Error requesting item for BGG Id {bggId}");
                }
            }

            var modelBuilder = new ModelBuilder();

            var games = itemsList.Select(x => x.Item).Select(x => modelBuilder.GetGameFromItem(x)).ToList();

            logger.Log(LogLevel.Info, "Games built from items");

            SetupRepositories();

            foreach (var game in games)
            {
                _gameRepository.InsertOne(game);

                foreach (var artist in game.Artists)
                {
                    if (_artists.All(x => x.BoardGameGeekId != artist.BoardGameGeekId))
                    {
                        _artistRepository.InsertOne(artist);
                        _artists.Add(artist);
                    }

                    //game has artist
                }

                foreach (var category in game.Categories)
                {
                    if (_categories.All(x => x.BoardGameGeekId != category.BoardGameGeekId))
                    {
                        _categoryRepository.InsertOne(category);
                        _categories.Add(category);
                    }

                    //game has Category
                }

                foreach (var compilation in game.Compilations)
                {
                    if (_compilations.All(x => x.BoardGameGeekId != compilation.BoardGameGeekId))
                    {
                        _compilationRepository.InsertOne(compilation);
                        _compilations.Add(compilation);
                    }

                    //game has compilation
                }

                foreach (var designer in game.Designers)
                {
                    if (_designers.All(x => x.BoardGameGeekId != designer.BoardGameGeekId))
                    {
                        _designerRepository.InsertOne(designer);
                        _designers.Add(designer);
                    }

                    //game has designer
                }

                foreach (var expansion in game.Expansions)
                {
                    if (_expansions.All(x => x.BoardGameGeekId != expansion.BoardGameGeekId))
                    {
                        _expansionRepository.InsertOne(expansion);
                        _expansions.Add(expansion);
                    }

                    //game has expansion
                }

                foreach (var family in game.Families)
                {
                    if (_families.All(x => x.BoardGameGeekId != family.BoardGameGeekId))
                    {
                        _familyRepository.InsertOne(family);
                        _families.Add(family);
                    }

                    //game has family
                }

                foreach (var integration in game.Integrations)
                {
                    if (_integrations.All(x => x.BoardGameGeekId != integration.BoardGameGeekId))
                    {
                        _integrationRepository.InsertOne(integration);
                        _integrations.Add(integration);
                    }

                    //game has integration
                }

                foreach (var languageDependence in game.LanguageDependences)
                {
                    if (_languageDependences.All(x => x.Description != languageDependence.Description))
                    {
                        _languageDependenceRepository.InsertOne(languageDependence);
                        _languageDependences.Add(languageDependence);
                    }

                    //game has languageDependence
                }

                foreach (var mechanic in game.Mechanics)
                {
                    if (_mechanics.All(x => x.BoardGameGeekId != mechanic.BoardGameGeekId))
                    {
                        _mechanicRepository.InsertOne(mechanic);
                        _mechanics.Add(mechanic);
                    }

                    //game has mechanic
                }

                foreach (var playerNumber in game.PlayerNumbers)
                {
                    if (!_playerNumbers.Any(x => x.Number == playerNumber.Number && x.AndUp == playerNumber.AndUp))
                    {
                        _playerNumberRepository.InsertOne(playerNumber);
                        _playerNumbers.Add(playerNumber);
                    }

                    //game has playerNumber
                }

                foreach (var playerAge in game.PlayerAges)
                {
                    if (!_playerAges.Any(x => x.Age == playerAge.Age && x.AndUp == playerAge.AndUp))
                    {
                        _playerAgeRepository.InsertOne(playerAge);
                        _playerAges.Add(playerAge);
                    }

                    //game has playerAge
                }

                foreach (var publisher in game.Publishers)
                {
                    if (_publishers.All(x => x.BoardGameGeekId != publisher.BoardGameGeekId))
                    {
                        _publisherRepository.InsertOne(publisher);
                        _publishers.Add(publisher);
                    }

                    //game has publisher
                }
            }
        }

        private static void SetupRepositories()
        {
            _gameRepository = new GameRepository();
            
            _artistRepository = new ArtistRepository();
            _artists = _artistRepository.GetAllItems();
            
            _categoryRepository = new CategoryRepository();
            _categories = _categoryRepository.GetAllItems();
            
            _compilationRepository = new CompilationRepository();
            _compilations = _compilationRepository.GetAllItems();
            
            _designerRepository = new DesignerRepository();
            _designers = _designerRepository.GetAllItems();
            
            _expansionRepository = new ExpansionRepository();
            _expansions = _expansionRepository.GetAllItems();
            
            _familyRepository = new FamilyRepository();
            _families = _familyRepository.GetAllItems();
            
            _integrationRepository = new IntegrationRepository();
            _integrations = _integrationRepository.GetAllItems();
            
            _languageDependenceRepository = new LanguageDependenceRepository();
            _languageDependences = _languageDependenceRepository.GetAllItems();
            
            _mechanicRepository = new MechanicRepository();
            _mechanics = _mechanicRepository.GetAllItems();
            
            _playerNumberRepository = new PlayerNumberRepository();
            _playerNumbers = _playerNumberRepository.GetAllItems();
            
            _publisherRepository = new PublisherRepository();
            _publishers = _publisherRepository.GetAllItems();
            
            _playerAgeRepository = new PlayerAgeRepository();
            _playerAges = _playerAgeRepository.GetAllItems();
        }

        private static void ConfigureLogger()
        {
            var config = new NLog.Config.LoggingConfiguration();

            var logfile = new NLog.Targets.FileTarget("logfile") {FileName = "file.txt"};
            var logconsole = new NLog.Targets.ConsoleTarget("logconsole");

            config.AddRule(LogLevel.Info, LogLevel.Fatal, logconsole);
            config.AddRule(LogLevel.Debug, LogLevel.Fatal, logfile);

            LogManager.Configuration = config;
        }
    }
}
