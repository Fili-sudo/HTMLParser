namespace HTMLParser.Tests.Types
{
    public class PropertyDecoratorTestType
    {
        public int Property1 { get; set; }
        public string Property2 { get; set; }
        public AType Property3 { get; set; }
        public PropertyDecoratorTestType ReferenceProperty { get; set; }

        public string NoParameterMethod() => "empty param list";
        public string Method1(string word, int number) => $"{word} - {number} - {Property1}";
        public AType Method2(AType referenceType) => new();

        public PropertyDecoratorTestType Method3()
        {
            return new()
            {
                Property1 = 10,
                Property2 = "test 10",
                Property3 = new()
            };
        }

    }
}
