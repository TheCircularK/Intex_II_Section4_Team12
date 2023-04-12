using System;
using System.Collections.Generic;

namespace Intex_II_Section4_Team12.Models
{
    public partial class Photodatum
    {
        public Photodatum()
        {
            MainTextiles = new HashSet<Textile>();
        }

        public long Id { get; set; }
        public string? Description { get; set; }
        public string? Filename { get; set; }
        public int? Photodataid { get; set; }
        public DateTime? Date { get; set; }
        public string? Url { get; set; }

        public virtual ICollection<Textile> MainTextiles { get; set; }
    }
}
