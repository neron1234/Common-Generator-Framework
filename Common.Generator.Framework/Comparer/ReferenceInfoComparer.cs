using Mobioos.Foundation.Jade.Models;
using System.Collections.Generic;
using System.Linq;

namespace Common.Generator.Framework.Comparer
{
    public class ReferenceInfoComparer : PropertyInfoComparer, IEqualityComparer<ReferenceInfo>
    {
        public bool Equals(ReferenceInfo x, ReferenceInfo y)
        {
            bool result = base.Equals(x, y);

            EntityInfoComparer entityComparer = new EntityInfoComparer();
            PropertyInfoComparer propertyComparer = new PropertyInfoComparer();

            if (x.ForeignKey != y.ForeignKey
                || !propertyComparer.Equals(x.Property, y.Property)
                || !entityComparer.Equals(x.Reference, y.Reference))
                return false;

            return result;
        }

        public int GetHashCode(ReferenceInfo obj)
        {
            return base.GetHashCode(obj);
        }
    }

    public class ReferenceInfoListComparer : IEqualityComparer<IEnumerable<ReferenceInfo>>
    {
        public bool Equals(IEnumerable<ReferenceInfo> x, IEnumerable<ReferenceInfo> y)
        {
            if (ReferenceEquals(x, y))
                return true;

            if (x == null || y == null)
                return false;

            ReferenceInfoComparer comparer = new ReferenceInfoComparer();

            foreach (ReferenceInfo reference in x.AsEnumerable())
                if (!y.AsEnumerable()
                      .Any(item => comparer.Equals(item, reference)))
                    return false;

            return true;
        }

        public int GetHashCode(IEnumerable<ReferenceInfo> obj)
        {
            return obj.ToString().GetHashCode();
        }
    }
}
