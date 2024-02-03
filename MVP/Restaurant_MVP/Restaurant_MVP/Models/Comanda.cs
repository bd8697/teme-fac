using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_MVP
{
    public class Comanda
    {
        public int Id { get; set; }

        public int Cod { get; set; }

        public string Client { get; set; }

        public string Continut { get; set; }

        public int Pret { get; set; }

        public string Stare { get; set; }

        public string Data { get; set; }

        public string Ora_Livrare { get; set; }
    }
}
