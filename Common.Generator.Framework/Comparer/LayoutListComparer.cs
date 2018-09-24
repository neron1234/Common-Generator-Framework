using Mobioos.Foundation.Jade.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Common.Generator.Framework.Comparer
{
    public class LayoutListComparer : IEqualityComparer<LayoutList>
    {
        public bool Equals(LayoutList x, LayoutList y)
        {
            foreach (LayoutInfo layout in x)
                if (!y.Any(item => item.Id == layout.Id))
                    return false;
            return true;
        }

        public int GetHashCode(LayoutList obj)
        {
            throw new NotImplementedException();
        }
    }
}
