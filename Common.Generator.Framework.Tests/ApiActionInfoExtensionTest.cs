using Common.Generator.Framework.Extensions;
using Mobioos.Foundation.Jade.Models;
using System.Linq;
using Xunit;

namespace Common.Generator.Framework.Tests
{
    public class ApiActionInfoExtensionTest : BaseTest
    {
        public ApiActionInfoExtensionTest() : base()
        {
        }

        [Fact]
        public void CSharpType()
        {
            ApiActionInfo apiAction = _smartApp.Api?.FirstOrDefault().Actions?.FirstOrDefault();
            string result = apiAction.CSharpType();
            Assert.NotNull(result);
        }
    }
}
