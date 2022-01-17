using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace WebApplicationMVC.Models
{
    public class RequestContext : DbContext
    {
        /// Ссылка на таблицу MyRequest
        public DbSet<MyRequest> MyRequest { get; set; }       

        // Логика взаимодействия с таблицами в БД
        public RequestContext(DbContextOptions<RequestContext> options) : base(options)
        {
            Database.EnsureCreated();            
        }
    }
}
