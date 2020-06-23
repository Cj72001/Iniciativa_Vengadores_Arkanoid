using System;

namespace Arkanoid.Controllers
{
    public class OutOfBoundsException : Exception
    {
        public OutOfBoundsException(string Message) : base(Message){}//fuera de bounds
    }
}