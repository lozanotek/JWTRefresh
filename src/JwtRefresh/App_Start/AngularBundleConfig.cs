using System.Web.Optimization;
using JwtRefresh;
using Pork.PayCheckoff.Web.Bundles;

[assembly: WebActivatorEx.PostApplicationStartMethod(typeof(AngularBundleConfig), "RegisterBundles")]

namespace JwtRefresh
{
    public class AngularBundleConfig
    {
        public static void RegisterBundles()
        {
           
            BundleTable.Bundles.Add(
                new SmartScriptBundle("~/bundles/app")
                    .Include(
                        "~/Scripts/angular.js",
                        "~/Scripts/angular-route.js",
                        "~/Scripts/angular-animate.js",
                        "~/Scripts/angular-jwt.js"
                    )
                    .IncludeDirectory("~/client/appServices", "*.js", true)
                    .Include("~/client/*.js")
                    .IncludeDirectory("~/client/modules", "*.js", true));
        }
    }
}
