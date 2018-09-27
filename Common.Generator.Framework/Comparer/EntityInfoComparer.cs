using Mobioos.Foundation.Jade.Models;
using System.Collections.Generic;

namespace Common.Generator.Framework.Comparer
{
    public class EntityInfoComparer : IEqualityComparer<EntityInfo>
    {
        public bool Equals(EntityInfo x, EntityInfo y)
        {
            if (ReferenceEquals(x, y))
                return true;

            if (x == null || y == null)
                return false;

            EntityInfoComparer entityComparer = new EntityInfoComparer();
            PropertyInfoListComparer propertyListComparer = new PropertyInfoListComparer();
            ReferenceInfoListComparer referenceListComparer = new ReferenceInfoListComparer();
            ValueInfoListComparer valueListComparer = new ValueInfoListComparer();

            if (x.Id != y.Id
                || x.Extends != y.Extends
                || x.Description != y.Description
                || !entityComparer.Equals(x.BaseEntity, y.BaseEntity)
                || x.IsAbstract != y.IsAbstract
                || x.IsEnum != y.IsEnum
                || !propertyListComparer.Equals(x.Properties, y.Properties)
                || !referenceListComparer.Equals(x.References, y.References)
                || !valueListComparer.Equals(x.Values, y.Values))
                return false;

            return true;
        }

        public int GetHashCode(EntityInfo obj)
        {
            return string.Concat(obj.Id, obj.Description).GetHashCode();
        }
    }
}
