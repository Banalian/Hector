using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hector.Model
{
    public class Famille
    {
        public int RefFamille { get; set; }
        public String NomFamille { get; set; }

        public Famille()
        {
            RefFamille = 0;
            NomFamille = "";
        }

        public Famille(String nom)
        {
            NomFamille = nom;
        }
    }
}
