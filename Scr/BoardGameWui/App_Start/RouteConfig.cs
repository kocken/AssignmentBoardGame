using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BoardGameWui
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Game",
                url: "TicTacToe/Game",
                defaults: new { controller = "TicTacToe", action = "Index" }
            );

            routes.MapRoute(
                name: "Lobby",
                url: "TicTacToe/Lobby",
                defaults: new { controller = "TicTacToe", action = "Index" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "TicTacToe", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}