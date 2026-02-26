using FogadoOra.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FogadoOra.Controllers
{
    internal class FogadoOraController
    {
        public List<FogadoOraModel> GetAllFogadoOra()
        {
            string connectionString = "server=localhost;database=fogadoora;user=root;password=;";

            List<FogadoOraModel> fogadoorak = new List<FogadoOraModel>();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "SELECT * FROM fogadoora";

                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        FogadoOraModel fogadoOra = new FogadoOraModel
                        {
                            Id = reader.GetInt32("Id"),
                            PlaceId = reader.GetInt32("Helyszin_Id"),
                            Start = reader.GetDateTime("Start"),
                            Lenght = reader.GetInt32("Lenght"),
                        };

                        fogadoorak.Add(fogadoOra);
                    }
                }

                conn.Close();
            }

            return fogadoorak;
        }

        FogadoOraModel GetFogadoOraByDate()
        {

            return new FogadoOraModel();
        }

        List<FogadoOraModel> GetTodayFogadoOras()
        {

            return new List<FogadoOraModel>();
        }

        void CreateFogadoOra()
        {

        }

        void UpdateFogadoOra()
        {

        }

        void DeleteFogadoOra()
        {

        }
    }
}
