using System;
using System.Collections.Generic;

namespace Intex_II_Section4_Team12.Models
{
    public partial class Textilefunction
    {
        public Textilefunction()
        {
            MainTextiles = new HashSet<Textile>();
        }

        public long Id { get; set; }
        public string? Value { get; set; }
        public int? Textilefunctionid { get; set; }

        public virtual ICollection<Textile> MainTextiles { get; set; }
    }
}
