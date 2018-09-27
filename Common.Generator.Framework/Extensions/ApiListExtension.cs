using Common.Generator.Framework.Comparer;
using Mobioos.Foundation.Jade.Models;
using System;
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
            List<EntityInfo> directReferences = new List<EntityInfo>();

            if (apis.AsEnumerable() == null)
                return directReferences;

            EntityInfoComparer entityComparer = new EntityInfoComparer();

            foreach (ApiInfo api in apis)
                if (api.Id != null
                    && !api.Id.Equals(""))
                    directReferences = directReferences.AsEnumerable()
                                                       .Union(api.GetApiDirectReferences().AsEnumerable(), entityComparer)
                                                       .ToList();

            return directReferences;
        }

        /// <summary>
        /// Retrieve ViewModels from a list of api.
        /// </summary>
        /// <param name="apis">An ApiList object.</param>
        /// <returns>A list of ViewModels id.</returns>
        public static List<string> GetApiListViewModelsId(this ApiList apis)
        {
            List<string> viewModels = new List<string>();

            if (apis == null)
                return viewModels;

            foreach (ApiInfo api in apis.AsEnumerable())
                if (api.Id != null
                    && !api.Id.Equals(""))
                    viewModels = viewModels.AsEnumerable()
                                           .Union(api.GetApiViewModelsId().AsEnumerable())
                                           .ToList();

            return viewModels;
        }

        /// <summary>
        /// Retrieve ViewModels from a list of api in function of a layout action.
        /// </summary>
        /// <param name="apis">An ApiList object.</param>
        /// <param name="layoutAction">A layout action name.</param>
        /// <returns>A list of ViewModels id.</returns>
        public static List<string> GetApiListViewModelsId(this ApiList apis, string layoutAction)
        {
            List<string> viewModels = new List<string>();

            if (apis == null
                || layoutAction == null)
                return viewModels;

            foreach (ApiInfo api in apis.AsEnumerable())
                if (api.Id != null
                    && !api.Id.Equals(""))
                    viewModels = viewModels.AsEnumerable()
                                           .Union(api.GetApiViewModelsId(layoutAction).AsEnumerable())
                                           .ToList();

            return viewModels;
        }

        /// <summary>
        /// Retrieve ViewModels from a list of api.
        /// </summary>
        /// <param name="apis">An ApiList object.</param>
        /// <returns>A list of EntityInfo.</returns>
        public static List<EntityInfo> GetApiListViewModelsEntities(this ApiList apis)
        {
            List<EntityInfo> viewModels = new List<EntityInfo>();

            if (apis == null)
                return viewModels;

            EntityInfoComparer entityComparer = new EntityInfoComparer();

            foreach (ApiInfo api in apis.AsEnumerable())
                if (api.Id != null
                    && !api.Id.Equals(""))
                    viewModels = viewModels.AsEnumerable()
                                           .Union(api.GetApiViewModelsEntities().AsEnumerable(), entityComparer)
                                           .ToList();

            return viewModels;
        }

        /// <summary>
        /// Retrieve ViewModels from a list of api in function of a layout action.
        /// </summary>
        /// <param name="apis">An ApiList object.</param>
        /// <param name="layoutAction">A layout action name.</param>
        /// <returns>A list of EntityInfo.</returns>
        public static List<EntityInfo> GetApiListViewModelsEntities(this ApiList apis, string layoutAction)
        {
            List<EntityInfo> viewModels = new List<EntityInfo>();

            if (apis == null
                || layoutAction == null)
                return viewModels;

            EntityInfoComparer entityComparer = new EntityInfoComparer();

            foreach (ApiInfo api in apis.AsEnumerable())
                if (api.Id != null
                    && !api.Id.Equals(""))
                    viewModels = viewModels.AsEnumerable()
                                           .Union(api.GetApiViewModelsEntities(layoutAction).AsEnumerable(), entityComparer)
                                           .ToList();

            return viewModels;
        }

        /// <summary>
        /// Retrieve a service id from a layout action service id.
        /// </summary>
        /// <param name="apis">An ApiList object.</param>
        /// <param name="apiService">A service id.</param>
        /// <returns>A service id.</returns>
        public static string GetApiListService(this ApiList apis, string apiService)
        {
            string result = "";

            if (apis.AsEnumerable() == null
                || apiService == null)
                return result;

            foreach (ApiInfo api in apis)
            {
                if (!result.Equals(""))
                    return result;
                else if (api.Id != null
                         && !api.Id.Equals(""))
                    result = api.GetApiService(apiService);
            }

            return result;
        }
    }
}
