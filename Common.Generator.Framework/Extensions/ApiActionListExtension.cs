using Common.Generator.Framework.Comparer;
using Mobioos.Foundation.Jade.Models;
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
            List<EntityInfo> directReferences = new List<EntityInfo>();

            if (apiActions.AsEnumerable() == null)
                return directReferences;

            foreach (ApiActionInfo apiAction in apiActions)
                if (apiAction.Id != null
                    && !apiAction.Id.Equals(""))
                    directReferences = directReferences.AsEnumerable()
                                                       .Union(apiAction.GetApiActionDirectReferences().AsEnumerable())
                                                       .ToList();

            return directReferences;
        }

        /// <summary>
        /// Retrieve ViewModels from all api actions parameters and return types.
        /// </summary>
        /// <param name="apiActions">A list of api actions.</param>
        /// <returns>A list of ViewModels id.</returns>
        public static List<string> GetApiActionListViewModelsId(this ApiActionList apiActions)
        {
            List<string> viewModels = new List<string>();

            if (apiActions.AsEnumerable() == null)
                return viewModels;

            foreach (ApiActionInfo apiAction in apiActions.AsEnumerable())
                if (apiAction.Id != null
                    && !apiAction.Id.Equals(""))
                    viewModels = viewModels.AsEnumerable()
                                           .Union(apiAction.GetApiActionViewModelsId().AsEnumerable())
                                           .ToList();

            return viewModels;
        }

        /// <summary>
        /// Retrieve ViewModels from all api actions parameters and return types.
        /// </summary>
        /// <param name="apiActions">A list of api actions.</param>
        /// <returns>A list of EntityInfo.</returns>
        public static List<EntityInfo> GetApiActionListViewModelsEntities(this ApiActionList apiActions)
        {
            List<EntityInfo> viewModels = new List<EntityInfo>();

            if (apiActions.AsEnumerable() == null)
                return viewModels;

            EntityInfoComparer comparer = new EntityInfoComparer();

            foreach (ApiActionInfo apiAction in apiActions.AsEnumerable())
                if (apiAction.Id != null
                    && !apiAction.Id.Equals(""))
                    viewModels = viewModels.AsEnumerable()
                                           .Union(apiAction.GetApiActionViewModelsEntities().AsEnumerable(), comparer)
                                           .ToList();

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
            List<string> viewModels = new List<string>();

            if (apiActions.AsEnumerable() == null
                || layoutAction == null)
                return viewModels;

            foreach (ApiActionInfo apiAction in apiActions.AsEnumerable())
                if (apiAction.Id != null
                    && !apiAction.Id.Equals(""))
                    viewModels = viewModels.AsEnumerable()
                                           .Union(apiAction.GetApiActionViewModelsId(layoutAction).AsEnumerable())
                                           .ToList();

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
            List<EntityInfo> viewModels = new List<EntityInfo>();

            if (apiActions.AsEnumerable() == null
                || layoutAction == null)
                return viewModels;

            foreach (ApiActionInfo apiAction in apiActions.AsEnumerable())
                if (apiAction.Id != null
                    && !apiAction.Id.Equals(""))
                    viewModels = viewModels.AsEnumerable()
                                           .Union(apiAction.GetApiActionViewModelsEntities().AsEnumerable())
                                           .ToList();

            return viewModels;
        }
    }
}
