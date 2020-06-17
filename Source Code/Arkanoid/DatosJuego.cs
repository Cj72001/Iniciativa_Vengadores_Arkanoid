namespace Arkanoid
{
    public static class GameData
    {
        public static bool gameStarted = false;
        public static double ticksCount = 0;
        public static int dirX = 7, dirY = -dirX, lifes = 3, score = 0;
        
        public static void InitializeGame()
        {
            gameStarted = false;
            lifes = 3;
            score = 0;
        }
    }
}
