using System;
namespace ChainOfResponsibility.YT_POApprover.Component
{
    public class Manager :POApprover
    {
        public Manager(POApprover successor)
        {
            _successor = successor;
        }

        public override void ProcessRequest(decimal price)
        {
            if (price <10000)
            {
                Console.WriteLine("${0} purchased approved by {1}",price,
                    this.GetType().Name);
            }
            else if(_successor!=null)
            {
                _successor.ProcessRequest(price);
            }
        }
    }
}
