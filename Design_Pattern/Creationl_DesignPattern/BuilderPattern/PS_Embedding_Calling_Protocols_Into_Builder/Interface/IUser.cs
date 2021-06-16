namespace Embedding_Calling_Protocols_Into_Builder
{
    public interface IUser: ITicketHolder
    {
        void SetIdentity(IUserIdentity identity);
        bool CanAcceptIdentity(IUserIdentity identity);
    }
}
