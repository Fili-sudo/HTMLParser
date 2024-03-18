using HTMLParser.Decorator;
using HTMLParser.Tests.Types;

namespace HTMLParser.Tests
{
    public class MethodDecoratorTests
    {
        private static PropertyDecoratorTestType CreateInstanceToTest()
        {
            return new PropertyDecoratorTestType()
            {
                Property1 = 1,
                Property2 = "test",
                Property3 = new()
            };
        }

        [Fact]
        public void ResultHasValueWhenGetValueIsCalled()
        {
            //Arrange
            PropertyDecoratorTestType instanceToTest = CreateInstanceToTest();
            var methodDecorator = new MethodDecorator()
            {
                MethodName = "Method1",
                Parameters = new object[] { "testWord", 3 }
            };

            //Act
            methodDecorator.GetValue(instanceToTest);

            //Assert
            Assert.NotNull(methodDecorator.Result);
        }

        [Fact]
        public void ResultHasValueWhenGetValueIsCalledWithEmptyParamList()
        {
            //Arrange
            PropertyDecoratorTestType instanceToTest = CreateInstanceToTest();
            var methodDecorator = new MethodDecorator()
            {
                MethodName = "NoParameterMethod",
                Parameters = new object[] { }
            };

            //Act
            methodDecorator.GetValue(instanceToTest);

            //Assert
            Assert.NotNull(methodDecorator.Result);
        }

        [Fact]
        public void ResultIsOfCorrectTypeWhenGetValueIsCalledWithEmptyParamList()
        {
            //Arrange
            PropertyDecoratorTestType instanceToTest = CreateInstanceToTest();
            var methodDecorator = new MethodDecorator()
            {
                MethodName = "NoParameterMethod",
                Parameters = new object[] { }
            };

            //Act
            methodDecorator.GetValue(instanceToTest);

            //Assert
            Assert.IsType<string>(methodDecorator.Result);
        }

        [Fact]
        public void ResultHasCorrectValueWhenGetValueIsCalledWithEmptyParamList()
        {
            //Arrange
            PropertyDecoratorTestType instanceToTest = CreateInstanceToTest();
            var methodDecorator = new MethodDecorator()
            {
                MethodName = "NoParameterMethod",
                Parameters = new object[] { }
            };

            //Act
            methodDecorator.GetValue(instanceToTest);

            //Assert
            Assert.Equal("empty param list", methodDecorator.Result);
        }

        [Fact]
        public void ResultThrowsInvalidOperationExceptionWhenGetValueIsCalledAndInstanceHasNotTheMethodName()
        {
            //Arrange
            PropertyDecoratorTestType instanceToTest = CreateInstanceToTest();
            var methodDecorator = new MethodDecorator()
            {
                MethodName = "giberish",
                Parameters = new object[] { "testWord", 3 }
            };

            //Assert
            Assert.Throws<InvalidOperationException>(() => methodDecorator.GetValue(instanceToTest));
        }

        [Fact]
        public void ResultThrowsInvalidOperationExceptionWhenGetValueIsCalledAndGivenWrongParameters()
        {
            //Arrange
            PropertyDecoratorTestType instanceToTest = CreateInstanceToTest();
            var methodDecorator = new MethodDecorator()
            {
                MethodName = "giberish",
                Parameters = new object[] { 3, "testWord" }
            };

            //Assert
            Assert.Throws<InvalidOperationException>(() => methodDecorator.GetValue(instanceToTest));
        }

        [Fact]
        public void ResultIsOfCorrectTypeWhenGetValueIsCalled()
        {
            //Arrange
            PropertyDecoratorTestType instanceToTest = CreateInstanceToTest();
            var methodDecorator = new MethodDecorator()
            {
                MethodName = "Method1",
                Parameters = new object[] { "testWord", 3 }
            };

            //Act
            methodDecorator.GetValue(instanceToTest);

            //Assert
            Assert.IsType<string>(methodDecorator.Result);
        }

        [Fact]
        public void ResultHasCorrectValueWhenGetValueIsCalled()
        {
            //Arrange
            PropertyDecoratorTestType instanceToTest = CreateInstanceToTest();
            var methodDecorator = new MethodDecorator()
            {
                MethodName = "Method1",
                Parameters = new object[] { "testWord", 3 }
            };

            //Act
            methodDecorator.GetValue(instanceToTest);

            //Assert
            Assert.Equal("testWord - 3 - 1", methodDecorator.Result);
        }

        [Fact]
        public void ResultReferenceTypeHasValueWhenGetValueIsCalled()
        {
            //Arrange
            PropertyDecoratorTestType instanceToTest = CreateInstanceToTest();
            var methodDecorator = new MethodDecorator()
            {
                MethodName = "Method2",
                Parameters = new object[] { new AType() }
            };

            //Act
            methodDecorator.GetValue(instanceToTest);

            //Assert
            Assert.NotNull(methodDecorator.Result);
        }

        [Fact]
        public void ResultReferenceTypeIsOfCorrectTypeWhenGetValueIsCalled()
        {
            //Arrange
            PropertyDecoratorTestType instanceToTest = CreateInstanceToTest();
            var methodDecorator = new MethodDecorator()
            {
                MethodName = "Method2",
                Parameters = new object[] { new AType() }
            };

            //Act
            methodDecorator.GetValue(instanceToTest);

            //Assert
            Assert.IsType<AType>(methodDecorator.Result);
        }

        [Fact]
        public void ResultReferenceTypeHasCorrectValueWhenGetValueIsCalled()
        {
            //Arrange
            PropertyDecoratorTestType instanceToTest = CreateInstanceToTest();
            var methodDecorator = new MethodDecorator()
            {
                MethodName = "Method2",
                Parameters = new object[] { new AType() }
            };

            //Act
            methodDecorator.GetValue(instanceToTest);
            var refValue = methodDecorator.Result as AType;

            //Assert
            Assert.Equal(1, refValue.IntegerProperty);
        }
    }
}
