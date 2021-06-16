using System;
namespace ChainOfResponsibility.PS_DynamicDownCast.Common
{
    public class Component
    {
        public Component()
        {

        }

        private readonly ExtractComponent components;

        public Component(ExtractComponent components)
        {
            this.components = components;
        } 

        public T As<T>(T defaultValue) where T : class
        {
            return this.components.As<T>(defaultValue);
        }
    }

}
