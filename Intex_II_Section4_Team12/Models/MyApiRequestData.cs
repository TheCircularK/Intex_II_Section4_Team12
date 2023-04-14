using System.ComponentModel.DataAnnotations;

namespace Intex_II_Section4_Team12.Models
{
    public class MyApiRequestData
    {
        [Required]
        public float Length { get; set; }
        [Required]
        public float Depth { get; set; }
        [Required]
        public float WestToHead { get; set; }
        [Required]
        public string AgeAtDeath { get; set; }
        public float AgeAtDeath_other { get; set; }
        public float AgeAtDeath_adult { get; set; }
        public float AgeAtDeath_child { get; set; }
        public float AgeAtDeath_infant { get; set; }
        [Required]
        public float WestToFeet { get; set; }
        [Required]
        public float SouthToHead { get; set; }
        [Required]
        public string Wrapping { get; set; }
        public float Wrapping_full { get; set; }
        public float Wrapping_partial { get; set; }
        public float Wrapping_none { get; set; }
    }
}
