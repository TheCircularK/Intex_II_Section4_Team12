using System.ComponentModel.DataAnnotations;

namespace Intex_II_Section4_Team12.Models
{
    public class MyApiRequestData
    {
        public float Length { get; set; }
        public float Depth { get; set; }
        public float WestToHead { get; set; }
        public string AgeAtDeath { get; set; }
        public float AgeAtDeath_other { get; set; }
        public float AgeAtDeath_adult { get; set; }
        public float AgeAtDeath_child { get; set; }
        public float AgeAtDeath_infant { get; set; }
        public float WestToFeet { get; set; }
        public float SouthToHead { get; set; }
        public string Wrapping { get; set; }
        public float Wrapping_full { get; set; }
        public float Wrapping_partial { get; set; }
        public float Wrapping_none { get; set; }
    }
}
