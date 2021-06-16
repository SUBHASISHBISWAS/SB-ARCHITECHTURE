using System;
namespace ChainOfResponsibility.YT_POApprover.Component
{
    public class VicePresident :POApprover
    {
        public VicePresident(POApprover successor)
        {
            _successor = successor;
        }

        public override void ProcessRequest(decimal price)
        {
            if (price < 25000)
            {
                Console.WriteLine("${0} purchased approved by {1}", price,
                    this.GetType().Name);
            }
            else if (_successor != null)
            {
                // pass the request to successor
                _successor.ProcessRequest(price);
            }
        }
    }
}
