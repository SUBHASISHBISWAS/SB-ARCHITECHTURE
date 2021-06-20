using System;
using Family.Common;

namespace Chain_Of_Responsibility.Componenet
{
    public class Hairy : IHairy
    {
        private readonly string owner; 
        public Hairy(string owner)
        {
            this.owner = owner;
        }

        public void GrowHair()
        {
            Console.WriteLine("{0} Hair get Long",this.owner);
        }
    }
}
