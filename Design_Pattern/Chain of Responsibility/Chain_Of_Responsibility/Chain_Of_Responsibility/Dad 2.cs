using System;
using Family.Common;

namespace Chain_Of_Responsibility
{
    public class Dad : IBeared, IEmotional
    {
        public void BeHappy()
        {
            Console.WriteLine("ho ho");
        }

        public void GrowBeared()
        {
            Console.WriteLine("Beard grows");
        }
    }
}
