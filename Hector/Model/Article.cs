using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hector.Model
{
    public class Article
    {
        public String Description { get; set; }
        public String Reference { get; set; }
        public Marque Marque { get; set; }
        public SousFamille SousFamille { get; set; }
        public float PrixHT { get; set; }

        public int Quantite { get; set; }

        public Article() {
            Description = "";
            Reference = "";
            PrixHT = 0.0f;
        }

        public Article(String description , String reference , float prixHT)
        {
            Description = description;
            Reference = reference;
            PrixHT = prixHT;
        }

        public override string ToString()
        {
            String rez = Description+" "+Reference+" "+SousFamille;
            return rez;
        }

        //this function can accept:
        //r for sorting by reference
        //f, by famille
        //s by sousFamille
        //m by marque
        //NOTE: we may not need this method, we can just invoke list.OrderBy() with the appropriate parameters based on context
        public void OrderBy(List<Article> liste, char sorter, char dir = 'a')
        {
            Object sorterObj = new object();
            //ascending
            if (dir == 'a')
            {
                if (sorter == 'm')
                {
                    liste.OrderBy(Article => Article.Marque);
                }
                else if (sorter == 'r')
                {
                    liste.OrderBy(Article => Article.Reference);
                }
                else if (sorter == 'f')
                {
                    liste.OrderBy(Article => Article.SousFamille.Famille);
                }
                else if (sorter == 's')
                {
                    liste.OrderBy(Article => Article.SousFamille);
                }
                else
                {
                    Exception e = new Exception("The inputed sorter does not exist! please sort by m,r,f or s");
                    throw e;
                }
            }
            //descending
            else if (dir =='d')
            {
                if (sorter == 'm')
                {
                    liste.OrderByDescending(Article => Article.Marque);
                }
                else if (sorter == 'r')
                {
                    liste.OrderByDescending(Article => Article.Reference);
                }
                else if (sorter == 'f')
                {
                    liste.OrderByDescending(Article => Article.SousFamille.Famille);
                }
                else if (sorter == 's')
                {
                    liste.OrderByDescending(Article => Article.SousFamille);
                }
                else
                {
                    Exception e = new Exception("The inputed sorter attribute does not exist!");
                    throw e;
                }

            }
            else
            {
                Exception e = new Exception("The inputed direction does not exist! please sort using 'a' for ascending, or 'b' for descending");
                throw e;
            }

        }
    }

}
