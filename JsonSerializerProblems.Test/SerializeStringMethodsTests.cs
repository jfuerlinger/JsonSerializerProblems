using FluentAssertions;
using JsonSerializerProblems.Core;
using JsonSerializerProblems.Core.Model;
using System.Collections;

namespace JsonSerializerProblems.Test
{
    public class CalculatorTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { "{\"payload\":\"test\"}", "test" };
            yield return new object[] { "{\"payload\":\"te\rst\"}", "te\rst" };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class SerializeStringMethodsTests
    {
        [Theory]
        [ClassData(typeof(CalculatorTestData))]
        public void DeserializeWithNewtonSoft_Call_ShouldNotThrowAnyException(string raw, string expected)
        {
            var actual = SerializeStringMethods.DeserializeWithNewtonSoft<MyModel>(raw);

            actual?.Payload.Should().Be(expected);
        }

        [Theory]
        [ClassData(typeof(CalculatorTestData))]
        public void DeserializeWithSystemTextJson_Call_ShouldNotThrowAnyException(string raw, string expected)
        {
            var actual = SerializeStringMethods.DeserializeWithSystemTextJson<MyModel>(raw);

            actual?.Payload.Should().Be(expected);
        }
    }
}