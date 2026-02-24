using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FogadoOra.Models
{
    internal class Bejelentkezo
    {
        int id;
        string name;
        string email;
        string mobile;

        public Bejelentkezo(int id, string name, string email, string mobile)
        {
            this.id = id;
            this.name = name;
            this.email = email;
            this.mobile = mobile;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Email { get => email; set => email = value; }
        public string Mobile { get => mobile; set => mobile = value; }

        public void Read()
        {
            //mysql read
            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection("server=localhost;user=root;database=fogadoora");
            conn.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT * FROM bejelentkezo", conn);
            MySql.Data.MySqlClient.MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine(reader["id"] + " " + reader["name"] + " " + reader["email"] + " " + reader["mobile"]);
            }
        }

    }
}
