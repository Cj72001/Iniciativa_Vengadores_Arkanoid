namespace Arkanoid.Model
{
    public static class GameData
    {
        public static bool GameStarted = false;
        public static double ticksMade = 0;
        public static int dirX = 15, dirY = -dirX, lives = 3, score = 0 ;

        public static void InitializeGame()
        {
            GameStarted = false;
            lives = 3;
            score = 0;
        }
 

    }
}