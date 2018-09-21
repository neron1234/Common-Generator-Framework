using Common.Generator.Framework.Extensions;
using Mobioos.Foundation.Jade.Models;
using Xunit;

namespace Common.Generator.Framework.Tests
{
    public class ApiParameterInfoExtensionTest : BaseTest
    {
        public ApiParameterInfoExtensionTest() : base()
        {
        }

        [Fact]
        public void IsModel()
        {
            if (_smartApp != null && _smartApp.Api != null)
            {
                foreach (ApiInfo api in _smartApp.Api)
                {
                    if (api.Actions != null)
                    {
                        foreach (ApiActionInfo apiAction in api.Actions)
                        {
                            if (apiAction.Parameters != null)
                            {
                                foreach (ApiParameterInfo apiActionParameter in apiAction.Parameters)
                                {
                                    bool result = apiActionParameter.IsModel();
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
