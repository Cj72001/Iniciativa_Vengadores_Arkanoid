using Arkanoid.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkanoid.Controllers
{
     static class ScoreController
    {
        public static DataTable GetTopTen(ref List<string> headers)
        {
            List<ScoreModel> TopTen = new List<ScoreModel>();
            DataTable TableScore =  DBConnetion.Query($"select  users.name as usuario, attempts.attempt as intento, " +
                $"attempts.score as puntaje from attempts inner join users on attempts.id_user = users.id " +
                $"ORDER BY attempts.score desc fetch first 10 rows only");

            foreach(DataColumn dc in TableScore.Columns)
            {
                headers.Add(dc.ColumnName);
            }

            foreach (DataRow dr in TableScore.Rows)
            {
                TopTen.Add(new ScoreModel(
                    dr[0].ToString(),
                    dr[1].ToString(),
                    dr[2].ToString()
                    ));
            }

            return TableScore;
        }
    }
}
