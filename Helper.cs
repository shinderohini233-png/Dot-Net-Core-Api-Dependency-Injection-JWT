using rentalmovie.Models;

namespace rentalmovie
{
    public class Helper
    {
        public static JWTTokenData GetTokenData(HttpContext httpContext)
        {
            JWTTokenData apiResponse = null;

            if (httpContext.Items["JWT_TokenData"] != null)
            {
                apiResponse = httpContext.Items["JWT_TokenData"] as JWTTokenData;


            }
            return apiResponse;
        }
    }
}
