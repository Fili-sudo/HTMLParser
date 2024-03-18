using System.Linq.Expressions;
using System.Reflection;

namespace HTMLParser.Decorator
{
    public class MethodDecorator : BaseDecorator
    {
        public MethodDecorator(IClassElement? wrappee = null) : base(wrappee) { }

        public string MethodName { get; set; } = string.Empty;
        public object[] Parameters { get; set; }
        public object? Result { get; set; }
        public override void GetValue(object instance)
        {
            var type = instance.GetType();
            var instanceParam = Expression.Parameter(type);
            var methodInfo = type.GetMethod(MethodName) ??
                throw new InvalidOperationException($"the instance provided doesn't have a {MethodName} method");

            var parametersInfo = methodInfo.GetParameters();
            List<Expression> parameters = new();

            foreach (var parameter in Parameters.Select((value, index) => (value, index)))
            {
                var parameterType = parameter.value.GetType();
                try
                {
                    CheckMethodParameters(parametersInfo[parameter.index], parameterType);
                }
                catch (InvalidOperationException) { throw; }

                parameters.Add(Expression.Constant(parameter.value));
            }
            var expression = Expression.Lambda(
                  Expression.Convert(
                    Expression.Call(instanceParam, methodInfo, parameters),
                    typeof(object)
                  ),
                instanceParam).Compile();

            Result = expression.DynamicInvoke(instance);

            if (Wrappee is not null && Result is not null)
            {
                try
                {
                    Wrappee.GetValue(Result);
                }
                catch (InvalidOperationException) { throw; }
            }
        }

        private void CheckMethodParameters(ParameterInfo parameterInfo, Type parameterType)
        {
            if (parameterType != parameterInfo.ParameterType)
            {
                throw new InvalidOperationException(
                    $"{MethodName}'s parameter {parameterInfo.Name} expected a parameter of type {parameterInfo.ParameterType} " +
                    $"and instead it was given a parameter of type {parameterType}");
            }
        }
    }
}
