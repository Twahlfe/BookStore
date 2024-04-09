using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Builder;
using System.Threading.Tasks;

namespace a1_bookstore_ict715.Tools
{
    public class BookstoreMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public BookstoreMiddleware(RequestDelegate next, ILoggerFactory logFactory)
        {
            _next = next;
            _logger = logFactory.CreateLogger("MyMiddleware");
        }

        public async Task Invoke(HttpContext httpContext)
        {
            var session = new BookstoreSession() { Session = httpContext.Session };

            // if no count value in session, use data in cookie to restore favorite courses in session 
            int? count = session.GetBookCount();
            if (count == null)
            {
                var cookies = new BookstoreCookies(httpContext.Request.Cookies);
                List<int> ids = cookies.GetUserBookIds();
                _logger.LogInformation("Loading the User Book Ids from Cookies");
                
                session.SetUserBookIds(ids);
            }

            await _next(httpContext);
        }
    }

    public static class BookstoreMiddlewareExtensions
    {
        public static IApplicationBuilder UseBookstoreMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<BookstoreMiddleware>();
        }
    }

}
