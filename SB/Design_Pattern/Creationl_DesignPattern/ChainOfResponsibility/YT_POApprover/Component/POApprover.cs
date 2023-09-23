using System;
namespace ChainOfResponsibility.YT_POApprover.Component
{
    public abstract class POApprover
    {
        protected POApprover _successor;

        public abstract void ProcessRequest(decimal price);
    }
}
