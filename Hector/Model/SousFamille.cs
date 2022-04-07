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

        /// <summary>
        /// surchage automatique de GetHashCode()
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            int hashCode = 263456498;
            hashCode = hashCode * -1521134295 + RefSousFamille.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<Famille>.Default.GetHashCode(Famille);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(NomSousFamille);
            return hashCode;
        }

        public static bool operator <(SousFamille g, SousFamille d)
        {
            return g.RefSousFamille < d.RefSousFamille;
        }

        public static bool operator >(SousFamille g, SousFamille d)
        {
            return g.RefSousFamille > d.RefSousFamille;
        }

    }
}
