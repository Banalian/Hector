using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hector.Model
{
    public class Marque
    {
        public int RefMarque { get; set; }
        public String NomMarque { get; set; }

        public Marque()
        {
            RefMarque = 0;
            NomMarque = "";
        }

        public Marque(String nom)
        {
            NomMarque = nom;
        }

        public override string ToString()
        {
            return NomMarque;
        }

        public override bool Equals(object marque)
        {
            return NomMarque == ((Marque) marque).NomMarque && RefMarque == ((Marque)marque).RefMarque;
        }

        /// <summary>
        /// surchage automatique de GetHashCode()
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            int hashCode = 277225159;
            hashCode = hashCode * -1521134295 + RefMarque.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(NomMarque);
            return hashCode;
        }

        public static bool operator < (Marque g, Marque d)
        {
            return g.RefMarque < d.RefMarque;
        }

        public static bool operator >(Marque g, Marque d)
        {
            return g.RefMarque > d.RefMarque;
        }

    }
}
