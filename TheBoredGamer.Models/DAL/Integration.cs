using System;

namespace TheBoredGamer.Models.DAL
{
    public class Integration
    {
        public Guid IntegrationId { get; set; }
        public int BoardGameGeekId { get; set; }
        public string Name { get; set; }
    }
}
