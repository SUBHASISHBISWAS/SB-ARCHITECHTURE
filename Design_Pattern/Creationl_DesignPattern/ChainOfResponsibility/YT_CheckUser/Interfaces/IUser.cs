using System;
namespace ChainOfResponsibility.YT_CheckUser.Interfaces
{
    public interface IUser
    {
        string UserID { get; set; }
        string Name { get; set; }
        string Password { get; set; }
    }
}
