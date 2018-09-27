using Mobioos.Foundation.Jade.Models;
using System.Collections.Generic;
using System.Linq;

namespace Common.Generator.Framework.Comparer
{
    public class ActionInfoComparer : IEqualityComparer<ActionInfo>
    {
        public bool Equals(ActionInfo x, ActionInfo y)
        {
            if (ReferenceEquals(x, y))
                return true;

            if (x == null || y == null)
                return false;

            ConcernInfoComparer concernComparer = new ConcernInfoComparer();
            ActionInfoComparer actionComparer = new ActionInfoComparer();
            TelemetryInfoComparer telemetryComparer = new TelemetryInfoComparer();

            if (x.Id != y.Id
                || x.Type != y.Type
                || x.Target != y.Target
                || x.Api != y.Api
                || !ReferenceEquals(x.Parent, y.Parent)
                || !concernComparer.Equals(x.TargetConcern, y.TargetConcern)
                || !actionComparer.Equals(x.TargetAction, y.TargetAction)
                || !telemetryComparer.Equals(x.Telemetry, y.Telemetry))
                return false;

            return true;
        }

        public int GetHashCode(ActionInfo obj)
        {
            return string.Concat(obj.Id, obj.Parent.Id).GetHashCode();
        }
    }

    public class ActionListComparer : IEqualityComparer<ActionList>
    {
        public bool Equals(ActionList x, ActionList y)
        {
            if (ReferenceEquals(x, y))
                return true;

            if (x == null || y == null)
                return false;

            if (x.Id != y.Id)
                return false;

            ActionInfoComparer actionComparer = new ActionInfoComparer();

            foreach (ActionInfo action in x.AsEnumerable())
                if (!y.AsEnumerable()
                      .Any(item => actionComparer.Equals(item, action)))
                    return false;

            return true;
        }

        public int GetHashCode(ActionList obj)
        {
            return string.Concat(obj.Id, obj.Parent.Id).GetHashCode();
        }
    }
}
