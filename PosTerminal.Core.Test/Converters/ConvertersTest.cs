using System.Collections.Generic;
using PosTerminal.Core.Converters;
using Xunit;

namespace PosTerminal.Core.Test.Converters
{
    public class ConvertersTest
    {
        [Theory]
        [MemberData(nameof(TestJsonData))]
        public void ShouldDeserializeToObject(string json, FirstTestObject result)
        {
            var converter = new JsonConverter();

            Assert.Equal(result, converter.Deserialize<FirstTestObject>(json));
        }

        #region TestJsonData

        public static IEnumerable<object[]> TestJsonData()
        {
            yield return new object[]
            {
                @"{'stringProperty': 'string', 'intProperty': 10}",
                new FirstTestObject() { StringProperty = "string", IntProperty = 10}
            };
            
            yield return new object[]
            {
                @"{'stringProperty': 'string 25', 'intProperty': 55, 'objectProperty': {'boolProperty': true}}",
                new FirstTestObject()
                {
                    StringProperty = "string 25", 
                    IntProperty = 55,
                    ObjectProperty = new SecondTestObject() { BoolProperty = true,}
                }
            };
        }

        #endregion
    }

    public record FirstTestObject
    {
        public string StringProperty { get; init; }
        public int IntProperty { get; init; }
        public SecondTestObject ObjectProperty { get; init; }
    }

    public record SecondTestObject
    {
        public bool BoolProperty { get; init; }
    }
}