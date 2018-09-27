using Mobioos.Foundation.Jade.Models;
using System.Collections.Generic;
using System.Linq;

namespace Common.Generator.Framework.Comparer
{
    public class ValueInfoComparer : IEqualityComparer<ValueInfo>
    {
        public bool Equals(ValueInfo x, ValueInfo y)
        {
            if (ReferenceEquals(x, y))
                return true;

            if (x == null || y == null)
                return false;

            if (x.Id != y.Id)
                return false;

            return true;
        }

        public int GetHashCode(ValueInfo obj)
        {
            return obj.Id.GetHashCode();
        }
    }

    public class ValueInfoListComparer : IEqualityComparer<IEnumerable<ValueInfo>>
    {
        public bool Equals(IEnumerable<ValueInfo> x, IEnumerable<ValueInfo> y)
        {
            if (ReferenceEquals(x, y))
                return true;

            if (x == null || y == null)
                return false;

            ValueInfoComparer comparer = new ValueInfoComparer();

            foreach (ValueInfo value in x.AsEnumerable())
                if (!y.AsEnumerable()
                      .Any(item => comparer.Equals(item, value)))
                    return false;

            return true;
        }

        public int GetHashCode(IEnumerable<ValueInfo> obj)
        {
            return obj.ToString().GetHashCode();
        }
    }
}
