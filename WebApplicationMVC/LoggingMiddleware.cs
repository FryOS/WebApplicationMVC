using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;
using WebApplicationMVC.Models;

namespace WebApplicationMVC
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IRequestRepository _requestRepository;

        /// <summary>
        ///  Middleware-компонент должен иметь конструктор, принимающий RequestDelegate
        /// </summary>
        public LoggingMiddleware(RequestDelegate next, IRequestRepository requestRepository)
        {
            _next = next;
            _requestRepository = requestRepository;
        }

        private void LogConsole(HttpContext context)
        {
            // Для логирования данных о запросе используем свойста объекта HttpContext
            Console.WriteLine($"[{DateTime.Now}]: New request to http://{context.Request.Host.Value + context.Request.Path}");
        }

        private async Task LogFile(HttpContext context)
        {
            // Строка для публикации в лог
            string logMessage = $"[{DateTime.Now}]: New request to http://{context.Request.Host.Value + context.Request.Path}{Environment.NewLine}";

            // Путь до лога (опять-таки, используем свойства IWebHostEnvironment)
            string logFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Logs", "RequestLog.txt");

            // Используем асинхронную запись в файл
            await File.AppendAllTextAsync(logFilePath, logMessage);
        }

        /// <summary>
        ///  Необходимо реализовать метод Invoke  или InvokeAsync
        /// </summary>
        public async Task InvokeAsync(HttpContext httpContext)
        {
            string userAgent = httpContext.Request.Headers["User-Agent"][0];
            var requestInfo = new MyRequest()
            {
                Id = Guid.NewGuid(),
                Date = DateTime.Now,
                Url = httpContext.Request.Host.Value
            };

            await _requestRepository.AddRequest(requestInfo);

            LogConsole(httpContext);
            await LogFile(httpContext);

            // Передача запроса далее по конвейеру
            await _next.Invoke(httpContext);
        }
    }
}
