using System;
namespace Chain_Of_Responsibility
{
    public class Program
    {
        public static void Main(string [] args)
        {
            Family family = new Family(new object[]
            {
                new Dad(),new Mom(),new Boy(),new Dog()
            });

            family.WinterBegins();
            family.SummerComes();
        }
    }
}
