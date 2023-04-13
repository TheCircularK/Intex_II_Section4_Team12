﻿using System;
using System.Collections.Generic;

namespace Intex_II_Section4_Team12.Models
{
    public partial class Burialmain
    {
        public Burialmain()
        {
            MainTextiles = new HashSet<Textile>();
            BodyAnalysisCharts = new HashSet<Bodyanalysischart>();
        }

        public long Id { get; set; }
        public string? Squarenorthsouth { get; set; }
        public string? Headdirection { get; set; }
        public string? Sex { get; set; }
        public string? Northsouth { get; set; }
        public double? Depth { get; set; }
        public string? Eastwest { get; set; }
        public string? Adultsubadult { get; set; }
        public string? Facebundles { get; set; }
        public string? Southtohead { get; set; }
        public string? Preservation { get; set; }
        public string? Fieldbookpage { get; set; }
        public string? Squareeastwest { get; set; }
        public string? Goods { get; set; }
        public string? Text { get; set; }
        public string? Wrapping { get; set; }
        public string? Haircolor { get; set; }
        public string? Westtohead { get; set; }
        public string? Samplescollected { get; set; }
        public string? Area { get; set; }
        public long? Burialid { get; set; }
        public string? Length { get; set; }
        public string? Burialnumber { get; set; }
        public string? Dataexpertinitials { get; set; }
        public string? Westtofeet { get; set; }
        public string? Ageatdeath { get; set; }
        public string? Southtofeet { get; set; }
        public string? Excavationrecorder { get; set; }
        public string? Photos { get; set; }
        public string? Hair { get; set; }
        public string? Burialmaterials { get; set; }
        public DateTime? Dateofexcavation { get; set; }
        public string? Fieldbookexcavationyear { get; set; }
        public string? Clusternumber { get; set; }
        public string? Shaftnumber { get; set; }

        public virtual ICollection<Textile> MainTextiles { get; set; }
        public virtual ICollection<Bodyanalysischart> BodyAnalysisCharts { get; set; }
    }
}
