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
        public Famille Famille { get; set; }
        public String NomSousFamille { get; set; }

        public SousFamille(String nom)
        {

            NomSousFamille = nom;
        }

        public override string ToString()
        {
            return NomSousFamille;
        }
        
        public override bool Equals(object sousFamille)
        {
            return RefSousFamille == ((SousFamille)sousFamille).RefSousFamille && 
                   Famille == ((SousFamille)sousFamille).Famille &&
                   NomSousFamille == ((SousFamille)sousFamille).NomSousFamille;
        }

    }
}
