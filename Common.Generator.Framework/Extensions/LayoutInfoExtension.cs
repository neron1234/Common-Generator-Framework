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
            List<string> viewModels = new List<string>();

            if (apis == null
                || layout == null
                || layout.Id == null
                || layout.Id.Equals(""))
                return viewModels;

            if (layout.Actions.AsEnumerable() != null)
                viewModels = viewModels.AsEnumerable()
                                       .Union(layout.Actions.GetActionsViewModelsId(apis).AsEnumerable())
                                       .ToList();

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
            List<EntityInfo> viewModels = new List<EntityInfo>();

            if (apis == null
                || layout == null
                || layout.Id == null
                || layout.Id.Equals(""))
                return viewModels;

            if (layout.Actions.AsEnumerable() != null)
                viewModels = viewModels.AsEnumerable()
                                       .Union(layout.Actions.GetActionsViewModelsEntities(apis).AsEnumerable())
                                       .ToList();

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
            List<string> services = new List<string>();

            if (layout == null
                || layout.Id != null
                || layout.Id.Equals("")
                || apis == null)
                return services;

            if (layout.Actions.AsEnumerable() != null)
                services = services.AsEnumerable()
                                   .Union(layout.Actions.GetActionListServices(apis).AsEnumerable())
                                   .ToList();

            return services;
        }

        /// <summary>
        /// Retrieve all direct references from layout datamodel.
        /// </summary>
        /// <param name="layout">A LayoutInfo object.</param>
        /// <returns>A list of EntityInfo.</returns>
        public static List<EntityInfo> GetLayoutDirectReferences(this LayoutInfo layout)
        {
            List<EntityInfo> directReferences = new List<EntityInfo>();

            if (layout == null
                || layout.Id == null
                || layout.Id.Equals(""))
                return directReferences;

            if (layout.DataModel != null
                && layout.DataModel.Id != null
                && !layout.DataModel.Id.Equals("")
                && layout.DataModel.References.AsEnumerable() != null)
                directReferences = directReferences.AsEnumerable()
                                                   .Union(layout.DataModel.GetEntityDirectReferences().AsEnumerable())
                                                   .ToList();

            return directReferences;
        }
    }
}
