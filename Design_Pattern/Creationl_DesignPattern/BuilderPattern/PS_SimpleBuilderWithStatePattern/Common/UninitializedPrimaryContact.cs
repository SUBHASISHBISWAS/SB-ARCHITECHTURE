using System;
using BuilderDemo.Interfaces;

namespace BuilderDemo.Common
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
