using Mobioos.Foundation.Jade.Models;
using System;
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
        public static List<string> GetLayoutViewModelsId(this LayoutInfo layout, ApiList apis)
        {
            if (apis == null || layout == null)
                throw new ArgumentNullException();

            List<string> viewModels = new List<string>();

            if (layout.Actions.AsEnumerable() != null)
                viewModels.Union(layout.Actions.GetActionsViewModelsId(apis));

            return viewModels;
        }

        /// <summary>
        /// Retrieve ViewModels from layout actions.
        /// </summary>
        /// <param name="layout">A LayoutInfo object.</param>
        /// <param name="apis">An ApiList object.</param>
        /// <returns>A list of EntityInfo.</returns>
        public static List<EntityInfo> GetLayoutViewModelsEntities(this LayoutInfo layout, ApiList apis)
        {
            if (apis == null || layout == null)
                throw new ArgumentNullException();

            List<EntityInfo> viewModels = new List<EntityInfo>();

            if (layout.Actions.AsEnumerable() != null)
                viewModels.Union(layout.Actions.GetActionsViewModelsEntities(apis));

            return viewModels;
        }

        /// <summary>
        /// Retrieve services id from layout actions.
        /// </summary>
        /// <param name="layout">A LayoutInfo object.</param>
        /// <param name="apis">An ApiList object.</param>
        /// <returns>A list of services id.</returns>
        public static List<string> GetLayoutServices(this LayoutInfo layout, ApiList apis)
        {
            if (layout == null || apis == null)
                throw new ArgumentNullException();

            List<string> services = new List<string>();

            if (layout.Actions.AsEnumerable() != null)
                services.Union(layout.Actions.GetActionListServices(apis));

            return services;
        }

        /// <summary>
        /// Retrieve all direct references from layout datamodel.
        /// </summary>
        /// <param name="layout">A LayoutInfo object.</param>
        /// <returns>A list of EntityInfo.</returns>
        public static List<EntityInfo> GetLayoutDirectReferences(this LayoutInfo layout)
        {
            if (layout == null)
                throw new ArgumentNullException();

            List<EntityInfo> directReferences = new List<EntityInfo>();

            if (layout.DataModel != null
                    && layout.DataModel.References.AsEnumerable() != null)
                directReferences.Union(layout.DataModel.GetEntityDirectReferences());

            return directReferences;
        }
    }
}
