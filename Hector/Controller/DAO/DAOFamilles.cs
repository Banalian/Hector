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
    /// DAO permettant d'interagir avec la base de donnée pour la classe Famille
    /// </summary>
    internal class DAOFamilles : DAO<Model.Famille>
    {
        /// <summary>
        /// Ajoute une nouvelle famille
        /// </summary>
        /// <param name="Entity">La famille à ajouter (avec tout ses paramètres)</param>
        /// <returns>Cette même famille avec l'Id qui lui a été attribué par la bdd</returns>
        public Famille Add(Famille Entity)
        {
            var Conn = ConnectionDB.DBConnection;
            var St = Conn.CreateCommand();
            St.CommandText = "INSERT INTO Familles('nom') VALUES(@nom)";
            St.Parameters.AddWithValue("@nom", Entity.NomFamille);
            St.ExecuteNonQuery();
            Entity.RefFamille = ConnectionDB.Dernier_Id_Insert();
            return Entity;
        }

        /// <summary>
        /// Supprime une famille par son Id
        /// </summary>
        /// <param name="Id">l'Id de la famille à supprimer</param>
        public void DeleteById(int Id)
        {
            var Conn = ConnectionDB.DBConnection;
            var St = Conn.CreateCommand();
            St.CommandText = "DELETE FROM Familles WHERE RefFamille=@id";
            St.Parameters.AddWithValue("@id",Id);
            St.ExecuteNonQuery();
        }

        /// <summary>
        /// Récupère une liste de toute les familles de la table.
        /// </summary>
        /// <returns>Une liste contenant toute les familles contenues dans la table de la bdd</returns>
        public List<Famille> GetAll()
        {
            var Conn = ConnectionDB.DBConnection;
            var St = Conn.CreateCommand();
            St.CommandText = "SELECT * FROM Familles";
            SQLiteDataReader Reader = St.ExecuteReader();
            var List = new List<Famille>();
            while (Reader.Read())
            {
                Famille FamilleTemp = new Famille();
                FamilleTemp.RefFamille = Reader.GetInt32(0);
                FamilleTemp.NomFamille = Reader.GetString(1);
                List.Add(FamilleTemp);
            }
            return List;
            
        }

        /// <summary>
        /// Récupere une Famille selon son id dans la base de données
        /// </summary>
        /// <param name="Id"> l'Id de la famille recherchée</param>
        /// <returns>la famille qui à cet Id</returns>
        public Famille GetById(int Id)
        {
            return GetById(Id.ToString());
        }

        /// <summary>
        /// Récupere une Famille selon son id dans la base de données
        /// </summary>
        /// <param name="Id"> l'Id de la famille recherchée</param>
        /// <returns>la famille qui à cet Id</returns>
        public Famille GetById(string Id)
        {
            var Conn = ConnectionDB.DBConnection;
            var St = Conn.CreateCommand();
            St.CommandText = "SELECT * FROM Familles WHERE RefFamille=@id";
            St.Parameters.AddWithValue("@id", Id);
            SQLiteDataReader Reader = St.ExecuteReader();
            Famille FamilleTemp = new Famille();
            if (Reader.Read())
            {
                FamilleTemp.RefFamille = Reader.GetInt32(0);
                FamilleTemp.NomFamille = Reader.GetString(1);
            }
            return FamilleTemp;

        }

        /// <summary>
        /// Update une famille en changeant tout ses paramètres
        /// </summary>
        /// <param name="Entity"> La famille à modifier (son Id doit être celui de la famille que l'on modifie)</param>
        public void UpdateById(Famille Entity)
        {
            var Conn = ConnectionDB.DBConnection;
            var St = Conn.CreateCommand();
            St.CommandText = "UPDATE Familles SET 'Nom'=@nom WHERE RefFamille=@id";
            St.Parameters.AddWithValue("@nom", Entity.NomFamille);
            St.Parameters.AddWithValue("@id", Entity.RefFamille);
            St.ExecuteNonQuery();
        }
    }
}
