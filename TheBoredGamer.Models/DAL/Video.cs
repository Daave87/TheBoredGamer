using System;

namespace TheBoredGamer.Models
{
    public class Video
    {
        public Guid VideoId { get; set; }
        public int BoardGameGeekId { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Language { get; set; }
        public string Url { get; set; }
        public User User { get; set; }
        public DateTime PostedDateTime { get; set; }
    }
}