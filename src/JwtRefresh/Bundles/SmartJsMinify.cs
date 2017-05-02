using System;
using System.Web.Optimization;
using Microsoft.Ajax.Utilities;

namespace JwtRefresh.Bundles
{
    public class SmartJsMinify : IItemTransform
    {
        public string Process(string includedVirtualPath, string input)
        {
            if (includedVirtualPath.EndsWith("min.js", StringComparison.OrdinalIgnoreCase))
            {
                return input;
            }

            var minifier = new Minifier();
            var codeSettings = new CodeSettings
            {
                EvalTreatment = EvalTreatment.MakeImmediateSafe,
                PreserveImportantComments = false,
                Format = JavaScriptFormat.Normal,
                MinifyCode = true
            };

            var str = minifier.MinifyJavaScript(input, codeSettings);

            if (minifier.ErrorList.Count > 0)
            {
                return "/* " + string.Concat(minifier.Errors) + " */";
            }

            return str;
        }
    }
}