using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TenisMVVM.Models
{
    public class Tenis
    {
        public string Nombre { get; set; }
        public decimal Valuado { get; set; }
        public string Historia { get; set; }
        public string Foto { get; set; }

        public Tenis()
        {
            Nombre = "";
            Historia = "";
            Foto = "";
        }
    }
}
