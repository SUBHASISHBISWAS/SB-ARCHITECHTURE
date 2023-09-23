using System;
using ChainOfResponsibility.YT_CheckUser.Interfaces;

namespace ChainOfResponsibility.YT_CheckUser.Common
{
    public class CheckPassword : CheckUser
    {
        public override void Check(IUser user)
        {
            if (user.Password == null)
            {
                throw new ArgumentException("ID Not Exist");
            }
            else
            {
                Console.WriteLine("Password Available");
                Next(user);
            }
        }
    }
}
