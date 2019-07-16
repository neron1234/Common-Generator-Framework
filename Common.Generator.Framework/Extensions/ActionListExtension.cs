using Common.Generator.Framework.Comparer;
using Mobioos.Foundation.Jade.Models;
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
        public static List<string> GetActionsViewModelsId(
            this ActionList layoutActions,
            ApiList apis)
        {
            var viewModels = new List<string>();

            if (!layoutActions.IsValid()
                || !apis.IsValid())
            {
                return viewModels;
            }

            foreach (var action in layoutActions)
            {
                if (action.IsValid())
                {
                    viewModels = viewModels
                        .Union(action.GetActionViewModelsId(apis))
                        .ToList();
                }
            }

            return viewModels;
        }

        /// <summary>
        /// Retrieve viewModels from actions.
        /// </summary>
        /// <param name="layoutActions">A list of layout actions.</param>
        /// <param name="apis">A list of api.</param>
        /// <returns>A list of EntityInfo.</returns>
        public static List<EntityInfo> GetActionsViewModelsEntities(
            this ActionList layoutActions,
            ApiList apis)
        {
            var viewModels = new List<EntityInfo>();

            if (!layoutActions.IsValid()
                || !apis.IsValid())
            {
                return viewModels;
            }

            var entityComparer = new EntityInfoComparer();

            if (layoutActions != null)
            {
                foreach (var action in layoutActions)
                {
                    if (action.IsValid())
                    {
                        viewModels = viewModels
                            .Union(
                                action.GetActionViewModelsEntities(apis),
                                entityComparer)
                            .ToList();
                    }
                }
            }

            return viewModels;
        }

        /// <summary>
        /// Retrieve services id from actions.
        /// </summary>
        /// <param name="layoutActions">An ActionList object.</param>
        /// <param name="apis">An ApiList object.</param>
        /// <returns>A list of services id.</returns>
        public static List<string> GetActionListServices(
            this ActionList layoutActions,
            ApiList apis)
        {
            var services = new List<string>();

            if (!layoutActions.IsValid()
                || !apis.IsValid())
            {
                return services;
            }

            foreach (var action in layoutActions)
            {
                if (action.IsValid())
                {
                    var service = action.GetActionService(apis);

                    if (service.IsValid()
                        && !services.Any(item => item == service))
                    {
                        services.Add(service);
                    }
                }
            }

            return services;
        }

        public static bool IsValid(this ActionList layoutActions)
        {
            if (!layoutActions.IsValid<ActionInfo>())
            {
                return false;
            }

            return true;
        }
    }
}
