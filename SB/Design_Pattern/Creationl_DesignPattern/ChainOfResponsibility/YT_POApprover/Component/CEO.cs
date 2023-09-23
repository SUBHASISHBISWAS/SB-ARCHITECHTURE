using System;
namespace ChainOfResponsibility.YT_POApprover.Component
{
    public class CEO :POApprover
    {
        public CEO(POApprover successor)
        {
            _successor = successor;
        }

        public override void ProcessRequest(decimal price)
        {
            if (price < 100000)
            {
                Console.WriteLine("${0} purchased approved by {1}", price,
                    this.GetType().Name);
            }
            else if (_successor != null)
            {
                // pass the request to successor
                Console.WriteLine("Overlimit : Plan executive metting");
                
            }
        }
    }
}
