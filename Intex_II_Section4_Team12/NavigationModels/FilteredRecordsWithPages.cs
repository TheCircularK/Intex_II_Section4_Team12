using Intex_II_Section4_Team12.Models;

namespace Intex_II_Section4_Team12.NavigationModels
{
    public class FilteredRecordsWithPages
    {
        public FilteredRecordsWithPages(ICollection<Burialmain> burialRecords, int pageNum, int pageCount)
        {
            BurialRecords = burialRecords;
            PageNum = pageNum;
            PageCount = pageCount;
        }

        public ICollection<Burialmain> BurialRecords { get; set; }
        public int PageNum { get; set; }
        public int PageCount { get; set; }
    }
}
