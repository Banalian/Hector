using Hector.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace Hector.Controller.DAO
{
    /// <summary>
    /// DAO permettant d'interagir avec la base de donnée pour la classe Marque
    /// </summary>
    internal class DAOArticles : DAO<Model.Article>
    {
        /// <summary>
        /// Ajoute un nouvelle article
        /// </summary>
        /// <param name="Entity">L'article à ajouter (avec tout ses paramètres)</param>
        /// <returns>Ce même article</returns>
        public Article Add(Article Entity)
        {
            if (Entity.SousFamille == null)
            {
                throw new Exception("L'article doit avoir une sous famille");
            }
            if (Entity.SousFamille.Famille == null)
            {
                throw new Exception("La sous famille de l'article doit avoir une famille");
            }
            if (Entity.Marque == null)
            {
                throw new Exception("L'article doit avoir une marque");
            }
            
            var Conn = ConnectionDB.DBConnection;
            var St = Conn.CreateCommand();
            St.CommandText = "INSERT INTO Articles('RefArticle','Description','RefSousFamille','RefMarque','PrixHT', 'Quantite') VALUES(@refA,@desc,@refSF,@refM,@prix,@quantite)";
            St.Parameters.AddWithValue("@refA",     Entity.Reference);
            St.Parameters.AddWithValue("@desc",     Entity.Description);
            St.Parameters.AddWithValue("@refSF",    Entity.SousFamille.RefSousFamille);
            St.Parameters.AddWithValue("@refM",     Entity.Marque.RefMarque);
            St.Parameters.AddWithValue("@prix",     Entity.PrixHT);
            St.Parameters.AddWithValue("@quantite", Entity.Quantite);
            
            St.ExecuteNonQuery();
            return Entity;
        }

        /// <summary>
        /// Supprime un artcile par son Id
        /// </summary>
        /// <param name="Id">l'Id de l'article à supprimer</param>
        public void DeleteById(int Id)
        {
            DeleteById(Id.ToString());
        }

        /// <summary>
        /// Supprime un artcile par son Id
        /// </summary>
        /// <param name="Id">l'Id de l'article à supprimer</param>
        public void DeleteById(string Id)
        {
            var Conn = ConnectionDB.DBConnection;
            var St = Conn.CreateCommand();
            St.CommandText = "DELETE FROM Article WHERE RefArticle=@id";
            St.Parameters.AddWithValue("@id", Id);
            St.ExecuteNonQuery();
        }

        /// <summary>
        /// Récupère une liste de tout les articles de la table.
        /// </summary>
        /// <returns>Une liste contenant tout les articles contenus dans la table de la bdd</returns>
        public List<Article> GetAll()
        {
            var Conn = ConnectionDB.DBConnection;
            var St = Conn.CreateCommand();
            St.CommandText = "SELECT * FROM Articles";
            SQLiteDataReader Reader = St.ExecuteReader();
            var List = new List<Article>();
            while (Reader.Read())
            {
                Article ArticleTemp = new Article();
                ArticleTemp.Reference = Reader.GetString(0);
                ArticleTemp.Description = Reader.GetString(1);
                
                DAOSousFamilles DaoSousFamilles = new DAOSousFamilles();
                ArticleTemp.SousFamille = DaoSousFamilles.GetById(Reader.GetInt32(2));

                DAOMarques DaoMarques = new DAOMarques();
                ArticleTemp.Marque = DaoMarques.GetById(Reader.GetInt32(3));

                ArticleTemp.PrixHT = Reader.GetFloat(4);
                ArticleTemp.Quantite = Reader.GetInt32(5);
                List.Add(ArticleTemp);
            }
            return List;

        }

        /// <summary>
        /// Récupere un article selon son id dans la base de données
        /// </summary>
        /// <param name="Id"> l'Id de l'article recherché</param>
        /// <returns>l'article qui à cet Id</returns>
        public Article GetById(int Id)
        {
            return GetById(Id.ToString());
        }

        /// <summary>
        /// Récupere un article selon son id dans la base de données
        /// </summary>
        /// <param name="Id"> l'Id de l'article recherché</param>
        /// <returns>l'article qui à cet Id</returns>
        public Article GetById(string Id)
        {
            var Conn = ConnectionDB.DBConnection;
            var St = Conn.CreateCommand();
            St.CommandText = "SELECT * FROM Articles WHERE RefArticle=@id";
            St.Parameters.AddWithValue("@id", Id);
            SQLiteDataReader Reader = St.ExecuteReader();
            Article ArticleTemp = new Article();
            if (Reader.Read())
            {
                ArticleTemp.Reference = Reader.GetString(0);
                ArticleTemp.Description = Reader.GetString(1);

                DAOSousFamilles DaoSousFamilles = new DAOSousFamilles();
                ArticleTemp.SousFamille = DaoSousFamilles.GetById(Reader.GetInt32(2));

                DAOMarques DaoMarques = new DAOMarques();
                ArticleTemp.Marque = DaoMarques.GetById(Reader.GetInt32(3));

                ArticleTemp.PrixHT = Reader.GetFloat(4);
                ArticleTemp.Quantite = Reader.GetInt32(5);
            }
            return ArticleTemp;

        }

        /// <summary>
        /// Update un article en changeant tout ses paramètres
        /// </summary>
        /// <param name="Entity"> L'article à modifier (son Id doit être celui de la marque que l'on modifie)</param>
        public void UpdateById(Article Entity)
        {
            var Conn = ConnectionDB.DBConnection;
            var St = Conn.CreateCommand();
            St.CommandText = "UPDATE Marques SET 'Description'=@desc,'RefSousFamille'=@refSF,'RefMarque'=@refM,'PrixHT'=@prix, 'Quantite'=@quantite WHERE RefMarque=@id";

            St.Parameters.AddWithValue("@desc", Entity.Description);
            St.Parameters.AddWithValue("@refSF", Entity.SousFamille.RefSousFamille);
            St.Parameters.AddWithValue("@refM", Entity.Marque.RefMarque);
            St.Parameters.AddWithValue("@prix", Entity.PrixHT);
            St.Parameters.AddWithValue("@quantite", Entity.Quantite);

            St.Parameters.AddWithValue("@id", Entity.Reference);
            St.ExecuteNonQuery();
        }

        /// <summary>
        /// Supprime tout les articles de la table
        /// </summary>
        public void DropDonnees()
        {
            var Conn = ConnectionDB.DBConnection;
            var St = Conn.CreateCommand();
            St.CommandText = "DELETE FROM Articles";
            St.ExecuteNonQuery();
        }

        /// <summary>
        /// Récupere tout les articles d'une marque
        /// </summary>
        /// <param name="discriminateur"> la marque a utiliser pour trouver les articles </param>
        /// <returns> une liste d'articles contenant tous les articles de cette marque </returns>
        public List<Article> GetAllByMarque(Marque discriminateur)
        {
            var Conn = ConnectionDB.DBConnection;
            var St = Conn.CreateCommand();
            St.CommandText = "SELECT * FROM Articles WHERE RefMarque=@id";
            St.Parameters.AddWithValue("@id", discriminateur.RefMarque);
            SQLiteDataReader Reader = St.ExecuteReader();
            var List = new List<Article>();
            while (Reader.Read())
            {
                Article ArticleTemp = new Article();
                ArticleTemp.Reference = Reader.GetString(0);
                ArticleTemp.Description = Reader.GetString(1);

                DAOSousFamilles DaoSousFamilles = new DAOSousFamilles();
                ArticleTemp.SousFamille = DaoSousFamilles.GetById(Reader.GetInt32(2));

                DAOMarques DaoMarques = new DAOMarques();
                ArticleTemp.Marque = DaoMarques.GetById(Reader.GetInt32(3));

                ArticleTemp.PrixHT = Reader.GetFloat(4);
                ArticleTemp.Quantite = Reader.GetInt32(5);
                List.Add(ArticleTemp);
            }
            return List;
        }

        /// <summary>
        /// Récupere tout les articles d'une sous famille
        /// </summary>
        /// <param name="discriminateur"> la sous famille a utiliser pour trouver les articles </param>
        /// <returns> une liste d'articles contenant tous les articles ayant cette sous famille</returns>
        public List<Article> GetAllBySousFamille(SousFamille discriminateur)
        {
            var Conn = ConnectionDB.DBConnection;
            var St = Conn.CreateCommand();
            St.CommandText = "SELECT * FROM Articles WHERE RefSousFamille=@id";
            St.Parameters.AddWithValue("@id", discriminateur.RefSousFamille);
            SQLiteDataReader Reader = St.ExecuteReader();
            var List = new List<Article>();
            while (Reader.Read())
            {
                Article ArticleTemp = new Article();
                ArticleTemp.Reference = Reader.GetString(0);
                ArticleTemp.Description = Reader.GetString(1);

                DAOSousFamilles DaoSousFamilles = new DAOSousFamilles();
                ArticleTemp.SousFamille = DaoSousFamilles.GetById(Reader.GetInt32(2));

                DAOMarques DaoMarques = new DAOMarques();
                ArticleTemp.Marque = DaoMarques.GetById(Reader.GetInt32(3));

                ArticleTemp.PrixHT = Reader.GetFloat(4);
                ArticleTemp.Quantite = Reader.GetInt32(5);
                List.Add(ArticleTemp);
            }
            return List;
        }


        /// <summary>
        /// Récupere le dernier Id inséré dans la table
        /// Ne pas utiliser pour cette table car elle utilise des clé en string
        /// </summary>
        /// <returns>le dernier Id inséré dans la table</returns>
        public int GetLastInsertedId()
        {
            throw new InvalidOperationException();
        }

        
    }
}
