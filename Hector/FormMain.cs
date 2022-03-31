using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Hector
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Appelle le form d'importation des données, avant d'actualiser l'arborescence
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void importerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormImport importForm = new FormImport();
            importForm.ShowDialog();

            // On actualise le treeView
            ActualiserTreeView();
        }

        //--------------------------------------------- TREE VIEW ---------------------------------------------

        /// <summary>
        /// Actualise la listView après une séléction d'un item dans le treeView par l'utilisateur
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if(e.Action != TreeViewAction.Expand && e.Action != TreeViewAction.Collapse)
            {
                // On regarde si le node contient un tag
                if (e.Node.Tag != null)
                {
                    // On detecte le type de l'item selectionne
                    if (e.Node.Tag.GetType() == typeof(Model.Marque))
                    {
                        // On affiche la liste des articles de la marque
                        SetupArticleListView();
                    }
                    else if (e.Node.Tag.GetType() == typeof(Model.Famille))
                    {
                        // On affiche la liste des sous familles de la famille
                        SetupDescriptionListView();
                    }
                    else if (e.Node.Tag.GetType() == typeof(Model.SousFamille))
                    {
                        // On affiche la liste des articles de la sous famille
                        SetupArticleListView();
                    }
                    else 
                    {
                        MessageBox.Show("Erreur : Type de l'item non reconnu/non valide, type = " + e.Node.Tag.GetType().ToString());
                    }
                }
                else
                {
                    // Si le noeud n'a pas de tag, c'est que c'est soit le noeud "Tous les articles" ou "Familles" ou "Marques"
                    // On regarde le nom du noeud
                    if (e.Node.Text == "Tous les articles")
                    {
                        // On affiche tous les articles
                        SetupArticleListView();
                        ListViewFillData(ListViewDisplayType.ARTICLES, null);


                    }
                    else if (e.Node.Text == "Familles")
                    {
                        // On affiche toutes les familles
                        SetupDescriptionListView();
                        
                    }
                    else if (e.Node.Text == "Marques")
                    {
                        // On affiche toutes les marques
                        SetupDescriptionListView();
                    }
                    else
                    {
                        MessageBox.Show("Erreur : Nom du noeud non reconnu/non valide, nom = " + e.Node.Text);
                    }
                }



            }
        }

        /// <summary>
        /// Actualise le treeView en le regénérant
        /// </summary>
        private void ActualiserTreeView()
        {
            treeView1.Nodes.Clear();
            treeView1.Nodes.Add(new TreeNode("Tous les articles"));
            treeView1.Nodes.Add(new TreeNode("Familles"));
            treeView1.Nodes.Add(new TreeNode("Marques"));

            Controller.DAO.DAOFamilles DaoFamilles = new Controller.DAO.DAOFamilles();
            Controller.DAO.DAOMarques DaoMarques = new Controller.DAO.DAOMarques();
            Controller.DAO.DAOSousFamilles DaoSousFamilles = new Controller.DAO.DAOSousFamilles();

            foreach (Model.Famille famille in DaoFamilles.GetAll())
            {
                TreeNode familleNode = new TreeNode(famille.NomFamille);
                familleNode.Tag = famille;
                treeView1.Nodes[1].Nodes.Add(familleNode);
                foreach (Model.SousFamille sousFamille in DaoSousFamilles.GetAll(famille.RefFamille))
                {
                    TreeNode sousFamilleNode = new TreeNode(sousFamille.NomSousFamille);
                    sousFamilleNode.Tag = sousFamille;
                    familleNode.Nodes.Add(sousFamilleNode);
                }
            }

            foreach (Model.Marque marque in DaoMarques.GetAll())
            {
                TreeNode marqueNode = new TreeNode(marque.NomMarque);
                marqueNode.Tag = marque;
                treeView1.Nodes[2].Nodes.Add(marqueNode);
            }

        }


        //--------------------------------------------- LIST VIEW ---------------------------------------------

        /// <summary>
        /// Vide la listView de toutes les données et colonnes
        /// </summary>
        private void ViderListView()
        {
            listView1.Items.Clear();
            listView1.Columns.Clear();
        }

        /// <summary>
        /// Met en place la listView pour afficher les articles
        /// </summary>
        private void SetupArticleListView()
        {
            ViderListView();

            listView1.Columns.Add("Description", "Description", 100);
            listView1.Columns.Add("Familles", "Familles", 100);
            listView1.Columns.Add("SousFamilles", "Sous-familles", 100);
            listView1.Columns.Add("Marques", "Marques", 100);
            listView1.Columns.Add("Quantite", "Quantité", 100);
        }

        /// <summary>
        /// Met en place la listView pour afficher les familles, sous familles ou marques
        /// </summary>
        private void SetupDescriptionListView()
        {
            ViderListView();
            listView1.Columns.Add("Description", "Description", 100);
        }

        /// <summary>
        /// Enum pour définir le type de données à afficher dans la listView
        /// </summary>
        private enum ListViewDisplayType
        {
            ARTICLES,
            FAMILLES,
            SOUSFAMILLES,
            MARQUES
        }

        /// <summary>
        /// Remplit la listView avec les données de la table en fonction du type et d'un potentiel discriminateur
        /// </summary>
        /// <param name="Type"> Le type de données qui va remplir le listView</param>
        /// <param name="discriminateur"> comment les données seront choisies (par exemple null pour tout prendre, ou un objet pour choisir ceux ayant le même)</param>
        private void ListViewFillData(ListViewDisplayType Type, object discriminateur = null)
        {
            // On regarde le type d'element a afficher
            switch (Type)
            {
                case ListViewDisplayType.ARTICLES:
                    // On regarde le discriminateur pour savoir :
                    // - si on affiche tous les articles sans filtre (discriminateur = null),
                    // - si on affiche les articles d'une marque (discriminateur = Marque)
                    // - si on affiche les articles d'une sous famille (discriminateur = sousFamille)

                    if (discriminateur == null)
                    {
                        // On affiche tous les articles
                        Controller.DAO.DAOArticles DaoArticles = new Controller.DAO.DAOArticles();
                        foreach (Model.Article article in DaoArticles.GetAll())
                        {
                            ListViewItem item;
                            string[] itemDesc = new string[5];
                            itemDesc[0] = article.Description;
                            itemDesc[1] = article.SousFamille.Famille.NomFamille;
                            itemDesc[2] = article.SousFamille.NomSousFamille;
                            itemDesc[3] = article.Marque.NomMarque;
                            itemDesc[4] = article.Quantite.ToString();
                            item = new ListViewItem(itemDesc);
                            listView1.Items.Add(item);
                        }
                    }
                    else if (discriminateur.GetType() == typeof(Model.Marque))
                    {
                        // On affiche les articles d'une marque
                        Controller.DAO.DAOArticles DaoArticles = new Controller.DAO.DAOArticles();
                        foreach (Model.Article article in DaoArticles.GetAllByMarque((Model.Marque)discriminateur))
                        {

                        }
                    }
                    else if (discriminateur.GetType() == typeof(Model.SousFamille))
                    {
                        // On affiche les articles d'une sous famille
                        Controller.DAO.DAOArticles DaoArticles = new Controller.DAO.DAOArticles();
                        foreach (Model.Article article in DaoArticles.GetAllBySousFamille((Model.SousFamille)discriminateur))
                        {

                        }
                    }
                    else
                    {
                        MessageBox.Show("Erreur : Type de discriminateur non reconnu/non valide, type = " + discriminateur.GetType().ToString());
                    }
                    break;
                    
                    
                case ListViewDisplayType.FAMILLES:
                    break;
                case ListViewDisplayType.SOUSFAMILLES:
                    break;
                case ListViewDisplayType.MARQUES:
                    break;
                default:
                    MessageBox.Show("Erreur : Type d'affichage non reconnu/non valide, type = " + Type.ToString());
                    break;
            }
        }

    }
}
