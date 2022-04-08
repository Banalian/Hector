using System;
using System.IO;
using Hector.Model;
using System.Collections.Generic;

namespace Hector.Controller
{
    public class EditeurCSV
    {
        private Stream Chemin { get; set; }
        private StreamWriter StreamWriter { get; set; }
        private List<char> Separateurs { get; set; }

        public EditeurCSV(Stream chemin)
        {
            Chemin = chemin;
            Separateurs = new List<char>();
            Separateurs.Add(';');
        }

        public void Ecrire(List<Article> articles)
        {
            StreamWriter = new StreamWriter(Chemin, System.Text.Encoding.Default);
            StreamWriter.WriteLine("{0};{1};{2};{3};{4};{5}", "Description"
                                                               , "Ref"
                                                               , "Marque"
                                                               , "Famille"
                                                               , "Sous-Famille"
                                                               , "Prix H.T."
                                                               );
            for (int i = 0; i < articles.Count; i++)
            {
                //inserer l'article dans le fichier
                StreamWriter.WriteLine("{0};{1};{2};{3};{4};{5}", articles[i].Description
                                                                , articles[i].Reference.ToString()
                                                                , articles[i].Marque.ToString()
                                                                , articles[i].SousFamille.Famille.ToString()
                                                                , articles[i].SousFamille.ToString()
                                                                , articles[i].PrixHT
                                                                );

            }

            StreamWriter.Close();   

        }
        
        public void Ecrire(LecteurResultat objets)
        {
            Ecrire(objets.Articles);
        }
        

    }
}
