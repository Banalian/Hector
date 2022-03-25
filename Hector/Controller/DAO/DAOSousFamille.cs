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
    /// DAO permettant d'interagir avec la base de donnée pour la classe SousFamille
    /// </summary>
    public class DAOSousFamilles : DAO<Model.SousFamille>
    {
        /// <summary>
        /// Ajoute une nouvelle sous famille
        /// </summary>
        /// <param name="Entity">La sous famille à ajouter (avec tout ses paramètres)</param>
        /// <returns>Cette même sous famille avec l'Id qui lui a été attribué par la bdd</returns>
        public SousFamille Add(SousFamille Entity)
        {
            var Conn = ConnectionDB.DBConnection;
            var St = Conn.CreateCommand();
            St.CommandText = "INSERT INTO SousFamilles('RefFamille','nom') VALUES(@idFamille, @nom)";
            St.Parameters.AddWithValue("@idFamille", Entity.RefFamille.RefFamille);
            St.Parameters.AddWithValue("@nom", Entity.NomSousFamille);
            St.ExecuteNonQuery();
            Entity.RefSousFamille = ConnectionDB.Dernier_Id_Insert();
            return Entity;
        }

        /// <summary>
        /// Supprime une sous famille par son Id
        /// </summary>
        /// <param name="Id">l'Id de la sous famille à supprimer</param>
        public void DeleteById(int Id)
        {
            var Conn = ConnectionDB.DBConnection;
            var St = Conn.CreateCommand();
            St.CommandText = "DELETE FROM SousFamilles WHERE RefSousFamille=@id";
            St.Parameters.AddWithValue("@id", Id);
            St.ExecuteNonQuery();
        }

        /// <summary>
        /// Récupère une liste de toute les sous familles de la table.
        /// </summary>
        /// <returns>Une liste contenant toute les sous familles contenues dans la table de la bdd</returns>
        public List<SousFamille> GetAll()
        {
            var Conn = ConnectionDB.DBConnection;
            var St = Conn.CreateCommand();
            St.CommandText = "SELECT * FROM SousFamilles";
            SQLiteDataReader Reader = St.ExecuteReader();
            var List = new List<SousFamille>();
            while (Reader.Read())
            {
                SousFamille SousFamilleTemp = new SousFamille();
                SousFamilleTemp.RefSousFamille = Reader.GetInt32(0);
                // On utilise le DAO des familles pour trouver la bonne sous famille.
                DAOFamilles DaoFamille = new DAOFamilles();
                SousFamilleTemp.RefFamille = DaoFamille.GetById(Reader.GetInt32(1));
                SousFamilleTemp.NomSousFamille = Reader.GetString(2);
                List.Add(SousFamilleTemp);
            }
            return List;

        }

        /// <summary>
        /// Récupere une SousFamille selon son id dans la base de données
        /// </summary>
        /// <param name="Id"> l'Id de la sous famille recherchée</param>
        /// <returns>la sous famille qui à cet Id</returns>
        public SousFamille GetById(int Id)
        {
            return GetById(Id.ToString());
        }

        /// <summary>
        /// Récupere une SousFamille selon son id dans la base de données
        /// </summary>
        /// <param name="Id"> l'Id de la sous famille recherchée</param>
        /// <returns>la sous famille qui à cet Id</returns>
        public SousFamille GetById(string Id)
        {
            var Conn = ConnectionDB.DBConnection;
            var St = Conn.CreateCommand();
            St.CommandText = "SELECT * FROM SousFamilles WHERE RefSousFamille=@id";
            St.Parameters.AddWithValue("@id", Id);
            SQLiteDataReader Reader = St.ExecuteReader();
            SousFamille SousFamilleTemp = new SousFamille();
            if (Reader.Read())
            {
                SousFamilleTemp.RefSousFamille = Reader.GetInt32(0);
                // On utilise le DAO des familles pour trouver la bonne sous famille.
                DAOFamilles DaoFamille = new DAOFamilles();
                SousFamilleTemp.RefFamille = DaoFamille.GetById(Reader.GetInt32(1));
                SousFamilleTemp.NomSousFamille = Reader.GetString(2);
            }
            return SousFamilleTemp;

        }

        /// <summary>
        /// Update une sous famille en changeant tout ses paramètres
        /// </summary>
        /// <param name="Entity"> La sous famille à modifier (son Id doit être celui de la famille que l'on modifie)</param>
        public void UpdateById(SousFamille Entity)
        {
            var Conn = ConnectionDB.DBConnection;
            var St = Conn.CreateCommand();
            St.CommandText = "UPDATE SousFamilles SET 'RefFamille'=@idFamille,'Nom'=@nom WHERE RefSousFamille=@id";
            St.Parameters.AddWithValue("@idFamille", Entity.RefFamille.RefFamille);
            St.Parameters.AddWithValue("@nom", Entity.NomSousFamille);
            St.Parameters.AddWithValue("@id", Entity.RefSousFamille);
            St.ExecuteNonQuery();
        }
    }
}
