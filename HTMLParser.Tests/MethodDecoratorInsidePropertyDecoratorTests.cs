using HTMLParser.Decorator;
using HTMLParser.Tests.Types;

namespace HTMLParser.Tests
{
    public class MethodDecoratorInsidePropertyDecoratorTests
    {
        private static PropertyDecoratorTestType CreateInstanceToTest()
        {
            return new PropertyDecoratorTestType()
            {
                Property1 = 1,
                Property2 = "test",
                Property3 = new(),
                ReferenceProperty = new()
                {
                    Property1 = 2,
                    Property2 = "test wrapee",
                    Property3 = new()
                }
            };
        }

        [Fact]
        public void WrappeeMethodDecoratorResultHasValueWhenGetValueIsCalledAndPropertyDecoratorHasAMethodDecoratorWrapee()
        {
            //Arrange
            PropertyDecoratorTestType instanceToTest = CreateInstanceToTest();
            var methodDecoratorWrappee = new MethodDecorator()
            {
                MethodName = "Method1",
                Parameters = new object[] { "testWord", 3 }
            };
            var propertyDecorator = new PropertyDecorator(methodDecoratorWrappee)
            {
                PropertyName = "ReferenceProperty"
            };

            //Act
            propertyDecorator.GetValue(instanceToTest);

            //Assert
            Assert.NotNull(methodDecoratorWrappee.Result);
        }

        [Fact]
        public void WrappeeMethodDecoratorResultIsOfCorrectTypeWhenGetValueIsCalledAndPropertyDecoratorHasAMethodDecoratorWrapee()
        {
            //Arrange
            PropertyDecoratorTestType instanceToTest = CreateInstanceToTest();
            var methodDecoratorWrappee = new MethodDecorator()
            {
                MethodName = "Method1",
                Parameters = new object[] { "testWord", 3 }
            };
            var propertyDecorator = new PropertyDecorator(methodDecoratorWrappee)
            {
                PropertyName = "ReferenceProperty"
            };

            //Act
            propertyDecorator.GetValue(instanceToTest);

            //Assert
            Assert.IsType<string>(methodDecoratorWrappee.Result);
        }

        [Fact]
        public void WrappeeMethodDecoratorResultHasCorrectValueWhenGetValueIsCalledAndPropertyDecoratorHasAMethodDecoratorWrapee()
        {
            //Arrange
            PropertyDecoratorTestType instanceToTest = CreateInstanceToTest();
            var methodDecoratorWrappee = new MethodDecorator()
            {
                MethodName = "Method1",
                Parameters = new object[] { "testWord", 3 }
            };
            var propertyDecorator = new PropertyDecorator(methodDecoratorWrappee)
            {
                PropertyName = "ReferenceProperty"
            };

            //Act
            propertyDecorator.GetValue(instanceToTest);

            //Assert
            Assert.Equal("testWord - 3 - 2", methodDecoratorWrappee.Result);
        }

        [Fact]
        public void WrappeeMethodDecoratorResultReferenceTypeHasValueWhenGetValueIsCalledAndPropertyDecoratorHasAMethodDecoratorWrapee()
        {
            //Arrange
            PropertyDecoratorTestType instanceToTest = CreateInstanceToTest();
            var methodDecoratorWrappee = new MethodDecorator()
            {
                MethodName = "Method2",
                Parameters = new object[] { new AType() }
            };
            var propertyDecorator = new PropertyDecorator(methodDecoratorWrappee)
            {
                PropertyName = "ReferenceProperty"
            };

            //Act
            propertyDecorator.GetValue(instanceToTest);

            //Assert
            Assert.NotNull(methodDecoratorWrappee.Result);
        }

        [Fact]
        public void WrappeeMethodDecoratorResultResultReferenceTypeIsOfCorrectTypeWhenGetValueIsCalledAndPropertyDecoratorHasAMethodDecoratorWrapee()
        {
            //Arrange
            PropertyDecoratorTestType instanceToTest = CreateInstanceToTest();
            var methodDecoratorWrappee = new MethodDecorator()
            {
                MethodName = "Method2",
                Parameters = new object[] { new AType() }
            };
            var propertyDecorator = new PropertyDecorator(methodDecoratorWrappee)
            {
                PropertyName = "ReferenceProperty"
            };

            //Act
            propertyDecorator.GetValue(instanceToTest);

            //Assert
            Assert.IsType<AType>(methodDecoratorWrappee.Result);
        }

        [Fact]
        public void WrappeeMethodDecoratorResultReferenceTypeHasCorrectValueWhenGetValueIsCalledAndPropertyDecoratorHasAMethodDecoratorWrapee()
        {
            //Arrange
            PropertyDecoratorTestType instanceToTest = CreateInstanceToTest();
            var methodDecoratorWrappee = new MethodDecorator()
            {
                MethodName = "Method2",
                Parameters = new object[] { new AType() }
            };
            var propertyDecorator = new PropertyDecorator(methodDecoratorWrappee)
            {
                PropertyName = "ReferenceProperty"
            };

            //Act
            propertyDecorator.GetValue(instanceToTest);
            var refValue = methodDecoratorWrappee.Result as AType;

            //Assert
            Assert.Equal(1, refValue.IntegerProperty);
        }
    }
}
