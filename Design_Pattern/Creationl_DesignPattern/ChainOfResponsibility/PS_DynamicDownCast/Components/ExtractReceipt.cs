using System;
using ChainOfResponsibility.PS_DynamicDownCast.Interfaces;

namespace ChainOfResponsibility.PS_DynamicDownCast.Common
{
    public class ExtractReceipt :ExtractComponent, IExtractReceipt
    {
        public ExtractReceipt(IExtractComponent nextExtractComponent) :
            base(nextExtractComponent)
        {
        }
        public ExtractReceipt()
        {

        }
        public void CreateReceipt()
        {
            Console.WriteLine("Get Receipt");
        }
    }
}
