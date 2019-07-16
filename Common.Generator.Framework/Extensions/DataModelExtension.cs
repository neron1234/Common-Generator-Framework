using Mobioos.Foundation.Jade.Models;

namespace Common.Generator.Framework.Extensions
{
    public static class DataModelExtension
    {
        public static bool IsValid(this DataModel dataModel)
        {
            if (dataModel == null
                || !dataModel.Entities.IsValid())
            {
                return false;
            }

            return true;
        }
    }
}
