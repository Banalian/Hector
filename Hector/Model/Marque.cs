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

        public Marque(String nom)
        {
            NomMarque = nom;
        }
    }
}
