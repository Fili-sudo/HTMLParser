using HTMLParser.Decorator;
using HTMLParser.Tests.Types;

namespace HTMLParser.Tests
{
    public class WrappedPropertyDecoratorsTests
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
        [InlineData("Property1", "ReferenceProperty")]
        [InlineData("Property2", "ReferenceProperty")]
        [InlineData("Property3", "ReferenceProperty")]
        [InlineData("IntegerProperty", "Property3")]
        public void WrappeePropertyValueHasValueWhenGetValueIsCalledAndPropertyDecoratorHasAPropertyDecoratorWrapee(string wrappeePropertyName, string wrapperPropertyName)
        {
            //Arrange
            PropertyDecoratorTestType instanceToTest = CreateInstanceToTest(2);
            var propertyDecoratorWrappee = new PropertyDecorator() { PropertyName = wrappeePropertyName };
            var propertyDecorator = new PropertyDecorator(propertyDecoratorWrappee) { PropertyName = wrapperPropertyName };

            //Act
            propertyDecorator.GetValue(instanceToTest);

            //Assert
            Assert.NotNull(propertyDecoratorWrappee.PropertyValue);
        }

        [Theory]
        [InlineData("Property1", "ReferenceProperty")]
        [InlineData("Property2", "ReferenceProperty")]
        [InlineData("Property3", "ReferenceProperty")]
        [InlineData("IntegerProperty", "Property3")]
        public void WrapperPropertyValueHasValueWhenGetValueIsCalledAndPropertyDecoratorHasAPropertyDecoratorWrapee(string wrappeePropertyName, string wrapperPropertyName)
        {
            //Arrange
            PropertyDecoratorTestType instanceToTest = CreateInstanceToTest(2);
            var propertyDecoratorWrappee = new PropertyDecorator() { PropertyName = wrappeePropertyName };
            var propertyDecorator = new PropertyDecorator(propertyDecoratorWrappee) { PropertyName = wrapperPropertyName };

            //Act
            propertyDecorator.GetValue(instanceToTest);

            //Assert
            Assert.NotNull(propertyDecorator.PropertyValue);
        }

        [Theory]
        [InlineData("Property1", "ReferenceProperty", typeof(int))]
        [InlineData("Property2", "ReferenceProperty", typeof(string))]
        [InlineData("Property3", "ReferenceProperty", typeof(AType))]
        [InlineData("IntegerProperty", "Property3", typeof(int))]
        public void WrappeePropertyValueIsOfCorrectTypeWhenGetValueIsCalledAndPropertyDecoratorHasAPropertyDecoratorWrapee(
            string wrappeePropertyName,
            string wrapperPropertyName,
            Type expectedType)
        {
            //Arrange
            PropertyDecoratorTestType instanceToTest = CreateInstanceToTest(2);
            var propertyDecoratorWrappee = new PropertyDecorator() { PropertyName = wrappeePropertyName };
            var propertyDecorator = new PropertyDecorator(propertyDecoratorWrappee) { PropertyName = wrapperPropertyName };

            //Act
            propertyDecorator.GetValue(instanceToTest);

            //Assert
            Assert.IsType(expectedType, propertyDecoratorWrappee.PropertyValue);
        }

        [Theory]
        [InlineData("Property1", "ReferenceProperty", typeof(PropertyDecoratorTestType))]
        [InlineData("Property2", "ReferenceProperty", typeof(PropertyDecoratorTestType))]
        [InlineData("Property3", "ReferenceProperty", typeof(PropertyDecoratorTestType))]
        [InlineData("IntegerProperty", "Property3", typeof(AType))]
        public void WrapperPropertyValueIsOfCorrectTypeWhenGetValueIsCalledAndPropertyDecoratorHasAPropertyDecoratorWrapee(
            string wrappeePropertyName,
            string wrapperPropertyName,
            Type expectedType)
        {
            //Arrange
            PropertyDecoratorTestType instanceToTest = CreateInstanceToTest(2);
            var propertyDecoratorWrappee = new PropertyDecorator() { PropertyName = wrappeePropertyName };
            var propertyDecorator = new PropertyDecorator(propertyDecoratorWrappee) { PropertyName = wrapperPropertyName };

            //Act
            propertyDecorator.GetValue(instanceToTest);

            //Assert
            Assert.IsType(expectedType, propertyDecorator.PropertyValue);
        }

        [Theory]
        [InlineData("Property1", "ReferenceProperty", 1)]
        [InlineData("Property2", "ReferenceProperty", "test - 1")]
        [InlineData("IntegerProperty", "Property3", 1)]
        public void WrappeePropertyValueIsOfCorrectValueWhenGetValueIsCalledAndPropertyDecoratorHasAPropertyDecoratorWrapee(
            string wrappeePropertyName,
            string wrapperPropertyName,
            object expectedValue)
        {
            //Arrange
            PropertyDecoratorTestType instanceToTest = CreateInstanceToTest(2);
            var propertyDecoratorWrappee = new PropertyDecorator() { PropertyName = wrappeePropertyName };
            var propertyDecorator = new PropertyDecorator(propertyDecoratorWrappee) { PropertyName = wrapperPropertyName };

            //Act
            propertyDecorator.GetValue(instanceToTest);

            //Assert
            Assert.Equal(expectedValue, propertyDecoratorWrappee.PropertyValue);
        }

        [Theory]
        [InlineData("Property1", "ReferenceProperty")]
        [InlineData("Property2", "ReferenceProperty")]
        public void WrapperPropertyValueIsOfCorrectValueWhenGetValueIsCalledAndPropertyDecoratorHasAPropertyDecoratorWrapee(
            string wrappeePropertyName,
            string wrapperPropertyName)
        {
            //Arrange
            PropertyDecoratorTestType instanceToTest = CreateInstanceToTest(2);
            var propertyDecoratorWrappee = new PropertyDecorator() { PropertyName = wrappeePropertyName };
            var propertyDecorator = new PropertyDecorator(propertyDecoratorWrappee) { PropertyName = wrapperPropertyName };

            //Act
            propertyDecorator.GetValue(instanceToTest);

            //Assert
            Assert.Equal(instanceToTest.ReferenceProperty, propertyDecorator.PropertyValue);
        }

        [Theory]
        [InlineData("Property1", "ReferenceProperty", "ReferenceProperty")]
        [InlineData("Property2", "ReferenceProperty", "ReferenceProperty")]
        [InlineData("Property3", "ReferenceProperty", "ReferenceProperty")]
        [InlineData("IntegerProperty", "Property3", "ReferenceProperty")]
        public void LastWrappeePropertyValueHasValueWhenGetValueIsCalledAndPropertyDecoratorHas2LayersOfWrappees(
            string lastWrapeePropertyName,
            string firstWrapeePropertyName,
            string wrapperPropertyName)
        {
            //Arrange
            PropertyDecoratorTestType instanceToTest = CreateInstanceToTest(3);
            var propertyDecoratorLastWrappee = new PropertyDecorator() { PropertyName = lastWrapeePropertyName };
            var propertyDecoratorFirstWrapee = new PropertyDecorator(propertyDecoratorLastWrappee) { PropertyName = firstWrapeePropertyName };
            var propertyDecorator = new PropertyDecorator(propertyDecoratorFirstWrapee) { PropertyName = wrapperPropertyName };

            //Act
            propertyDecorator.GetValue(instanceToTest);

            //Assert
            Assert.NotNull(propertyDecoratorLastWrappee.PropertyValue);
        }

        [Theory]
        [InlineData("Property1", "ReferenceProperty", "ReferenceProperty", typeof(int))]
        [InlineData("Property2", "ReferenceProperty", "ReferenceProperty", typeof(string))]
        [InlineData("Property3", "ReferenceProperty", "ReferenceProperty", typeof(AType))]
        [InlineData("IntegerProperty", "Property3", "ReferenceProperty", typeof(int))]
        public void LastWrappeePropertyValueIsOfCorrectTypeWhenGetValueIsCalledAndPropertyDecoratorHas2LayersOfWrappees(
            string lastWrapeePropertyName,
            string firstWrapeePropertyName,
            string wrapperPropertyName,
            Type expectedType)
        {
            //Arrange
            PropertyDecoratorTestType instanceToTest = CreateInstanceToTest(3);
            var propertyDecoratorLastWrappee = new PropertyDecorator() { PropertyName = lastWrapeePropertyName };
            var propertyDecoratorFirstWrapee = new PropertyDecorator(propertyDecoratorLastWrappee) { PropertyName = firstWrapeePropertyName };
            var propertyDecorator = new PropertyDecorator(propertyDecoratorFirstWrapee) { PropertyName = wrapperPropertyName };

            //Act
            propertyDecorator.GetValue(instanceToTest);

            //Assert
            Assert.IsType(expectedType, propertyDecoratorLastWrappee.PropertyValue);
        }

        [Theory]
        [InlineData("Property1", "ReferenceProperty", "ReferenceProperty", 1)]
        [InlineData("Property2", "ReferenceProperty", "ReferenceProperty", "test - 1")]
        [InlineData("IntegerProperty", "Property3", "ReferenceProperty", 1)]
        public void LastWrappeePropertyValueIsOfCorrectValueWhenGetValueIsCalledAndPropertyDecoratorHas2LayersOfWrappees(
            string lastWrapeePropertyName,
            string firstWrapeePropertyName,
            string wrapperPropertyName,
            object expectedValue)
        {
            //Arrange
            PropertyDecoratorTestType instanceToTest = CreateInstanceToTest(3);
            var propertyDecoratorLastWrappee = new PropertyDecorator() { PropertyName = lastWrapeePropertyName };
            var propertyDecoratorFirstWrapee = new PropertyDecorator(propertyDecoratorLastWrappee) { PropertyName = firstWrapeePropertyName };
            var propertyDecorator = new PropertyDecorator(propertyDecoratorFirstWrapee) { PropertyName = wrapperPropertyName };

            //Act
            propertyDecorator.GetValue(instanceToTest);

            //Assert
            Assert.Equal(expectedValue, propertyDecoratorLastWrappee.PropertyValue);
        }

        [Theory]
        [InlineData("Property1", "ReferenceProperty", "ReferenceProperty", 1)]
        [InlineData("Property2", "ReferenceProperty", "ReferenceProperty", "test - 1")]
        public void AllPropertyValueIsOfCorrectValueWhenGetValueIsCalledAndPropertyDecoratorHas2LayersOfWrappees(
            string lastWrapeePropertyName,
            string firstWrapeePropertyName,
            string wrapperPropertyName,
            object expectedValue)
        {
            //Arrange
            PropertyDecoratorTestType instanceToTest = CreateInstanceToTest(3);
            var propertyDecoratorLastWrappee = new PropertyDecorator() { PropertyName = lastWrapeePropertyName };
            var propertyDecoratorFirstWrapee = new PropertyDecorator(propertyDecoratorLastWrappee) { PropertyName = firstWrapeePropertyName };
            var propertyDecorator = new PropertyDecorator(propertyDecoratorFirstWrapee) { PropertyName = wrapperPropertyName };

            //Act
            propertyDecorator.GetValue(instanceToTest);

            //Assert
            var propertyInfo = typeof(PropertyDecoratorTestType).GetProperty(lastWrapeePropertyName);

            Assert.Equal(expectedValue, propertyDecoratorLastWrappee.PropertyValue);
            Assert.Equal(propertyInfo.GetValue(instanceToTest.ReferenceProperty), propertyInfo.GetValue(propertyDecorator.PropertyValue as PropertyDecoratorTestType));
            Assert.Equal(propertyInfo.GetValue(instanceToTest.ReferenceProperty.ReferenceProperty), propertyInfo.GetValue(propertyDecoratorFirstWrapee.PropertyValue as PropertyDecoratorTestType));
        }

        [Fact]
        public void LastWrappeePropertyValueThrowsInvalidOperationExceptionWhenGetValueIsCalledAndInstanceHasNotTheProperty()
        {
            //Arrange
            PropertyDecoratorTestType instanceToTest = CreateInstanceToTest(3);
            var propertyDecoratorLastWrappee = new PropertyDecorator() { PropertyName = "gibberish" };
            var propertyDecoratorFirstWrapee = new PropertyDecorator(propertyDecoratorLastWrappee) { PropertyName = "ReferenceProperty" };
            var propertyDecorator = new PropertyDecorator(propertyDecoratorFirstWrapee) { PropertyName = "ReferenceProperty" };

            //Assert
            Assert.Throws<InvalidOperationException>(() => propertyDecoratorLastWrappee.GetValue(instanceToTest));
        }

        [Fact]
        public void MiddleWrappeePropertyValueThrowsInvalidOperationExceptionWhenGetValueIsCalledAndInstanceHasNotTheProperty()
        {
            //Arrange
            PropertyDecoratorTestType instanceToTest = CreateInstanceToTest(3);
            var propertyDecoratorLastWrappee = new PropertyDecorator() { PropertyName = "Property1" };
            var propertyDecoratorFirstWrapee = new PropertyDecorator(propertyDecoratorLastWrappee) { PropertyName = "gibberish" };
            var propertyDecorator = new PropertyDecorator(propertyDecoratorFirstWrapee) { PropertyName = "ReferenceProperty" };

            //Assert
            Assert.Throws<InvalidOperationException>(() => propertyDecoratorFirstWrapee.GetValue(instanceToTest));
        }

        [Theory]
        [InlineData("gibberish", "ReferenceProperty", "ReferenceProperty")]
        [InlineData("Property1", "gibberish", "ReferenceProperty")]
        [InlineData("Property2", "gibberish", "ReferenceProperty")]
        [InlineData("Property3", "gibberish", "ReferenceProperty")]
        [InlineData("Property1", "gibberish", "gibberish")]
        [InlineData("Property2", "gibberish", "gibberish")]
        [InlineData("Property3", "gibberish", "gibberish")]
        public void InvalidOperationExceptionPropagatesBackToParentDecoratorsWhenAChildDecoratorThrows(
            string lastWrapeePropertyName,
            string firstWrapeePropertyName,
            string wrapperPropertyName)
        {
            //Arrange
            PropertyDecoratorTestType instanceToTest = CreateInstanceToTest(3);
            var propertyDecoratorLastWrappee = new PropertyDecorator() { PropertyName = lastWrapeePropertyName };
            var propertyDecoratorFirstWrapee = new PropertyDecorator(propertyDecoratorLastWrappee) { PropertyName = firstWrapeePropertyName };
            var propertyDecorator = new PropertyDecorator(propertyDecoratorFirstWrapee) { PropertyName = wrapperPropertyName };

            //Assert
            Assert.Throws<InvalidOperationException>(() => propertyDecorator.GetValue(instanceToTest));
        }
    }
}
