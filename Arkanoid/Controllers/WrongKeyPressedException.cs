using System;

namespace Arkanoid.Controllers
{
    public class WrongKeyPressedException : Exception
    {
        public WrongKeyPressedException(string Message) : base(Message){}//presionar tecla 
    }
}