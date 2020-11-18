using System.Web;
using System.Web.Optimization;

namespace Dream_voyage.Web
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/bundles/bootstrap/css").Include(
             "~/Content/bootstrap.min.css", new CssRewriteUrlTransform()));
            bundles.Add(new StyleBundle("~/bundles/main/css").Include(
          "~/Content/main.css", new CssRewriteUrlTransform()));
            bundles.Add(new StyleBundle("~/bundles/style/css").Include(
         "~/Content/style.css", new CssRewriteUrlTransform()));
            bundles.Add(new StyleBundle("~/bundles/site/css").Include(
            "~/Content/Site.css", new CssRewriteUrlTransform()));
            bundles.Add(new StyleBundle("~/bundles/fontawesome/css").Include(
           "~/Content/fontawesome.min.css", new CssRewriteUrlTransform()));
            bundles.Add(new StyleBundle("~/bundles/faqs/css").Include(
           "~/Content/faqs.css", new CssRewriteUrlTransform()));
            bundles.Add(new StyleBundle("~/bundles/avtorizatia/css").Include(
           "~/Content/avtorizatia.css", new CssRewriteUrlTransform()));
            bundles.Add(new StyleBundle("~/bundles/app/css").Include(
           "~/Content/app.css", new CssRewriteUrlTransform()));
            bundles.Add(new StyleBundle("~/bundles/game/css").Include(
           "~/Content/game.css", new CssRewriteUrlTransform()));


            bundles.Add(new ScriptBundle("~/bundles/jquery/js").Include(
          "~/Scripts/jquery-3.4.1.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/bootstrap/js").Include(
         "~/Scripts/bootstrap.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/all/js").Include(
        "~/Scripts/fontawesome/all.js"));
            bundles.Add(new ScriptBundle("~/bundles/platform/js").Include(
       "~/Scripts/platform.js"));
            bundles.Add(new ScriptBundle("~/bundles/game/js").Include(
       "~/Scripts/game.js"));
            bundles.Add(new ScriptBundle("~/bundles/end/js").Include(
       "~/Scripts/end.js"));

        }
    }
}
