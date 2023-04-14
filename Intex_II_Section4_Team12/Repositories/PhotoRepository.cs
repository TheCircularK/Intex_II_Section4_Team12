using Intex_II_Section4_Team12.Context;

namespace Intex_II_Section4_Team12.Repositories
{
    public class PhotoRepository : IPhotoRepository
    {
        private MummyContext mummyContext;
        public PhotoRepository(MummyContext context)
        {
            mummyContext = context;
        }

        public ICollection<string?> Photos(string BurialNumberId)
        {
            return mummyContext
                .PhotoInfo
                .Where(i => i.SquareNorthSouth + i.NorthSouth + i.SquareEastWest + i.EastWest + i.Area + i.BurialNumber == BurialNumberId)
                .Select(r => r.PhotoFileName)
                .ToList();
        }
    }
}
