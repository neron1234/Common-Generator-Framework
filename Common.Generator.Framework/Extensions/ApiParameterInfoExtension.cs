using Mobioos.Foundation.Jade.Models;
using System;

namespace Common.Generator.Framework.Extensions
{
    public static class ApiParameterInfoExtension
    {
        /// <summary>
        /// Transform Mobioos types to C# types.
        /// </summary>
        /// <param name="apiParameter">A Mobioos api action parameter.</param>
        /// <returns>A C# type in string.</returns>
        public static string CSharpType(this ApiParameterInfo apiParameter)
        {
            if (apiParameter == null)
                throw new ArgumentNullException();

            return apiParameter.Type.CSharpType();
        }

        /// <summary>
        /// Transform Mobioos types to TypeScript types.
        /// </summary>
        /// <param name="apiParameter">A Mobioos api action parameter.</param>
        /// <returns>A TypeScript type in string.</returns>
        public static string TypeScriptType(this ApiParameterInfo apiParameter)
        {
            if (apiParameter == null)
                throw new ArgumentNullException();

            return apiParameter.Type.TypeScriptType();
        }

        /// <summary>
        /// Check if the given type is a primitive type.
        /// </summary>
        /// <param name="property">A ApiParameterInfo object.</param>
        /// <returns>A boolean.</returns>
        public static bool IsPrimitiveType(this ApiParameterInfo apiParameter)
        {
            if (apiParameter == null)
                throw new ArgumentNullException();

            return apiParameter.Type.IsPrimitiveType();
        }

        /// <summary>
        /// Check if the given type is a model.
        /// </summary>
        /// <param name="property">A ApiParameterInfo object.</param>
        /// <returns>A boolean.</returns>
        public static bool IsModel(this ApiParameterInfo apiParameter)
        {
            if (apiParameter == null)
                throw new ArgumentNullException();

            if (!apiParameter.IsPrimitiveType() && apiParameter.DataModel != null)
                return true;

            return false;
        }
    }
}
