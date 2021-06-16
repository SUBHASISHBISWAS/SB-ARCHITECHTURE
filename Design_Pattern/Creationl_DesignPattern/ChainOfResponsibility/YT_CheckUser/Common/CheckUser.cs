using System;
using ChainOfResponsibility.YT_CheckUser.Interfaces;

namespace ChainOfResponsibility.YT_CheckUser.Common
{
    public abstract class CheckUser : ICheckUser
    {
        ICheckUser checkNext;

        public CheckUser()
        {
            
        }

        public abstract void Check(IUser user);
        
        public void Next(IUser user)
        {
            if (checkNext == null)
            {
                return;
            }
            else
            {
                checkNext.Check(user);
            }
            

        }

        public void Then(ICheckUser check)
        {
            checkNext = check;
        }
    }
}
