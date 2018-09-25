using Mobioos.Foundation.Jade.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Common.Generator.Framework.Extensions
{
    public static class ActionListExtension
    {
        /// <summary>
        /// Retrieve viewModels from actions.
        /// </summary>
        /// <param name="layoutActions">A list of layout actions.</param>
        /// <param name="apis">A list of api.</param>
        /// <returns>A list of ViewModels id.</returns>
        public static List<string> GetActionsViewModelsId(this ActionList layoutActions, ApiList apis)
        {
            if (layoutActions.AsEnumerable() == null || apis == null)
                throw new ArgumentNullException();

            List<string> viewModels = new List<string>();

            if (layoutActions.AsEnumerable() != null)
                foreach (ActionInfo action in layoutActions.AsEnumerable())
                    viewModels = viewModels.AsEnumerable()
                                           .Union(action.GetActionViewModelsId(apis).AsEnumerable())
                                           .ToList();

            return viewModels;
        }

        /// <summary>
        /// Retrieve viewModels from actions.
        /// </summary>
        /// <param name="layoutActions">A list of layout actions.</param>
        /// <param name="apis">A list of api.</param>
        /// <returns>A list of EntityInfo.</returns>
        public static List<EntityInfo> GetActionsViewModelsEntities(this ActionList layoutActions, ApiList apis)
        {
            if (layoutActions.AsEnumerable() == null || apis == null)
                throw new ArgumentNullException();

            List<EntityInfo> viewModels = new List<EntityInfo>();

            if (layoutActions.AsEnumerable() != null)
                foreach (ActionInfo action in layoutActions.AsEnumerable())
                    viewModels = viewModels.AsEnumerable()
                                           .Union(action.GetActionViewModelsEntities(apis).AsEnumerable())
                                           .ToList();

            return viewModels;
        }

        /// <summary>
        /// Retrieve services id from actions.
        /// </summary>
        /// <param name="layoutActions">An ActionList object.</param>
        /// <param name="apis">An ApiList object.</param>
        /// <returns>A list of services id.</returns>
        public static List<string> GetActionListServices(this ActionList layoutActions, ApiList apis)
        {
            if (layoutActions.AsEnumerable() == null)
                throw new ArgumentNullException();

            List<string> services = new List<string>();

            foreach (ActionInfo action in layoutActions.AsEnumerable())
            {
                string service = action.GetActionService(apis);
                if (!services.Contains(service))
                    services.Add(service);
            }

            return services;
        }
    }
}
