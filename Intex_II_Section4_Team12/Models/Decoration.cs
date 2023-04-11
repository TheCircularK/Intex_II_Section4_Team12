using System;
using System.Collections.Generic;

namespace Intex_II_Section4_Team12.Models
{
    public partial class Decoration
    {
        public Decoration()
        {
            MainTextiles = new HashSet<Textile>();
        }

        public long Id { get; set; }
        public int? Decorationid { get; set; }
        public string? Value { get; set; }

        public virtual ICollection<Textile> MainTextiles { get; set; }
    }
}
