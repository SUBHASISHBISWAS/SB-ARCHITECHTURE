using System;
using System.Collections.Generic;
using BuilderDemo.Interfaces;

namespace Embedding_Calling_Protocols_Into_Builder
{
    public class Person : IUser
    {
        public string Name { get; }
        public string Surname { get; }
        private IList<IContactInfo> Contacts { get; } = new List<IContactInfo>();
        private IContactInfo PrimaryContact { get; set; }

        public Person(string name, string surname)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException();
            if (string.IsNullOrEmpty(surname))
                throw new ArgumentException();

            this.Name = name;
            this.Surname = surname;
        }

        public void SetIdentity(IUserIdentity identity) { }

        public bool CanAcceptIdentity(IUserIdentity identity) =>
            identity is IdentityCard;

        public override string ToString() => $"{this.Name} {this.Surname}";

        public void Add(IContactInfo contact)
        {
            if (contact == null)
            {
                throw new ArgumentException();
            }
            this.Contacts.Add(contact);
        }


        public void SetPrimaryContact(IContactInfo contact)
        {
            if (contact == null)
            {
                throw new ArgumentException("");
            }

            if (!Contacts.Contains(contact))
            {
                throw new ArgumentException("");
            }

            PrimaryContact = contact;
        }
    }
}
