using System.Web;
using System.Web.Optimization;

namespace ShopDemoC
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/adminlte").Include(
                        "~/Scripts/adminlte.min.js",
                        "~/Scripts/bootstrap.bundle.min.js",
                        "~/Scripts/Chart.min.js",
                        "~/Scripts/sparkline.js",
                        "~/Scripts/moment.min.js",
                        "~/Scripts/daterangepicker.js",
                        "~/Scripts/tempusdominus-bootstrap-4.min.js",
                        "~/Scripts/summernote-bs4.min.js",
                        "~/Scripts/jquery.overlayScrollbars.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/mainjs").Include(
                        "~/Scripts/mainjs/brands.js",
                        "~/Scripts/mainjs/solid.js",
                        "~/Scripts/mainjs/fontawesome.js",
                        "~/Scripts/mainjs/jquery.js",                                             
                        "~/Scripts/mainjs/angularjs.js",
                        "~/Scripts/mainjs/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/ckeditor").Include(
                        "~/Scripts/ckeditor/ckeditor.js"));

            bundles.Add(new ScriptBundle("~/bundles/product").Include(
                        "~/Scripts/gallery.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/adminlte/css").Include(
                      "~/Content/Fontawesome/all.min.css",
                      "~/Content/adminlte.min.css",                     
                      "~/Content/tempusdominus-bootstrap-4.min.css",
                      "~/Content/icheck-bootstrap.min.css",
                      "~/Content/OverlayScrollbars.css",
                      "~/Content/daterangepicker.css",
                      "~/Content/summernote-bs4.css"));

            bundles.Add(new StyleBundle("~/Content/main/css").Include(
                      "~/Content/maincss/bootstrap.css",
                      "~/Content/maincss/all.css",
                      "~/Content/maincss/fontawesome.css",
                      "~/Content/maincss/brands.css",
                      "~/Content/maincss/solid.css",
                      "~/Content/maincss/line-awesome.css",
                      "~/Content/maincss/main.css"));

            bundles.Add(new StyleBundle("~/Content/productcss").Include(
                      "~/Content/maincss/product-only.css"));

            bundles.Add(new StyleBundle("~/Content/cartcss").Include(
                      "~/Content/maincss/cart.css"));

            bundles.Add(new StyleBundle("~/Content/aboutcss").Include(
                      "~/Content/maincss/about-us-only.css"));
        }
    }
}
