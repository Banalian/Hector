using System;
using System.IO;
using Hector.Model;
using System.Collections.Generic;

namespace Hector.Controller
{
    public class EditeurCSV
    {
        private String Chemin { get; set; }
        private StreamWriter StreamWriter { get; set; }
        private List<char> Separateurs { get; set; }

        public EditeurCSV(String chemin)
        {
            Chemin = chemin;
            StreamWriter = new StreamWriter(Chemin);
        }

        public void EcrireCSV(List<Article> articles)
        {
            String ligne = "";

            for (int i=0 ; i < articles.Count() ; i++)
            {

                //ajouter la description

                ligne.Insert(ligne.Length,articles[i].Description);
                ligne.Insert(";");
                //ajouter la reference
                ligne.Insert(ligne.Length, articles[i].Reference);
                ligne.Insert(";");
                //ajouter la marque
                ligne.Insert(ligne.Length, articles[i].Marque);
                ligne.Insert(";");
                //ajouter la famille
                ligne.Insert(ligne.Length, articles[i].Famille);
                ligne.Insert(";");
                //ajouter la sous-famille
                ligne.Insert(ligne.Length, articles[i].SousFamille);
                ligne.Insert(";");
                //ajouter le prix hors taxes
                ligne.Insert(ligne.Length, articles[i].PrixHT);

                //inserer la ligne dans le fichier
                StreamWriter.

                ligne = "";
            }

        }

        public void EcrireCSV(LecteurResultat objets)
        {
            EcrireCSV(objets.Articles);
        }

    }
}
