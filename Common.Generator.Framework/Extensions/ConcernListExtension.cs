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
            bool result = false;

            if (concerns.AsEnumerable() == null)
                return result;

            foreach (ConcernInfo concern in concerns.AsEnumerable())
                if (concern.Id != null
                    && !concern.Id.Equals("")
                    && concern.GetMenu().AsEnumerable()
                                        .Count() > 0)
                    return true;

            return result;
        }

        /// <summary>
        /// Retrieve all direct references from concerns.
        /// </summary>
        /// <param name="concerns">A ConcernList object.</param>
        /// <returns>A list of EntityInfo.</returns>
        public static List<EntityInfo> GetConcernListDirectReferences(this ConcernList concerns)
        {
            List<EntityInfo> directReferences = new List<EntityInfo>();

            if (concerns == null)
                return directReferences;

            foreach (ConcernInfo concern in concerns.AsEnumerable())
                if (concern.Id != null
                    && !concern.Id.Equals(""))
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
            LayoutList layouts = new LayoutList();

            if (concerns == null)
                return layouts;

            foreach (ConcernInfo concern in concerns)
                if (concern.Id != null
                    && !concern.Id.Equals("")
                    && concern.Layouts != null
                    && concern.Parent != null
                    && concern.Layouts.Parent != null
                    && concern.Layouts.Parent.Id != null
                    && !concern.Layouts.Parent.Id.Equals(""))
                    layouts = layouts.AsEnumerable()
                                     .Union(concern.Layouts.AsEnumerable())
                                     .ToLayoutList((ConcernInfo)concern.Layouts.Parent);

            return layouts;
        }
    }
}
