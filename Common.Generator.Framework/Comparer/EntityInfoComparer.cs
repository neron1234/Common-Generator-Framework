using Mobioos.Foundation.Jade.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Common.Generator.Framework.Comparer
{
    public class EntityInfoComparer : IEqualityComparer<EntityInfo>
    {
        public bool Equals(EntityInfo x, EntityInfo y)
        {
            if (x.Id == y.Id)
            {
                foreach (PropertyInfo property in x.Properties.AsEnumerable())
                    if (property.Id != null
                        && !property.Id.Equals("")
                        && !y.Properties.AsEnumerable()
                                     .Any(item => item.Id == property.Id
                                               && item.IsCollection == property.IsCollection
                                               && item.IsKey == property.IsKey))
                        return false;

                foreach (ReferenceInfo reference in x.References.AsEnumerable())
                    if (!y.References.AsEnumerable()
                                     .Any(item => item.Id == reference.Id
                                               && item.ForeignKey == reference.ForeignKey
                                               && 
                                               && item.IsCollection == reference.IsCollection
                                               && item.IsKey == reference.IsKey))
                        return false;

                return true;
            }

            return false;
        }

        public int GetHashCode(EntityInfo obj)
        {
            int result = obj.GetHashCode();
            Int32.TryParse(obj.Id, out result);
            return result;
        }
    }
}
