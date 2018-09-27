using Mobioos.Foundation.Jade.Models;
using System;
using System.Collections.Generic;

namespace Common.Generator.Framework.Comparer
{
    public class ReferenceInfoComparer : IEqualityComparer<ReferenceInfo>
    {
        public bool Equals(ReferenceInfo x, ReferenceInfo y)
        {
            if (x == null && y == null)
                return true;

            if (x == null && y != null)
                return false;

            if (x != null && y == null)
                return false;

            if (x.Id != null
                && y.Id != null
                && x.Id.Equals(y.Id)
                && x.IsCollection.Equals(y.IsCollection)
                && x.IsKey.Equals(y.IsKey)
                && x.ForeignKey.Equals(y.ForeignKey)
                && x.Type.Equals(y.Type)
                && ((x.ModelProperty != null
                     && y.ModelProperty != null
                     && x.ModelProperty.Equals(y.ModelProperty))
                   || (x.ModelProperty == null
                       && y.ModelProperty == null))
                && x.Target != null
                && y.Target != null
                && x.Target.Equals(y.Target)
                && x.)
                return true;

            return false;
        }

        public int GetHashCode(ReferenceInfo obj)
        {
            int result = obj.GetHashCode();
            Int32.TryParse(obj.Id, out result);
            return result;
        }
    }
}
