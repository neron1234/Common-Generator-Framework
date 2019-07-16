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
            var directReferences = new List<EntityInfo>();

            if (!apiActions.IsValid())
            {
                return directReferences;
            }

            var entityComparer = new EntityInfoComparer();

            foreach (var apiAction in apiActions)
            {
                if (apiAction.IsValid())
                {
                    directReferences = directReferences
                        .Union(
                            apiAction.GetApiActionDirectReferences(),
                            entityComparer)
                        .ToList();
                }
            }

            return directReferences;
        }

        /// <summary>
        /// Retrieve ViewModels from all api actions parameters and return types.
        /// </summary>
        /// <param name="apiActions">A list of api actions.</param>
        /// <returns>A list of ViewModels id.</returns>
        public static List<string> GetApiActionListViewModelsId(this ApiActionList apiActions)
        {
            var viewModels = new List<string>();

            if (!apiActions.IsValid())
            {
                return viewModels;
            }

            foreach (var apiAction in apiActions)
            {
                if (apiAction.IsValid())
                {
                    viewModels = viewModels
                        .Union(apiAction.GetApiActionViewModelsId())
                        .ToList();
                }
            }

            return viewModels;
        }

        /// <summary>
        /// Retrieve ViewModels from all api actions parameters and return types.
        /// </summary>
        /// <param name="apiActions">A list of api actions.</param>
        /// <returns>A list of EntityInfo.</returns>
        public static List<EntityInfo> GetApiActionListViewModelsEntities(this ApiActionList apiActions)
        {
            var viewModels = new List<EntityInfo>();

            if (!apiActions.IsValid())
            {
                return viewModels;
            }

            var entityComparer = new EntityInfoComparer();

            foreach (var apiAction in apiActions)
            {
                if (apiAction.IsValid())
                {
                    viewModels = viewModels
                        .Union(
                            apiAction.GetApiActionViewModelsEntities(),
                            entityComparer)
                        .ToList();
                }
            }

            return viewModels;
        }

        /// <summary>
        /// Retrieve ViewModels from api actions parameters and return
        /// type for a specific layout action.
        /// </summary>
        /// <param name="layoutAction">A layout action.</param>
        /// <param name="apiActions">A list of api actions.</param>
        /// <returns>A list of ViewModels id.</returns>
        public static List<string> GetApiActionListViewModelsId(
            this ApiActionList apiActions,
            string layoutAction)
        {
            var viewModels = new List<string>();

            if (!apiActions.IsValid()
                || !layoutAction.IsValid())
            {
                return viewModels;
            }

            foreach (var apiAction in apiActions)
            {
                if (apiAction.IsValid())
                {
                    viewModels = viewModels
                        .Union(apiAction.GetApiActionViewModelsId(layoutAction))
                        .ToList();
                }
            }

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
            this ApiActionList apiActions,
            string layoutAction)
        {
            var viewModels = new List<EntityInfo>();

            if (!apiActions.IsValid()
                || !layoutAction.IsValid())
            {
                return viewModels;
            }

            var entityComparer = new EntityInfoComparer();

            foreach (var apiAction in apiActions)
            {
                if (apiAction.IsValid())
                {
                    viewModels = viewModels
                        .Union(
                            apiAction.GetApiActionViewModelsEntities(layoutAction),
                            entityComparer)
                        .ToList();
                }
            }

            return viewModels;
        }

        public static bool IsValid(this ApiActionList apiActions)
        {
            if (!apiActions.IsValid<ApiActionInfo>())
            {
                return false;
            }

            return true;
        }
    }
}
