using System;
using MySql.Data.MySqlClient;

namespace FogadoOra.Controllers
{
    internal class UserController
    {

        private string connectionString = "server=localhost;user=root;password=;database=fogadoora";
        public void AllUser()
        {
            using (MySqlConnection connector = new MySqlConnection(connectionString))
            {
                Console.WriteLine("Csatlakozás a MySql adatbázishoz...");
                connector.Open();
                Console.WriteLine("Sikeres csatlakozás a MySQL adatbázishoz");
                MySqlCommand command = new MySqlCommand("SELECT * FROM bejelentkezo", connector);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"Név: {reader["Name"]}, E-mail: {reader["Email"]}, Telefonszám: {reader["Mobile"]}");
                    }
                }
            }
        }
        public void Login()
        {
            using (MySqlConnection connector = new MySqlConnection(connectionString))
            {
                Console.WriteLine("Csatlakozás a MySql adatbázishoz...");
                connector.Open();
                Console.WriteLine("Sikeres csatlakozás a MySQL adatbázishoz");
                Console.WriteLine("Név: ");
                string nev = Console.ReadLine();
                Console.WriteLine("E-mail: ");
                string email = Console.ReadLine();
                MySqlCommand command = new MySqlCommand("SELECT * FROM bejelentkezo WHERE Name = @Name AND Email = @Email", connector);
                command.Parameters.AddWithValue("@Name", nev);
                command.Parameters.AddWithValue("@Email", email);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Console.WriteLine($"Sikeres bejelentkezés, üdvözöllek {nev}!");
                    }
                    else
                    {
                        Console.WriteLine("Hiba: Nem található ilyen felhasználó, vagy a megadott e-mail cím nem egyezik!");
                    }
                }
            }
        }
        public void NewUser()
        {
            using (MySqlConnection connector = new MySqlConnection(connectionString))
            {
                Console.WriteLine("Csatlakozás a MySql adatbázishoz...");
                connector.Open();
                Console.WriteLine("Sikeres csatlakozás a MySQL adatbázishoz");

                Console.WriteLine("Név: ");
                string nev = Console.ReadLine();
                Console.WriteLine("E-mail: ");
                string email = Console.ReadLine();
                Console.WriteLine("Telefonszám: ");
                string telefonszam = Console.ReadLine();

                MySqlCommand command = new MySqlCommand("INSERT INTO bejelentkezo (Name, Email, Mobile) VALUES (@Name, @Email, @Mobile)", connector);
                command.Parameters.AddWithValue("@Name", nev);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Mobile", telefonszam);
                command.ExecuteNonQuery();

                Console.WriteLine("Sikeres új felhasználó létrehozása");
            } 
        }

        public void DeleteUser()
        {
            using (MySqlConnection connector = new MySqlConnection(connectionString))
            {
                Console.WriteLine("Csatlakozás a MySql adatbázishoz...");
                connector.Open();

                Console.WriteLine("A törölni kívánt saját fiókod neve: ");
                string nev = Console.ReadLine();

                Console.WriteLine("Kérlek, add meg az e-mail címedet a megerősítéshez: ");
                string email = Console.ReadLine();

                MySqlCommand command = new MySqlCommand("DELETE FROM bejelentkezo WHERE Name = @Name AND Email = @Email", connector);
                command.Parameters.AddWithValue("@Name", nev);
                command.Parameters.AddWithValue("@Email", email);

                int affectedRows = command.ExecuteNonQuery();

                if (affectedRows > 0)
                {
                    Console.WriteLine("A fiókodat sikeresen töröltük.");
                }
                else
                {
                    Console.WriteLine("Hiba: Nem található ilyen felhasználó, vagy a megadott e-mail cím nem egyezik!");
                }
            }
        }

        public void UpdateUser()
        {
            using (MySqlConnection connector = new MySqlConnection(connectionString))
            {
                Console.WriteLine("Csatlakozás a MySql adatbázishoz...");
                connector.Open();

                Console.WriteLine("A módosítani kívánt saját felhasználóneved: ");
                string nev = Console.ReadLine();

                Console.WriteLine("Jelenlegi e-mail címed (azonosításhoz): ");
                string regiEmail = Console.ReadLine();

                Console.WriteLine("Új e-mail: ");
                string ujEmail = Console.ReadLine();
                Console.WriteLine("Új telefonszám: ");
                string telefonszam = Console.ReadLine();

                MySqlCommand command = new MySqlCommand("UPDATE bejelentkezo SET Email = @UjEmail, Mobile = @Mobile WHERE Name = @Name AND Email = @RegiEmail", connector);


                command.Parameters.AddWithValue("@UjEmail", ujEmail);
                command.Parameters.AddWithValue("@Mobile", telefonszam);
                command.Parameters.AddWithValue("@Name", nev);
                command.Parameters.AddWithValue("@RegiEmail", regiEmail);

                int affectedRows = command.ExecuteNonQuery();

                if (affectedRows > 0)
                {
                    Console.WriteLine("Sikeres adatmódosítás!");
                }
                else
                {
                    Console.WriteLine("Hiba a módosítás során! Ellenőrizd a nevet és az eredeti e-mail címet.");
                }
            }
        }
    }
}