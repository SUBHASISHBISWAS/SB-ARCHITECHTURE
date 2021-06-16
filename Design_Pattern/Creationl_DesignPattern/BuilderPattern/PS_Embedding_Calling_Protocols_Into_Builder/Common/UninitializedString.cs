namespace Embedding_Calling_Protocols_Into_Builder
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
