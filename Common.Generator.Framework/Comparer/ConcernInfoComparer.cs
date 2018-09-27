using Mobioos.Foundation.Jade.Models;
using System.Collections.Generic;

namespace Common.Generator.Framework.Comparer
{
    public class ConcernInfoComparer : IEqualityComparer<ConcernInfo>
    {
        public bool Equals(ConcernInfo x, ConcernInfo y)
        {
            if (ReferenceEquals(x, y))
                return true;

            if (x == null || y == null)
                return false;

            LayoutListComparer layoutListComparer = new LayoutListComparer();

            if (x.Id != y.Id
                || x.Title != y.Title
                || x.Description != y.Description
                || x.IsRequired != y.IsRequired
                || x.Mandatory != y.Mandatory
                || !layoutListComparer.Equals(x.Layouts, y.Layouts))
                return false;

            return true;
        }

        public int GetHashCode(ConcernInfo obj)
        {
            return string.Concat(obj.Id, obj.Parent.Id).GetHashCode();
        }
    }
}
