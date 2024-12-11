using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Ulacit_parkingC_
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // Ruta para registro
            routes.MapRoute(
                name: "RegisterRegister",
                url: "Register/Register",
                defaults: new { controller = "Register", action = "Register" }
            );

            // Ruta predeterminada
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}

