using System;
using ChainOfResponsibility.PS_DynamicDownCast.Interfaces;

namespace ChainOfResponsibility.PS_DynamicDownCast.Common
{
    public class ExtractCustomer : ExtractComponent,IExtractCustomer 
    {
        public ExtractCustomer(IExtractComponent nextExtractComponent):
            base(nextExtractComponent)
        {

        }
        public ExtractCustomer()
        {

        }

        public void GetCustomers()
        {
            Console.WriteLine("Get Customers");
        }
    }
}
