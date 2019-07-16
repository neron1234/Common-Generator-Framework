using Mobioos.Foundation.Jade.Models;
using System.Collections.Generic;
using System.Linq;

namespace Common.Generator.Framework.Comparer
{
    public class ReferenceInfoComparer : 
        PropertyInfoComparer,
        IEqualityComparer<ReferenceInfo>
    {
        public bool Equals(
            ReferenceInfo x,
            ReferenceInfo y)
        {
            bool result = base.Equals(x, y);

            var entityComparer = new EntityInfoComparer();
            var propertyComparer = new PropertyInfoComparer();

            if (x.ForeignKey != y.ForeignKey
                || !propertyComparer.Equals(
                    x.Property,
                    y.Property)
                || !entityComparer.Equals(
                    x.Reference,
                    y.Reference))
            {
                return false;
            }

            return result;
        }

        public int GetHashCode(ReferenceInfo obj)
        => base.GetHashCode(obj);
    }

    public class ReferenceInfoListComparer : IEqualityComparer<IEnumerable<ReferenceInfo>>
    {
        public bool Equals(
            IEnumerable<ReferenceInfo> x,
            IEnumerable<ReferenceInfo> y)
        {
            if (ReferenceEquals(x, y))
            {
                return true;
            }

            if (x == null
                || y == null)
            {
                return false;
            }

            var comparer = new ReferenceInfoComparer();

            foreach (var reference in x)
            {
                if (!y.Any(item =>
                    comparer.Equals(
                        item,
                        reference)))
                {
                    return false;
                }
            }

            return true;
        }

        public int GetHashCode(IEnumerable<ReferenceInfo> obj)
        => obj
            .ToString()
            .GetHashCode();
    }
}
