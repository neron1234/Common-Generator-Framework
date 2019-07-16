using Common.Generator.Framework.Comparer;
using Mobioos.Foundation.Jade.Models;
using System.Collections.Generic;
using System.Linq;

namespace Common.Generator.Framework.Extensions
{
    public static class ActionInfoExtension
    {
        /// <summary>
        /// Retrieve the action name linked to the current action.
        /// </summary>
        /// <param name="action">An ActionInfo object.</param>
        /// <returns>An action name.</returns>
        public static string GetAction(this ActionInfo action)
        {
            if (!action.IsValid())
            {
                return null;
            }

            if (action.Type.IsValid()
                && action.Api.IsValid()
                && action.Type.IsDataAction())
            {
                return action.Api.Split('.')[1];
            }

            return null;
        }

        /// <summary>
        /// Retrieve the service linked to the current action.
        /// </summary>
        /// <param name="action">An ActionInfo object.</param>
        /// <returns>A service name.</returns>
        public static string GetService(this ActionInfo action)
        {
            if (!action.IsValid())
            {
                return null;
            }

            if (action.Type.IsValid()
                && action.Api.IsValid()
                && action.Type.IsDataAction())
            {
                return action.Api.Split('.')[0];
            }

            return null;
        }

        /// <summary>
        /// Retrieve the targeted concern in the case of a navigation action.
        /// </summary>
        /// <param name="action">An ActonInfo object.</param>
        /// <returns>A concern id.</returns>
        public static string GetTargetedConcern(this ActionInfo action)
        {
            if (!action.IsValid())
            {
                return null;
            }

            if (action.Target.IsValid())
            {
                return action.Target.Split('.')[0];
            }

            return null;
        }

        /// <summary>
        /// Retrieve the targeted layout in the case of a navigation action.
        /// </summary>
        /// <param name="action">An ActonInfo object.</param>
        /// <returns>A layout id.</returns>
        public static string GetTargetedLayout(this ActionInfo action)
        {
            if (!action.IsValid())
            {
                return null;
            }

            if (action.Target.IsValid())
            {
                return action.Target.Split('.')[1];
            }

            return null;
        }

        /// <summary>
        /// Retrieve ViewModels from a layout action.
        /// </summary>
        /// <param name="action">An ActionInfo object.</param>
        /// <param name="apis">An ApiList object.</param>
        /// <returns>A list of ViewModels id.</returns>
        public static List<string> GetActionViewModelsId(
            this ActionInfo action,
            ApiList apis)
        {
            var viewModels = new List<string>();

            if (!action.IsValid()
                || !apis.IsValid())
            {
                return viewModels;
            }

            var apiAction = action.GetAction();

            if (apiAction.IsValid())
            {
                viewModels = viewModels
                    .Union(apis.GetApiListViewModelsId(apiAction))
                    .ToList();
            }

            return viewModels;
        }

        /// <summary>
        /// Retrieve service id from a layout action.
        /// </summary>
        /// <param name="action">An ActionInfo object.</param>
        /// <param name="apis">An ApiList object.</param>
        /// <returns>A service id.</returns>
        public static string GetActionService(
            this ActionInfo action,
            ApiList apis)
        {
            if (!action.IsValid()
                || !apis.IsValid())
            {
                return null;
            }

            var apiService = action.GetService();

            if (apiService.IsValid())
            {
                return apis.GetApiListService(apiService);
            }

            return null;
        }

        /// <summary>
        /// Retrieve ViewModels from a layout action.
        /// </summary>
        /// <param name="action">An ActionInfo object.</param>
        /// <returns>A list of EntityInfo.</returns>
        public static List<EntityInfo> GetActionViewModelsEntities(
            this ActionInfo action,
            ApiList apis)
        {
            var viewModels = new List<EntityInfo>();

            if (!action.IsValid()
                || !apis.IsValid())
            {
                return viewModels;
            }

            var apiAction = action.GetAction();
            var entityComparer = new EntityInfoComparer();

            if (apiAction.IsValid())
            {
                viewModels = viewModels
                    .Union(
                        apis.GetApiListViewModelsEntities(apiAction),
                        entityComparer)
                    .ToList();
            }

            return viewModels;
        }

        public static bool IsValid(this ActionInfo action)
        {
            if (action == null
                || !action.Id.IsValid())
            {
                return false;
            }

            return true;
        }
    }
}
