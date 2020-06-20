namespace Arkanoid.Model
{
    public class User
    {
        
        public string userName { get; set; }
        
        public int score { get; set; }
        
        
        
        public User(string userName, int score)
        {
            this.userName = userName;
            this.score = score;
        }
    }
}