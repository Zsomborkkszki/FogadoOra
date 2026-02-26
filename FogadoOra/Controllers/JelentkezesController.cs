using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FogadoOra.Controllers
{
    internal class JelentkezesController
    {
        public void JelentkezesFogadoOrara(int fogadoOraId, int bejelentkezoId)
        {
            string connectionString = "server=localhost;database=fogadoora;user=root;password=;";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = @"INSERT INTO `jelentkezes` (`Id`, `Fogadoora_Id`, `Bejelentkezo_Id`, `Jelentkezes_Ideje`) VALUES (NULL, @fogadoOraId, @jelentkezoId, @jelentkezesIdo);";

                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@fogadoOraId", fogadoOraId);
                    cmd.Parameters.AddWithValue("@jelentkezoId", bejelentkezoId);
                    cmd.Parameters.AddWithValue("@jelentkezesIdo", DateTime.Now);

                    cmd.ExecuteNonQuery();
                }

                conn.Close();
            }
        }
    }
}
