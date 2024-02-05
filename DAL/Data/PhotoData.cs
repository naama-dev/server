using DAL.Interface;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DAL.Data
{
    public class PhotoData:IPhoto
    {

        private readonly DataProjectContext _context;

        public PhotoData(DataProjectContext context)
        {
            _context = context;
        }
        public async Task<List<Photo>> getAllPhotos()
        {
           List<Photo> photos = await _context.Photo.ToListAsync();
            return photos;
        }
        public async Task<bool> AddPhoto(Photo p)
        {
            //Photo photo = new();
            await _context.Photo.AddAsync(p);
            var isOk = _context.SaveChanges() > 0;
            return isOk;
        }
        public async Task<bool> DeletePhoto(int id)
        {
            var idPhoto = _context.Photo.FirstOrDefault(x => x.Id == id);
            _context.Photo.Remove(idPhoto);
            var isOk = _context.SaveChanges() > 0;
            return isOk;
        }
        public async Task<bool> UpdatePhoto(int id, Photo photo)
        {
            var idPhoto = _context.Photo.FirstOrDefault(x => x.Id == id);
            if (idPhoto == null)
            {
                return false;
            }
            idPhoto.ImgUrl = photo.ImgUrl;
            var isOk = _context.SaveChanges() > 0;
            return isOk;
        }
    }
}
