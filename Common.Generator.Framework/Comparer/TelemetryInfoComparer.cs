using Mobioos.Foundation.Jade.Models;
using System.Collections.Generic;

namespace Common.Generator.Framework.Comparer
{
    public class TelemetryInfoComparer : IEqualityComparer<TelemetryInfo>
    {
        public bool Equals(TelemetryInfo x, TelemetryInfo y)
        {
            if (ReferenceEquals(x, y))
                return true;

            if (x == null || y == null)
                return false;

            ActionInfoComparer actionComparer = new ActionInfoComparer();

            if (x.Id != y.Id
                || x.Title != y.Title
                || x.Type != y.Type)
                return false;

            return true;
        }

        public int GetHashCode(TelemetryInfo obj)
        {
            return string.Concat(obj.Id, obj.Parent.Id).GetHashCode();
        }
    }
}
