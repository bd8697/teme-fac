using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_MVP
{
    public class Meniu_preparat
    {
        public int Id { get; set; }

        public string Denumire { get; set; }

        public string Pret { get; set; }

        public string Cantitate { get; set; }

        public string Cantitate_Totala { get; set; }

        public string Categorie { get; set; }

        public string Alergen { get; set; }
    }
}
