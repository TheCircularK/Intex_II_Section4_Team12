using System;
using System.Collections.Generic;

namespace Intex_II_Section4_Team12.Models
{
    public partial class DimensionTextile
    {
        public long MainDimensionid { get; set; }
        public long MainTextileid { get; set; }

        public virtual Textile MainTextile { get; set; } = null!;
    }
}
