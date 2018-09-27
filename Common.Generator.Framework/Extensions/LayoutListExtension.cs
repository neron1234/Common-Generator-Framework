using Common.Generator.Framework.Comparer;
using Mobioos.Foundation.Jade.Models;
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
            List<EntityInfo> directReferences = new List<EntityInfo>();

            if (layouts.AsEnumerable() == null)
                return directReferences;

            EntityInfoComparer entityComparer = new EntityInfoComparer();

            foreach (LayoutInfo layout in layouts)
                if (layout.Id != null
                    && !layout.Id.Equals(""))
                    directReferences = directReferences.AsEnumerable()
                                                       .Union(layout.GetLayoutDirectReferences().AsEnumerable(), entityComparer)
                                                       .ToList();

            return directReferences;
        }

        /// <summary>
        /// Convert an IEnumerable to a LayoutList
        /// </summary>
        /// <param name="layouts">A list of LayoutInfo objects.</param>
        /// <param name="parent">A ConcernInfo object.</param>
        /// <returns>A LayoutList</returns>
        public static LayoutList ToLayoutList(this IEnumerable<LayoutInfo> layouts, ConcernInfo parent)
        {
            LayoutList result = new LayoutList();

            if (parent != null
                && !parent.Id.Equals(""))
                foreach (LayoutInfo layout in layouts)
                    if (layout.Id != null
                        && !layout.Id.Equals(""))
                    {
                        result.Add(layout);
                        result.Last().Parent = parent;
                    }

            return result;
        }

        /// <summary>
        /// Convert an IEnumerable to a LayoutList
        /// </summary>
        /// <param name="layouts">A list of LayoutInfo objects.</param>
        /// <returns>A LayoutList</returns>
        public static LayoutList ToLayoutList(this IEnumerable<LayoutInfo> layouts)
        {
            LayoutList result = new LayoutList();
            foreach (LayoutInfo layout in layouts)
                if (layout.Id != null
                    && !layout.Id.Equals(""))
                {
                    var parent = layout.Parent;
                    result.Add(layout);
                    result.Last().Parent = parent;
                }

            return result;
        }
    }
}
