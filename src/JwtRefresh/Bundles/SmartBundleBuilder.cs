using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Optimization;

namespace JwtRefresh.Bundles
{
    public class SmartBundleBuilder : IBundleBuilder
    {
        internal static string ConvertToAppRelativePath(string appPath, string fullName)
        {
            return (string.IsNullOrEmpty(appPath) || !fullName.StartsWith(appPath, StringComparison.OrdinalIgnoreCase) ? fullName : fullName.Replace(appPath, "~/")).Replace('\\', '/');
        }

        public string BuildBundleContent(Bundle bundle, BundleContext context, IEnumerable<BundleFile> files)
        {
            if (files == null)
            {
                return string.Empty;
            }

            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            if (bundle == null)
            {
                throw new ArgumentNullException("bundle");
            }

            var stringBuilder = new StringBuilder();
            foreach (var bundleFile in files)
            {
                stringBuilder.AppendFormat("/* {0} */\r\n", bundleFile.VirtualFile.Name);
                bundleFile.Transforms.Add(new SmartJsMinify());
                stringBuilder.Append(bundleFile.ApplyTransforms());
                stringBuilder.Append(bundle.ConcatenationToken);
            }

            return stringBuilder.ToString();
        }
    }
}
