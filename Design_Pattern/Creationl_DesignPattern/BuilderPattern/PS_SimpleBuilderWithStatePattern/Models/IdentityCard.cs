using BuilderDemo.Interfaces;

namespace BuilderDemo.Models
{
    public class IdentityCard: IUserIdentity
    {
        public string SSN => "imagine one";
    }
}
