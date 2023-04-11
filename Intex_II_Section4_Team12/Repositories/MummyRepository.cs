using Intex_II_Section4_Team12.Context;
using Intex_II_Section4_Team12.Models;
using Intex_II_Section4_Team12.NavigationModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq;

namespace Intex_II_Section4_Team12.Repositories
{
    public class MummyRepository : IMummyRepository
    {
        public MummyRepository(MummyContext context)
        {
            _context = context;
        }

        private readonly MummyContext _context;
        private int pageSize = 10;

        public ICollection<Burialmain> GetAllPaged(int pageNum = 1)
        {
            if (pageNum == 0) { pageNum = 1; }

            var numToSkip = (pageNum - 1) / pageSize;

            var burials = _context.Burialmains
                .Skip(numToSkip)
                .Take(pageSize)
                .ToList();

            return burials;
        }

        public ICollection<Burialmain> GetFiltered(FilteredRecordRequest request)
        {
            IQueryable<Burialmain> burials;

            burials = _context
                .Set<Burialmain>()
                .Include(b => b.BodyAnalysisCharts)
                .Include(b => b.MainTextiles)
                    .ThenInclude(t => t.MainStructures)
                .Include(b => b.MainTextiles)
                    .ThenInclude(t => t.MainTextilefunctions)
                .Include(b => b.BodyAnalysisCharts);

            //FILTERS
            //Sex
            if (request.Sexes != null && request.Sexes.Count > 0)
            {
                burials = burials
                    .Where(b => request.Sexes.Contains(b.Sex));
            }

            //Burial depths
            if (request.MinBurialDepth.HasValue && request.MinBurialDepth > 0)
            {
                burials = burials
                    .Where(b => float.Parse(b.Depth) >= request.MinBurialDepth);
            }
            if (request.MaxBurialDepth.HasValue && request.MaxBurialDepth > 0)
            {
                burials = burials
                    .Where(b => float.Parse(b.Depth) <= request.MaxBurialDepth);
            }


            return new List<Burialmain>();

        }


    }
}
