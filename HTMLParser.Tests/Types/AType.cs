namespace HTMLParser.Tests.Types
{
    public class AType
    {
        public int IntegerProperty { get; set; } = 1;

        public override bool Equals(object? obj)
        {
            return obj is AType type &&
                   IntegerProperty == type.IntegerProperty;
        }
    }
}
