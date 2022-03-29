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
            StreamWriter = new StreamWriter(Chemin,false, System.Text.Encoding.Default);
        }

        public void Ecrire(List<Article> articles)
        {

            for (int i = 0; i < articles.Count; i++)
            {
                //inserer l'article dans le fichier
                StreamWriter.WriteLine("{0};{1};{2};{3};{4}", articles[i].Description
                                                                , articles[i].Reference.ToString()
                                                                , articles[i].SousFamille.RefFamille.ToString()
                                                                , articles[i].SousFamille.ToString()
                                                                , articles[i].PrixHT
                                                                );

            }

        }
        
        public void Ecrire(LecteurResultat objets)
        {
            Ecrire(objets.Articles);
        }
        

    }
}
