using System;
using ChainOfResponsibility.PS_DynamicDownCast.Common;

namespace ChainOfResponsibility.PS_DynamicDownCast.Main
{
    public class MainClass
    {
       /*
        static void Main(string[] args)
        {
            Component components =
            new Component(
                new ExtractCustomer(
                    new ExtractReceipt(
                        new ExtractInvoice())));

            InvoiceComponents invoiceComponent =
                new InvoiceComponents(new Component[] { components });

            invoiceComponent.PerformInvoiceExtraction();
        }
       */
    }
}
