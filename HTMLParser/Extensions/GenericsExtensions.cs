using System.Reflection;

namespace HTMLParser.Extensions
{
    public static class GenericsExtensions
    {
        public static PropertyInfo? GetPropertyOrDefault(this object model, string propertyName)
            => model.GetType().GetProperty(propertyName);

    }
}
