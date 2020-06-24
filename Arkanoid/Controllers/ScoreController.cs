using Arkanoid.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkanoid.Controllers
{
     static class ScoreController//score
    {
        public static DataTable GetTopTen(ref List<string> headers) 
        {
            List<ScoreModel> TopTen = new List<ScoreModel>();
            DataTable TableScore =  DBConnetion.RealizarConsulta($"select users.name as usuario, t.attempt as intento, t.score as puntaje from " +
                $"(SELECT distinct on (id_user) id_user, attempt, score from attempts ORDER BY id_user, score DESC) as t " +
                $"inner join users on t.id_user = users.id  ORDER BY t.score desc fetch first 10 rows only");

            foreach(DataColumn dc in TableScore.Columns) headers.Add(dc.ColumnName);
            

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
