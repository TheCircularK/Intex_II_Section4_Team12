using System;
using System.Collections.Generic;

namespace Intex_II_Section4_Team12.Models
{
    public partial class Analysis
    {
        public Analysis()
        {
            MainTextiles = new HashSet<Textile>();
        }

        public long Id { get; set; }
        public int? Analysistype { get; set; }
        public string? Doneby { get; set; }
        public int? Analysisid { get; set; }
        public DateTime? Date { get; set; }

        public virtual ICollection<Textile> MainTextiles { get; set; }
    }
}
