using System;

namespace Arkanoid.Controllers
{
    public class EmpyNicknameException : Exception
    {
        public EmpyNicknameException(string Message) : base(Message){ }
    }
}