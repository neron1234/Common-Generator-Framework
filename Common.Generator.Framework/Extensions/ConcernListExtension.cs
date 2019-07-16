using Common.Generator.Framework.Comparer;
using Mobioos.Foundation.Jade.Models;
using System.Collections.Generic;
using System.Linq;

namespace Common.Generator.Framework.Extensions
{
    public static class ConcernListExtension
    {
        /// <summary>
        /// Check if there is at least one menu in the list of concerns.
        /// </summary>
        /// <param name="concerns">A ConcernList object.</param>
        /// <returns>A boolean.</returns>
        public static bool HasMenu(this ConcernList concerns)
        {
            if (!concerns.IsValid())
            {
                return false;
            }

            foreach (var concern in concerns)
            {
                if (concern.IsValid()
                    && concern
                        .GetMenu()
                        .Count() > 0)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Retrieve all direct references from concerns.
        /// </summary>
        /// <param name="concerns">A ConcernList object.</param>
        /// <returns>A list of EntityInfo.</returns>
        public static List<EntityInfo> GetConcernListDirectReferences(this ConcernList concerns)
        {
            var directReferences = new List<EntityInfo>();

            if (!concerns.IsValid())
            {
                return directReferences;
            }

            var entityComparer = new EntityInfoComparer();

            foreach (var concern in concerns)
            {
                if (concern.IsValid())
                {
                    directReferences = directReferences
                        .Union(
                            concern.GetConcernDirectReferences(),
                            entityComparer)
                        .ToList();
                }
            }

            return directReferences;
        }

        /// <summary>
        /// Retrieve layouts from concerns.
        /// </summary>
        /// <param name="concerns">A ConcernList object.</param>
        /// <returns>A LayoutList.</returns>
        public static LayoutList GetLayouts(this ConcernList concerns)
        {
            var layouts = new LayoutList();

            if (!concerns.IsValid())
            {
                return layouts;
            }

            var layoutComparer = new LayoutInfoComparer();

            foreach (var concern in concerns)
            {
                if (concern.IsValid()
                    && concern.Layouts.IsValid())
                {
                    layouts = layouts
                        .Union(
                            concern.Layouts.ToLayoutList(concern),
                            layoutComparer)
                        .ToLayoutList();
                }
            }

            return layouts;
        }

        public static bool IsValid(this ConcernList concerns)
        {
            if (!concerns.IsValid<ConcernInfo>())
            {
                return false;
            }

            return true;
        }
    }
}
