using Common.Generator.Framework.Extensions;
using Xunit;

namespace Common.Generator.Framework.Tests
{
    public class SmartAppInfoExtensionTest : BaseTest
    {
        public SmartAppInfoExtensionTest() : base()
        {
        }

        [Fact]
        public void GetLayouts()
        {
            var layouts = _smartApp.GetLayouts();
            Assert.NotNull(layouts);
        }

        [Fact]
        public void GetModels()
        {
            var models = _smartApp.GetModels();
            Assert.NotNull(models);
        }

        [Fact]
        public void GetViewModels()
        {
            var viewModels = _smartApp.GetViewModels();
            Assert.NotNull(viewModels);
        }
    }
}
