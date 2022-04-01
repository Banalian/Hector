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


        public SousFamille()
        {
            RefSousFamille = 0;
            NomSousFamille = "";
        }

        public SousFamille(String nom)
        {
            RefSousFamille = 0;
            NomSousFamille = nom;
        }

        public override string ToString()
        {
            return NomSousFamille;
        }
        
        public override bool Equals(object sousFamille)
        {
            return RefSousFamille == ((SousFamille)sousFamille).RefSousFamille && 
                   Famille.Equals(((SousFamille)sousFamille).Famille)&&
                   NomSousFamille == ((SousFamille)sousFamille).NomSousFamille;
        }
        public static bool operator <(SousFamille g, SousFamille d)
        {
            return (g.RefSousFamille < d.RefSousFamille);
        }

        public static bool operator >(SousFamille g, SousFamille d)
        {
            return (g.RefSousFamille > d.RefSousFamille);
        }

    }
}
