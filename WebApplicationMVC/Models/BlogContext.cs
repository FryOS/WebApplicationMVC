using Microsoft.EntityFrameworkCore;

namespace WebApplicationMVC.Models
{
    public sealed class BlogContext : DbContext
    {
        /// Ссылка на таблицу Users
        public DbSet<User> Users { get; set; }

        public DbSet<MyRequest> MyRequests { get; set; }

        /// Ссылка на таблицу UserPosts
        public DbSet<UserPosts> UserPosts { get; set; }

        // Логика взаимодействия с таблицами в БД
        public BlogContext(DbContextOptions<BlogContext> options) : base(options)
        {
            Database.EnsureCreated(); 
        }
    }
}
