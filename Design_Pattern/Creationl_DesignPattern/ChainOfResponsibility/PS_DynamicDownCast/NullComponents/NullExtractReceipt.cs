using System;
using ChainOfResponsibility.PS_DynamicDownCast.Interfaces;

namespace ChainOfResponsibility.PS_DynamicDownCast.NullComponents
{
    
    public class NullExtractReceipt : IExtractReceipt
    {
        private static IExtractReceipt instance;

        private NullExtractReceipt() { }

        public static IExtractReceipt Instance
        {
            get
            {
                if (instance == null)
                    instance = new NullExtractReceipt();
                return instance;
            }
        }

        public void CreateReceipt()
        { }
        
    }
}
