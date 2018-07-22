using System;

namespace TheBoredGamer.Models
{
    public class Category
    {
        public Guid CategoryId { get; set; }
        public int BoardGameGeekId { get; set; }
        public string Name { get; set; }
    }
}
