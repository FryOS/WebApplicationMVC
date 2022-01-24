using System.Threading.Tasks;

namespace WebApplicationMVC.Models
{
    public interface IBlogRepository
    {
        Task AddUser(User user);
        Task<User[]> GetUsers();
    }
}
