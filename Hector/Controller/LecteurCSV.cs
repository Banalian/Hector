using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Hector.Model
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

        public Article[] Lire()
        {

            StreamReader = new StreamReader(Chemin);

            Article[] Articles = null;
            Article articleActuel = new Article();

            Marque[] marques = null;
            Famille[] familles = null;
            SousFamille[] sousFamilles = null;

            String data = StreamReader.ReadLine();
            String[] ligne;
            while ((data = StreamReader.ReadLine()) != null)
            {
                ligne = data.Split(Separateurs);

                articleActuel = new Article(ligne[0], ligne[1], float.Parse(ligne[5]));

                Famille familleActuelle = new Famille(ligne[3]);
                articleActuel.Famille = familleActuelle;
                if (! familles.Contains(familleActuelle))
                {
                    familles.Append(familleActuelle);
                }

                Marque marqueAcuelle = new Marque(ligne[2]);
                articleActuel.Marque = marqueAcuelle;
                if (!marques.Contains(marqueAcuelle))
                {
                    marques.Append(marqueAcuelle);
                }

                SousFamille sousFamilleActuelle = new SousFamille(ligne[4]);
                articleActuel.SousFamille = sousFamilleActuelle;
                if (sousFamilles.Contains(sousFamilleActuelle))
                {
                    sousFamilles.Append(sousFamilleActuelle);
                }

                Articles.Append(articleActuel);

            }

            return Articles;
        }

    }

}
