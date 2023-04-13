using System;
using System.Collections.Generic;

namespace Intex_II_Section4_Team12.Models
{
    public partial class Yarnmanipulation
    {
        public Yarnmanipulation()
        {
            MainTextiles = new HashSet<Textile>();
        }

        public long Id { get; set; }
        public string? Thickness { get; set; }
        public string? Angle { get; set; }
        public string? Manipulation { get; set; }
        public string? Material { get; set; }
        public string? Count { get; set; }
        public string? Component { get; set; }
        public string? Ply { get; set; }
        public int? Yarnmanipulationid { get; set; }
        public string? Direction { get; set; }

        public virtual ICollection<Textile> MainTextiles { get; set; }
    }
}
