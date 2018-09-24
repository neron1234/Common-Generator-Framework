using Mobioos.Foundation.Jade.Models;
using System.Collections.Generic;
using System.Linq;

namespace Common.Generator.Framework.Comparer
{
    public class EntityInfoListComparer : IEqualityComparer<List<EntityInfo>>
    {
        public bool Equals(List<EntityInfo> x, List<EntityInfo> y)
        {
            foreach (EntityInfo entity in x)
                if (!y.Any(item => item.Id == entity.Id))
                    return false;
            return true;
        }

        public int GetHashCode(List<EntityInfo> obj)
        {
            return obj.GetHashCode();
        }
    }
}
