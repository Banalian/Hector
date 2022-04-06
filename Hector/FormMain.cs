using System;
using static Hector.Model.Article;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Collections.Generic;

namespace Hector
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();

            // Connexion de l'evenement ListView.ColumnClick au handler  d'evenements ColumnClick.
            this.listView1.ColumnClick += new ColumnClickEventHandler(ColumnClick);
            listView1.Sorting = SortOrder.Ascending;

            this.listView1.MouseClick += new MouseEventHandler(RightClick);

            ActualiserTreeView();
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
            if (e.Action != TreeViewAction.Expand && e.Action != TreeViewAction.Collapse)
            {
                // On regarde si le node contient un tag
                if (e.Node.Tag != null)
                {
                    // On detecte le type de l'item selectionne
                    if (e.Node.Tag.GetType() == typeof(Model.Marque))
                    {
                        // On affiche la liste des articles de la marque
                        SetupArticleListView();
                        ListViewFillData(ListViewDisplayType.ARTICLES, e.Node.Tag);
                    }
                    else if (e.Node.Tag.GetType() == typeof(Model.Famille))
                    {
                        // On affiche la liste des sous familles de la famille
                        SetupDescriptionListView(ListViewDisplayType.SOUSFAMILLES);
                        ListViewFillData(ListViewDisplayType.SOUSFAMILLES, e.Node.Tag);
                    }
                    else if (e.Node.Tag.GetType() == typeof(Model.SousFamille))
                    {
                        // On affiche la liste des articles de la sous famille
                        SetupArticleListView();
                        ListViewFillData(ListViewDisplayType.ARTICLES, e.Node.Tag);
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
                        SetupDescriptionListView(ListViewDisplayType.FAMILLES);
                        ListViewFillData(ListViewDisplayType.FAMILLES, null);
                    }
                    else if (e.Node.Text == "Marques")
                    {
                        // On affiche toutes les marques
                        SetupDescriptionListView(ListViewDisplayType.MARQUES);
                        ListViewFillData(ListViewDisplayType.MARQUES, null);
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
                foreach (Model.SousFamille sousFamille in DaoSousFamilles.GetAllByFamille(famille))
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
        /// Enum pour définir le type de données à afficher dans la listView
        /// </summary>
        public enum ListViewDisplayType
        {
            ARTICLES,
            FAMILLES,
            SOUSFAMILLES,
            MARQUES,
            NONVALIDE
        }
        ListViewDisplayType TypeAfficheActuel = ListViewDisplayType.NONVALIDE;


        /// <summary>
        /// Vide la listView de toutes les données et colonnes
        /// </summary>
        private void ViderListView()
        {
            listView1.Items.Clear();
            listView1.Columns.Clear();
            TypeAfficheActuel = ListViewDisplayType.NONVALIDE;
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

            TypeAfficheActuel = ListViewDisplayType.ARTICLES;
        }

        /// <summary>
        /// Met en place la listView pour afficher les familles, sous familles ou marques
        /// </summary>
        private void SetupDescriptionListView(ListViewDisplayType Type)
        {
            ViderListView();
            listView1.Columns.Add("Description", "Description", 100);
            TypeAfficheActuel = Type;
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
                        foreach (Model.Article Article in DaoArticles.GetAll())
                        {
                            ListViewItem Item = CreerListeViewItemArticle(Article);
                            Item.Tag = Article;
                            listView1.Items.Add(Item);
                        }
                    }
                    else if (discriminateur.GetType() == typeof(Model.Marque))
                    {
                        // On affiche les articles d'une marque
                        Controller.DAO.DAOArticles DaoArticles = new Controller.DAO.DAOArticles();
                        foreach (Model.Article Article in DaoArticles.GetAllByMarque((Model.Marque)discriminateur))
                        {
                            ListViewItem Item = CreerListeViewItemArticle(Article);
                            Item.Tag = Article;
                            listView1.Items.Add(Item);
                        }
                    }
                    else if (discriminateur.GetType() == typeof(Model.SousFamille))
                    {
                        // On affiche les articles d'une sous famille
                        Controller.DAO.DAOArticles DaoArticles = new Controller.DAO.DAOArticles();
                        foreach (Model.Article Article in DaoArticles.GetAllBySousFamille((Model.SousFamille)discriminateur))
                        {
                            ListViewItem Item = CreerListeViewItemArticle(Article);
                            Item.Tag = Article;
                            listView1.Items.Add(Item);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Erreur : Type de discriminateur non reconnu/non valide, type = " + discriminateur.GetType().ToString());
                    }
                    break;

                case ListViewDisplayType.FAMILLES:
                    if (discriminateur == null)
                    {
                        Controller.DAO.DAOFamilles DaoFamilles = new Controller.DAO.DAOFamilles();
                        foreach (Model.Famille Famille in DaoFamilles.GetAll())
                        {
                            ListViewItem Item = CreerListeViewItemDescription(Famille);
                            Item.Tag = Famille;
                            listView1.Items.Add(Item);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Erreur : Type de discriminateur non reconnu/non valide, type = " + discriminateur.GetType().ToString());
                    }
                    break;

                case ListViewDisplayType.SOUSFAMILLES:
                    if (discriminateur == null)
                    {
                        Controller.DAO.DAOSousFamilles DaoSousFamilles = new Controller.DAO.DAOSousFamilles();
                        foreach (Model.SousFamille SousFamille in DaoSousFamilles.GetAll())
                        {
                            ListViewItem Item = CreerListeViewItemDescription(SousFamille);
                            Item.Tag = SousFamille;
                            listView1.Items.Add(Item);
                        }
                    }
                    else if (discriminateur.GetType() == typeof(Model.Famille))
                    {
                        Controller.DAO.DAOSousFamilles DaoSousFamilles = new Controller.DAO.DAOSousFamilles();
                        foreach (Model.SousFamille SousFamille in DaoSousFamilles.GetAllByFamille((Model.Famille)discriminateur))
                        {
                            ListViewItem Item = CreerListeViewItemDescription(SousFamille);
                            Item.Tag = SousFamille;
                            listView1.Items.Add(Item);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Erreur : Type de discriminateur non reconnu/non valide, type = " + discriminateur.GetType().ToString());
                    }
                    break;

                case ListViewDisplayType.MARQUES:
                    if (discriminateur == null)
                    {
                        Controller.DAO.DAOMarques DaoMarques = new Controller.DAO.DAOMarques();
                        foreach (Model.Marque Marque in DaoMarques.GetAll())
                        {
                            ListViewItem Item = CreerListeViewItemDescription(Marque);
                            Item.Tag = Marque;
                            listView1.Items.Add(Item);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Erreur : Type de discriminateur non reconnu/non valide, type = " + discriminateur.GetType().ToString());
                    }
                    break;

                default:
                    MessageBox.Show("Erreur : Type d'affichage non reconnu/non valide, type = " + Type.ToString());
                    break;
            }
        }

        private ListViewItem CreerListeViewItemArticle(Model.Article Article)
        {
            ListViewItem Item;
            string[] ItemDesc = new string[5];
            ItemDesc[0] = Article.Description;
            ItemDesc[1] = Article.SousFamille.Famille.NomFamille;
            ItemDesc[2] = Article.SousFamille.NomSousFamille;
            ItemDesc[3] = Article.Marque.NomMarque;
            ItemDesc[4] = Article.Quantite.ToString();
            Item = new ListViewItem(ItemDesc);
            return Item;
        }

        private ListViewItem CreerListeViewItemDescription(object Objet)
        {
            ListViewItem Item;          
            string[] ItemDesc = new string[1];
            if (Objet.GetType() == typeof(Model.Famille))
            {
                ItemDesc[0] = ((Model.Famille)Objet).NomFamille;
            }
            else if (Objet.GetType() == typeof(Model.Marque))
            {
                ItemDesc[0] = ((Model.Marque)Objet).NomMarque;
            }
            else if (Objet.GetType() == typeof(Model.SousFamille))
            {
                ItemDesc[0] = ((Model.SousFamille)Objet).NomSousFamille;
            }
            else
            {
                return null;
            }
            Item = new ListViewItem(ItemDesc);
            return Item;
        }

        /// <summary>
        /// Event handler de l'evenement ColumnClick
        /// </summary>
        /// <param name="o"> l'objet suur lequel on a clicke</param>
        /// <param name="e"> evenement click de la colonne</param>
        private void ColumnClick(object o, ColumnClickEventArgs e)
        {
            // On donne a la liste un nouveau Sorter qui se base sur la colonne clickee
            this.listView1.ListViewItemSorter = new ListViewItemComparer(e.Column);

        }

        private void RightClick(Object o, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Right:
                    {
                        contextMenuStrip1.Show(MousePosition);// placement du menu a la positiojn du pointeur

                        
                        //Si aucun item n'est selectionné, les options de suppression et de modification sont grisées
                        if (! listView1.ContainsFocus)
                        {
                            supprimerLélémentToolStripMenuItem.Enabled = false;
                            modifierLélémentToolStripMenuItem.Enabled = false;
                        }
                        else
                        {
                            supprimerLélémentToolStripMenuItem.Enabled = true;
                            modifierLélémentToolStripMenuItem.Enabled = true;

                        }
                        
                    }
                    break;
            }

        }
        
        // Implementation du Comparateur d'items par colonnes.
        class ListViewItemComparer : IComparer
        {
            private int col;
            public ListViewItemComparer()
            {
                col = 0;
            }
            public ListViewItemComparer(int column)
            {
                col = column;
            }
            public int Compare(object x, object y)
            {
                return String.Compare(((ListViewItem)x).SubItems[col].Text, ((ListViewItem)y).SubItems[col].Text);
            }

        }



        private void listView1_ItemSelected(object sender, MouseEventArgs e)
        {
            // On recupère l'objet sélectionné puis on recupere son tag pour obtenir l'objet contenu
            ListViewItem Item = listView1.SelectedItems[0];
            object Objet = Item.Tag;
            
            
            FormModification FormModif = new FormModification(TypeAfficheActuel,2,Objet);
            FormModif.ShowDialog();
            if(FormModif.DialogResult == DialogResult.OK)
            {
                Debug.WriteLine(FormModif.returnObjet());
            }
        }





    }
}
