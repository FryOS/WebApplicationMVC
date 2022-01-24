using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace WebApplicationMVC.Models
{
    public interface IRequestRepository
    {
        Task AddRequest(MyRequest request, HttpContext httpContext);

        Task<MyRequest[]> GetRequests();

    }
}
