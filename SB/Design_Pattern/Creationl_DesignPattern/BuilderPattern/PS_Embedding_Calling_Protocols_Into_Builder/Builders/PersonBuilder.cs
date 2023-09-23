using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using BuilderDemo.Common;
using BuilderDemo.Interfaces;

namespace Embedding_Calling_Protocols_Into_Builder
{
    public class PersonBuilder
    {

        private INonEmptyStringState FirstNameState { get; set; } =
            new UninitializedString();

        private INonEmptyStringState LastNameState { get; set; } =
            new UninitializedString();

        private IList<IContactInfo> Contacts { get; set; }
        private IPrimaryContactState PrimaryContactState { get; set; }

        public PersonBuilder()
        {
            Contacts = new List<IContactInfo>();
            PrimaryContactState = new UninitializedPrimaryContact(Contacts.Contains);
        }
        public void SetFirstName(string firstName)
        {
            this.FirstNameState = this.FirstNameState.Set(firstName);
        }

        public void SetLastName(string lastName)
        {
            this.LastNameState = this.LastNameState.Set(lastName);
        }

        public void SetPrimaryContact(IContactInfo contact)
        {
            if (contact==null)
            {
                throw new ArgumentException("");
            }

            if (!Contacts.Contains(contact))
            {
                throw new ArgumentException("");
            }

            PrimaryContactState = PrimaryContactState.Set(contact);
        }

        public void Add(IContactInfo contact)
        {
            if (Contacts.Contains(contact))
            {
                throw new ArgumentException("");
            }
            this.Contacts.Add(contact);
        }

        public Person Build()
        {
            var person= new Person(this.FirstNameState.Get(), this.LastNameState.Get());
            foreach (var contact in Contacts)
            {
                person.Add(contact);
            }
            person.SetPrimaryContact(PrimaryContactState.Get());
            return person;
        }

        
    }
}
