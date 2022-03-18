using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hector.Model
{
    class Article
    {
        private int IdArticle;
        private String Description;
        private String Reference;
        //private Marque Marque;
        //private Famille Famille;
        //private SousFamille SousFamille;

        private float PrixHT;

        public Article() {
            Description = "";
            Reference = "";
            PrixHT = 0.0f;
        }
        


    }
}
