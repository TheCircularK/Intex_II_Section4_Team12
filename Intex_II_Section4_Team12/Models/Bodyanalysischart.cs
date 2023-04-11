using System;
using System.Collections.Generic;

namespace Intex_II_Section4_Team12.Models
{
    public partial class Bodyanalysischart
    {
        public long? Id { get; set; }
        public long? BurialMainId { get; set; }
        public string? SquareNorthSouth { get; set; }
        public string? NorthSouth { get; set; }
        public string? SquareEastWest { get; set; }
        public string? EastWest { get; set; }
        public string? Area { get; set; }
        public string? BurialNumber { get; set; }
        public string? DateofExamination { get; set; }
        public int? PreservationIndex { get; set; }
        public string? HairColor { get; set; }
        public string? Observations { get; set; }
        public string? Robust { get; set; }
        public string? SupraorbitalRidges { get; set; }
        public string? OrbitEdge { get; set; }
        public string? ParietalBossing { get; set; }
        public string? Gonion { get; set; }
        public string? NuchalCrest { get; set; }
        public string? ZygomaticCrest { get; set; }
        public string? SphenooccipitalSynchrondrosis { get; set; }
        public string? LamboidSuture { get; set; }
        public string? SquamosSuture { get; set; }
        public string? ToothAttrition { get; set; }
        public string? ToothEruption { get; set; }
        public string? ToothEruptionAgeEstimate { get; set; }
        public string? VentralArc { get; set; }
        public string? SubpubicAngle { get; set; }
        public string? SciaticNotch { get; set; }
        public string? PubicBone { get; set; }
        public string? PreauricularSulcusBoolean { get; set; }
        public string? MedialIpRamus { get; set; }
        public string? DorsalPittingBoolean { get; set; }
        public string? Femur { get; set; }
        public string? Humerus { get; set; }
        public decimal? FemurHeadDiameter { get; set; }
        public decimal? HumerusHeadDiameter { get; set; }
        public decimal? FemurLength { get; set; }
        public decimal? HumerusLength { get; set; }
        public decimal? Tibia { get; set; }
        public string? EstimateStature { get; set; }
        public string? Osteophytosis { get; set; }
        public string? CariesPeriodontalDisease { get; set; }
        public string? Notes { get; set; }

        public virtual Burialmain? BurialMain { get; set; }
    }
}
