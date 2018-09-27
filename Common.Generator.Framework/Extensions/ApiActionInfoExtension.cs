using Common.Generator.Framework.Comparer;
using Mobioos.Foundation.Jade.Models;
using System;
using System.Collections.Generic;
using System.Linq;

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
            string result = "";

            if (apiAction == null
                || apiAction.Type == null)
                return result;

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

        /// <summary>
        /// Retrieve direct references from api action parameters and return type.
        /// </summary>
        /// <param name="apiAction">An ApiActionInfo object.</param>
        /// <returns>A list of EntityInfo.</returns>
        public static List<EntityInfo> GetApiActionDirectReferences(this ApiActionInfo apiAction)
        {
            List<EntityInfo> directReferences = new List<EntityInfo>();

            if (apiAction == null
                || apiAction.Id == null
                || apiAction.Id.Equals(""))
                return directReferences;

            if (apiAction.Parameters.AsEnumerable() != null)
                directReferences = directReferences.AsEnumerable()
                                                   .Union(apiAction.Parameters.GetApiParametersDirectReferences().AsEnumerable())
                                                   .ToList();

            if (apiAction.ReturnType != null
                && apiAction.ReturnType.Id != null
                && !apiAction.ReturnType.Id.Equals("")
                && apiAction.ReturnType.References.AsEnumerable() != null)
                directReferences = directReferences.AsEnumerable()
                                                   .Union(apiAction.ReturnType.GetEntityDirectReferences().AsEnumerable())
                                                   .ToList();

            return directReferences;
        }

        /// <summary>
        /// Retrieve all direct references from api parameters.
        /// </summary>
        /// <param name="apiParameters">A list of ApiParameterInfo objects.</param>
        /// <returns>A list of EntityInfo.</returns>
        public static List<EntityInfo> GetApiParametersDirectReferences(this IEnumerable<ApiParameterInfo> apiParameters)
        {
            List<EntityInfo> directReferences = new List<EntityInfo>();

            if (apiParameters.AsEnumerable() == null)
                return directReferences;

            foreach (ApiParameterInfo apiActionParameter in apiParameters.AsEnumerable())
                if (apiActionParameter.Id != null
                    && !apiActionParameter.Id.Equals(""))
                    directReferences = directReferences.AsEnumerable()
                                                       .Union(apiActionParameter.GetApiParameterDirectReferences().AsEnumerable())
                                                       .ToList();

            return directReferences;
        }

        /// <summary>
        /// Retrieve ViewModels from an api action.
        /// </summary>
        /// <param name="apiAction">An ApiActionInfo object.</param>
        /// <returns>A list of ViewModels id.</returns>
        public static List<string> GetApiActionViewModelsId(this ApiActionInfo apiAction)
        {
            List<string> viewModels = new List<string>();

            if (apiAction == null
                || apiAction.Id == null
                || apiAction.Id.Equals(""))
                return viewModels;

            if (apiAction.Parameters.AsEnumerable() != null)
            {
                if (apiAction.ReturnType != null
                    && apiAction.ReturnType.Id != null
                    && !apiAction.ReturnType.Id.ToPascalCase().Equals("")
                    && !viewModels.AsEnumerable()
                                  .Any(item => item == apiAction.ReturnType.Id.ToPascalCase()))
                    viewModels.Add(apiAction.ReturnType.Id.ToPascalCase());

                viewModels = viewModels.AsEnumerable()
                                       .Union(apiAction.Parameters.AsEnumerable().GetApiParametersViewModelsId().AsEnumerable())
                                       .ToList();
            }

            return viewModels;
        }

        /// <summary>
        /// Retrieve ViewModels from a list of api action parameters.
        /// </summary>
        /// <param name="apiParameters">A list of ApiParameterInfo.</param>
        /// <returns>A list of ViewModels id.</returns>
        public static List<string> GetApiParametersViewModelsId(this IEnumerable<ApiParameterInfo> apiParameters)
        {
            List<string> viewModels = new List<string>();

            if (apiParameters.AsEnumerable() == null)
                return viewModels;

            foreach (ApiParameterInfo apiActionParameter in apiParameters.AsEnumerable())
                if (apiActionParameter.Id != null
                    && !apiActionParameter.Id.Equals("")
                    && apiActionParameter.IsModel()
                    && apiActionParameter.DataModel != null
                    && apiActionParameter.DataModel.Id != null
                    && !apiActionParameter.DataModel.Id.Equals("")
                    && !apiActionParameter.TypeScriptType().ToPascalCase().Equals("")
                    && !viewModels.AsEnumerable()
                                  .Any(item => item == apiActionParameter.TypeScriptType().ToPascalCase()))
                    viewModels.Add(apiActionParameter.TypeScriptType().ToPascalCase());

            return viewModels;
        }

        /// <summary>
        /// Retrieve ViewModels from an api action.
        /// </summary>
        /// <param name="apiAction">An ApiActionInfo object.</param>
        /// <returns>A list of EntityInfo.</returns>
        public static List<EntityInfo> GetApiActionViewModelsEntities(this ApiActionInfo apiAction)
        {
            List<EntityInfo> viewModels = new List<EntityInfo>();

            if (apiAction == null
                || apiAction.Id == null
                || apiAction.Id.Equals(""))
                return viewModels;

            if (apiAction.Parameters.AsEnumerable() != null)
            {
                if (apiAction.ReturnType != null
                    && apiAction.ReturnType.Id != null
                    && !apiAction.ReturnType.Id.Equals("")
                    && !viewModels.AsEnumerable()
                                  .Any(item => item == apiAction.ReturnType))
                    viewModels.Add(apiAction.ReturnType);

                EntityInfoComparer comparer = new EntityInfoComparer();

                viewModels = viewModels.AsEnumerable()
                                       .Union(apiAction.Parameters.AsEnumerable().GetApiParametersViewModelsEntities().AsEnumerable(), comparer)
                                       .ToList();
            }

            return viewModels;
        }

        /// <summary>
        /// Retrieve ViewModels from a list of api action parameters.
        /// </summary>
        /// <param name="apiParameters">A list of ApiParameterInfo.</param>
        /// <returns>A list of EntityInfo.</returns>
        public static List<EntityInfo> GetApiParametersViewModelsEntities(
            this IEnumerable<ApiParameterInfo> apiParameters)
        {
            List<EntityInfo> viewModels = new List<EntityInfo>();

            if (apiParameters.AsEnumerable() == null)
                return viewModels;

            foreach (ApiParameterInfo apiActionParameter in apiParameters.AsEnumerable())
                if (apiActionParameter.Id != null
                    && !apiActionParameter.Id.Equals("")
                    && apiActionParameter.IsModel()
                    && apiActionParameter.DataModel != null
                    && apiActionParameter.DataModel.Id != null
                    && !apiActionParameter.DataModel.Id.Equals("")
                    && !viewModels.AsEnumerable()
                                  .Any(item => item == apiActionParameter.DataModel))
                    viewModels.Add(apiActionParameter.DataModel);

            return viewModels;
        }

        /// <summary>
        /// Retrieve ViewModels from an api action for a specific layout action.
        /// </summary>
        /// <param name="apiAction">An ApiActionInfo object.</param>
        /// <param name="layoutAction">A layout name.</param>
        /// <returns>A list of ViewModels id.</returns>
        public static List<string> GetApiActionViewModelsId(this ApiActionInfo apiAction, string layoutAction)
        {
            List<string> viewModels = new List<string>();

            if (apiAction == null
                || apiAction.Id == null
                || apiAction.Id.Equals("")
                || layoutAction == null)
                return viewModels;

            if (apiAction.Id.ToLower().Equals(layoutAction.ToLower())
                && apiAction.Parameters.AsEnumerable() != null)
            {
                if (apiAction.ReturnType != null
                    && apiAction.ReturnType.Id != null
                    && !apiAction.ReturnType.Id.ToPascalCase().Equals("")
                    && !viewModels.AsEnumerable()
                                  .Any(item => item == apiAction.ReturnType.Id.ToPascalCase()))
                    viewModels.Add(apiAction.ReturnType.Id.ToPascalCase());

                viewModels = viewModels.AsEnumerable()
                                       .Union(apiAction.Parameters.AsEnumerable().GetApiParametersViewModelsId().AsEnumerable())
                                       .ToList();
            }

            return viewModels;
        }

        /// <summary>
        /// Retrieve ViewModels from an api action for a specific layout action.
        /// </summary>
        /// <param name="apiAction">An ApiActionInfo object.</param>
        /// <param name="layoutAction">A layout name.</param>
        /// <returns>A list of EntityInfo.</returns>
        public static List<EntityInfo> GetApiActionViewModelsEntities(this ApiActionInfo apiAction, string layoutAction)
        {
            List<EntityInfo> viewModels = new List<EntityInfo>();

            if (apiAction == null
                || apiAction.Id == null
                || apiAction.Id.Equals("")
                || layoutAction == null)
                return viewModels;

            if (apiAction.Id.ToLower().Equals(layoutAction.ToLower())
                && apiAction.Parameters.AsEnumerable() != null)
            {
                if (apiAction.ReturnType != null
                    && apiAction.ReturnType.Id != null
                    && !apiAction.ReturnType.Id.Equals("")
                    && !viewModels.AsEnumerable()
                                  .Any(item => item == apiAction.ReturnType))
                    viewModels.Add(apiAction.ReturnType);

                viewModels = viewModels.AsEnumerable()
                                       .Union(apiAction.Parameters.AsEnumerable().GetApiParametersViewModelsEntities().AsEnumerable())
                                       .ToList();
            }

            return viewModels;
        }
    }
}
