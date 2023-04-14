namespace Intex_II_Section4_Team12.Repositories
{
    public interface IPhotoRepository
    {
        ICollection<string> Photos(string BurialNumberId);
    }
}
