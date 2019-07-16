using Common.Generator.Framework.Comparer;
using Mobioos.Foundation.Jade.Models;
using System.Collections.Generic;
using System.Linq;

namespace Common.Generator.Framework.Extensions
{
    public static class ApiListExtension
    {
        /// <summary>
        /// Retrieve all direct references from an api list.
        /// </summary>
        /// <param name="apis">An ApiList object.</param>
        /// <returns>A list of EntityInfo.</returns>
        public static List<EntityInfo> GetApiListDirectReferences(this ApiList apis)
        {
            var directReferences = new List<EntityInfo>();

            if (!apis.IsValid())
            {
                return directReferences;
            }

            var entityComparer = new EntityInfoComparer();

            foreach (var api in apis)
            {
                if (api.IsValid())
                {
                    directReferences = directReferences
                        .Union(
                            api.GetApiDirectReferences(),
                            entityComparer)
                        .ToList();
                }
            }

            return directReferences;
        }

        /// <summary>
        /// Retrieve ViewModels from a list of api.
        /// </summary>
        /// <param name="apis">An ApiList object.</param>
        /// <returns>A list of ViewModels id.</returns>
        public static List<string> GetApiListViewModelsId(this ApiList apis)
        {
            var viewModels = new List<string>();

            if (!apis.IsValid())
            {
                return viewModels;
            }

            foreach (var api in apis)
            {
                if (api.IsValid())
                {
                    viewModels = viewModels
                        .Union(api.GetApiViewModelsId())
                        .ToList();
                }
            }

            return viewModels;
        }

        /// <summary>
        /// Retrieve ViewModels from a list of api in function of a layout action.
        /// </summary>
        /// <param name="apis">An ApiList object.</param>
        /// <param name="layoutAction">A layout action name.</param>
        /// <returns>A list of ViewModels id.</returns>
        public static List<string> GetApiListViewModelsId(
            this ApiList apis,
            string layoutAction)
        {
            var viewModels = new List<string>();

            if (!apis.IsValid()
                || !layoutAction.IsValid())
            {
                return viewModels;
            }

            foreach (var api in apis)
            {
                if (api.IsValid())
                {
                    viewModels = viewModels
                        .Union(api.GetApiViewModelsId(layoutAction))
                        .ToList();
                }
            }

            return viewModels;
        }

        /// <summary>
        /// Retrieve ViewModels from a list of api.
        /// </summary>
        /// <param name="apis">An ApiList object.</param>
        /// <returns>A list of EntityInfo.</returns>
        public static List<EntityInfo> GetApiListViewModelsEntities(this ApiList apis)
        {
            var viewModels = new List<EntityInfo>();

            if (!apis.IsValid())
            {
                return viewModels;
            }

            var entityComparer = new EntityInfoComparer();

            foreach (var api in apis)
            {
                if (api.IsValid())
                {
                    viewModels = viewModels
                        .Union(
                            api.GetApiViewModelsEntities(),
                            entityComparer)
                        .ToList();
                }
            }

            return viewModels;
        }

        /// <summary>
        /// Retrieve ViewModels from a list of api in function of a layout action.
        /// </summary>
        /// <param name="apis">An ApiList object.</param>
        /// <param name="layoutAction">A layout action name.</param>
        /// <returns>A list of EntityInfo.</returns>
        public static List<EntityInfo> GetApiListViewModelsEntities(
            this ApiList apis,
            string layoutAction)
        {
            var viewModels = new List<EntityInfo>();

            if (!apis.IsValid()
                || !layoutAction.IsValid())
            {
                return viewModels;
            }

            var entityComparer = new EntityInfoComparer();

            foreach (var api in apis)
            { 
                if (api.IsValid())
                {
                    viewModels = viewModels
                        .Union(
                            api.GetApiViewModelsEntities(layoutAction),
                            entityComparer)
                        .ToList();
                }
            }

            return viewModels;
        }

        /// <summary>
        /// Retrieve a service id from a layout action service id.
        /// </summary>
        /// <param name="apis">An ApiList object.</param>
        /// <param name="apiService">A service id.</param>
        /// <returns>A service id.</returns>
        public static string GetApiListService(
            this ApiList apis,
            string apiService)
        {
            if (!apis.IsValid()
                || !apiService.IsValid())
            {
                return null;
            }

            return apis
                .Where(a => a.GetApiService(apiService) != null)
                .Select(a => a.GetApiService(apiService))
                .FirstOrDefault();
        }

        public static bool IsValid(this ApiList apis)
        {
            if (!apis.IsValid<ApiInfo>())
            {
                return false;
            }

            return true;
        }
    }
}
