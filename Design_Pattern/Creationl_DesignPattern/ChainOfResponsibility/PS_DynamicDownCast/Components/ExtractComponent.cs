using System;
using ChainOfResponsibility.PS_DynamicDownCast.Interfaces;

namespace ChainOfResponsibility.PS_DynamicDownCast.Common
{
    public class ExtractComponent : IExtractComponent
    {
        private readonly IExtractComponent _nextExtractComponent;
        // Take it self as dependency
        public ExtractComponent(IExtractComponent extractComponent)
        {
            _nextExtractComponent = extractComponent;
        }

        protected ExtractComponent()
            : this(NullExtractComponent.Instance)
        { }

        //Recurshive call to the same method 
        public virtual T As<T>(T defaultValue) where T : class
        {
            //Base Condistion for recursion
            if (this is T )
            {
                return this as T;
            }
            return _nextExtractComponent.As<T>(defaultValue) as T; 
        }
        
    }
}
