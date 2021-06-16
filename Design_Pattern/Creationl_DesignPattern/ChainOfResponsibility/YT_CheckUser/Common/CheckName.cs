using System;
using ChainOfResponsibility.YT_CheckUser.Interfaces;

namespace ChainOfResponsibility.YT_CheckUser.Common
{
    public class CheckName : CheckUser
    {
        public override void Check(IUser user)
        {
            if (user.Name == null)
            {
                throw new ArgumentException("Name Not Exist");
            }
            else
            {
                Console.WriteLine("Name Available");
                Next(user);
            }
        }
    }
}
