using System.Linq.Expressions;

namespace HTMLParser.Decorator
{
    public class ArrayDecorator : BaseDecorator
    {
        public string PropertyName { get; set; } = string.Empty;
        public int Index { get; set; }
        public object[]? ArrayValue { get; set; }
        public object? ElementValue { get; set; }
        public ArrayDecorator(IClassElement? wrappee = null) : base(wrappee) { }
        public override void GetValue(object instance)
        {
            if (ArrayValue is null)
            {
                var type = instance.GetType();
                var instanceParam = Expression.Parameter(type);
                var getMethodInfo = (type.GetProperty(PropertyName)?.GetGetMethod()) ??
                    throw new InvalidOperationException($"the instance provided doesn't have an array property of name {PropertyName}");

                var expression = Expression.Lambda(
                      Expression.Convert(
                          Expression.Call(instanceParam, getMethodInfo),
                          typeof(object)
                      ),
                    instanceParam).Compile();

                var propertyValue = (Array)expression.DynamicInvoke(instance);
                ArrayValue = new object[propertyValue.Length];
                propertyValue.CopyTo(ArrayValue, 0);
            }

            if (Index >= ArrayValue.Length)
                throw new InvalidOperationException($"{Index} is out of bounds of the array property {PropertyName}");
            ElementValue = ArrayValue[Index];
        }
    }
}
