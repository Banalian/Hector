using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hector.Model
{
    public class SousFamille
    {
        public int RefSousFamille { get; set; }
        public Famille refFamille { get; set; }
        public String NomSousFamille { get; set; }

        public SousFamille(String nom)
        {

            NomSousFamille = nom;
        }

    }
}
