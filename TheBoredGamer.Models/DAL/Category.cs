using System;

namespace TheBoredGamer.Models.DAL
{
    public class Category
    {
        public string CategoryId { get; set; }
        public int BoardGameGeekId { get; set; }
        public string Name { get; set; }
    }
}
