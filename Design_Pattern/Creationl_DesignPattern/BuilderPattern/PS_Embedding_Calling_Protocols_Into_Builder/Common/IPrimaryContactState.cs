using BuilderDemo.Interfaces;

namespace Embedding_Calling_Protocols_Into_Builder
{
    internal interface IPrimaryContactState
    {
        IPrimaryContactState Set(IContactInfo contact);
        IContactInfo Get();
    }

}
