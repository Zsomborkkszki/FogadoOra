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
        MySqlConnection DataBaseConnection()
        {
            string connectionString = "server=localhost;database=fogadoora;user=root;password=;";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                return conn;
                //Console.WriteLine("Sikeres kapcsolódás!");
            }
        }

        public List<FogadoOraModel> GetAllFogadoOra()
        {
            MySqlConnection conn = DataBaseConnection();
            conn.Open();
            conn.Close();

            return new List<FogadoOraModel>()
            {
                new FogadoOraModel("101-es terem", DateTime.Parse("2025-01-01"), 70),
                new FogadoOraModel("101-es terem", DateTime.Parse("2025-01-01"), 70),
                new FogadoOraModel("101-es terem", DateTime.Parse("2025-01-01"), 70),
                new FogadoOraModel("101-es terem", DateTime.Parse("2025-01-01"), 70),
                new FogadoOraModel("101-es terem", DateTime.Parse("2025-01-01"), 70),
                new FogadoOraModel("101-es terem", DateTime.Parse("2025-01-01"), 70),
                new FogadoOraModel("101-es terem", DateTime.Parse("2025-01-01"), 70),
                new FogadoOraModel("101-es terem", DateTime.Parse("2025-01-01"), 70),
                new FogadoOraModel("101-es terem", DateTime.Parse("2025-01-01"), 70),
                new FogadoOraModel("101-es terem", DateTime.Parse("2025-01-01"), 70),
            };
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
