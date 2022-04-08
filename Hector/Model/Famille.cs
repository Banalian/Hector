using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hector.Model
{
    /// <summary>
    /// Classe représentant une famille d'un objet
    /// </summary>
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
        public override string ToString()
        {
            return NomFamille;
        }
        public override bool Equals(object famille)
        {
            return NomFamille == ((Famille)famille).NomFamille &&
                   RefFamille == ((Famille)famille).RefFamille;
        }

        /// <summary>
        /// surchage automatique de GetHashCode()
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            int hashCode = 460557253;
            hashCode = hashCode * -1521134295 + RefFamille.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(NomFamille);
            return hashCode;
        }

        public static bool operator <(Famille g, Famille d)
        {
            return g.RefFamille < d.RefFamille;
        }

        public static bool operator >(Famille g, Famille d)
        {
            return g.RefFamille > d.RefFamille;
        }
    }
}
