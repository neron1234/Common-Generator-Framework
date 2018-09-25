using Mobioos.Foundation.Jade.Models;
using System;
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
            if (concerns.AsEnumerable() == null)
                throw new ArgumentNullException();

            foreach (ConcernInfo concern in concerns.AsEnumerable())
                if (concern.GetMenu().AsEnumerable().Count() > 0)
                    return true;

            return false;
        }

        /// <summary>
        /// Retrieve all direct references from concerns.
        /// </summary>
        /// <param name="concerns">A ConcernList object.</param>
        /// <returns>A list of EntityInfo.</returns>
        public static List<EntityInfo> GetConcernListDirectReferences(this ConcernList concerns)
        {
            if (concerns == null)
                throw new ArgumentNullException();

            List<EntityInfo> directReferences = new List<EntityInfo>();

            foreach (ConcernInfo concern in concerns.AsEnumerable())
                directReferences = directReferences.AsEnumerable()
                                                   .Union(concern.GetConcernDirectReferences().AsEnumerable())
                                                   .ToList();

            return directReferences;
        }

        /// <summary>
        /// Retrieve layouts from concerns.
        /// </summary>
        /// <param name="concerns">A ConcernList object.</param>
        /// <returns>A LayoutList.</returns>
        public static LayoutList GetLayouts(this ConcernList concerns)
        {
            if (concerns == null)
                throw new ArgumentNullException();

            LayoutList layouts = new LayoutList();

            foreach (ConcernInfo concern in concerns)
                layouts = layouts.AsEnumerable()
                                 .Union(concern.Layouts.AsEnumerable())
                                 .ToLayoutList();

            return layouts;
        }
    }
}
