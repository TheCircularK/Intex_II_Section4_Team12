﻿using System;
using System.Collections.Generic;

namespace Intex_II_Section4_Team12.Models
{
    public partial class Book
    {
        public long Id { get; set; }
        public string? Description { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public string? Link { get; set; }
    }
}
