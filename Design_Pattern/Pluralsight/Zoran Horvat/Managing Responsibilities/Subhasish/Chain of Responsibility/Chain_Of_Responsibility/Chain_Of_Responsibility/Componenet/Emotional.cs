using System;
using Family.Common;

namespace Chain_Of_Responsibility.Componenet
{
    public class Emotional : IEmotional
    {
        private readonly string owner;
        private readonly string laughingSound;
        public Emotional(string owner, string laughingSound)
        {
            this.owner = owner;
            this.laughingSound = laughingSound;
        }

        public void BeHappy()
        {
            Console.WriteLine( "{0} : {1}",this.owner, this.laughingSound);
        }
    }
}
