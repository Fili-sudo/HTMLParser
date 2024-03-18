using HTMLParser.Decorator;
using HTMLParser.Tests.Types;

namespace HTMLParser.Tests
{
    public class PropertyDecoratorTests
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

        [Theory]
        [InlineData("Property1")]
        [InlineData("Property2")]
        [InlineData("Property3")]
        public void PropertyValueHasValueWhenGetValueIsCalled(string propertyName)
        {
            //Arrange
            PropertyDecoratorTestType instanceToTest = CreateInstanceToTest();
            var propertyDecorator = new PropertyDecorator()
            {
                PropertyName = propertyName
            };

            //Act
            propertyDecorator.GetValue(instanceToTest);

            //Assert
            Assert.NotNull(propertyDecorator.PropertyValue);
        }

        [Fact]
        public void PropertyValueThrowsInvalidOperationExceptionWhenGetValueIsCalledAndInstanceHasNotTheProperty()
        {
            //Arrange
            PropertyDecoratorTestType instanceToTest = CreateInstanceToTest();
            var propertyDecorator = new PropertyDecorator()
            {
                PropertyName = "giberish"
            };

            //Assert
            Assert.Throws<InvalidOperationException>(() => propertyDecorator.GetValue(instanceToTest));
        }

        [Theory]
        [InlineData("Property1", typeof(int))]
        [InlineData("Property2", typeof(string))]
        [InlineData("Property3", typeof(AType))]
        public void PropertyValueIsOfCorrectTypeWhenGetValueIsCalled(string propertyName, Type expectedType)
        {
            //Arrange
            PropertyDecoratorTestType instanceToTest = CreateInstanceToTest();
            var propertyDecorator = new PropertyDecorator()
            {
                PropertyName = propertyName
            };

            //Act
            propertyDecorator.GetValue(instanceToTest);

            //Assert
            Assert.IsType(expectedType, propertyDecorator.PropertyValue);
        }

        [Theory]
        [InlineData("Property1", 1)]
        [InlineData("Property2", "test")]
        public void PropertyValueIsOfCorrectValueWhenGetValueIsCalled(string propertyName, object expectedValue)
        {
            //Arrange
            PropertyDecoratorTestType instanceToTest = CreateInstanceToTest();
            var propertyDecorator = new PropertyDecorator()
            {
                PropertyName = propertyName
            };

            //Act
            propertyDecorator.GetValue(instanceToTest);

            //Assert
            Assert.Equal(expectedValue, propertyDecorator.PropertyValue);
        }

        [Fact]
        public void PropertyValueIsOfCorrectReferenceValueWhenGetValueIsCalled()
        {
            //Arrange
            PropertyDecoratorTestType instanceToTest = CreateInstanceToTest();
            var propertyDecorator = new PropertyDecorator()
            {
                PropertyName = "Property3"
            };

            //Act
            propertyDecorator.GetValue(instanceToTest);
            var refValue = propertyDecorator.PropertyValue as AType;

            //Assert
            Assert.Equal(1, refValue.IntegerProperty);
        }
    }
}