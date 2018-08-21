using System;

namespace TheBoredGamer.Models.DAL
{
    public class Artist
    {
        public string ArtistId { get; set; }
        public int BoardGameGeekId { get; set; }
        public string Name { get; set; }
    }
}