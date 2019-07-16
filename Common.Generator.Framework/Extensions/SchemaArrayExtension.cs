using Mobioos.Foundation.Jade.Models;

namespace Common.Generator.Framework.Extensions
{
    public static class SchemaArrayExtension
    {
        public static bool IsValid<T>(this SchemaArray<T> array)
            where T : SchemaElement
        {
            if (array == null)
            {
                return false;
            }

            return true;
        }
    }
}
