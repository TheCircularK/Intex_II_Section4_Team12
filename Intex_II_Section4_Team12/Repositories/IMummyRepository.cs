using Intex_II_Section4_Team12.Context;
using Intex_II_Section4_Team12.Models;
using Intex_II_Section4_Team12.NavigationModels;
using Microsoft.EntityFrameworkCore;

namespace Intex_II_Section4_Team12.Repositories
{
    public interface IMummyRepository
    {
        ICollection<Burialmain> GetAllPaged(int pageNum);
        FilteredRecordsWithPages GetFiltered(FilteredRecordRequest request);
    }
}
