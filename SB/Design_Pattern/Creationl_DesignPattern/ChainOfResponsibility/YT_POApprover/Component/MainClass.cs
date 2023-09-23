using System;
namespace ChainOfResponsibility.YT_POApprover.Component
{
    public class MainClass
    {
        public static void Main(string [] arags)
        {
            var poSystem = new POSystem();
            poSystem.ProcessRequest(1000);
            poSystem.ProcessRequest(20000);
            poSystem.ProcessRequest(50000);
        }
    }
}
