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
            if (concern == null)
                throw new ArgumentNullException();

            Dictionary<string, string> menu = new Dictionary<string, string>();

            if (concern.Id != null
                && concern.Layouts.AsEnumerable() != null)
                foreach (LayoutInfo layout in concern.Layouts.AsEnumerable())
                    if (layout.IsVisibleInMenu
                        && layout.Id != null
                        && layout.Title != null
                        && !menu.ContainsKey(concern.Id.ToCamelCase() + "-" + layout.Id.ToCamelCase()))
                        menu.Add(concern.Id.ToCamelCase() + "-" + layout.Id.ToCamelCase(),layout.Title);
            return menu;
        }
    }
}
