using Common.Generator.Framework.Comparer;
using Mobioos.Foundation.Jade.Models;
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
            if (!apiAction.IsValid())
            {
                return null;
            }

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
            var directReferences = new List<EntityInfo>();

            if (!apiAction.IsValid())
            {
                return directReferences;
            }

            var entityComparer = new EntityInfoComparer();

            if (apiAction.Parameters != null)
            {
                directReferences = directReferences
                    .Union(
                        apiAction.Parameters.GetApiParametersDirectReferences(),
                        entityComparer)
                    .ToList();
            }

            if (apiAction.ReturnType.IsValid()
                && apiAction.ReturnType.References != null)
            {
                directReferences = directReferences
                    .Union(
                        apiAction.ReturnType.GetEntityDirectReferences(),
                        entityComparer)
                    .ToList();
            }

            return directReferences;
        }

        /// <summary>
        /// Retrieve all direct references from api parameters.
        /// </summary>
        /// <param name="apiParameters">A list of ApiParameterInfo objects.</param>
        /// <returns>A list of EntityInfo.</returns>
        public static List<EntityInfo> GetApiParametersDirectReferences(
            this IEnumerable<ApiParameterInfo> apiParameters)
        {
            var directReferences = new List<EntityInfo>();

            if (apiParameters == null)
            {
                return directReferences;
            }

            var entityComparer = new EntityInfoComparer();

            foreach (var apiActionParameter in apiParameters)
            {
                if (apiActionParameter.IsValid())
                {
                    directReferences = directReferences
                        .Union(
                            apiActionParameter.GetApiParameterDirectReferences(),
                            entityComparer)
                        .ToList();
                }
            }

            return directReferences;
        }

        /// <summary>
        /// Retrieve ViewModels from an api action.
        /// </summary>
        /// <param name="apiAction">An ApiActionInfo object.</param>
        /// <returns>A list of ViewModels id.</returns>
        public static List<string> GetApiActionViewModelsId(this ApiActionInfo apiAction)
        {
            var viewModels = new List<string>();

            if (!apiAction.IsValid())
            {
                return viewModels;
            }

            if (apiAction.Parameters != null)
            {
                if (apiAction.ReturnType.IsValid()
                    && !viewModels.Any(item =>
                            item == apiAction.ReturnType.Id.ToPascalCase()))
                {
                    viewModels.Add(apiAction.ReturnType.Id.ToPascalCase());
                }

                viewModels = viewModels
                    .Union(apiAction.Parameters.GetApiParametersViewModelsId())
                    .ToList();
            }

            return viewModels;
        }

        /// <summary>
        /// Retrieve ViewModels from a list of api action parameters.
        /// </summary>
        /// <param name="apiParameters">A list of ApiParameterInfo.</param>
        /// <returns>A list of ViewModels id.</returns>
        public static List<string> GetApiParametersViewModelsId(
            this IEnumerable<ApiParameterInfo> apiParameters)
        {
            var viewModels = new List<string>();

            if (apiParameters == null)
            {
                return viewModels;
            }

            foreach (var apiActionParameter in apiParameters)
            {
                if (apiActionParameter.IsValid()
                    && apiActionParameter.IsModel()
                    && apiActionParameter.DataModel.IsValid()
                    && !viewModels.Any(item =>
                            item == apiActionParameter.TypeScriptType().ToPascalCase()))
                {
                    viewModels.Add(apiActionParameter.TypeScriptType().ToPascalCase());
                }
            }

            return viewModels;
        }

        /// <summary>
        /// Retrieve ViewModels from an api action.
        /// </summary>
        /// <param name="apiAction">An ApiActionInfo object.</param>
        /// <returns>A list of EntityInfo.</returns>
        public static List<EntityInfo> GetApiActionViewModelsEntities(this ApiActionInfo apiAction)
        {
            var viewModels = new List<EntityInfo>();

            if (!apiAction.IsValid())
            {
                return viewModels;
            }

            var entityComparer = new EntityInfoComparer();

            if (apiAction.Parameters != null)
            {
                if (apiAction.ReturnType.IsValid()
                    && !viewModels.Any(item =>
                            entityComparer.Equals(
                                item,
                                apiAction.ReturnType)))
                {
                    viewModels.Add(apiAction.ReturnType);
                }

                viewModels = viewModels
                    .Union(
                        apiAction.Parameters.GetApiParametersViewModelsEntities(),
                        entityComparer)
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
            var viewModels = new List<EntityInfo>();

            if (apiParameters == null)
            {
                return viewModels;
            }

            var entityComparer = new EntityInfoComparer();

            foreach (var apiActionParameter in apiParameters)
            {
                if (apiActionParameter.IsValid()
                    && apiActionParameter.IsModel()
                    && apiActionParameter.DataModel.IsValid()
                    && !viewModels.Any(item =>
                            entityComparer.Equals(
                                item,
                                apiActionParameter.DataModel)))
                {
                    viewModels.Add(apiActionParameter.DataModel);
                }
            }

            return viewModels;
        }

        /// <summary>
        /// Retrieve ViewModels from an api action for a specific layout action.
        /// </summary>
        /// <param name="apiAction">An ApiActionInfo object.</param>
        /// <param name="layoutAction">A layout name.</param>
        /// <returns>A list of ViewModels id.</returns>
        public static List<string> GetApiActionViewModelsId(
            this ApiActionInfo apiAction,
            string layoutAction)
        {
            var viewModels = new List<string>();

            if (!apiAction.IsValid()
                || !layoutAction.IsValid())
            {
                return viewModels;
            }

            if (apiAction.Id.ToLower().Equals(layoutAction.ToLower())
                && apiAction.Parameters != null)
            {
                if (apiAction.ReturnType.IsValid()
                    && !viewModels.Any(item =>
                            item == apiAction.ReturnType.Id.ToPascalCase()))
                {
                    viewModels.Add(apiAction.ReturnType.Id.ToPascalCase());
                }

                viewModels = viewModels
                    .Union(apiAction.Parameters.GetApiParametersViewModelsId())
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
        public static List<EntityInfo> GetApiActionViewModelsEntities(
            this ApiActionInfo apiAction,
            string layoutAction)
        {
            var viewModels = new List<EntityInfo>();

            if (!apiAction.IsValid()
                || !layoutAction.IsValid())
            {
                return viewModels;
            }

            var entityComparer = new EntityInfoComparer();

            if (apiAction.Id.ToLower().Equals(layoutAction.ToLower())
                && apiAction.Parameters != null)
            {
                if (apiAction.ReturnType.IsValid()
                    && !viewModels.Any(item =>
                            entityComparer.Equals(
                                item,
                                apiAction.ReturnType)))
                {
                    viewModels.Add(apiAction.ReturnType);
                }

                viewModels = viewModels
                    .Union(
                        apiAction.Parameters.GetApiParametersViewModelsEntities(),
                        entityComparer)
                    .ToList();
            }

            return viewModels;
        }

        public static bool IsValid(this ApiActionInfo apiAction)
        {
            if (apiAction == null
                || !apiAction.Id.IsValid()
                || !apiAction.Type.IsValid())
            {
                return false;
            }

            return true;
        }
    }
}
