using System;
using System.IO;
using System.Linq;
using Hector.Model;


namespace Hector.Controller
{
    class LecteurCSV
    {
        private String Chemin { get; set; }
        private StreamReader StreamReader { get; set; }
        private char[] Separateurs { get; set; }

        public LecteurCSV(String chemin)
        {
            Chemin = chemin;
            Separateurs.Append(',');
        }
        public LecteurCSV(String chemin,char[] separateurs)
        {
            Chemin = chemin;
            Separateurs = separateurs;
        }

        public LecteurResultat Lire()
        {

            StreamReader = new StreamReader(Chemin);
            
            Article articleActuel = new Article();

            LecteurResultat rez = new LecteurResultat();

            String data = StreamReader.ReadLine();
            String[] ligne;
            while ((data = StreamReader.ReadLine()) != null)
            {
                ligne = data.Split(Separateurs);

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
