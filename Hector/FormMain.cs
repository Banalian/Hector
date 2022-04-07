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


        /// <summary>
        /// Event handler de l'evenement du bouton "actualiser"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void actualiserToolStripMenuItem_Click(object sender, EventArgs e)
        {
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

        /// <summary>
        /// Crée un item article pour la listView
        /// </summary>
        /// <param name="Article">L'article à utiliser pour l'item</param>
        /// <returns>un nouvel item avec les informations de cet article</returns>
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

        /// <summary>
        /// Crée un item pour la listView avec une description (utile pour la famille, marque etc..)
        /// </summary>
        /// <param name="Article">L'objet à utiliser pour l'item</param>
        /// <returns>un nouvel item avec le nom de cet objet, null si l'item n'a pas une classe connue</returns>
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

        // --------------- Tri ---------------


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

        // -------------------------- Modification/Ajout/Delete --------------------------

        /// <summary>
        /// Fonction de modification d'un élément de la liste. Ouvre une fenetre de modification de l'élément avant de le modifier dans la base de données et la liste.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView1_ItemSelected(object sender, MouseEventArgs e)
        {
            // On recupère l'objet sélectionné puis on recupere son tag pour obtenir l'objet contenu
            ListViewItem Item = listView1.SelectedItems[0];
            object Objet = Item.Tag;
            
            
            FormModification FormModif = new FormModification(TypeAfficheActuel,2,Objet);
            FormModif.ShowDialog();
            if(FormModif.DialogResult == DialogResult.OK)
            {
                Debug.WriteLine(FormModif.Objet);
                // On recupere le type de l'objet avant de le modifier dans la BDD avec le DAO. Ensuite, on change l'objet dans la liste avec les nouvelles données
                if (Objet.GetType() == typeof(Model.Article))
                {
                    Controller.DAO.DAOArticles DaoArticles = new Controller.DAO.DAOArticles();
                    DaoArticles.UpdateById((Model.Article)Objet);
                    Item = CreerListeViewItemArticle((Model.Article)Objet);
                    Item.Tag = Objet;
                    listView1.Items[listView1.SelectedIndices[0]] = Item;
                }
                else if (Objet.GetType() == typeof(Model.Famille))
                {
                    Controller.DAO.DAOFamilles DaoFamilles = new Controller.DAO.DAOFamilles();
                    DaoFamilles.UpdateById((Model.Famille)Objet);
                    Item = CreerListeViewItemDescription(Objet);
                    Item.Tag = Objet;
                    listView1.Items[listView1.SelectedIndices[0]] = Item;
                }
                else if (Objet.GetType() == typeof(Model.Marque))
                {
                    Controller.DAO.DAOMarques DaoMarques = new Controller.DAO.DAOMarques();
                    DaoMarques.UpdateById((Model.Marque)Objet);
                    Item = CreerListeViewItemDescription(Objet);
                    Item.Tag = Objet;
                    listView1.Items[listView1.SelectedIndices[0]] = Item;
                }
                else if (Objet.GetType() == typeof(Model.SousFamille))
                {
                    Controller.DAO.DAOSousFamilles DaoSousFamilles = new Controller.DAO.DAOSousFamilles();
                    DaoSousFamilles.UpdateById((Model.SousFamille)Objet);
                    Item = CreerListeViewItemDescription(Objet);
                    Item.Tag = Objet;
                    listView1.Items[listView1.SelectedIndices[0]] = Item;
                }
                else
                {
                    MessageBox.Show("Erreur : Type de l'objet non reconnu/non valide, type = " + Objet.GetType().ToString());
                }
            }
        }

        /// <summary>
        /// Event handler de l'evenement de l'ouverture du menu contextuel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            //Si aucun item n'est selectionné, les options de suppression et de modification sont grisées
            if (listView1.SelectedItems.Count > 0)
            {
                supprimerLélémentToolStripMenuItem.Enabled = true;
                modifierLélémentToolStripMenuItem.Enabled = true;
            }
            else
            {
                supprimerLélémentToolStripMenuItem.Enabled = false;
                modifierLélémentToolStripMenuItem.Enabled = false
            }
        }

        /// <summary>
        /// Event handler de l'evenement de la modification d'un élément de la liste
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void modifierLélémentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1_ItemSelected(sender, null);
        }

        /// <summary>
        /// Event handler de l'evenement de l'ajout d'un element
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ajouterUnElementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormModification FormModif = new FormModification(TypeAfficheActuel, 1);
            FormModif.ShowDialog();

            if (FormModif.DialogResult == DialogResult.OK)
            {
                // On recupere le type de l'objet avant de l'inserer dans la BDD avec le DAO. Ensuite, on ajoute l'objet dans la liste avec les nouvelles données
                if (FormModif.Objet.GetType() == typeof(Model.Article))
                {
                    Controller.DAO.DAOArticles DaoArticles = new Controller.DAO.DAOArticles();
                    DaoArticles.Add((Model.Article)FormModif.Objet);
                    ListViewItem Item = CreerListeViewItemArticle((Model.Article)FormModif.Objet);
                    Item.Tag = FormModif.Objet;
                    listView1.Items.Add(Item);
                }
                else if (FormModif.Objet.GetType() == typeof(Model.Famille))
                {
                    Controller.DAO.DAOFamilles DaoFamilles = new Controller.DAO.DAOFamilles();
                    DaoFamilles.Add((Model.Famille)FormModif.Objet);
                    ListViewItem Item = CreerListeViewItemDescription(FormModif.Objet);
                    Item.Tag = FormModif.Objet;
                    listView1.Items.Add(Item);
                    // On ajoute également la famille dans le TreeView
                    TreeNode Famille = new TreeNode(((Model.Famille)FormModif.Objet).NomFamille);
                    Famille.Tag = FormModif.Objet;
                    treeView1.Nodes[1].Nodes.Add(Famille);
                }
                else if (FormModif.Objet.GetType() == typeof(Model.Marque))
                {
                    Controller.DAO.DAOMarques DaoMarques = new Controller.DAO.DAOMarques();
                    DaoMarques.Add((Model.Marque)FormModif.Objet);
                    ListViewItem Item = CreerListeViewItemDescription(FormModif.Objet);
                    Item.Tag = FormModif.Objet;
                    listView1.Items.Add(Item);
                    // On ajoute également la marque dans le TreeView
                    TreeNode Marque = new TreeNode(((Model.Marque)FormModif.Objet).NomMarque);
                    Marque.Tag = FormModif.Objet;
                    treeView1.Nodes[2].Nodes.Add(Marque);
                }
                else if (FormModif.Objet.GetType() == typeof(Model.SousFamille))
                {
                    Controller.DAO.DAOSousFamilles DaoSousFamilles = new Controller.DAO.DAOSousFamilles();
                    DaoSousFamilles.Add((Model.SousFamille)FormModif.Objet);
                    ListViewItem Item = CreerListeViewItemDescription(FormModif.Objet);
                    Item.Tag = FormModif.Objet;
                    listView1.Items.Add(Item);
                    // On ajoute également la sous famille dans le TreeView
                    TreeNode SousFamille = new TreeNode(((Model.SousFamille)FormModif.Objet).NomSousFamille);
                    SousFamille.Tag = FormModif.Objet;
                    //On cherche la famille parente de la sous famille
                    foreach (TreeNode Famille in treeView1.Nodes[1].Nodes)
                    {
                        if (((Model.SousFamille)FormModif.Objet).Famille == ((Model.Famille)Famille.Tag))
                        {
                            Famille.Nodes.Add(SousFamille);
                            break;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Erreur : Type de l'objet non reconnu/non valide, type = " + FormModif.Objet.GetType().ToString());
                }
            
            }
        }
    }
}
