using Common.Generator.Framework.Comparer;
using Common.Generator.Framework.Extensions;
using Mobioos.Foundation.Jade.Models;
using System.Collections.Generic;
using System.Linq;
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
        }

        [Fact]
        public void GetModels()
        {
            var models = _smartApp.GetModels();
        }

        [Fact]
        public void CompareEntityInfoList()
        {
            EntityInfo entity = new EntityInfo()
            {
                Id = "vlarf"
            };

            EntityInfo entity2 = new EntityInfo()
            {
                Id = "test"
            };

            List<EntityInfo> list = new List<EntityInfo>();
            list.Add(entity);
            list.Add(entity2);

            List<EntityInfo> list2 = new List<EntityInfo>();
            list2.Add(entity);
            list2.Add(entity2);

            var union = list.Union(list2);

            Assert.Null(union);
        }

        [Fact]
        public void CompareLayoutList()
        {
            LayoutInfo layout = new LayoutInfo()
            {
                Id = "vlarf"
            };

            LayoutInfo layout2 = new LayoutInfo()
            {
                Id = "test"
            };

            LayoutList list = new LayoutList();
            list.Add(layout);
            list.Add(layout2);

            LayoutList list2 = new LayoutList();
            list2.Add(layout);
            list2.Add(layout2);

            var union = list.Union(list2);

            foreach (LayoutInfo la in union.AsEnumerable())
            {
                var l = la;
            }

            Assert.NotNull(union);
        }
    }
}
