using System.Web.Http;

namespace Practica4.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Enable attribute routing so we can expose /api/estudiantes exactly
            config.MapHttpAttributeRoutes();

            // Optional: keep a conventional default route for other APIs
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}