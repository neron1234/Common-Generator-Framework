using Common.Generator.Framework.Comparer;
using Mobioos.Foundation.Jade.Models;
using System.Collections.Generic;
using System.Linq;

namespace Common.Generator.Framework.Extensions
{
    public static class ApiInfoExtension
    {
        /// <summary>
        /// Retrieve all direct references from an api.
        /// </summary>
        /// <param name="api">An ApiInfo object.</param>
        /// <returns>A list of EntityInfo.</returns>
        public static List<EntityInfo> GetApiDirectReferences(this ApiInfo api)
        {
            var directReferences = new List<EntityInfo>();

            if (!api.IsValid())
            {
                return directReferences;
            }

            var entityComparer = new EntityInfoComparer();

            if (api.Actions.IsValid())
            {
                directReferences = directReferences
                    .Union(
                        api.Actions.GetApiActionListDirectReferences(),
                        entityComparer)
                    .ToList();
            }

            return directReferences;
        }

        /// <summary>
        /// Retrieve all ViewModels from an api.
        /// </summary>
        /// <param name="api">An ApiInfo object.</param>
        /// <returns>A list of ViewModels id.</returns>
        public static List<string> GetApiViewModelsId(this ApiInfo api)
        {
            var viewModels = new List<string>();

            if (!api.IsValid())
            {
                return viewModels;
            }

            if (api.Actions.IsValid())
            {
                viewModels = viewModels
                    .Union(api.Actions.GetApiActionListViewModelsId())
                    .ToList();
            }

            return viewModels;
        }

        /// <summary>
        /// Retrieve all ViewModels from an api in function of a layout action.
        /// </summary>
        /// <param name="api">An ApiInfo object.</param>
        /// <param name="layoutAction">A layout action name.</param>
        /// <returns>A list of ViewModels id.</returns>
        public static List<string> GetApiViewModelsId(
            this ApiInfo api,
            string layoutAction)
        {
            var viewModels = new List<string>();

            if (!api.IsValid()
                || !layoutAction.IsValid())
            {
                return viewModels;
            }

            if (api.Actions.IsValid())
            {
                viewModels = viewModels
                    .Union(api.Actions.GetApiActionListViewModelsId(layoutAction))
                    .ToList();
            }

            return viewModels;
        }

        /// <summary>
        /// Retrieve all ViewModels from an api.
        /// </summary>
        /// <param name="api">An ApiInfo object.</param>
        /// <returns>A list of EntityInfo.</returns>
        public static List<EntityInfo> GetApiViewModelsEntities(this ApiInfo api)
        {
            var viewModels = new List<EntityInfo>();

            if (!api.IsValid())
            {
                return viewModels;
            }

            var entityComparer = new EntityInfoComparer();

            if (api.Actions.IsValid())
            {
                viewModels = viewModels
                    .Union(
                        api.Actions.GetApiActionListViewModelsEntities(),
                        entityComparer)
                    .ToList();
            }

            return viewModels;
        }

        /// <summary>
        /// Retrieve all ViewModels from an api in function of a layout action.
        /// </summary>
        /// <param name="api">An ApiInfo object.</param>
        /// <returns>A list of EntityInfo.</returns>
        public static List<EntityInfo> GetApiViewModelsEntities(
            this ApiInfo api,
            string layoutAction)
        {
            var viewModels = new List<EntityInfo>();

            if (!api.IsValid()
                || !layoutAction.IsValid())
            {
                return viewModels;
            }

            var entityComparer = new EntityInfoComparer();

            if (api.Actions.IsValid())
            {
                viewModels = viewModels
                    .Union(
                        api.Actions.GetApiActionListViewModelsEntities(layoutAction),
                        entityComparer)
                    .ToList();
            }

            return viewModels;
        }

        /// <summary>
        /// Retrieve an api service id from a layout api service id.
        /// </summary>
        /// <param name="api">An ApiInfo object.</param>
        /// <param name="apiService">A service id.</param>
        /// <returns>A service id.</returns>
        public static string GetApiService(
            this ApiInfo api,
            string apiService)
        {
            if (!api.IsValid()
                || !apiService.IsValid())
            {
                return null;
            }

            if (api.Id.ToLower().Equals(apiService.ToLower()))
            {
                return apiService.ToPascalCase();
            }

            return null;
        }

        public static bool IsValid(this ApiInfo api)
        {
            if (api == null
                || !api.Id.IsValid())
            {
                return false;
            }

            return true;
        }
    }
}
