using System;
using ChainOfResponsibility.PS_DynamicDownCast.Interfaces;

namespace ChainOfResponsibility.PS_DynamicDownCast.NullComponents
{
    public class NullExtractInvoice : IExtractInvoice
    {
        private static IExtractInvoice instance;

        private NullExtractInvoice() { }

        public static IExtractInvoice Instance
        {
            get
            {
                if (instance == null)
                    instance = new NullExtractInvoice();
                return instance;
            }
        }

        public void GetInvoice()
        {
        }
    }
}
