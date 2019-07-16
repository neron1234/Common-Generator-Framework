using Common.Generator.Framework.Comparer;
using Mobioos.Foundation.Jade.Models;
using System.Collections.Generic;
using System.Linq;

namespace Common.Generator.Framework.Extensions
{
    public static class LayoutInfoExtension
    {
        /// <summary>
        /// Retrieve ViewModels from layout actions.
        /// </summary>
        /// <param name="layout">A LayoutInfo object.</param>
        /// <param name="apis">An ApiList object.</param>
        /// <returns>A list of ViewModels id.</returns>
        public static List<string> GetLayoutViewModelsId(
            this LayoutInfo layout,
            ApiList apis)
        {
            var viewModels = new List<string>();

            if (!apis.IsValid()
                || !layout.IsValid())
            {
                return viewModels;
            }

            if (layout.Actions.IsValid())
            {
                viewModels = viewModels
                    .Union(layout.Actions.GetActionsViewModelsId(apis))
                    .ToList();
            }

            return viewModels;
        }

        /// <summary>
        /// Retrieve ViewModels from layout actions.
        /// </summary>
        /// <param name="layout">A LayoutInfo object.</param>
        /// <param name="apis">An ApiList object.</param>
        /// <returns>A list of EntityInfo.</returns>
        public static List<EntityInfo> GetLayoutViewModelsEntities(
            this LayoutInfo layout,
            ApiList apis)
        {
            var viewModels = new List<EntityInfo>();

            if (!apis.IsValid()
                || !layout.IsValid())
            {
                return viewModels;
            }

            var entityComparer = new EntityInfoComparer();

            if (layout.Actions.IsValid())
            {
                viewModels = viewModels
                    .Union(
                        layout.Actions.GetActionsViewModelsEntities(apis),
                        entityComparer)
                    .ToList();
            }

            return viewModels;
        }

        /// <summary>
        /// Retrieve services id from layout actions.
        /// </summary>
        /// <param name="layout">A LayoutInfo object.</param>
        /// <param name="apis">An ApiList object.</param>
        /// <returns>A list of services id.</returns>
        public static List<string> GetLayoutServices(
            this LayoutInfo layout,
            ApiList apis)
        {
            var services = new List<string>();

            if (!apis.IsValid()
                || !layout.IsValid())
            {
                return services;
            }

            if (layout.Actions.IsValid())
            {
                services = services
                    .Union(layout.Actions.GetActionListServices(apis))
                    .ToList();
            }

            return services;
        }

        /// <summary>
        /// Retrieve all direct references from layout datamodel.
        /// </summary>
        /// <param name="layout">A LayoutInfo object.</param>
        /// <returns>A list of EntityInfo.</returns>
        public static List<EntityInfo> GetLayoutDirectReferences(this LayoutInfo layout)
        {
            var directReferences = new List<EntityInfo>();

            if (!layout.IsValid())
            {
                return directReferences;
            }

            var entityComparer = new EntityInfoComparer();

            if (layout.DataModel.IsValid()
                && layout.DataModel.References != null)
            {
                directReferences = directReferences
                    .Union(
                        layout.DataModel.GetEntityDirectReferences(),
                        entityComparer)
                    .ToList();
            }

            return directReferences;
        }

        public static bool IsValid(this LayoutInfo layout)
        {
            if (layout == null
                || !layout.Id.IsValid())
            {
                return false;
            }

            return true;
        }
    }
}
