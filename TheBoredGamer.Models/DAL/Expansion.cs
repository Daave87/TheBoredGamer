﻿using System;

namespace TheBoredGamer.Models.DAL
{
    public class Expansion
    {
        public Guid ExpansionId { get; set; }
        public int BoardGameGeekId { get; set; }
        public string Name { get; set; }
    }
}
