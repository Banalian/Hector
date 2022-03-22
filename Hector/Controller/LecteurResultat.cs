using Hector.Model;
using System.Collections.Generic;

namespace Hector.Controller
{
    class LecteurResultat
    {
        public List<Article> articles { get; set; }
        public List<Marque> marques { get; set; }
        public List<Famille> familles { get; set; }
        public List<SousFamille> sousFamilles { get; set; }

        public void ajouterFamille(Famille nouvelleFamille)
        {
            if (!familles.Contains(nouvelleFamille))
            {
                familles.Add(nouvelleFamille);
            }
        }

        public void ajouterMarque(Marque nouvelleMarque)
        {
            if (!marques.Contains(nouvelleMarque))
            {
                marques.Add(nouvelleMarque);
            }
        }

        public void ajouterSousFamille(SousFamille nouvelleSF)
        {
            if (sousFamilles.Contains(nouvelleSF))
            {
                sousFamilles.Add(nouvelleSF);
            }
        }
        public void ajouterArticle(Article nouvelArticle)
        {
            if (articles.Contains(nouvelArticle))
            {
                articles.Add(nouvelArticle);
            }
        }

    }
}
