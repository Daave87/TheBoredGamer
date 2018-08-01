using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace TheBoredGamer.Models
{
    public class Game
    {
        public Guid GameId { get; set; }
        public int BoardGameGeekId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Thumbnail { get; set; }
        public string Image { get; set; }
        public int YearPubished { get; set; }
        public List<PlayerNumber> PlayerNumbers { get; set; }
        public int PlayingTimeMinutes { get; set; }
        public int MinPlayingTime { get; set; }
        public int MaxPlayingTime { get; set; }
        public int MinAge { get; set; }
        public int MinPlayers { get; set; }
        public int MaxPlayers { get; set; }
        public List<SuggestedPlayerAge> SuggestedPlayerAges { get; set; }
        public List<LanguageDependence> LanguageDependences { get; set; }
        public List<Category> Categories { get; set; }
        public List<Mechanic> Mechanics { get; set; }
        public List<Expansion> Expansions { get; set; }
        public List<Integration> Integrations { get; set; }
        public List<Designer> Designers { get; set; }
        public List<Artist> Artists { get; set; }
        public List<Publisher> Publishers { get; set; }
    }
}
