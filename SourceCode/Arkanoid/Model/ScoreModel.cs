using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkanoid.Model
{
    class ScoreModel
    {
        public string User { get; set; }
        public string Attempt { get; set; }
        public string Scores { get; set; }

        public ScoreModel(string user, string attempt, string scores)
        {
            User = user;
            Attempt = attempt;
            Scores = scores;
        }
    }
}
