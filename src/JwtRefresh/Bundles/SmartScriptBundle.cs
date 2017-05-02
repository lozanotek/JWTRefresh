using System;
using System.Web.Optimization;
using JwtRefresh.Bundles;

namespace Pork.PayCheckoff.Web.Bundles
{
    //http://stackoverflow.com/questions/23022586/dont-uglify-certain-file-when-using-microsoft-web-optimization-framework
    public class SmartScriptBundle : Bundle
    {
        public SmartScriptBundle(string virtualPath)
            : this(virtualPath, null)
        {
        }

        public SmartScriptBundle(string virtualPath, string cdnPath)
            : base(virtualPath, cdnPath, null)
        {
            this.ConcatenationToken = ";" + Environment.NewLine;
            this.Builder = new SmartBundleBuilder();
        }
    }
}