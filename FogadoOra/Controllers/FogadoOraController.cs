using FogadoOra.Models;
using FogadoOra.View;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace FogadoOra.Controllers
{
    internal class FogadoOraController
    {
        // Összes fogadóóra lekérdezése
        public List<FogadoOraModel> GetAllFogadoOra()
        {
            string connectionString = "server=localhost;database=fogadoora;user=root;password=;";
            List<FogadoOraModel> fogadoorak = new List<FogadoOraModel>();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = @"
                    SELECT f.Id, f.Start, f.Lenght, h.Name AS HelyszinNev
                    FROM fogadoora f
                    JOIN helyszin h ON f.Helyszin_Id = h.Id";

                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        fogadoorak.Add(new FogadoOraModel
                        {
                            Id = reader.GetInt32("Id"),
                            Place = reader.GetString("HelyszinNev"),
                            Start = reader.GetDateTime("Start"),
                            Lenght = reader.GetInt32("Lenght")
                        });
                    }
                }
            }

            return fogadoorak;
        }

        // Fogadóóra lekérdezése adott dátumra
        public List<FogadoOraModel> GetFogadoOraByDate(DateTime date)
        {
            string connectionString = "server=localhost;database=fogadoora;user=root;password=;";
            List<FogadoOraModel> fogadoorak = new List<FogadoOraModel>();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = @"
                    SELECT f.Id, f.Start, f.Lenght, h.Name AS HelyszinNev
                    FROM fogadoora f
                    JOIN helyszin h ON f.Helyszin_Id = h.Id
                    WHERE DATE(f.Start) = @date";

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
                                Place = reader.GetString("HelyszinNev"),
                                Start = reader.GetDateTime("Start"),
                                Lenght = reader.GetInt32("Lenght")
                            });
                        }
                    }
                }
            }

            return fogadoorak;
        }

        // Fogadóóra lekérdezése adott dátum string alapján
        public List<FogadoOraModel> GetFogadoOrakOfDay(string date)
        {
            string connectionString = "server=localhost;database=fogadoora;user=root;password=;";
            List<FogadoOraModel> fogadoorak = new List<FogadoOraModel>();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = @"
                    SELECT f.Id, f.Start, f.Lenght, h.Name AS HelyszinNev
                    FROM fogadoora f
                    JOIN helyszin h ON f.Helyszin_Id = h.Id
                    WHERE DATE(f.Start) = @date";

                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@date", date);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            fogadoorak.Add(new FogadoOraModel
                            {
                                Id = reader.GetInt32("Id"),
                                Place = reader.GetString("HelyszinNev"),
                                Start = reader.GetDateTime("Start"),
                                Lenght = reader.GetInt32("Lenght")
                            });
                        }
                    }
                }
            }

            return fogadoorak;
        }

        // Fogadóórák lekérdezése a mai napra
        public List<FogadoOraModel> GetTodayFogadoOras()
        {
            string connectionString = "server=localhost;database=fogadoora;user=root;password=;";
            List<FogadoOraModel> fogadoorak = new List<FogadoOraModel>();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = @"
                    SELECT f.Id, f.Start, f.Lenght, h.Name AS HelyszinNev
                    FROM fogadoora f
                    JOIN helyszin h ON f.Helyszin_Id = h.Id
                    WHERE f.Start >= CURDATE() AND f.Start < CURDATE() + INTERVAL 1 DAY";

                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        fogadoorak.Add(new FogadoOraModel
                        {
                            Id = reader.GetInt32("Id"),
                            Place = reader.GetString("HelyszinNev"),
                            Start = reader.GetDateTime("Start"),
                            Lenght = reader.GetInt32("Lenght")
                        });
                    }
                }
            }

            return fogadoorak;
        }

        // Az összes fogadóóra lekérdezése, amire egy adott felhasználó jelentkezett
        public List<FogadoOraModel> GetAllFogadoOraOfUser(int userId)
        {
            string connectionString = "server=localhost;database=fogadoora;user=root;password=;";
            List<FogadoOraModel> fogadoorak = new List<FogadoOraModel>();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = @"
                    SELECT f.Id, f.Start, f.Lenght, h.Name AS HelyszinNev
                    FROM fogadoora f
                    JOIN jelentkezes j ON f.Id = j.Fogadoora_Id
                    JOIN helyszin h ON f.Helyszin_Id = h.Id
                    WHERE j.Bejelentkezo_Id = @userId";

                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@userId", userId);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            fogadoorak.Add(new FogadoOraModel
                            {
                                Id = reader.GetInt32("Id"),
                                Place = reader.GetString("HelyszinNev"),
                                Start = reader.GetDateTime("Start"),
                                Lenght = reader.GetInt32("Lenght")
                            });
                        }
                    }
                }
            }

            return fogadoorak;
        }

        public void CreateFogadoOra(int placeId, string start, int lenght)
        {
            string connectionString = "server=localhost;database=fogadoora;user=root;password=;";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = @"
            INSERT INTO fogadoora (Id, Helyszin_Id, Start, Lenght)
            VALUES (NULL, @placeId, @start, @lenght);";

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

        public void UpdateFogadoOra(string id)
        {
            Console.Clear();

            Console.Write(
                "Válasszon szerkesztendő Értéket:\n" +
                "1. Helyszin_Id\n" +
                "2. Kezdési időpont\n" +
                "3. Hossz\n\n--> "
            );

            string valasztas = Console.ReadLine();
            string valtoztatni = "";

            if (valasztas == "1")
            {
                valtoztatni = "Helyszin_Id";
            }
            else if (valasztas == "2")
            {
                valtoztatni = "Start";
            }
            else if (valasztas == "3")
            {
                valtoztatni = "Lenght";
            }
            else
            {
                Console.WriteLine("Helytelen paraméter");
                Console.ReadLine();
                Console.Clear();
                new Megjelenites().FoMegjelenites();
                return;
            }

            Console.Write("Új érték --> ");
            string ujErtek = Console.ReadLine();

            string connectionString = "server=localhost;database=fogadoora;user=root;password=;";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = $"UPDATE fogadoora SET {valtoztatni} = @ujErtek WHERE Id = @Id";

                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Parameters.AddWithValue("@ujErtek", ujErtek);

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