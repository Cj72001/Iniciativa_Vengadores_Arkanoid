using System;

namespace Arkanoid.Controllers
{
    public class ExceededMaxCharactersException : Exception
    {
        public ExceededMaxCharactersException(string Message) : base(Message){}
    }
}