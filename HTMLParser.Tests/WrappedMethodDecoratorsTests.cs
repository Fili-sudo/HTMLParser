using HTMLParser.Decorator;
using HTMLParser.Tests.Types;

namespace HTMLParser.Tests
{
    public class WrappedMethodDecoratorsTests
    {
        private static PropertyDecoratorTestType? CreateInstanceToTest(int layer = 1)
        {
            return layer == 0 ? null
            : new PropertyDecoratorTestType()
            {
                Property1 = layer,
                Property2 = $"test - {layer}",
                Property3 = new(),
                ReferenceProperty = CreateInstanceToTest(layer - 1),
            };
        }

        [Fact]
        public void WrappeeResultHasValueWhenGetValueIsCalledAndMethodDecoratorHasAMethodDecoratorWrappee()
        {
            //Arrange
            PropertyDecoratorTestType instanceToTest = CreateInstanceToTest();
            var methodDecoratorWrappee = new MethodDecorator()
            {
                MethodName = "Method1",
                Parameters = new object[] { "testWord", 3 }
            };
            var methodDecorator = new MethodDecorator(methodDecoratorWrappee)
            {
                MethodName = "Method3",
                Parameters = new object[] { }
            };

            //Act
            methodDecorator.GetValue(instanceToTest);

            //Assert
            Assert.NotNull(methodDecoratorWrappee.Result);
        }

        [Fact]
        public void WrappeeResultIsOfCorrectTypeWhenGetValueIsCalledAndMethodDecoratorHasAMethodDecoratorWrappee()
        {
            //Arrange
            PropertyDecoratorTestType instanceToTest = CreateInstanceToTest();
            var methodDecoratorWrappee = new MethodDecorator()
            {
                MethodName = "Method1",
                Parameters = new object[] { "testWord", 3 }
            };
            var methodDecorator = new MethodDecorator(methodDecoratorWrappee)
            {
                MethodName = "Method3",
                Parameters = new object[] { }
            };

            //Act
            methodDecorator.GetValue(instanceToTest);

            //Assert
            Assert.IsType<string>(methodDecoratorWrappee.Result);
        }

        [Fact]
        public void WrappeeResultHasCorrectValueWhenGetValueIsCalledAndMethodDecoratorHasAMethodDecoratorWrappee()
        {
            //Arrange
            PropertyDecoratorTestType instanceToTest = CreateInstanceToTest();
            var methodDecoratorWrappee = new MethodDecorator()
            {
                MethodName = "Method1",
                Parameters = new object[] { "testWord", 3 }
            };
            var methodDecorator = new MethodDecorator(methodDecoratorWrappee)
            {
                MethodName = "Method3",
                Parameters = new object[] { }
            };

            //Act
            methodDecorator.GetValue(instanceToTest);

            //Assert
            Assert.Equal("testWord - 3 - 10", methodDecoratorWrappee.Result);
        }

        [Fact]
        public void LastWrappeeResultHasValueWhenGetValueIsCalledAndMethodDecoratorHas2LayersOfWrappees()
        {
            //Arrange
            PropertyDecoratorTestType instanceToTest = CreateInstanceToTest();
            var lastDecoratorWrappee = new MethodDecorator()
            {
                MethodName = "Method1",
                Parameters = new object[] { "testWord", 3 }
            };
            var firstMethodDecorator = new MethodDecorator(lastDecoratorWrappee)
            {
                MethodName = "Method3",
                Parameters = new object[] { }
            };
            var methodDecorator = new MethodDecorator(firstMethodDecorator)
            {
                MethodName = "Method3",
                Parameters = new object[] { }
            };

            //Act
            methodDecorator.GetValue(instanceToTest);

            //Assert
            Assert.NotNull(lastDecoratorWrappee.Result);
        }

        [Fact]
        public void LastWrappeeResultIsOfCorrectTypeWhenGetValueIsCalledAndMethodDecoratorHas2LayersOfWrappees()
        {
            //Arrange
            PropertyDecoratorTestType instanceToTest = CreateInstanceToTest();
            var lastDecoratorWrappee = new MethodDecorator()
            {
                MethodName = "Method1",
                Parameters = new object[] { "testWord", 3 }
            };
            var firstMethodDecorator = new MethodDecorator(lastDecoratorWrappee)
            {
                MethodName = "Method3",
                Parameters = new object[] { }
            };
            var methodDecorator = new MethodDecorator(firstMethodDecorator)
            {
                MethodName = "Method3",
                Parameters = new object[] { }
            };

            //Act
            methodDecorator.GetValue(instanceToTest);

            //Assert
            Assert.IsType<string>(lastDecoratorWrappee.Result);
        }

        [Fact]
        public void LastWrappeeResultHasCorrectValueWhenGetValueIsCalledAndMethodDecoratorHas2LayersOfWrappees()
        {
            //Arrange
            PropertyDecoratorTestType instanceToTest = CreateInstanceToTest();
            var lastDecoratorWrappee = new MethodDecorator()
            {
                MethodName = "Method1",
                Parameters = new object[] { "testWord", 3 }
            };
            var firstMethodDecorator = new MethodDecorator(lastDecoratorWrappee)
            {
                MethodName = "Method3",
                Parameters = new object[] { }
            };
            var methodDecorator = new MethodDecorator(firstMethodDecorator)
            {
                MethodName = "Method3",
                Parameters = new object[] { }
            };

            //Act
            methodDecorator.GetValue(instanceToTest);

            //Assert
            Assert.Equal("testWord - 3 - 10", lastDecoratorWrappee.Result);
        }
    }
}
