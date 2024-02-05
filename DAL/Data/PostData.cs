using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface;
using Microsoft.EntityFrameworkCore;

namespace DAL.Data
{
    public class PostData:IPost
    {
        private readonly DataProjectContext _context;

        public PostData(DataProjectContext context)
        {
            _context = context;
        }
        public async Task<List<Post>> getAllPosts()
        {
            List<Post> posts = await _context.Post.ToListAsync();
            return posts;
        }
        public async Task<bool> AddPost(Post p)
        {
            await _context.Post.AddAsync(p);
            var isOk = _context.SaveChanges() > 0;
            return isOk;
        }
        public async Task<bool> DeletePost(int id)
        {
            var idPost = _context.Post.FirstOrDefault(x => x.Id == id);
            _context.Post.Remove(idPost);
            var isOk = _context.SaveChanges() > 0;
            return isOk;
        }
        public async Task<bool> UpdatePost(int id, Post post)
        {
            var idPost = _context.Post.FirstOrDefault(x => x.Id == id);
            if (idPost == null)
            {
                return false;
            }
            idPost.Contect = post.Contect;
            idPost.Like = post.Like;
            var isOk = _context.SaveChanges() > 0;
            return isOk;
        }
        public async Task<bool> IsLikePost(int id)
        {
            var idPost = _context.Post.FirstOrDefault(x => x.Id == id);
            if (idPost == null)
                return false;
            idPost.Like = true;
            try
            {
                var isOk = _context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
    }
}
