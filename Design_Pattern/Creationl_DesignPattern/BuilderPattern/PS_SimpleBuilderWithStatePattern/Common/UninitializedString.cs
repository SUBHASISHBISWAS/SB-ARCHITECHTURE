namespace BuilderDemo.Common
{
    internal class UninitializedString: INonEmptyStringState
    {
        public INonEmptyStringState Set(string value) => new NonEmptyString(value);

        public string Get()
        {
            throw new System.InvalidOperationException();
        }
    }
}
