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
            if (action == null)
                throw new ArgumentNullException();

            char delimiter = '.';

            if (action.Type != null
                && action.Api != null
                && action.Type.IsDataAction())
                return action.Api.Split(delimiter)[1];
            return null;
        }

        /// <summary>
        /// Retrieve the service linked to the current action.
        /// </summary>
        /// <param name="action">An ActionInfo object.</param>
        /// <returns>A service name.</returns>
        public static string GetService(this ActionInfo action)
        {
            if (action == null)
                throw new ArgumentNullException();

            char delimiter = '.';

            if (action.Type != null
                && action.Api != null
                && action.Type.IsDataAction())
                return action.Api.Split(delimiter)[0];
            return null;
        }

        /// <summary>
        /// Retrieve ViewModels from a layout action.
        /// </summary>
        /// <param name="action">An ActionInfo object.</param>
        /// <param name="apis">An ApiList object.</param>
        /// <returns>A list of ViewModels id.</returns>
        public static List<string> GetActionViewModelsId(this ActionInfo action, ApiList apis)
        {
            if (action == null || apis == null)
                throw new ArgumentNullException();

            List<string> viewModels = new List<string>();
            string apiAction = action.GetAction();

            if (apiAction != null)
                viewModels.Union(apis.GetApiListViewModelsId(apiAction));

            return viewModels;
        }

        /// <summary>
        /// Retrieve ViewModels from a layout action.
        /// </summary>
        /// <param name="action">An ActionInfo object.</param>
        /// <returns>A list of EntityInfo.</returns>
        public static List<EntityInfo> GetActionViewModelsEntities(this ActionInfo action, ApiList apis)
        {
            if (action == null || apis == null)
                throw new ArgumentNullException();

            List<EntityInfo> viewModels = new List<EntityInfo>();
            string apiAction = action.GetAction();

            if (apiAction != null)
                viewModels.Union(apis.GetApiListViewModelsEntities(apiAction));

            return viewModels;
        }
    }
}
