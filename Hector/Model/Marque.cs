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
        public static bool operator < (Marque g, Marque d)
        {
            return (g.RefMarque < d.RefMarque);
        }

        public static bool operator >(Marque g, Marque d)
        {
            return (g.RefMarque > d.RefMarque);
        }

    }
}
