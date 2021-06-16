using System;
using ChainOfResponsibility.YT_CheckUser.Interfaces;

namespace ChainOfResponsibility.YT_CheckUser.Common
{
    public class CheckId : CheckUser
    {
        public CheckId()
        {
        }

        public override void Check(IUser user)
        {
            if (user.UserID==null)
            {
                throw new ArgumentException("ID Not Exist");
            }
            else
            {
                Console.WriteLine("Id Available");
                Next(user);
            }
        }
    }
}
