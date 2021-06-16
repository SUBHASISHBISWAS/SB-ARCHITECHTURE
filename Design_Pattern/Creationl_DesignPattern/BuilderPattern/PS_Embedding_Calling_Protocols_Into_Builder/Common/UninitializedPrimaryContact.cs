using System;
using BuilderDemo.Interfaces;

namespace Embedding_Calling_Protocols_Into_Builder
{
    internal class UninitializedPrimaryContact : IPrimaryContactState
    {

        private Func<IContactInfo, bool> Predicate { get; }

        public UninitializedPrimaryContact(Func<IContactInfo, bool> predicate)
        {
            if (predicate == null)
                throw new ArgumentNullException();
            this.Predicate = predicate;
        }

        public IPrimaryContactState Set(IContactInfo contact)
        {
            return new ValidPrimaryContact(contact, this.Predicate);
        }

        public IContactInfo Get()
        {
            throw new InvalidOperationException();
        }
    }
}
