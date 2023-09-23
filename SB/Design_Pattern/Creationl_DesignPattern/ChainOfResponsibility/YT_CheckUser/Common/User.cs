using System;
using ChainOfResponsibility.YT_CheckUser.Interfaces;

namespace ChainOfResponsibility.YT_CheckUser.Common
{
    public class User:IUser
    {
        public User()
        {
        }

        public string UserID { get => "1234"; set => throw new NotImplementedException(); }
        public string Name { get => null; set => throw new NotImplementedException(); }
        public string Password { get => "Password"; set => throw new NotImplementedException(); }
    }
}
