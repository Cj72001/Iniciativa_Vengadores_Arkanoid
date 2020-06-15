using System.Data;
using Npgsql;

namespace Arkanoid.Model
{
    public static class DBConnetion
    {
       private static string CadenaConexion =
                   "Server = ruby.db.elephantsql.com;" +
                   "Port = 5432;User Id=rwnpnzul;" +
                   "Password = fWYhnDsRuBKitfROuM1i2fo4FH7TzlRQ;" +
                   "Database = rwnpnzul";
               
               public static DataTable Query(string sql)
               {
                   NpgsqlConnection conn = new NpgsqlConnection(CadenaConexion);
                   DataSet ds = new DataSet();
                   
                   conn.Open();
                   NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
                   da.Fill(ds);
                   conn.Close();
                   
                   return ds.Tables[0];
               }
       
               public static void NonQuery(string sql)
               {
                   NpgsqlConnection conn = new NpgsqlConnection(CadenaConexion);
                   
                   conn.Open();
                   NpgsqlCommand nc = new NpgsqlCommand(sql, conn);
                   nc.ExecuteNonQuery();
                   conn.Close();
               } 
    }
}