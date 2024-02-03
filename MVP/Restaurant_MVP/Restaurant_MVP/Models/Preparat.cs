using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_MVP
{
    public class Preparat
    {
        public int Id { get; set; }

        public string Denumire { get; set; }

        public int Pret { get; set; }

        public int Cantitate { get; set; }

        public int Cantitate_Totala { get; set; }

        public string Categorie { get; set; }

        public string Alergen { get; set; }
    }
}
