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
            var directReferences = new List<EntityInfo>();

            if (!layouts.IsValid())
            {
                return directReferences;
            }

            var entityComparer = new EntityInfoComparer();

            foreach (var layout in layouts)
            {
                if (layout.IsValid())
                {
                    directReferences = directReferences
                        .Union(
                            layout.GetLayoutDirectReferences(),
                            entityComparer)
                        .ToList();
                }
            }

            return directReferences;
        }

        /// <summary>
        /// Convert an IEnumerable to a LayoutList
        /// </summary>
        /// <param name="layouts">A list of LayoutInfo objects.</param>
        /// <param name="parent">A ConcernInfo object.</param>
        /// <returns>A LayoutList</returns>
        public static LayoutList ToLayoutList(
            this IEnumerable<LayoutInfo> layouts,
            ConcernInfo parent)
        {
            var result = new LayoutList();

            if (parent.IsValid())
            {
                foreach (var layout in layouts)
                {
                    if (layout.IsValid())
                    {
                        result.Add(layout);
                        result.Last().Parent = parent;
                    }
                }
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

            foreach (var layout in layouts)
            {
                if (layout.IsValid())
                {
                    var parent = layout.Parent;
                    result.Add(layout);
                    result.Last().Parent = parent;
                }
            }

            return result;
        }

        public static bool IsValid(this LayoutList layouts)
        {
            if (!layouts.IsValid<LayoutInfo>())
            {
                return false;
            }

            return true;
        }
    }
}
