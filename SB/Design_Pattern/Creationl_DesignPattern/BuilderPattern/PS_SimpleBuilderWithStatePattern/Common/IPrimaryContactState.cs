using BuilderDemo.Interfaces;

namespace BuilderDemo.Common
{
    internal interface IPrimaryContactState
    {
        IPrimaryContactState Set(IContactInfo contact);
        IContactInfo Get();
    }

}
