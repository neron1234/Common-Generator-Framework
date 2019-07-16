using Mobioos.Foundation.Jade.Models;

namespace Common.Generator.Framework.Extensions
{
    public static class SchemaElementExtension
    {
        public static bool IsValid(this SchemaElement schema)
        {
            if (schema == null
                || !schema.Id.IsValid())
            {
                return false;
            }

            return true;
        }
    }
}
