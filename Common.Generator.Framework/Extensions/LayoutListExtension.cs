using Mobioos.Foundation.Jade.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Common.Generator.Framework.Extensions
{
    public static class LayoutListExtension
    {
        /// <summary>
        /// Retrieve all direct references from a list of layouts.
        /// </summary>
        /// <param name="layouts">A LayoutList object.</param>
        /// <returns>A list of EntityInfo.</returns>
        public static List<EntityInfo> GetLayoutListDirectReferences(this LayoutList layouts)
        {
            if (layouts.AsEnumerable() == null)
                throw new ArgumentNullException();

            List<EntityInfo> directReferences = new List<EntityInfo>();

            foreach (LayoutInfo layout in layouts)
                directReferences.Union(layout.GetLayoutDirectReferences());

            return directReferences;
        }
    }
}
