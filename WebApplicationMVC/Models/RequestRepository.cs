using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace WebApplicationMVC.Models
{
    public class RequestRepository : IRequestRepository
    {
        // ссылка на контекст
        private readonly RequestContext _context;

        // Метод-конструктор для инициализации
        public RequestRepository(RequestContext context)
        {
            _context = context;
        }

        /*public async Task AddUser(User user)
        {
            // Добавление пользователя
            var entry = _context.Entry(user);
            if (entry.State == EntityState.Detached)
                await _context.Users.AddAsync(user);

            // Сохранение изенений
            await _context.SaveChangesAsync();
        }*/

        public async Task AddRequest(MyRequest request)
        {
            
            request.Id = Guid.NewGuid();
            request.Date = DateTime.Now;
            request.Url = "url";
            

            // Добавление запроса
            var entry = _context.Entry(request);
            if (entry.State == EntityState.Detached)
                await _context.MyRequest.AddAsync(request);

            // Сохранение изенений
            await _context.SaveChangesAsync();
        }


        
    }
}
