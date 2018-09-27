using Common.Generator.Framework.Comparer;
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
            List<EntityInfo> directReferences = new List<EntityInfo>();

            if (api == null
                || api.Id == null
                || api.Id.Equals(""))
                return directReferences;

            if (api.Actions.AsEnumerable() != null)
                directReferences = directReferences.AsEnumerable()
                                                   .Union(api.Actions.GetApiActionListDirectReferences().AsEnumerable())
                                                   .ToList();

            return directReferences;
        }

        /// <summary>
        /// Retrieve all ViewModels from an api.
        /// </summary>
        /// <param name="api">An ApiInfo object.</param>
        /// <returns>A list of ViewModels id.</returns>
        public static List<string> GetApiViewModelsId(this ApiInfo api)
        {
            List<string> viewModels = new List<string>();

            if (api == null
                || api.Id == null
                || api.Id.Equals(""))
                return viewModels;

            if (api.Actions.AsEnumerable() != null)
                viewModels = viewModels.AsEnumerable()
                                       .Union(api.Actions.GetApiActionListViewModelsId().AsEnumerable())
                                       .ToList();

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
            List<string> viewModels = new List<string>();

            if (api == null
                || api.Id == null
                || api.Id.Equals("")
                || layoutAction == null)
                return viewModels;

            if (api.Actions.AsEnumerable() != null)
                viewModels = viewModels.AsEnumerable()
                                       .Union(api.Actions.GetApiActionListViewModelsId(layoutAction).AsEnumerable())
                                       .ToList();

            return viewModels;
        }

        /// <summary>
        /// Retrieve all ViewModels from an api.
        /// </summary>
        /// <param name="api">An ApiInfo object.</param>
        /// <returns>A list of EntityInfo.</returns>
        public static List<EntityInfo> GetApiViewModelsEntities(this ApiInfo api)
        {
            List<EntityInfo> viewModels = new List<EntityInfo>();

            if (api == null
                || api.Id == null
                || api.Id.Equals(""))
                return viewModels;

            EntityInfoComparer comparer = new EntityInfoComparer();

            if (api.Actions.AsEnumerable() != null)
                viewModels = viewModels.AsEnumerable()
                                       .Union(api.Actions.GetApiActionListViewModelsEntities().AsEnumerable(), comparer)
                                       .ToList();

            return viewModels;
        }

        /// <summary>
        /// Retrieve all ViewModels from an api in function of a layout action.
        /// </summary>
        /// <param name="api">An ApiInfo object.</param>
        /// <returns>A list of EntityInfo.</returns>
        public static List<EntityInfo> GetApiViewModelsEntities(this ApiInfo api, string layoutAction)
        {
            List<EntityInfo> viewModels = new List<EntityInfo>();

            if (api == null
                || api.Id == null
                || api.Id.Equals("")
                || layoutAction == null)
                return viewModels;

            if (api.Actions.AsEnumerable() != null)
                viewModels = viewModels.AsEnumerable()
                                       .Union(api.Actions.GetApiActionListViewModelsEntities(layoutAction).AsEnumerable())
                                       .ToList();

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
            string result = "";

            if (api == null
                || api.Id == null
                || api.Id.Equals("")
                || apiService == null)
                return result;

            if (api.Id.ToLower().Equals(apiService.ToLower()))
                return apiService.ToPascalCase();

            return result;
        }
    }
}
