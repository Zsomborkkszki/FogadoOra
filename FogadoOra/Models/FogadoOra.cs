using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FogadoOra.Models
{
    internal class FogadoOra
    {
        string place;
        DateTime start;
        DateTime lenght;

        public FogadoOra(string place, DateTime start, DateTime lenght)
        {
            this.Place = place;
            this.Start = start;
            this.Lenght = lenght;
        }

        public string Place { get => place; set => place = value; }
        public DateTime Start { get => start; set => start = value; }
        public DateTime Lenght { get => lenght; set => lenght = value; }
    }
}
