using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hector.Controller.DAO
{
    /// <summary>
    /// Interface permettant de réaliser un DAO pour faire la liaison entre une base de donnée et une classe.
    /// </summary>
    /// <typeparam name="T">La classe de l'objet</typeparam>
    internal interface DAO<T>
    {
        /// <summary>
        /// Récupere un objet T selon son id dans la base de données
        /// </summary>
        /// <param name="Id"> l'Id de l'objet recherché</param>
        /// <returns>l'objet qui à cet Id</returns>
        T GetById(int Id);

        /// <summary>
        /// Récupere un objet T selon son id dans la base de données
        /// </summary>
        /// <param name="Id"> l'Id de l'objet recherché</param>
        /// <returns>l'objet qui à cet Id</returns>
        T GetById(string Id);

        /// <summary>
        /// Update un objet T en changeant tout ses paramètres
        /// </summary>
        /// <param name="Entity"> L'entité à modifier (son Id doit être celui de l'entité que l'on modifie)</param>
        void UpdateById(T Entity);
        
        /// <summary>
        /// Supprime un objet par son Id
        /// </summary>
        /// <param name="Id">l'Id de l'objet a supprimer</param>
        void DeleteById(int Id);

        /// <summary>
        /// Récupère une liste de tout les objets de la table.
        /// </summary>
        /// <returns>Une liste contenant tout les objets contenus dans la table de la bdd</returns>
        List<T> GetAll();

        /// <summary>
        /// Ajoute une nouvelle entitée
        /// </summary>
        /// <param name="Entity">L'entitée à ajouter (avec tout ses paramètres)</param>
        /// <returns>Cette même entitée avec l'Id qui lui a été attribué par la bdd</returns>
        T Add(T Entity);

        /// <summary>
        /// Supprime toutes les données de la table
        /// </summary>
        void DropDonnees();

        /// <summary>
        /// Récupere le dernier Id inséré dans la table
        /// </summary>
        /// <returns>le dernier Id inséré dans la table</returns>
        int GetLastInsertedId();
    }
}
