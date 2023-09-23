using System;
namespace ChainOfResponsibility.YT_POApprover.Component
{
    public class POSystem
    {
        protected POApprover approverChain = null;

        public POSystem()
        {
            approverChain =
                new Manager
                (new VicePresident
                (new CEO(null)));
        }

        public void ProcessRequest(decimal price)
        {
            approverChain.ProcessRequest(price);
        }
    }
}
