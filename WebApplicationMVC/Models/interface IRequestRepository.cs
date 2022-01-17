using System.Threading.Tasks;

namespace WebApplicationMVC.Models
{
    public interface IRequestRepository
    {
        Task AddRequest(MyRequest request);
        
    }
}
