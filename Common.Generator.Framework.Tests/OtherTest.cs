using Common.Generator.Framework.Extensions;
using Mobioos.Foundation.Jade.Models;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Common.Generator.Framework.Tests
{
    public class OtherTest : BaseTest
    {
        public OtherTest() : base()
        {
        }

        [Fact]
        public void UnionEntityInfoList()
        {
            EntityInfo entity1 = new EntityInfo()
            {
                Id = "vlarf"
            };

            EntityInfo entity2 = new EntityInfo()
            {
                Id = "test"
            };

            EntityInfo entity3 = new EntityInfo()
            {
                Id = "today"
            };

            List<EntityInfo> list1 = new List<EntityInfo>();
            list1.Add(entity1);
            list1.Add(entity2);

            List<EntityInfo> list2 = new List<EntityInfo>();
            list2.Add(entity1);
            list2.Add(entity3);

            var union = list1.AsEnumerable().Union(list2.AsEnumerable());

            Assert.NotNull(union);
        }

        [Fact]
        public void UnionLayoutList()
        {
            LayoutInfo layout1 = new LayoutInfo()
            {
                Id = "vlarf"
            };

            LayoutInfo layout2 = new LayoutInfo()
            {
                Id = "test"
            };

            LayoutInfo layout3 = new LayoutInfo()
            {
                Id = "today"
            };

            LayoutList list1 = new LayoutList();
            list1.Add(layout1);
            list1.Add(layout2);

            LayoutList list2 = new LayoutList();
            list2.Add(layout1);
            list2.Add(layout3);

            var union = list1.AsEnumerable().Union(list2.AsEnumerable());

            Assert.NotNull(union);
        }

        [Fact]
        public void ToPascalCase()
        {
            string s = "testMille";
            string result = s.ToPascalCase();
        }

        [Fact]
        public void ToCamelCase()
        {
            string s = "TestMille";
            string result = s.ToCamelCase();
        }
    }
}
