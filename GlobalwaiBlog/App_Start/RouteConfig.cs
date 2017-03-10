using GlobalwaiBlog.Models;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace GlobalwaiBlog
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Menu", action = "Index", id = UrlParameter.Optional }
            //);

            routes.Add("PostTitle", new SeoFriendlyRoute("{id}",
            new RouteValueDictionary(new { controller = "Menu", action = "Post" }),
            new MvcRouteHandler()));

            //routes.MapRoute("BlogPost", "{id}/{title}", new { controller = "Menu", action = "Post", id = UrlParameter.Optional });

            routes.MapRoute("Default", "{controller}/{action}/{id}", new { controller = "Menu", action = "Index", id = UrlParameter.Optional });
        }
    }

    public class SeoFriendlyRoute : Route
    {
        public SeoFriendlyRoute(string url, RouteValueDictionary defaults, IRouteHandler routeHandler)
            : base(url, defaults, routeHandler)
        {
        }

        public override RouteData GetRouteData(HttpContextBase httpContext)
        {
            var routeData = base.GetRouteData(httpContext);

            if (routeData != null)
            {
                if (routeData.Values.ContainsKey("id"))
                    routeData.Values["id"] = GetIdValue(routeData.Values["id"]);
            }

            return routeData;
        }

        private object GetIdValue(object id)
        {
            if (id != null)
            {
                string idValue = id.ToString();

                var regex = new Regex(@"^(?<id>\d+).*$");
                var match = regex.Match(idValue);

                if (match.Success)
                {
                    return match.Groups["id"].Value;
                }
            }

            return id;
        }
    }
}