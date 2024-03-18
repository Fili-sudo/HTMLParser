namespace HTMLParser.Decorator
{
    public abstract class BaseDecorator : IClassElement
    {
        protected BaseDecorator(IClassElement? wrappee = null)
        {
            Wrappee = wrappee;
        }

        public IClassElement? Wrappee { get; set; }

        public abstract void GetValue(object instance);
    }
}
