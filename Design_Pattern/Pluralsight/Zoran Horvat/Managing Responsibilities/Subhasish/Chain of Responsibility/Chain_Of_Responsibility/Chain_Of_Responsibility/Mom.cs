using System;
using Family.Common;

namespace Chain_Of_Responsibility
{
    public class Mom :IEmotional,IHairy
    {
        public Mom()
        {
        }

        public void BeHappy()
        {
            Console.WriteLine("hi hi");
        }

        public void GrowHair()
        {
            Console.WriteLine("Hair Grows");
        }
    }
}
