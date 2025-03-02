using KargoTakip.WebApi.Modules;

namespace KargoTakip.WebApi.Routes
{
    public static class RegisterRoute
    {
        public static void RegisterRoutes(this IEndpointRouteBuilder app)
        {
            app.RegisterEmployeeRoutes();
        }
    }
}