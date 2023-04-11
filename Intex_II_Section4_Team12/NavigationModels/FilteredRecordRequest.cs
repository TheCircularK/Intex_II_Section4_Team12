namespace Intex_II_Section4_Team12.NavigationModels
{
    public class FilteredRecordRequest
    {
        public FilteredRecordRequest(int pageNum)
        {
            PageNum = pageNum;
        }

        public List<long>? TextileStructureIds { get; set; } = new();
        public List<string>? Sexes { get; set; } = new();

        public float? MinBurialDepth { get; set; } = new();
        public float? MaxBurialDepth { get; set; } = new();

        public int? MinEstimateStature { get; set; } = new();
        public int? MaxEstimateStature { get; set; } = new();

        public int? MinAgeAtDeath { get; set; } = new();
        public int? MaxAgeAtDeath { get; set; } = new();

        public List<string>? HeadDirections { get; set; } = new();

        public string? SquareNorthSouth { get; set; } = "";
        public string? NorthSouth { get; set; } = "";
        public string? SquareEastWest { get; set; } = "";
        public string? EastWest { get; set; } = "";
        public string? BurialNumber { get; set; } = "";

        public List<string>? TextileFunctions { get; set; } = new();

        public List<string>? HairColors { get; set; } = new();

        public int PageNum { get; set; }
    }
}
