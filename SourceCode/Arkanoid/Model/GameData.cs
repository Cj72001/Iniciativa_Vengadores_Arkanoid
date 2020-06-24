namespace Arkanoid.Model
{
    public static class GameData
    {
        public static bool gameStarted = false;
        public static double ticksMade = 0;
        public static int dirX = 15, dirY = -dirX, lives = 3, score = 0 ;

        public static void InitializeGame()
        {
            gameStarted = false;
            lives = 3;
            score = 0;
        }
 

    }
}