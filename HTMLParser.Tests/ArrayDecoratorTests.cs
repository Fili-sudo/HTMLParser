using HTMLParser.Decorator;

namespace HTMLParser.Tests
{
    public class ArrayDecoratorTests
    {
        [Fact(Skip = "temporary debug test")]
        public void DebugTest()
        {
            var instanceToTest = new ArrayClass() { IntegerArray = new int[] { 1, 2, 3 } };
            var decorator = new ArrayDecorator()
            {
                PropertyName = "IntegerArray",
                Index = 0,
            };
            decorator.GetValue(instanceToTest);
        }

        public class ArrayClass
        {
            public int[] IntegerArray { get; set; }
        }
    }
}
