using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace exercise_planner
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional });

            routes.MapRoute(
                name: "Plan",
                url: "plan",
                defaults: new { controller = "Home", action = "Plan" });

            routes.MapRoute(
                name: "Exercises",
                url: "exercises",
                defaults: new { controller = "Home", action = "Cwiczenia" });

            routes.MapRoute(
            name: "EditPlan",
            url: "Plan/Edit/{id}",
            defaults: new { controller = "Plan", action = "Edit" });
    
        }
    }
}
