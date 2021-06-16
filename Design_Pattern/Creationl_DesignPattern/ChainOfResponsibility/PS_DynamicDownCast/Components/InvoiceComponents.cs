using System;
using System.Collections.Generic;
using ChainOfResponsibility.PS_DynamicDownCast.Interfaces;
using ChainOfResponsibility.PS_DynamicDownCast.NullComponents;

namespace ChainOfResponsibility.PS_DynamicDownCast.Common
{
    public class InvoiceComponents
    {
        private readonly IEnumerable<Component> _components;

        public InvoiceComponents(IEnumerable<Component> components)
        {
            _components = components;

        }

        public void PerformInvoiceExtraction()
        {
            foreach (var component in _components)
            {
                component.As<IExtractCustomer>(NullExtractCustomer.Instance).
                    GetCustomers();
                component.As<IExtractReceipt>(NullExtractReceipt.Instance).
                    CreateReceipt();
                component.As<IExtractInvoice>(NullExtractInvoice.Instance).
                    GetInvoice();
            }
            Console.WriteLine(new string('-', 20));
        }
    }
}
