using Models.Models;

namespace DAL.Interface
{
    public interface IPhoto
    {
        Task<List<Photo>> getAllPhotos();
        Task<bool> AddPhoto(Photo p);
        Task<bool> DeletePhoto(int id);
        Task<bool> UpdatePhoto(int id, Photo photo);
    }
}
