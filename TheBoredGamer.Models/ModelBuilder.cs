using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using TheBoredGamer.Models.BoardGameGeek;
using TheBoredGamer.Models.DAL;

namespace TheBoredGamer.Models
{
    public class ModelBuilder
    {
        private readonly IMapper _mapper;

        public ModelBuilder()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Item, Game>()
                    .ForMember(dest => dest.BoardGameGeekId, opt => opt.MapFrom(src => int.Parse(src.Id)))
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.FirstOrDefault(x => x.Type == "primary").Value))
                    .ForMember(dest => dest.YearPubished, opt => opt.MapFrom(src => src.Yearpublished.Value))
                    .ForMember(dest => dest.MaxPlayers, opt => opt.MapFrom(src => src.Maxplayers.Value))
                    .ForMember(dest => dest.MaxPlayingTime, opt => opt.MapFrom(src => src.Maxplaytime.Value))
                    .ForMember(dest => dest.MinAge, opt => opt.MapFrom(src => src.Minage.Value))
                    .ForMember(dest => dest.PlayingTime, opt => opt.MapFrom(src => src.Playingtime.Value))
                    .ForMember(dest => dest.MinPlayers, opt => opt.MapFrom(src => src.Minplayers.Value))
                    .ForMember(dest => dest.MinPlayingTime, opt => opt.MapFrom(src => src.Minplaytime.Value))
                    .ForMember(dest => dest.PlayerNumbers, opt => opt.MapFrom(src => GetPlayerNumbersFromPoll(src.Poll.SingleOrDefault(x => x.Name == "suggested_numplayers"))))
                    .ForMember(dest => dest.PlayerAges, opt => opt.MapFrom(src => GetPlayerAgesFromPoll(src.Poll.SingleOrDefault(x => x.Name == "suggested_playerage"))))
                    .ForMember(dest => dest.LanguageDependences, opt => opt.MapFrom(src => GetLanguageDependencesFromPoll(src.Poll.SingleOrDefault(x => x.Name == "language_dependence"))))
                    .ForMember(dest => dest.Artists, opt => opt.MapFrom(src => GetArtistsFromLinks(src.Link.Where(x => x.Type == "boardgameartist"))))
                    .ForMember(dest => dest.Categories, opt => opt.MapFrom(src => GetCategoriesFromLinks(src.Link.Where(x => x.Type == "boardgamecategory"))))
                    .ForMember(dest => dest.Mechanics, opt => opt.MapFrom(src => GetMechanicsFromLinks(src.Link.Where(x => x.Type == "boardgamemechanic"))))
                    .ForMember(dest => dest.Publishers, opt => opt.MapFrom(src => GetPublishersFromLinks(src.Link.Where(x => x.Type == "boardgamepublisher"))))
                    .ForMember(dest => dest.Expansions, opt => opt.MapFrom(src => GetExpansionsFromLinks(src.Link.Where(x => x.Type == "boardgameexpansion"))))
                    .ForMember(dest => dest.Designers, opt => opt.MapFrom(src => GetDesignersFromLinks(src.Link.Where(x => x.Type == "boardgamedesigner"))))
                    .ForMember(dest => dest.Families, opt => opt.MapFrom(src => GetFamiliesFromLinks(src.Link.Where(x => x.Type == "boardgamefamily"))))
                    .ForMember(dest => dest.Integrations, opt => opt.MapFrom(src => GetIntegrationsFromLinks(src.Link.Where(x => x.Type == "boardgameintegration"))))
                    ;
            });
            
            _mapper = config.CreateMapper();
        }

        public Game GetGameFromItem(Item item)
        {
            return _mapper.Map<Item, Game>(item);
        }

        private static IEnumerable<PlayerNumber> GetPlayerNumbersFromPoll(Poll poll)
        {
            foreach (var results in poll.Results)
            {
                yield return new PlayerNumber
                {
                    Number = Convert.ToInt32(results.Numplayers.Replace("+", "")),
                    AndUp = results.Numplayers.Contains("+"),
                    BestVotes = results.Result.Where(x => x.Value == "Best").Sum(x => Convert.ToInt32(x.Numvotes)),
                    RecommendedVotes = results.Result.Where(x => x.Value == "Recommended").Sum(x => Convert.ToInt32(x.Numvotes)),
                    NotRecommendedVotes = results.Result.Where(x => x.Value == "Not Recommended").Sum(x => Convert.ToInt32(x.Numvotes))
                };
            }
        }

        private static IEnumerable<SuggestedPlayerAge> GetPlayerAgesFromPoll(Poll poll)
        {
            return poll.Results.SingleOrDefault()?.Result.Select(result => new SuggestedPlayerAge
            {
                Age = Convert.ToInt32(result.Value.Replace(" and up", "")),
                AndUp = result.Value.Contains(" and up"),
                Votes = Convert.ToInt32(result.Numvotes)
            });
        }

        private static IEnumerable<LanguageDependence> GetLanguageDependencesFromPoll(Poll poll)
        {
            return poll.Results.SingleOrDefault()?.Result.Select(result => new LanguageDependence
            {
                Level = (LanguageDependenceLevel) Convert.ToInt32(result.Level),
                Votes = Convert.ToInt32(result.Numvotes)
            });
        }

        private static IEnumerable<Artist> GetArtistsFromLinks(IEnumerable<Link> links)
        {
            return links.Select(link => new Artist
            {
                Name = link.Value,
                BoardGameGeekId = Convert.ToInt32(link.Id)
            });
        }

        private static IEnumerable<Category> GetCategoriesFromLinks(IEnumerable<Link> links)
        {
            return links.Select(link => new Category
            {
                Name = link.Value,
                BoardGameGeekId = Convert.ToInt32(link.Id)
            });
        }

        private static IEnumerable<Publisher> GetPublishersFromLinks(IEnumerable<Link> links)
        {
            return links.Select(link => new Publisher
            {
                Name = link.Value,
                BoardGameGeekId = Convert.ToInt32(link.Id)
            });
        }

        private static IEnumerable<Expansion> GetExpansionsFromLinks(IEnumerable<Link> links)
        {
            return links.Select(link => new Expansion
            {
                Name = link.Value,
                BoardGameGeekId = Convert.ToInt32(link.Id)
            });
        }

        private static IEnumerable<Mechanic> GetMechanicsFromLinks(IEnumerable<Link> links)
        {
            return links.Select(link => new Mechanic
            {
                Name = link.Value,
                BoardGameGeekId = Convert.ToInt32(link.Id)
            });
        }

        private static IEnumerable<Integration> GetIntegrationsFromLinks(IEnumerable<Link> links)
        {
            return links.Select(link => new Integration
            {
                Name = link.Value,
                BoardGameGeekId = Convert.ToInt32(link.Id)
            });
        }

        private static IEnumerable<Designer> GetDesignersFromLinks(IEnumerable<Link> links)
        {
            return links.Select(link => new Designer
            {
                Name = link.Value,
                BoardGameGeekId = Convert.ToInt32(link.Id)
            });
        }

        private static IEnumerable<Family> GetFamiliesFromLinks(IEnumerable<Link> links)
        {
            return links.Select(link => new Family
            {
                Name = link.Value,
                BoardGameGeekId = Convert.ToInt32(link.Id)
            });
        }
    }
}
