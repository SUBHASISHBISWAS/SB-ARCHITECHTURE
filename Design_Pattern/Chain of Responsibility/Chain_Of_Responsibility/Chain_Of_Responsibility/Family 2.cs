using System;
using System.Collections;
using System.Collections.Generic;
using Family.Common;

namespace Chain_Of_Responsibility
{
    public class Family
    {
        private IEnumerable<object> members;

        public Family(IEnumerable<object> members)
        {
            this.members = new List<object>(members);
        }

        public void WinterBegins()
        {
            Console.WriteLine("Winter....Begins");
            foreach (var obj in this.members)
            {
                this.GrowHair(obj);
                this.GrowBeared(obj);
            }
            Console.WriteLine(new string('-',20));

        }

        public void SummerComes()
        {
            Console.WriteLine("Summer....Begins");
            foreach (var obj in this.members)
            {
                this.BeHappy(obj);
            }
            Console.WriteLine(new string('-', 20));
        }

        private void BeHappy(object obj)
        {
            IEmotional emotional = obj as IEmotional;
            if (emotional!=null)
            {
                Console.WriteLine("{0}",obj.GetType().Name);
                emotional.BeHappy();
            }
        }

        private void GrowBeared(object obj)
        {
            IBeared beared = obj as IBeared;
            if (beared != null)
            {
                Console.WriteLine("{0}", obj.GetType().Name);
                beared.GrowBeared();
            }
        }

        private void GrowHair(object obj)
        {
            IHairy hairy = obj as IHairy;
            if (hairy != null)
            {
                Console.WriteLine("{0}", obj.GetType().Name);
                hairy.GrowHair();
            }
        }
    }
}
