using System;

namespace TheBoredGamer.Models
{
    public class Mechanic
    {
        public Guid MechanicId { get; set; }
        public int BoardGameGeekId { get; set; }
        public string Name { get; set; }
    }
}