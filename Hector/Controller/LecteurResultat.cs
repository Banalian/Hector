using Hector.Model;
using System;
using System.Collections.Generic;

namespace Hector.Controller
{
    public class LecteurResultat
    {
        public List<Article> Articles { get; set; }
        public List<Marque> Marques { get; set; }
        public List<Famille> Familles { get; set; }
        public List<SousFamille> SousFamilles { get; set; }
        public LecteurResultat()
        {
            Articles = new List<Article>();
            Marques = new List<Marque>();
            SousFamilles = new List<SousFamille>();
            Familles = new List<Famille>();
        }

        public void ajouterFamille(Famille nouvelleFamille)
        {
            if (! Familles.Contains(nouvelleFamille))
            {
                Familles.Add(nouvelleFamille);
            }
        }

        public void ajouterMarque(Marque nouvelleMarque)
        {
            if (! Marques.Contains(nouvelleMarque))
            {
                Marques.Add(nouvelleMarque);
            }
        }

        public void ajouterSousFamille(SousFamille nouvelleSF)
        {
            if (! SousFamilles.Contains(nouvelleSF))
            {
                SousFamilles.Add(nouvelleSF);
            }
        }
        public void ajouterArticle(Article nouvelArticle)
        {
            Articles.Add(nouvelArticle);
        }

        public override string ToString()
        {
            string rezArticles = "";
            for (int i = 0 ; i<Articles.Count ; i++)
            {
                rezArticles += Articles[i]+ ";";
            }
            string rezMarques = "";
            for (int i = 0; i < Marques.Count; i++)
            {
                rezMarques += Marques[i] + ";";
            }
            string rezFamilles = "";
            for (int i = 0; i < Familles.Count; i++)
            {
                rezFamilles += Familles[i] + ";";
            }
            string rezSousFamilles = "";
            for (int i = 0; i < SousFamilles.Count; i++)
            {
                rezSousFamilles += SousFamilles[i] + ";";
            }
            return rezArticles+"\n\n"+rezMarques+"\n\n"+rezFamilles+"\n\n"+rezSousFamilles;
        }

    }
}
