using Mobioos.Foundation.Jade.Models;
using System;
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
            Dictionary<string, string> menu = new Dictionary<string, string>();

            if (concern == null
                || concern.Id == null
                || concern.Id.Equals(""))
                return menu;

            if (concern.Layouts.AsEnumerable() != null)
                foreach (LayoutInfo layout in concern.Layouts.AsEnumerable())
                    if (layout.Id != null
                        && !layout.Id.Equals("")
                        && layout.Title != null
                        && !layout.Title.Equals("")
                        && layout.IsVisibleInMenu
                        && !concern.Id.ToCamelCase().Equals("")
                        && !layout.Id.ToCamelCase().Equals("")
                        && !menu.Any(item => item.Key == (concern.Id.ToCamelCase() + "-" + layout.Id.ToCamelCase())))
                        menu.Add(concern.Id.ToCamelCase() + "-" + layout.Id.ToCamelCase(), layout.Title);
            return menu;
        }

        /// <summary>
        /// Retrieve all direct references from a concern.
        /// </summary>
        /// <param name="concern">A ConcernInfo object.</param>
        /// <returns>A list of EntityInfo.</returns>
        public static List<EntityInfo> GetConcernDirectReferences(this ConcernInfo concern)
        {
            List<EntityInfo> directReferences = new List<EntityInfo>();

            if (concern == null
                || concern.Id == null
                || concern.Id.Equals(""))
                return directReferences;

            if (concern.Layouts.AsEnumerable() != null)
                directReferences = directReferences.AsEnumerable()
                                                   .Union(concern.Layouts.GetLayoutListDirectReferences().AsEnumerable())
                                                   .ToList();

            return directReferences;
        }
    }
}
