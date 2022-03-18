using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hector.Model
{
    public class Article
    {
        public String Description { get; set; }
        public String Reference { get; set; }
        public Marque Marque { get; set; }
        public Famille Famille { get; set; }
        public SousFamille SousFamille { get; set; }

        public float PrixHT { get; set; }

        public Article() {
            Description = "";
            Reference = "";
            PrixHT = 0.0f;
        }

        public Article(String description , String reference , float prixHT)
        {
            Description = description;
            Reference = reference;
            PrixHT = prixHT;
        }

    }

}
