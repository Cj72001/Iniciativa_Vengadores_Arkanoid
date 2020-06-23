using System;

namespace Arkanoid.Controllers
{
    public class ExceededMaxCharactersException : Exception //exceso
    {
        public ExceededMaxCharactersException(string Message) : base(Message){}
    }
}