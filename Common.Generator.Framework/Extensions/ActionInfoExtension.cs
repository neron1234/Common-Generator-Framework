using Mobioos.Foundation.Jade.Models;
using System;
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
            string result = "";

            if (action == null
                || action.Id == null
                || action.Id.Equals(""))
                return result;

            char delimiter = '.';

            if (action.Type != null
                && action.Api != null
                && action.Type.IsDataAction()
                && !action.Api.Equals(""))
                return action.Api.Split(delimiter)[1];
            return result;
        }

        /// <summary>
        /// Retrieve the service linked to the current action.
        /// </summary>
        /// <param name="action">An ActionInfo object.</param>
        /// <returns>A service name.</returns>
        public static string GetService(this ActionInfo action)
        {
            string result = "";

            if (action == null
                || action.Id == null
                || action.Id.Equals(""))
                return result;

            char delimiter = '.';

            if (action.Type != null
                && action.Api != null
                && action.Type.IsDataAction()
                && !action.Api.Equals(""))
                return action.Api.Split(delimiter)[0];
            return result;
        }

        /// <summary>
        /// Retrieve the targeted concern in the case of a navigation action.
        /// </summary>
        /// <param name="action">An ActonInfo object.</param>
        /// <returns>A concern id.</returns>
        public static string GetTargetedConcern(this ActionInfo action)
        {
            string result = "";

            if (action == null
                || action.Id == null
                || action.Id.Equals(""))
                return result;

            char delimiter = '.';

            if (action.Target != null
                && !action.Target.Equals(""))
                return action.Target.Split(delimiter)[0];

            return result;
        }

        /// <summary>
        /// Retrieve the targeted layout in the case of a navigation action.
        /// </summary>
        /// <param name="action">An ActonInfo object.</param>
        /// <returns>A layout id.</returns>
        public static string GetTargetedLayout(this ActionInfo action)
        {
            string result = "";

            if (action == null
                || action.Id == null
                || action.Id.Equals(""))
                return result;

            char delimiter = '.';

            if (action.Target != null
                && !action.Target.Equals(""))
                return action.Target.Split(delimiter)[1];

            return result;
        }

        /// <summary>
        /// Retrieve ViewModels from a layout action.
        /// </summary>
        /// <param name="action">An ActionInfo object.</param>
        /// <param name="apis">An ApiList object.</param>
        /// <returns>A list of ViewModels id.</returns>
        public static List<string> GetActionViewModelsId(this ActionInfo action, ApiList apis)
        {
            List<string> viewModels = new List<string>();

            if (action == null
                || action.Id == null
                || action.Id.Equals("")
                || apis.AsEnumerable() == null)
                return viewModels;

            string apiAction = action.GetAction();

            if (apiAction != null
                && !apiAction.Equals(""))
                viewModels = viewModels.AsEnumerable()
                                       .Union(apis.GetApiListViewModelsId(apiAction).AsEnumerable())
                                       .ToList();

            return viewModels;
        }

        /// <summary>
        /// Retrieve service id from a layout action.
        /// </summary>
        /// <param name="action">An ActionInfo object.</param>
        /// <param name="apis">An ApiList object.</param>
        /// <returns>A service id.</returns>
        public static string GetActionService(this ActionInfo action, ApiList apis)
        {
            string result = "";

            if (action == null
                || action.Id == null
                || action.Id.Equals("")
                || apis.AsEnumerable() == null)
                return result;

            string apiService = action.GetService();

            if (apiService != null
                && !apiService.Equals(""))
                result = apis.GetApiListService(apiService);

            return result;
        }

        /// <summary>
        /// Retrieve ViewModels from a layout action.
        /// </summary>
        /// <param name="action">An ActionInfo object.</param>
        /// <returns>A list of EntityInfo.</returns>
        public static List<EntityInfo> GetActionViewModelsEntities(this ActionInfo action, ApiList apis)
        {
            List<EntityInfo> viewModels = new List<EntityInfo>();

            if (action == null
                || action.Id == null
                || action.Id.Equals("")
                || apis.AsEnumerable() == null)
                return viewModels;

            string apiAction = action.GetAction();

            if (apiAction != null
                && !apiAction.Equals(""))
                viewModels = viewModels.AsEnumerable()
                                       .Union(apis.GetApiListViewModelsEntities(apiAction).AsEnumerable())
                                       .ToList();

            return viewModels;
        }
    }
}
