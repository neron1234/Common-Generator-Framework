using Mobioos.Foundation.Jade.Models;
using System;

namespace Common.Generator.Framework.Extensions
{
    public static class ApiActionInfoExtension
    {
        /// <summary>
        /// Transform a Mobioos request type to a C# request type.
        /// </summary>
        /// <param name="apiAction">An ApiActionInfo object.</param>
        /// <returns>A request type in string.</returns>
        public static string CSharpType(this ApiActionInfo apiAction)
        {
            if (apiAction == null)
                throw new ArgumentNullException();

            switch (apiAction.Type.ToLower())
            {
                case "datalist": case "dataget":
                    return "HttpGet";
                case "datacreate":
                    return "HttpPost";
                case "dataupdate":
                    return "HttpPut";
                case "datadelete":
                    return "HttpDelete";
                default:
                    return apiAction.Type;
            }
        }
    }
}
