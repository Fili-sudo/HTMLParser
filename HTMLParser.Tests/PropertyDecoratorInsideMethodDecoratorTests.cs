using HTMLParser.Decorator;
using HTMLParser.Tests.Types;

namespace HTMLParser.Tests
{
    public class PropertyDecoratorInsideMethodDecoratorTests
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

        [Theory]
        [InlineData("Property1")]
        [InlineData("Property2")]
        [InlineData("Property3")]
        public void WrappeePropertyValueHasValueWhenGetValueIsCalledAndMethodDecoratorHasAPropertyDecoratorWrapee(string propertyName)
        {
            //Arrange
            PropertyDecoratorTestType instanceToTest = CreateInstanceToTest();
            var propertyDecoratorWrappee = new PropertyDecorator()
            {
                PropertyName = propertyName
            };
            var methodDecorator = new MethodDecorator(propertyDecoratorWrappee)
            {
                MethodName = "Method3",
                Parameters = new object[] { }
            };

            //Act
            methodDecorator.GetValue(instanceToTest);

            //Assert
            Assert.NotNull(propertyDecoratorWrappee.PropertyValue);
        }

        [Theory]
        [InlineData("Property1", typeof(int))]
        [InlineData("Property2", typeof(string))]
        [InlineData("Property3", typeof(AType))]
        public void WrappeePropertyValueIsOfCorrectTypeWhenGetValueIsCalledAndMethodDecoratorHasAPropertyDecoratorWrapee(string propertyName, Type expectedType)
        {
            //Arrange
            PropertyDecoratorTestType instanceToTest = CreateInstanceToTest();
            var propertyDecoratorWrappee = new PropertyDecorator()
            {
                PropertyName = propertyName
            };
            var methodDecorator = new MethodDecorator(propertyDecoratorWrappee)
            {
                MethodName = "Method3",
                Parameters = new object[] { }
            };

            //Act
            methodDecorator.GetValue(instanceToTest);

            //Assert
            Assert.IsType(expectedType, propertyDecoratorWrappee.PropertyValue);
        }

        [Theory]
        [InlineData("Property1", 10)]
        [InlineData("Property2", "test 10")]
        public void WrappeePropertyValueHasCorrectValueWhenGetValueIsCalledAndMethodDecoratorHasAPropertyDecoratorWrapee(string propertyName, object expectedValue)
        {
            //Arrange
            PropertyDecoratorTestType instanceToTest = CreateInstanceToTest();
            var propertyDecoratorWrappee = new PropertyDecorator()
            {
                PropertyName = propertyName
            };
            var methodDecorator = new MethodDecorator(propertyDecoratorWrappee)
            {
                MethodName = "Method3",
                Parameters = new object[] { }
            };

            //Act
            methodDecorator.GetValue(instanceToTest);

            //Assert
            Assert.Equal(expectedValue, propertyDecoratorWrappee.PropertyValue);
        }
    }
}
