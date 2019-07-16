using Common.Generator.Framework.Extensions;
using Mobioos.Foundation.Jade.Models;
using Xunit;

namespace Common.Generator.Framework.Tests
{
    public class EntityInfoExtensionTest : BaseTest
    {
        public EntityInfoExtensionTest() : base()
        {

        }

        [Fact]
        public void GetProperties()
        {
            var models = _smartApp.GetModels();

            foreach (var entity in models)
            {
                var test = entity.GetProperties();
            }
        }

        [Fact]
        public void IsInherited()
        {
            var models = _smartApp.GetModels();
            var count = 0;

            foreach (var entity in models)
            {
                var test = entity.IsInherited(models);

                if (test)
                {
                    count++;
                }
            }
        }
    }
}
