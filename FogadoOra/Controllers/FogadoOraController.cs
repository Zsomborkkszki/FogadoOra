using FogadoOra.Models;
using MySql.Data.MySqlClient;
using Mysqlx.Resultset;
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

        public List<FogadoOraModel> GetFogadoOraByDate(DateTime date)
        {
            string connectionString = "server=localhost;database=fogadoora;user=root;password=;";
            List<FogadoOraModel> fogadoorak = new List<FogadoOraModel>();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "SELECT * FROM fogadoora WHERE DATE(Start) = @date";

                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@date", date.Date);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            fogadoorak.Add(new FogadoOraModel
                            {
                                Id = reader.GetInt32("Id"),
                                PlaceId = reader.GetInt32("Helyszin_Id"),
                                Start = reader.GetDateTime("Start"),
                                Lenght = reader.GetInt32("Lenght"),
                            });
                        }
                    }
                }
            }

            return fogadoorak;
        }

        List<FogadoOraModel> GetTodayFogadoOras()
        {

            return new List<FogadoOraModel>();
        }

        public void CreateFogadoOra(int placeId, string start, int lenght)
        {
            string connectionString = "server=localhost;database=fogadoora;user=root;password=;";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = @"INSERT INTO `fogadoora` (`Id`, `Helyszin_Id`, `Start`, `Lenght`) VALUES (NULL, @placeId, @start, @lenght);";

                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@placeId", placeId);
                    cmd.Parameters.AddWithValue("@start", start);
                    cmd.Parameters.AddWithValue("@lenght", lenght);

                    cmd.ExecuteNonQuery();
                }

                conn.Close();
            }
        }

        public void UpdateFogadoOra(string id, string valtoztatni, string ujertek)
        {
            string connectionString = "server=localhost;database=fogadoora;user=root;password=;";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = @"UPDATE fogadoora SET @valtoztatni = @ujErtek WHERE Id = @Id";

                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Parameters.AddWithValue("@valtoztatni", valtoztatni);
                    cmd.Parameters.AddWithValue("@ujErtek", ujertek);
                    
                    cmd.ExecuteNonQuery();
                }

                conn.Close();
            }
        }

        public void DeleteFogadoOra(int id)
        {
            string connectionString = "server=localhost;database=fogadoora;user=root;password=;";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = @"DELETE FROM fogadoora WHERE Id = @Id";

                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand(query, conn)) 
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();
                }

                conn.Close();
            }    
        }
    }
}
