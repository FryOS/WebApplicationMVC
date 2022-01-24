using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApplicationMVC.Models;

namespace WebApplicationMVC.Controllers
{
    public class MyRequestController : Controller
    {
        

        private readonly IRequestRepository _requestRepository;

        public MyRequestController(IRequestRepository requestRepository)
        {
            _requestRepository = requestRepository;
        }

        public async Task<IActionResult> Requests()
        {
            var reqs = await _requestRepository.GetRequests();
            return View(reqs);
        }


        //[HttpGet]
        //public async Task<IActionResult> Register()
        //{
        //    return View();
        //}

        //[HttpGet]
        //public async Task<IActionResult> Requests()
        //{
        //    return View();
        //}

        
    }
}
