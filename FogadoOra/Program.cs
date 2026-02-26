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
            List<FogadoOraModel> f = new FogadoOraController().GetFogadoOraByDate(DateTime.Parse("2026-03-02 08:00:00"));

            Console.WriteLine(f[0].Id);
        }
    }
}