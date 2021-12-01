using System.Web.Optimization;

namespace Api
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/site.css",
                      "~/Content/nav.css",
                      "~/Content/jsonview.bundle.css"));

            bundles.Add(new ScriptBundle("~/bundles/javascript").Include(
                "~/Scripts/js.js",
                "~/Scripts/jsonview.bundle.js"));
        }
    }
}
