using Mobioos.Foundation.Jade.Models;
using System.Collections.Generic;
using System.Linq;

namespace Common.Generator.Framework.Comparer
{
    public class PropertyInfoComparer : IEqualityComparer<PropertyInfo>
    {
        public bool Equals(PropertyInfo x, PropertyInfo y)
        {
            if (ReferenceEquals(x, y))
                return true;

            if (x == null || y == null)
                return false;

            EntityInfoComparer entityComparer = new EntityInfoComparer();

            if (x.Id != y.Id
                || x.IsCollection != y.IsCollection
                || x.IsKey != y.IsKey
                || x.IsRequired != y.IsRequired
                || x.Minimum != y.Minimum
                || x.Maximum != y.Maximum
                || !entityComparer.Equals(x.Target, y.Target)
                || x.ModelProperty != y.ModelProperty)
                return false;

            return true;
        }

        public int GetHashCode(PropertyInfo obj)
        {
            return obj.Id.GetHashCode();
        }
    }

    public class PropertyInfoListComparer : IEqualityComparer<IEnumerable<PropertyInfo>>
    {
        public bool Equals(IEnumerable<PropertyInfo> x, IEnumerable<PropertyInfo> y)
        {
            if (ReferenceEquals(x, y))
                return true;

            if (x == null || y == null)
                return false;

            PropertyInfoComparer comparer = new PropertyInfoComparer();

            foreach (PropertyInfo prop in x.AsEnumerable())
                if (!y.AsEnumerable()
                      .Any(item => comparer.Equals(item, prop)))
                    return false;

            return true;
        }

        public int GetHashCode(IEnumerable<PropertyInfo> obj)
        {
            return obj.ToString().GetHashCode();
        }
    }
}
