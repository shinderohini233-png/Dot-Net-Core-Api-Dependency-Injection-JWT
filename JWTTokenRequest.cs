using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using Microsoft.IdentityModel.Tokens;
using rentalmovie.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace rentalmovie
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class JWTTokenRequest
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;
        private const string JWTToken = "Authorization";
        public JWTTokenRequest(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _configuration = configuration;
            
        }

        public async Task Invoke(HttpContext httpContext)
        {
            StringValues extractedToken = "";
            if ( !httpContext.Request.Headers.TryGetValue(JWTToken, out 
                    extractedToken))
            {
                httpContext.Response.StatusCode = 401;
                await httpContext.Response.WriteAsync("JWT token was not provided ");
                return;
            }

                var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {extractedToken}");

            JWTTokenRequestService userData = new JWTTokenRequestService(_configuration);
            var result = userData.VerifyToken(extractedToken);
            if (result != null && result.status.Equals(200))
            {
                httpContext.Items["JWT_TokenData"] = result;
            }
            else
            {
                httpContext.Response.StatusCode = 401;
                await httpContext.Response.WriteAsync("Unauthorized client");
                return;
            }

           
            
            await _next(httpContext);
        }

      
    }

    
    
   
}
