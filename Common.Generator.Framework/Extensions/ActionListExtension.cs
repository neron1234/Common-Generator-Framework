using Common.Generator.Framework.Comparer;
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
            List<string> viewModels = new List<string>();

            if (layoutActions.AsEnumerable() == null
                || apis == null)
                return viewModels;

            if (layoutActions.AsEnumerable() != null)
                foreach (ActionInfo action in layoutActions.AsEnumerable())
                    if (action.Id != null
                        && !action.Id.Equals(""))
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
            List<EntityInfo> viewModels = new List<EntityInfo>();

            if (layoutActions.AsEnumerable() == null
                || apis == null)
                return viewModels;

            EntityInfoComparer entityComparer = new EntityInfoComparer();

            if (layoutActions.AsEnumerable() != null)
                foreach (ActionInfo action in layoutActions.AsEnumerable())
                    if (action.Id != null
                        && !action.Id.Equals(""))
                        viewModels = viewModels.AsEnumerable()
                                               .Union(action.GetActionViewModelsEntities(apis).AsEnumerable(), entityComparer)
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
            List<string> services = new List<string>();

            if (layoutActions.AsEnumerable() == null
                || apis == null)
                return services;

            foreach (ActionInfo action in layoutActions.AsEnumerable())
                if (action.Id != null
                    && !action.Id.Equals(""))
                {
                    string service = action.GetActionService(apis);
                    if (service != null
                        && !service.Equals("")
                        && !services.Any(item => item == service))
                        services.Add(service);
                }

            return services;
        }
    }
}
