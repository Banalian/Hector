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
        private String chemin { get; set; }
        private StreamReader streamReader { get; set; }
        private char[] separateurs { get; set; }

        public Article[] Lire()
        {
            Article[] articles = null;
            Article articleActuel = new Article();

            Marque[] marques = null;
            Famille[] familles = null;
            SousFamille[] sousFamilles = null;

            String data = streamReader.ReadLine();
            String[] ligne;
            while ((data = streamReader.ReadLine()) != null)
            {
                ligne = data.Split(separateurs);

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

                articles.Append(articleActuel);

            }

            return articles;
        }

    }

}
