using System;

namespace Arkanoid.Controllers
{
    public class NoRemainingLivesException : Exception
    {
        public NoRemainingLivesException(string Message) : base(Message){}
    }
}