using Intex_II_Section4_Team12.Context;
using Intex_II_Section4_Team12.Models;
using Intex_II_Section4_Team12.NavigationModels;
using Microsoft.EntityFrameworkCore;
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

        public ICollection<Burialmain> GetAllPaged(int pageNum)
        {
            var burials = _context.Burialmains
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return burials;
        }

        public ICollection<Burialmain> GetFiltered(FilteredRecordRequest request)
        {

            return _context.Burialmains.ToList();
            //IQueryable<Burialmain> burials = _context
            //    .Burialmains
            //    .Join(_context.Textiles, id => )
            //    .AsQueryable();

            ////FILTERS
            ////Textile structures
            //if (request.TextileStructureIds.Count > 0)
            //{
            //    var textileIds = _context
            //        .BurialmainTextiles
            //        .Where(r => request.TextileStructureIds.Contains(r.MainTextileid))
            //        .Select(l => l.MainTextileid)
            //        .ToList();

            //    var textiles = _context
            //        .Textiles
            //        .Where(t => textileIds.Contains(t.Id))
            //        .ToList();


            //}


        }


    }
}
