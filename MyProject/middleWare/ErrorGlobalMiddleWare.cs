using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Serilog;
using System.Threading.Tasks;
namespace MyProject.middleWare
{
    public class ErrorGlobalMiddleWare
    {
        private readonly RequestDelegate _next;

        public ErrorGlobalMiddleWare(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                Log.Error("message: " + ex.Message);
            }

        }
    }
}
