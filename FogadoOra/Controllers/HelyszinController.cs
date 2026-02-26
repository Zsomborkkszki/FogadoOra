using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace FogadoOra.Controllers
{
    internal class HelyszinController
    {
        private string connectionString = "server=localhost;user=root;password=;database=fogadoora";
        public void AllPlace()
        {
            using (MySqlConnection connector = new MySqlConnection(connectionString))
            {
                connector.Open();
                MySqlCommand command = new MySqlCommand("SELECT * FROM helyszin", connector);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"Id: {reader["Id"]}, Név: {reader["Name"]}");
                    }
                }
            }
        }
        public void NewPlace() 
        {
            using (MySqlConnection connector = new MySqlConnection(connectionString))
            {
                connector.Open();
                Console.WriteLine("Helyszín neve: ");
                string nev = Console.ReadLine();
                MySqlCommand command = new MySqlCommand("INSERT INTO helyszin (Name) VALUES (@Name)", connector);
                command.Parameters.AddWithValue("@Name", nev);
                command.ExecuteNonQuery();
                
                Console.WriteLine("Sikeres helyszín hozzáadás!");
                
            }
        }
        public void UpdatePlace()
        {
            //Meglévő helyszín nevének módosítása
            using (MySqlConnection connector = new MySqlConnection(connectionString))
            {
                connector.Open();
                Console.WriteLine("Módosítani kívánt helyszín Neve: ");
                string nev = Console.ReadLine();
                Console.WriteLine("Új helyszín neve: ");
                string ujNev = Console.ReadLine();
                MySqlCommand command = new MySqlCommand("UPDATE helyszin SET Name = @NewName WHERE Name = @OldName", connector);
                command.Parameters.AddWithValue("@NewName", ujNev);
                command.Parameters.AddWithValue("@OldName", nev);
                command.ExecuteNonQuery();
                Console.WriteLine("Sikeres helyszín módosítás!");
                
            }
        }
    }
}
