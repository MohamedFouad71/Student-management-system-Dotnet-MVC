using StudentManagementSystem.Data;
using System.Diagnostics;
using System.Text;

namespace StudentManagementSystem.Middlewares
{
    public class RequestLoggerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestLoggerMiddleware> _logger;

        public RequestLoggerMiddleware(RequestDelegate next, ILogger<RequestLoggerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();


            _logger.LogInformation($"[Request] {context.Request.Method} {context.Request.Path}");

            await _next(context);

            _logger.LogInformation($"[Response] Status: {context.Response.StatusCode}");

            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;

            string elapsedTime = string.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);

            Console.WriteLine("Time Taken:" + elapsedTime);

        }
    }
}