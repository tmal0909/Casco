using System.Web;
using System.Web.Optimization;

namespace CascoCS
{
    public class BundleConfig
    {
        // 如需統合的詳細資訊，請瀏覽 https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryPlugin").Include(
                        "~/Scripts/jquery.unobtrusive-ajax.js",
                        "~/Scripts/jquery.loading.js",
                        "~/Scripts/jquery.waypoints.js"));

            // 使用開發版本的 Modernizr 進行開發並學習。然後，當您
            // 準備好可進行生產時，請使用 https://modernizr.com 的建置工具，只挑選您需要的測試。
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/bootstrap-popper.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/googleJs").Include(
                      "~/Scripts/gmap.js"));

            bundles.Add(new ScriptBundle("~/bundles/siteJs").Include(
                      "~/Scripts/siteConfig.js",
                      "~/Scripts/siteUtil.js",
                      "~/Scripts/siteIndex.js"));
        }
    }
}
