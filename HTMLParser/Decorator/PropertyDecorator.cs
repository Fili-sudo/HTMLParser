using System.Linq.Expressions;

namespace HTMLParser.Decorator
{
    public class PropertyDecorator : BaseDecorator
    {
        public string PropertyName { get; set; } = string.Empty;
        public object? PropertyValue { get; set; }
        public PropertyDecorator(IClassElement? wrappee = null) : base(wrappee)
        {
        }

        public override void GetValue(object instance)
        {
            var type = instance.GetType();
            var instanceParam = Expression.Parameter(type);
            var getMethodInfo = (type.GetProperty(PropertyName)?.GetGetMethod()) ??
                throw new InvalidOperationException($"the instance provided doesn't have a {PropertyName} property");

            var expression = Expression.Lambda(
                  Expression.Convert(
                      Expression.Call(instanceParam, getMethodInfo),
                      typeof(object)
                  ),
                instanceParam).Compile();

            PropertyValue = expression.DynamicInvoke(instance);

            if (Wrappee is not null && PropertyValue is not null)
            {
                try
                {
                    Wrappee.GetValue(PropertyValue);
                }
                catch (InvalidOperationException) { throw; }
            }
        }
    }
}
