using FogadoOra.Controllers;
using FogadoOra.Models;
using System;
using System.Collections.Generic;

namespace FogadoOra
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<FogadoOraModel> orak = new FogadoOraController().GetTodayFogadoOras();

            foreach (var item in orak)
            {
                Console.WriteLine(item.Id);
            }
        }
    }
}