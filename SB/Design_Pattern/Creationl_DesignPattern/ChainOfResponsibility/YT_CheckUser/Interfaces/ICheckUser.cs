using System;
namespace ChainOfResponsibility.YT_CheckUser.Interfaces
{
    public interface ICheckUser
    {
        void Then(ICheckUser check);
        void Next(IUser user);
        void Check(IUser user);
    }
}
