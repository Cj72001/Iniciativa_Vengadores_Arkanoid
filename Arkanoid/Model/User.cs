namespace Arkanoid.Model
{
    public class User
    {
        public string IdUsuario { get; set; }

        public string NombreUsuario { get; set; }
        
        public User(string idUsuario, string nombreUsuario)
        {
            IdUsuario = idUsuario;
            NombreUsuario = nombreUsuario;
        }
    }
}