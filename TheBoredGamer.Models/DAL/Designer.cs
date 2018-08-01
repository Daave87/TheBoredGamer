using System;

namespace TheBoredGamer.Models
{
    public class Designer
    {
        public Guid DesignerId { get; set; }
        public int BoardGameGeekId { get; set; }
        public string Name { get; set; }
    }
}