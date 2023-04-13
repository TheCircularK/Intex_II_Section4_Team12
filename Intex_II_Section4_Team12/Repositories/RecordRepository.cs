using Intex_II_Section4_Team12.Context;
using Intex_II_Section4_Team12.Models;

namespace Intex_II_Section4_Team12.Repositories
{
    public class RecordRepository : IRecordRepository
    {
        public RecordRepository(MummyContext context)
        {
            _context = context;
        }

        private readonly MummyContext _context;

        public void AddBurialMain(Burialmain burial)
        {
            if (!_context.Burialmains.Any(b => b.Id == burial.Id))
            {
                _context.Add(burial);
                _context.SaveChanges();
            }
        }

        public void EditBurialMain(Burialmain burial)
        {
            _context.Update(burial);
            _context.SaveChanges();
        }

        public void DeleteBurialMain(Burialmain burial)
        {
            _context.Remove(burial);
            _context.SaveChanges();
        }

        public void AddBodyAnalysis(Bodyanalysischart bodyanalysis)
        {
            if (!_context.Bodyanalysischarts.Any(c => c.Id == bodyanalysis.Id))
            {
                _context.Add(bodyanalysis);
                _context.SaveChanges();
            }
        }

        public void EditBodyAnalysis(Bodyanalysischart bodyanalysis)
        {
            _context.Update(bodyanalysis);
            _context.SaveChanges();
        }

        public void DeleteBodyAnalysis(Burialmain burial)
        {
            _context.Remove(burial);
            _context.SaveChanges();
        }

        public void AddTextile(Textile textile)
        {
            if (!_context.Textiles.Any(t => t.Id == textile.Id))
            {
                _context.Add(textile);
                _context.SaveChanges();
            }
        }

        public void EditTextile(Textile textile)
        {
            _context.Update(textile);
            _context.SaveChanges();
        }

        public void DeleteTextile(Textile textile)
        {
            _context.Remove(textile);
            _context.SaveChanges();
        }
    }
}
