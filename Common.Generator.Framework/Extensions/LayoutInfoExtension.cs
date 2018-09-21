using Mobioos.Foundation.Jade.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Common.Generator.Framework.Extensions
{
    public static class LayoutInfoExtension
    {
        /// <summary>
        /// Retrieve viewModels from layout actions.
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
        /// Retrieve viewModels from layout actions.
        /// </summary>
        /// <param name="layout">A LayoutInfo object.</param>
        /// <param name="apis">An ApiList object.</param>
        /// <returns>A list of EntityInfo.</returns>
        public static List<EntityInfo> GetViewModelsId(this LayoutInfo layout, ApiList apis)
        {
            if (apis == null || layout == null)
                throw new ArgumentNullException();

            List<EntityInfo> viewModels = new List<EntityInfo>();

            if (layout.Actions.AsEnumerable() != null)
                viewModels.Union(layout.Actions.GetActionsViewModelsEntities(apis));

            return viewModels;
        }
    }
}
