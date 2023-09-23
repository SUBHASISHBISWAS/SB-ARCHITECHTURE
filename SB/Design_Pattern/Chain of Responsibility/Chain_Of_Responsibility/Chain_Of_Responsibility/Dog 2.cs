using System;
using Family.Common;

namespace Chain_Of_Responsibility
{
    public class Dog :IEmotional
    {
        public Dog()
        {
        }

        public void BeHappy()
        {
            Console.WriteLine("Tail Waiving");
        }
    }
}
