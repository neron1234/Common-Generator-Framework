using Mobioos.Foundation.Jade.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Common.Generator.Framework.Extensions
{
    public static class ConcernListExtension
    {
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
                directReferences.Union(concern.GetConcernDirectReferences());

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
                layouts.Union(concern.Layouts);

            return layouts;
        }
    }
}
