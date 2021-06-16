using System;
namespace ChainOfResponsibility.PS_DynamicDownCast.Interfaces
{
    public class NullExtractComponent:IExtractComponent
    {
        private static IExtractComponent instance;
        private NullExtractComponent()
        {
        }

        public static IExtractComponent Instance
        {
            get
            {
                if (instance == null)
                    instance = new NullExtractComponent();
                return instance;
            }
        }
        public T As<T>(T defaultValue) where T : class
        {
            return defaultValue;
        }
    }
}
