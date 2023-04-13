using Intex_II_Section4_Team12.Models;

namespace Intex_II_Section4_Team12.Repositories
{
    public interface IRecordRepository
    {
        void AddBurialMain(Burialmain burial);
        void EditBurialMain(Burialmain burial);
        void DeleteBurialMain(Burialmain burial);

        void AddBodyAnalysis(Bodyanalysischart bodyanalysis);
        void EditBodyAnalysis(Bodyanalysischart bodyanalysis);
        void DeleteBodyAnalysis(Burialmain burial);

        void AddTextile(Textile textile);
        void EditTextile(Textile textile);
        void DeleteTextile(Textile textile);
    }
}
