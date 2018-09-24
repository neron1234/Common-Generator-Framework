using Mobioos.Foundation.Jade.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Common.Generator.Framework.Extensions
{
    public static class ApiActionListExtension
    {
        /// <summary>
        /// Retrieve all direct refrences from api actions.
        /// </summary>
        /// <param name="apiActions">An ApiActionList object.</param>
        /// <returns>A list of EntityInfo.</returns>
        public static List<EntityInfo> GetApiActionListDirectReferences(this ApiActionList apiActions)
        {
            if (apiActions.AsEnumerable() == null)
                throw new ArgumentNullException();

            List<EntityInfo> directReferences = new List<EntityInfo>();

            foreach (ApiActionInfo apiAction in apiActions)
                directReferences.Union(apiAction.GetApiActionDirectReferences());

            return directReferences;
        }

        /// <summary>
        /// Retrieve ViewModels from all api actions parameters and return types.
        /// </summary>
        /// <param name="apiActions">A list of api actions.</param>
        /// <returns>A list of ViewModels id.</returns>
        public static List<string> GetApiActionListViewModelsId(this ApiActionList apiActions)
        {
            if (apiActions.AsEnumerable() == null)
                throw new ArgumentNullException();

            List<string> viewModels = new List<string>();

            foreach (ApiActionInfo apiAction in apiActions.AsEnumerable())
                viewModels.Union(apiAction.GetApiActionViewModelsId());

            return viewModels;
        }

        /// <summary>
        /// Retrieve ViewModels from all api actions parameters and return types.
        /// </summary>
        /// <param name="apiActions">A list of api actions.</param>
        /// <returns>A list of EntityInfo.</returns>
        public static List<EntityInfo> GetApiActionListViewModelsEntities(this ApiActionList apiActions)
        {
            if (apiActions.AsEnumerable() == null)
                throw new ArgumentNullException();

            List<EntityInfo> viewModels = new List<EntityInfo>();

            foreach (ApiActionInfo apiAction in apiActions.AsEnumerable())
                viewModels.Union(apiAction.GetApiActionViewModelsEntities());

            return viewModels;
        }

        /// <summary>
        /// Retrieve ViewModels from api actions parameters and return
        /// type for a specific layout action.
        /// </summary>
        /// <param name="layoutAction">A layout action.</param>
        /// <param name="apiActions">A list of api actions.</param>
        /// <returns>A list of ViewModels id.</returns>
        public static List<string> GetApiActionListViewModelsId(this ApiActionList apiActions, string layoutAction)
        {
            if (apiActions.AsEnumerable() == null || layoutAction == null)
                throw new ArgumentNullException();

            List<string> viewModels = new List<string>();

            foreach (ApiActionInfo apiAction in apiActions.AsEnumerable())
                viewModels.Union(apiAction.GetApiActionViewModelsId(layoutAction));

            return viewModels;
        }

        /// <summary>
        /// Retrieve ViewModels from api actions parameters and return
        /// type for a specific layout action.
        /// </summary>
        /// <param name="layoutAction">A layout action.</param>
        /// <param name="apiActions">A list of api actions.</param>
        /// <returns>A list of EntityInfo.</returns>
        public static List<EntityInfo> GetApiActionListViewModelsEntities(
            this ApiActionList apiActions, string layoutAction)
        {
            if (apiActions.AsEnumerable() == null || layoutAction == null)
                throw new ArgumentNullException();

            List<EntityInfo> viewModels = new List<EntityInfo>();

            foreach (ApiActionInfo apiAction in apiActions.AsEnumerable())
                viewModels.Union(apiAction.GetApiActionViewModelsEntities());

            return viewModels;
        }
    }
}
