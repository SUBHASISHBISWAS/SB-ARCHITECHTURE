using System;
using BuilderDemo.Interfaces;

namespace BuilderDemo.Common
{
    internal class ValidPrimaryContact : IPrimaryContactState
    {

        private IContactInfo Contact { get; }
        private Func<IContactInfo, bool> Predicate { get; }

        public ValidPrimaryContact(IContactInfo contact, Func<IContactInfo, bool> predicate)
        {
            if (contact == null)
                throw new ArgumentNullException();

            if (predicate == null)
                throw new ArgumentNullException();

            if (!predicate(contact))
                throw new ArgumentException();

            this.Contact = contact;
            this.Predicate = predicate;

        }

        public IPrimaryContactState Set(IContactInfo contact)
        {
            return new ValidPrimaryContact(contact, this.Predicate);
        }

        public IContactInfo Get()
        {
            return this.Contact;
        }
    }

}
