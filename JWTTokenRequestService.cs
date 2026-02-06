using Microsoft.Extensions.Primitives;
using Microsoft.IdentityModel.Tokens;
using rentalmovie.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace rentalmovie
{
    public class JWTTokenRequestService
    {
        private readonly IConfiguration _config;


        public JWTTokenRequestService(IConfiguration configuration)
        {
            _config = configuration;

        }
        public JWTTokenData VerifyToken(StringValues extractedToken)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config["Jwt:SecretKey"]);
            try
            {
                tokenHandler.ValidateToken(extractedToken, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                string validuser_id = jwtToken.Claims.FirstOrDefault(x => x.Type == "id").Value;
                string validuser_role = jwtToken.Claims.FirstOrDefault(x => x.Type == "Role").Value;
                if (validuser_id != null)
                {

                    var response = new JWTTokenData()
                    {

                        userId = Convert.ToInt32(validuser_id),
                        roles = validuser_role,
                        status = 200,
                        response = "success",
                    };
                    return response;

                }
                else
                {
                    var response = new JWTTokenData()
                    {
                        status = 401,
                        response = "unauthorized"
                    };

                    return response;
                }

                return null;
            }
            catch
            {
                var response = new JWTTokenData()
                {
                    status = 401,
                    response = "unauthorized"
                };

                return response;
            }
        }

    }
}
