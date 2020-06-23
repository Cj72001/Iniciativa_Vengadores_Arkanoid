using System;

namespace Arkanoid.Controllers
{
    public class EmpyNicknameException : Exception //vacio
    {
        public EmpyNicknameException(string Message) : base(Message){ }
    }
}