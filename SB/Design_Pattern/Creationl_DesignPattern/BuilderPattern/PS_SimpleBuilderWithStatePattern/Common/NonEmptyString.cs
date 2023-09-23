using System;

namespace BuilderDemo.Common
{
    internal class NonEmptyString: INonEmptyStringState
    {

        private string Value { get; }

        public NonEmptyString(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException();
            this.Value = value;
        }

        public INonEmptyStringState Set(string value) => new NonEmptyString(value);

        public string Get() => this.Value;

    }
}
