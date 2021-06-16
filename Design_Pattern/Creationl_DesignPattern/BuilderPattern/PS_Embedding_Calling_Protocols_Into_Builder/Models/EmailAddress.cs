using System;
using BuilderDemo.Interfaces;

namespace Embedding_Calling_Protocols_Into_Builder
{
    public class EmailAddress : IContactInfo
    {

        private string Address { get; }

        public EmailAddress(string address)
        {
            if (address == null)
                throw new ArgumentNullException();
            this.Address = address;
        }

        public override int GetHashCode()
        {
            return this.Address.ToLower().GetHashCode();
        }

        public override bool Equals(object obj)
        {

            EmailAddress email = obj as EmailAddress;

            if (email == null)
                return false;

            return string.Compare(this.Address, email.Address,
                                    StringComparison.InvariantCultureIgnoreCase) == 0;

        }

        public override string ToString() => $"{this.Address}";

    }
}
