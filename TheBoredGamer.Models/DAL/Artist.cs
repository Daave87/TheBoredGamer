﻿using System;

namespace TheBoredGamer.Models
{
    public class Artist
    {
        public Guid ArtistId { get; set; }
        public int BoardGameGeekId { get; set; }
        public string Name { get; set; }
    }
}