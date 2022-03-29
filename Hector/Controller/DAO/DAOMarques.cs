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
    internal class DAOMarques : DAO<Model.Marque>
    {
        /// <summary>
        /// Ajoute une nouvelle marque
        /// </summary>
        /// <param name="Entity">La marque à ajouter (avec tout ses paramètres)</param>
        /// <returns>Cette même marque avec l'Id qui lui a été attribué par la bdd</returns>
        public Marque Add(Marque Entity)
        {
            var Conn = ConnectionDB.DBConnection;
            var St = Conn.CreateCommand();
            St.CommandText = "INSERT INTO Marques('nom') VALUES(@nom)";
            St.Parameters.AddWithValue("@nom", Entity.NomMarque);
            St.ExecuteNonQuery();
            Entity.RefMarque = GetLastInsertedId();
            return Entity;
        }

        /// <summary>
        /// Supprime une marque par son Id
        /// </summary>
        /// <param name="Id">l'Id de la marque à supprimer</param>
        public void DeleteById(int Id)
        {
            var Conn = ConnectionDB.DBConnection;
            var St = Conn.CreateCommand();
            St.CommandText = "DELETE FROM Marques WHERE RefMarque=@id";
            St.Parameters.AddWithValue("@id", Id);
            St.ExecuteNonQuery();
        }

        /// <summary>
        /// Récupère une liste de toute les marque de la table.
        /// </summary>
        /// <returns>Une liste contenant toute les marque contenues dans la table de la bdd</returns>
        public List<Marque> GetAll()
        {
            var Conn = ConnectionDB.DBConnection;
            var St = Conn.CreateCommand();
            St.CommandText = "SELECT * FROM Marques";
            SQLiteDataReader Reader = St.ExecuteReader();
            var List = new List<Marque>();
            while (Reader.Read())
            {
                Marque MarqueTemp = new Marque();
                MarqueTemp.RefMarque = Reader.GetInt32(0);
                MarqueTemp.NomMarque = Reader.GetString(1);
                List.Add(MarqueTemp);
            }
            return List;

        }

        /// <summary>
        /// Récupere une marque selon son id dans la base de données
        /// </summary>
        /// <param name="Id"> l'Id de la marque recherchée</param>
        /// <returns>la marque qui à cet Id</returns>
        public Marque GetById(int Id)
        {
            return GetById(Id.ToString());
        }

        /// <summary>
        /// Récupere une marque selon son id dans la base de données
        /// </summary>
        /// <param name="Id"> l'Id de la marque recherchée</param>
        /// <returns>la marque qui à cet Id</returns>
        public Marque GetById(string Id)
        {
            var Conn = ConnectionDB.DBConnection;
            var St = Conn.CreateCommand();
            St.CommandText = "SELECT * FROM Marques WHERE RefMarque=@id";
            St.Parameters.AddWithValue("@id", Id);
            SQLiteDataReader Reader = St.ExecuteReader();
            Marque MarqueTemp = new Marque();
            if (Reader.Read())
            {
                MarqueTemp.RefMarque = Reader.GetInt32(0);
                MarqueTemp.NomMarque = Reader.GetString(1);
            }
            return MarqueTemp;

        }

        /// <summary>
        /// Update une marque en changeant tout ses paramètres
        /// </summary>
        /// <param name="Entity"> La marque à modifier (son Id doit être celui de la marque que l'on modifie)</param>
        public void UpdateById(Marque Entity)
        {
            var Conn = ConnectionDB.DBConnection;
            var St = Conn.CreateCommand();
            St.CommandText = "UPDATE Marques SET 'Nom'=@nom WHERE RefMarque=@id";
            St.Parameters.AddWithValue("@nom", Entity.NomMarque);
            St.Parameters.AddWithValue("@id", Entity.RefMarque);
            St.ExecuteNonQuery();
        }

        /// <summary>
        /// Supprime toutes les marques de la table
        /// </summary>
        public void DropDonnees()
        {
            var Conn = ConnectionDB.DBConnection;
            var St = Conn.CreateCommand();
            St.CommandText = "DELETE FROM Marques";
            St.ExecuteNonQuery();
        }

        /// <summary>
        /// Récupere le dernier Id inséré dans la table
        /// </summary>
        /// <returns>le dernier Id inséré dans la table</returns>
        public int GetLastInsertedId()
        {
            string sql = "select seq from sqlite_sequence where name='Marques';";
            SQLiteCommand cmd = new SQLiteCommand(sql, ConnectionDB.DBConnection);
            int newId = Convert.ToInt32(cmd.ExecuteScalar());
            return newId;
        }
    }
}
