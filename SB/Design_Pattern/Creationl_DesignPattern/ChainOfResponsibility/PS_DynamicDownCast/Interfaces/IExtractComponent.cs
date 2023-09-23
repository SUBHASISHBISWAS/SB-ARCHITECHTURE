using System;
namespace ChainOfResponsibility.PS_DynamicDownCast.Interfaces
{
    public interface IExtractComponent
    {
        T As<T>(T defaultValue) where T : class;
    }
}
