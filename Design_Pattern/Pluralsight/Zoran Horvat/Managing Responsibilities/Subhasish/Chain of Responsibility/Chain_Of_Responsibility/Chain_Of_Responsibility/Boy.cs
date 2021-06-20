using System;
using Family.Common;

namespace Chain_Of_Responsibility
{
    public class Boy:IEmotional
    {
        public Boy()
        {
        }

        public void BeHappy()
        {
            Console.WriteLine("Ha Ha Ha");
        }
    }
}
