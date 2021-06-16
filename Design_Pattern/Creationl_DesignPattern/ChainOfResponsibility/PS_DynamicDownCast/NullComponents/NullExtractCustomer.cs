using System;
using ChainOfResponsibility.PS_DynamicDownCast.Interfaces;

namespace ChainOfResponsibility.PS_DynamicDownCast.NullComponents
{
    public class NullExtractCustomer : IExtractCustomer
    {
        private static IExtractCustomer instance;

        private NullExtractCustomer() { }

        public static IExtractCustomer Instance
        {
            get
            {
                if (instance == null)
                    instance = new NullExtractCustomer();
                return instance;
            }
        }

        public void GetCustomers()
        {

        }
    }
}

