//using Microsoft.AspNetCore.Components.Routing;
using Microsoft.EntityFrameworkCore;

namespace Models.Models
{
    public class DataProjectContext: DbContext
    {
        public DataProjectContext(DbContextOptions<DataProjectContext> options) : base(options)
        {
        }

        public DbSet<ToDo> ToDo { get; set; }
        public DbSet<Post> Post { get; set; }
        public DbSet<Photo> Photo { get; set;}
        public DbSet<User> User { get; set; }
    }

}
