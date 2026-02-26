using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FogadoOra.Models
{
    internal class FogadoOraModel
    {
        string place;
        DateTime start;
        int lenght;

        public FogadoOraModel(string place, DateTime start, int lenght)
        {
            this.Place = place;
            this.Start = start;
            this.Lenght = lenght;
        }

        public FogadoOraModel()
        {

        }

        public string Place { get => place; set => place = value; }
        public DateTime Start { get => start; set => start = value; }
        public int Lenght { get => lenght; set => lenght = value; }
    }
}
