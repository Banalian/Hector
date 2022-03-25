using System;
using System.IO;
using Hector.Model;
using System.Collections.Generic;


namespace Hector.Controller
{
    class LecteurCSV
    {
        private String Chemin { get; set; }
        private StreamReader StreamReader { get; set; }
        private List<char> Separateurs { get; set; }

        public LecteurCSV(String chemin)
        {
            Chemin = chemin;
            Separateurs = new List<char>();
            Separateurs.Add(';');
            StreamReader = new StreamReader(Chemin,System.Text.Encoding.Default);
        }
        public LecteurCSV(String chemin,List<char> separateurs)
        {
            Chemin = chemin;
            Separateurs = separateurs;
            StreamReader = new StreamReader(Chemin);
        }

        public LecteurResultat Lire()
        {

            
            Article articleActuel = new Article();

            LecteurResultat rez = new LecteurResultat();

            String data = StreamReader.ReadLine();
            String[] ligne;
            while ((data = StreamReader.ReadLine()) != null)
            {
                ligne = data.Split(Separateurs.ToArray());

                articleActuel = new Article(ligne[0], ligne[1], float.Parse(ligne[5]));

                Famille familleActuelle = new Famille(ligne[3]);
                articleActuel.Famille = familleActuelle;
                rez.ajouterFamille(familleActuelle);

                Marque marqueAcuelle = new Marque(ligne[2]);
                articleActuel.Marque = marqueAcuelle;
                rez.ajouterMarque(marqueAcuelle);

                SousFamille sousFamilleActuelle = new SousFamille(ligne[4]);
                articleActuel.SousFamille = sousFamilleActuelle;
                rez.ajouterSousFamille(sousFamilleActuelle);

                rez.ajouterArticle(articleActuel);

            }

            return rez;
        }

    }

}
