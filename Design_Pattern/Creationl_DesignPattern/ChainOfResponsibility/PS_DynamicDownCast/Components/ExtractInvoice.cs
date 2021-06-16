using System;
using ChainOfResponsibility.PS_DynamicDownCast.Interfaces;

namespace ChainOfResponsibility.PS_DynamicDownCast.Common
{
    public class ExtractInvoice : ExtractComponent, IExtractInvoice
    {
        public ExtractInvoice(IExtractComponent nextExtractComponent):
            base(nextExtractComponent)
        {

        }
        public ExtractInvoice()
        {

        }
        public void GetInvoice()
        {
            Console.WriteLine("Get Invoice");
        }
    }
}
