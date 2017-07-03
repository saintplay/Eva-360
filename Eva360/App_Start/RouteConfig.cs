using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Eva360
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            var settings = ConfigurationManager.ConnectionStrings["EVA360Entities"];
            var fi = typeof(ConfigurationElement).GetField("_bReadOnly", BindingFlags.Instance | BindingFlags.NonPublic);
            fi.SetValue(settings, false);
            String expanded = Environment.ExpandEnvironmentVariables(settings.ConnectionString);
            settings.ConnectionString = expanded;

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
