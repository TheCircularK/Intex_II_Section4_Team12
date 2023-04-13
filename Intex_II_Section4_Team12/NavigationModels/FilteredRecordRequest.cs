namespace Intex_II_Section4_Team12.NavigationModels
{
    public class FilteredRecordRequest
    {
        public FilteredRecordRequest(int pageNum)
        {
            PageNum = pageNum;
        }

        public string? Sex { get; set; }

        public float? MinBurialDepth { get; set; } = new();
        public float? MaxBurialDepth { get; set; } = new();

        public string? EstimateStature { get; set; }

        public List<string>? AgeAtDeath { get; set; } = new();

        public string? HeadDirection { get; set; }

        public string? BurialId { get; set; }

        public List<string>? HairColors { get; set; } = new();

        //Burial main - Y/N
        public string? FaceBundles { get; set; }

        //LIKE statement
        public string? TextileStructure { get; set; }

        //Textile color - LIKE
        public string? TextileColor { get; set; }

        //Presence of ribbons - TEXTILE DESCRIPTION CONTAINS RIBBONS!!!
        public bool? ContainsRibbons { get; set; }

        //Like statement
        public string? TextileFunction { get; set; }

        public int PageNum { get; set; }
    }
}
