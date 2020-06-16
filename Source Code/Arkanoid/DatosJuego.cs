namespace Arkanoid
{
    public static class DatosJuego
    {
        public static bool juegoIniciado = false;
        public static double ticksRealizados = 0;
        public static int dirX = 7, dirY = -dirX, vidas = 3, puntaje = 0;
        
        public static void InicializarJuego()
        {
            juegoIniciado = false;
            vidas = 3;
            puntaje = 0;
        }
    }
}
