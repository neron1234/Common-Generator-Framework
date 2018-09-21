using Mobioos.Foundation.Jade.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Common.Generator.Framework.Extensions
{
    public static class ApiInfoExtension
    {
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
                viewModels.Union(api.Actions.GetApiActionViewModelsId());

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
            if (api == null)
                throw new ArgumentNullException();

            List<string> viewModels = new List<string>();

            if (api.Actions.AsEnumerable() != null)
                viewModels.Union(api.Actions.GetApiActionViewModelsId(layoutAction));

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
                viewModels.Union(api.Actions.GetApiActionViewModelsEntities());

            return viewModels;
        }

        /// <summary>
        /// Retrieve all ViewModels from an api in function of a layout action.
        /// </summary>
        /// <param name="api">An ApiInfo object.</param>
        /// <returns>A list of EntityInfo.</returns>
        public static List<EntityInfo> GetApiViewModelsEntities(this ApiInfo api, string layoutAction)
        {
            if (api == null)
                throw new ArgumentNullException();

            List<EntityInfo> viewModels = new List<EntityInfo>();

            if (api.Actions.AsEnumerable() != null)
                viewModels.Union(api.Actions.GetApiActionViewModelsEntities(layoutAction));

            return viewModels;
        }
    }
}
