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

        /// <summary>
        /// Get all 
        /// </summary>
        /// <param name="pageNum"></param>
        /// <returns></returns>
        public ICollection<Burialmain> GetAllPaged(int pageNum = 1)
        {
            if (pageNum == 0) { pageNum = 1; }

            var numToSkip = (pageNum - 1) / pageSize;

            var burials = _context.Burialmains
                .Skip(numToSkip)
                .Take(pageSize)
                .Where(b => b.MainTextiles.Count > 0)
                .Include(b => b.MainTextiles)
                .ToList();

            return burials;
        }

        public FilteredRecordsWithPages GetFiltered(FilteredRecordRequest request)
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

            //Age at Death
            if (request.AgeAtDeath.Count > 0)
            {
                burials = burials
                    .Where(b => request.AgeAtDeath.Contains(b.Ageatdeath)); 
            }

            //Head direction
            if (request.HeadDirections.Count > 0)
            {
                burials = burials
                    .Where(b => request.HeadDirections.Contains(b.Headdirection));
            }

            //Hair colors
            if (request.HairColors.Count > 0)
            {
                burials = burials
                    .Where(b => request.HairColors.Contains(b.Haircolor));
            }

            //Face bundles
            if (request.FaceBundles != null)
            {
                burials = burials
                    .Where(b => b.Facebundles == request.FaceBundles);
            }

            //TEXTILE FUNCTIONS
            //Get list of IDs so far
            var burialIds = burials.Select(b => b.Id).ToList();



            //Stature
            if (!String.IsNullOrEmpty(request.EstimateStature))
            {
                burials = burials
                    .Where(b => b.BodyAnalysisCharts
                    .Any(c => c.EstimateStature
                    .Contains(request.EstimateStature)));
            }



            //Burial ID
            if (!String.IsNullOrEmpty(request.BurialId))
            {
                burials = burials
                    .Where(b => (b.Squarenorthsouth + b.Northsouth + b.Squareeastwest + b.Eastwest + b.Area + b.Burialnumber) == request.BurialId);
            }



            FilteredRecordsWithPages response = new FilteredRecordsWithPages(burials.ToList(), request.PageNum, burials.Count()/pageSize);

            return response;

        }


    }
}
