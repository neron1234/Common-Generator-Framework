using Mobioos.Foundation.Jade;
using Mobioos.Foundation.Jade.Models;

namespace Common.Generator.Framework.Tests
{
    public class BaseTest
    {
        public SmartAppInfo _smartApp;

        public BaseTest()
        {
            _smartApp = JadeEngine.Parse("Manifest");
        }
    }
}
