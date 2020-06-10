using System.Data;
using Npgsql;

namespace Arkanoid.Model
{
    public static class DBConnetion
    {
       private static string CadenaConexion = 
                   "Server = 10.0.2.2;" +
                   "Port = 5432;User Id=postgres;" +
                   "Password = root;" +
                   "Database = bddEmpleados";
               
               public static DataTable RealizarConsulta(string sql)
               {
                   NpgsqlConnection conn = new NpgsqlConnection(CadenaConexion);
                   DataSet ds = new DataSet();
                   
                   conn.Open();
                   NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
                   da.Fill(ds);
                   conn.Close();
                   
                   return ds.Tables[0];
               }
       
               public static void RealizarAccion(string sql)
               {
                   NpgsqlConnection conn = new NpgsqlConnection(CadenaConexion);
                   
                   conn.Open();
                   NpgsqlCommand nc = new NpgsqlCommand(sql, conn);
                   nc.ExecuteNonQuery();
                   conn.Close();
               } 
    }
}