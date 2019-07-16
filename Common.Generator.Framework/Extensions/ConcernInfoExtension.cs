using Common.Generator.Framework.Comparer;
using Mobioos.Foundation.Jade.Models;
using System.Collections.Generic;
using System.Linq;

namespace Common.Generator.Framework.Extensions
{
    public static class ConcernInfoExtension
    {
        /// <summary>
        /// Retrieve the specific menu for a concern.
        /// </summary>
        /// <param name="concern">A concern.</param>
        /// <returns>A dictionary of the menu.</returns>
        public static Dictionary<string, string> GetMenu(this ConcernInfo concern)
        {
            var menu = new Dictionary<string, string>();

            if (!concern.IsValid())
            {
                return menu;
            }

            if (concern.Layouts.IsValid())
            {
                foreach (var layout in concern.Layouts)
                {
                    if (layout.IsValid()
                        && layout.Title.IsValid()
                        && layout.IsVisibleInMenu
                        && !menu.Any(item =>
                            item.Key == $"{concern.Id.ToCamelCase()}-{layout.Id.ToCamelCase()}"))
                    {
                        menu.Add(
                            $"{concern.Id.ToCamelCase()}-{layout.Id.ToCamelCase()}",
                            layout.Title);
                    }
                }
            }

            return menu;
        }

        /// <summary>
        /// Retrieve all direct references from a concern.
        /// </summary>
        /// <param name="concern">A ConcernInfo object.</param>
        /// <returns>A list of EntityInfo.</returns>
        public static List<EntityInfo> GetConcernDirectReferences(this ConcernInfo concern)
        {
            var directReferences = new List<EntityInfo>();

            if (!concern.IsValid())
            {
                return directReferences;
            }

            var entityComparer = new EntityInfoComparer();

            if (concern.Layouts.IsValid())
            {
                directReferences = directReferences
                    .Union(
                        concern.Layouts.GetLayoutListDirectReferences(),
                        entityComparer)
                    .ToList();
            }

            return directReferences;
        }

        public static bool IsValid(this ConcernInfo concern)
        {
            if (concern == null
                || !concern.Id.IsValid())
            {
                return false;
            }

            return true;
        }
    }
}
