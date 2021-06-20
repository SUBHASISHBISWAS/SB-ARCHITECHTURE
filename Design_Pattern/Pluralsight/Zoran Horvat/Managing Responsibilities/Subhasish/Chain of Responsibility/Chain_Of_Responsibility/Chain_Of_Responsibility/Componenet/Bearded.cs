using System;
using Family.Common;

namespace Chain_Of_Responsibility.Componenet
{ 
    public class Bearded : IBeared
    {
        private readonly string owner;
        public Bearded(string owner)
        {
            this.owner = owner;
        }

        public void GrowBeared()
        {
            Console.WriteLine("Bearded Grows By Owner {0}",owner);
        }
    }
}
