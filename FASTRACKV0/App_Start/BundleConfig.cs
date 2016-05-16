using System.Web;
using System.Web.Optimization;

namespace FASTrack
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.min.js",
                      "~/Scripts/respond.min.js",
                      "~/Scripts/fastrack.js"));

            bundles.Add(new ScriptBundle("~/bundles/unobtrusive").Include(
                "~/Scripts/jquery.unobtrusive-ajax.min.js",
                "~/Scripts/jquery.validate.min.js",
                "~/Scripts/jquery.validate.unobtrusive.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/bootstrap-theme.min.css",
                      "~/Content/Site.css"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").
                Include("~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/fastrack").
                Include("~/Scripts/app/loading.js"));

            bundles.Add(new StyleBundle("~/Content/jqueryui").
                Include("~/Content/themes/base/*.css"));

            bundles.Add(new StyleBundle("~/Content/fastrack").
                Include("~/Content/app/app.css").
                Include("~/Content/app/loading.css"));
        }
    }
}
