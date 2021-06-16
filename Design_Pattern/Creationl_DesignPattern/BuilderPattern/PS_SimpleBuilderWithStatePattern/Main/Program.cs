using System;
using BuilderDemo.Builders.Person;
using BuilderDemo.Interfaces;
using BuilderDemo.Models;

namespace BuilderDemo
{
    class Program
    {

        static void ConfigureUser()
        {
            PersonBuilder builder = new PersonBuilder();

            builder.SetFirstName("Subhasish");
            builder.SetLastName("Biswas");

            IContactInfo contact = new EmailAddress("Subhasishbiswas15@gmail.com");
            builder.Add(contact);

            Person person = builder.Build();

            Console.WriteLine(person);
        }

        
        /* 
        static void Main(string[] args)
        {

            ConfigureUser();

            Console.WriteLine("Reached end of demonstration...");
            Console.ReadLine();
        }
        */
    }
}
