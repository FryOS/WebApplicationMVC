using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace WebApplicationMVC.Models
{
    public class RequestRepository : IRequestRepository
    {
        // ссылка на контекст
        private readonly BlogContext _context;
        

        // Метод-конструктор для инициализации
        public RequestRepository(BlogContext context)
        {
            _context = context;
        }

       
        public async Task AddRequest(MyRequest request, HttpContext _httpContext)
        {
            request.Id = Guid.NewGuid();
            request.Date = DateTime.Now;
            request.Url = _httpContext.Request.Path;
            

            // Добавление запроса
            var entry = _context.Entry(request);
            if (entry.State == EntityState.Detached)
                await _context.MyRequests.AddAsync(request);

            // Сохранение изенений
            await _context.SaveChangesAsync();
        }

        public async Task<MyRequest[]> GetRequests()
        {
            // Получим всех активных пользователей
            return await _context.MyRequests.ToArrayAsync();
        }



    }
}
