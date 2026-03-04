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
        public List<FogadoOraModel> GetFogadoOraByDate(DateTime start)
        {
            string connectionString = "server=localhost;database=fogadoora;user=root;password=;";
            List<FogadoOraModel> fogadoorak = new List<FogadoOraModel>();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = @"
                    SELECT f.Id, f.Start, f.Lenght, h.Name AS HelyszinNev
                    FROM fogadoora f
                    JOIN helyszin h ON f.Helyszin_Id = h.Id
                    WHERE f.Start = @start";

                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@start", start);

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

        public bool CreateFogadoOra(int placeId, DateTime start, int length)
        {
            string connectionString = "server=localhost;database=fogadoora;user=root;password=;";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string checkQuery = @"
                    SELECT COUNT(*) 
                    FROM fogadoora
                    WHERE Helyszin_Id = @placeId
                    AND Start < DATE_ADD(@start, INTERVAL @length MINUTE)
                    AND DATE_ADD(Start, INTERVAL Lenght MINUTE) > @start;";

                using (MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn))
                {
                    checkCmd.Parameters.AddWithValue("@placeId", placeId);
                    checkCmd.Parameters.AddWithValue("@start", start);
                    checkCmd.Parameters.AddWithValue("@length", length);

                    int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                    if (count > 0)
                    {
                        Console.WriteLine("Ebben a teremben már van fogadóóra ebben az időpontban!\nEnterrel tovább! ");
                        Console.ReadLine();
                        return false;
                    }
                }

                string insertQuery = @"
                    INSERT INTO fogadoora (Helyszin_Id, Start, Lenght)
                    VALUES (@placeId, @start, @length);";

                using (MySqlCommand insertCmd = new MySqlCommand(insertQuery, conn))
                {
                    insertCmd.Parameters.AddWithValue("@placeId", placeId);
                    insertCmd.Parameters.AddWithValue("@start", start);
                    insertCmd.Parameters.AddWithValue("@length", length);

                    insertCmd.ExecuteNonQuery();
                }

                return true;
            }
        }

        public void UpdateFogadoOra(int id)
        {
            string connectionString = "server=localhost;database=fogadoora;user=root;password=;";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                // 1️⃣ Lekérjük a jelenlegi adatokat
                string selectQuery = "SELECT Helyszin_Id, Start, Lenght FROM fogadoora WHERE Id = @Id";

                int placeId;
                DateTime start;
                int length;

                using (MySqlCommand selectCmd = new MySqlCommand(selectQuery, conn))
                {
                    selectCmd.Parameters.AddWithValue("@Id", id);

                    using (MySqlDataReader reader = selectCmd.ExecuteReader())
                    {
                        if (!reader.Read())
                        {
                            Console.WriteLine("Nincs ilyen fogadóóra!");
                            return;
                        }

                        placeId = reader.GetInt32("Helyszin_Id");
                        start = reader.GetDateTime("Start");
                        length = reader.GetInt32("Lenght");
                    }
                }

                Console.WriteLine("1. Helyszin_Id\n2. Kezdés\n3. Hossz");
                string valasztas = Console.ReadLine();

                if (valasztas == "1")
                {
                    Console.Write("Új helyszín ID: ");
                    placeId = int.Parse(Console.ReadLine());
                }
                else if (valasztas == "2")
                {
                    Console.Write("Új kezdés (yyyy-MM-dd HH:mm): ");
                    start = DateTime.Parse(Console.ReadLine());
                }
                else if (valasztas == "3")
                {
                    Console.Write("Új hossz (perc): ");
                    length = int.Parse(Console.ReadLine());
                }

                string checkQuery = @"
                    SELECT COUNT(*) 
                    FROM fogadoora
                    WHERE Helyszin_Id = @placeId
                    AND Id != @Id
                    AND Start < DATE_ADD(@start, INTERVAL @length MINUTE)
                    AND DATE_ADD(Start, INTERVAL Lenght MINUTE) > @start";

                using (MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn))
                {
                    checkCmd.Parameters.AddWithValue("@placeId", placeId);
                    checkCmd.Parameters.AddWithValue("@start", start);
                    checkCmd.Parameters.AddWithValue("@length", length);
                    checkCmd.Parameters.AddWithValue("@Id", id);

                    int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                    if (count > 0)
                    {
                        Console.WriteLine("Ütközés van ebben a teremben!");
                        return;
                    }
                }

                string updateQuery = @"
                    UPDATE fogadoora 
                    SET Helyszin_Id = @placeId,
                        Start = @start,
                        Lenght = @length
                    WHERE Id = @Id";

                using (MySqlCommand updateCmd = new MySqlCommand(updateQuery, conn))
                {
                    updateCmd.Parameters.AddWithValue("@placeId", placeId);
                    updateCmd.Parameters.AddWithValue("@start", start);
                    updateCmd.Parameters.AddWithValue("@length", length);
                    updateCmd.Parameters.AddWithValue("@Id", id);

                    updateCmd.ExecuteNonQuery();
                }

                Console.WriteLine("Sikeres módosítás!");
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

                conn.Close();//
            }
        }
    }
}