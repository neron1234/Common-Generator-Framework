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
            foreach (EntityInfo entity in models)
            {
                var test = entity.GetProperties();
            }
        }
    }
}
