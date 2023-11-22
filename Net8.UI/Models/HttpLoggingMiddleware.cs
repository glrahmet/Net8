using System.Data;
using System.Security.Claims;

namespace Net8.UI.Models
{
    public class HttpLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;

        private readonly IHttpContextAccessor httpContextAccessor;


        public HttpLoggingMiddleware(RequestDelegate next, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _next = next;
            _configuration = configuration;
            this.httpContextAccessor = httpContextAccessor;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            finally
            {
                if (context.Request.Protocol == "HTTP/2" &&
                    !context.Request.Path.Equals("/") &&
                    !context.Request.Path.Value.Contains("/js") &&
                    !context.Request.Path.Value.Contains("/css") &&
                    !context.Request.Path.Value.Contains("/img") &&
                    !context.Request.Path.Value.Contains("/webfonts")
                  )
                    databaseLog(context.Request?.Method, httpContextAccessor.HttpContext != null ? httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString() : string.Empty, context.Request?.Path.Value);
            }
        }

        private async void databaseLog(string method, string ipaddress, string path)
        {
            //if (!ipaddress.Equals("::1"))
            //{ 
            ClaimsIdentity identity = (ClaimsIdentity)httpContextAccessor.HttpContext.User.Identity;
            string email, userName, roleName;
            email = userName = roleName = string.Empty;

            if (identity.Claims.Count() > 0)
            {
                email = identity.Claims.Where(c => c.Type == ClaimTypes.Email).FirstOrDefault().Value;
                userName = identity.Claims.Where(c => c.Type == ClaimTypes.GivenName).FirstOrDefault().Value;
                roleName = identity.Claims.Where(c => c.Type == ClaimTypes.Role).FirstOrDefault().Value;
            }

            //hata loglama kayıt için
            //}
        }
    }
}

