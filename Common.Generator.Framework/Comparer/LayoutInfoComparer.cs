using Mobioos.Foundation.Jade.Models;
using System.Collections.Generic;
using System.Linq;

namespace Common.Generator.Framework.Comparer
{
    public class LayoutInfoComparer : IEqualityComparer<LayoutInfo>
    {
        public bool Equals(
            LayoutInfo x,
            LayoutInfo y)
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

            var entityComparer = new EntityInfoComparer();
            var actionListComparer = new ActionListComparer();
            var concernComparer = new ConcernInfoComparer();

            if (x.Title != y.Title
                || x.Description != y.Description
                || x.IsVisibleInMenu != y.IsVisibleInMenu
                || x.IsRoot != y.IsRoot
                || !ReferenceEquals(
                    x.Parent,
                    y.Parent)
                || !actionListComparer.Equals(
                    x.Actions,
                    y.Actions)
                || !entityComparer.Equals(
                    x.DataModel,
                    y.DataModel)
                || !concernComparer.Equals(
                    x.Concern,
                    y.Concern))
            {
                return false;
            }

            return true;
        }

        public int GetHashCode(LayoutInfo obj)
        => string
            .Concat(
                obj.Id,
                obj.Title)
            .GetHashCode();
    }

    public class LayoutListComparer : IEqualityComparer<LayoutList>
    {
        public bool Equals(
            LayoutList x,
            LayoutList y)
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

            if (x.Id != y.Id)
            {
                return false;
            }

            var layoutComparer = new LayoutInfoComparer();

            foreach (var layout in x)
            {
                if (!y.Any(item =>
                    layoutComparer.Equals(
                        item,
                        layout)))
                {
                    return false;
                }
            }

            return true;
        }

        public int GetHashCode(LayoutList obj)
        => string
            .Concat(
                obj.Id,
                obj.Parent.Id)
            .GetHashCode();
    }
}
