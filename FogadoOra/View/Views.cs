using FogadoOra.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FogadoOra.View
{
    internal class Views
    {
        public void Main(string[] args)
        {
            Console.WriteLine("Megjelenítés");
        }


        public void MegjelenitOra(List<FogadoOraModel> orak)
        {
            Console.WriteLine("Fogadó órák");
            foreach(FogadoOraModel ora in orak)
            {
                Console.WriteLine(ora.Place);
                Console.WriteLine(ora.Start);
                Console.WriteLine(ora.Lenght);

            }
        }

    }
}
