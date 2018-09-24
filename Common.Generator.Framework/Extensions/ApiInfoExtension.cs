using Mobioos.Foundation.Jade.Models;
using System;
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
            if (api == null)
                throw new ArgumentNullException();

            List<EntityInfo> directReferences = new List<EntityInfo>();

            if (api.Actions.AsEnumerable() != null)
                directReferences.Union(api.Actions.GetApiActionListDirectReferences());

            return directReferences;
        }

        /// <summary>
        /// Retrieve all ViewModels from an api.
        /// </summary>
        /// <param name="api">An ApiInfo object.</param>
        /// <returns>A list of ViewModels id.</returns>
        public static List<string> GetApiViewModelsId(this ApiInfo api)
        {
            if (api == null)
                throw new ArgumentNullException();

            List<string> viewModels = new List<string>();

            if (api.Actions.AsEnumerable() != null)
                viewModels.Union(api.Actions.GetApiActionListViewModelsId());

            return viewModels;
        }

        /// <summary>
        /// Retrieve all ViewModels from an api in function of a layout action.
        /// </summary>
        /// <param name="api">An ApiInfo object.</param>
        /// <param name="layoutAction">A layout action name.</param>
        /// <returns>A list of ViewModels id.</returns>
        public static List<string> GetApiViewModelsId(this ApiInfo api, string layoutAction)
        {
            if (api == null || layoutAction == null)
                throw new ArgumentNullException();

            List<string> viewModels = new List<string>();

            if (api.Actions.AsEnumerable() != null)
                viewModels.Union(api.Actions.GetApiActionListViewModelsId(layoutAction));

            return viewModels;
        }

        /// <summary>
        /// Retrieve all ViewModels from an api.
        /// </summary>
        /// <param name="api">An ApiInfo object.</param>
        /// <returns>A list of EntityInfo.</returns>
        public static List<EntityInfo> GetApiViewModelsEntities(this ApiInfo api)
        {
            if (api == null)
                throw new ArgumentNullException();

            List<EntityInfo> viewModels = new List<EntityInfo>();

            if (api.Actions.AsEnumerable() != null)
                viewModels.Union(api.Actions.GetApiActionListViewModelsEntities());

            return viewModels;
        }

        /// <summary>
        /// Retrieve all ViewModels from an api in function of a layout action.
        /// </summary>
        /// <param name="api">An ApiInfo object.</param>
        /// <returns>A list of EntityInfo.</returns>
        public static List<EntityInfo> GetApiViewModelsEntities(this ApiInfo api, string layoutAction)
        {
            if (api == null || layoutAction == null)
                throw new ArgumentNullException();

            List<EntityInfo> viewModels = new List<EntityInfo>();

            if (api.Actions.AsEnumerable() != null)
                viewModels.Union(api.Actions.GetApiActionListViewModelsEntities(layoutAction));

            return viewModels;
        }

        /// <summary>
        /// Retrieve an api service id from a layout api service id.
        /// </summary>
        /// <param name="api">An ApiInfo object.</param>
        /// <param name="apiService">A service id.</param>
        /// <returns>A service id.</returns>
        public static string GetApiService(this ApiInfo api, string apiService)
        {
            if (api == null || apiService == null)
                throw new ArgumentNullException();

            if (api.Id.ToLower().Equals(apiService.ToLower()))
                return apiService.ToPascalCase();

            return null;
        }
    }
}
