using System;

namespace TheBoredGamer.Models
{
    public class Publisher
    {
        public Guid PublisherId { get; set; }
        public int BoardGameGeekId { get; set; }
        public string Name { get; set; }
    }
}