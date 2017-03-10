using System.Web.Optimization;

namespace GlobalwaiBlog
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles) {
            bundles.Add(new StyleBundle("~/bunddles/css").Include(
                "~/Content/vendor/bootstrap/css/bootstrap.min.css",
                "~/Content/css/clean-blog.min.css",
                "~/Content/vendor/font-awesome/css/font-awesome.min.css"
                ));

            bundles.Add(new ScriptBundle("~/bunddles/js").Include(
                "~/Content/vendor/jquery/jquery.min.js",
                "~/Content/vendor/bootstrap/js/bootstrap.min.js",
                "~/Content/js/jqBootstrapValidation.js",
                "~/Content/js/contact_me.js",
                "~/Content/js/clean-blog.min.js"
                ));
        }
    }
}