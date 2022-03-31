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

        private void importerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormImport importForm = new FormImport();
            importForm.ShowDialog();

            // On actualise le treeView
            ActualiserTreeView();
        }

        //--------------------------------------------- TREE VIEW ---------------------------------------------


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
        
        
        private void ViderListView()
        {
            listView1.Items.Clear();
            listView1.Columns.Clear();
        }
        
        
        private void SetupArticleListView()
        {
            ViderListView();

            listView1.Columns.Add("Description", "Description", 100);
            listView1.Columns.Add("Familles", "Familles", 100);
            listView1.Columns.Add("SousFamilles", "Sous-familles", 100);
            listView1.Columns.Add("Marques", "Marques", 100);
            listView1.Columns.Add("Quantite", "Quantité", 100);
        }

        private void SetupDescriptionListView()
        {
            ViderListView();
            listView1.Columns.Add("Description", "Description", 100);
        }

    }
}
