using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hector
{
    public partial class FormModification : Form
    {
        /// <summary>
        /// Objet représentant l'objet à modifier, comme un article ou une marque par exemple
        /// </summary>
        public object Objet { get; private set; }

        /// <summary>
        /// Type de l'objet, afin de plus facilement le traiter
        /// </summary>
        private FormMain.ListViewDisplayType Type;

        /// <summary>
        /// Id de l'objet actuel
        /// </summary>
        private int IdObjet;

        /// <summary>
        /// Mode du formulaire (1 pour un ajout, 2 pour une modification)
        /// </summary>
        private int Mode;

        /// <summary>
        /// Constructeur de la fenêtre de modification/d'ajout
        /// </summary>
        /// <param name="type">Type de l'objet que l'on modifie/ajoute</param>
        /// <param name="mode">1 si on creer, 2 si on modifie</param>
        /// <param name="obj">l'objet a modifier, s'il existe</param>
        public FormModification(FormMain.ListViewDisplayType type, int mode = 1, object obj = null)
        {
            InitializeComponent();
            // On met la fenêtre au centre de son parent
            this.StartPosition = FormStartPosition.CenterParent;
            if (type == FormMain.ListViewDisplayType.NONVALIDE)
            {
                throw new Exception("Erreur : Type est non valide");
            }
            if (mode == 2 && obj == null)
            {
                throw new Exception("Erreur : mode 2 et objet null");
            }
            Objet = obj;
            Type = type;
            if (mode == 1)
            {
                buttonEnd.Text = "Ajouter";
            }
            else if (mode == 2)
            {
                buttonEnd.Text = "Modifier";
            }
            this.Mode = mode;


            // On affiche uniquement le formulaire qui nous interesse
            switch (Type)
            {
                case FormMain.ListViewDisplayType.ARTICLES:
                    {
                        tableLayoutPanelArticle.Visible = true;
                        tableLayoutPanelArticle.Enabled = true;
                        this.MinimumSize = new Size(tableLayoutPanelArticle.Width + 20, tableLayoutPanelArticle.Height + 200);
                        tableLayoutPanelArticle.Dock = DockStyle.Fill;
                        break;
                    }
                case FormMain.ListViewDisplayType.MARQUES:
                    {
                        tableLayoutPanelMarque.Visible = true;
                        tableLayoutPanelMarque.Enabled = true;
                        this.MinimumSize = new Size(tableLayoutPanelMarque.Width + 20, tableLayoutPanelMarque.Height + 200);
                        tableLayoutPanelMarque.Dock = DockStyle.Fill;
                        break;
                    }
                case FormMain.ListViewDisplayType.FAMILLES:
                    {
                        tableLayoutPanelFamille.Visible = true;
                        tableLayoutPanelFamille.Enabled = true;
                        this.MinimumSize = new Size(tableLayoutPanelFamille.Width + 20, tableLayoutPanelFamille.Height + 200);
                        tableLayoutPanelFamille.Dock = DockStyle.Fill;
                        break;
                    }
                case FormMain.ListViewDisplayType.SOUSFAMILLES:
                    {
                        tableLayoutPanelSousFamille.Visible = true;
                        tableLayoutPanelSousFamille.Enabled = true;
                        this.MinimumSize = new Size(tableLayoutPanelSousFamille.Width + 20, tableLayoutPanelSousFamille.Height + 200);
                        tableLayoutPanelSousFamille.Dock = DockStyle.Fill;
                        break;
                    }
            }

            RemplirComboBox();
            RemplirData();


        }

        /// <summary>
        /// Remplit les choix des combobox si besoin pour l'objet
        /// </summary>
        private void RemplirComboBox()
        {
            switch (Type)
            {
                case FormMain.ListViewDisplayType.ARTICLES:
                    {
                        Controller.DAO.DAOMarques DaoMarques = new Controller.DAO.DAOMarques();
                        Controller.DAO.DAOSousFamilles DaoSousFamilles = new Controller.DAO.DAOSousFamilles();

                        List<Model.Marque> Marques = DaoMarques.GetAll();
                        List<Model.SousFamille> SousFamilles = DaoSousFamilles.GetAll();

                        comboBoxMarque.DisplayMember = "NomMarque";
                        comboBoxMarque.DataSource = Marques;

                        comboBoxSousFamille.DisplayMember = "NomSousFamille";
                        comboBoxSousFamille.DataSource = SousFamilles;

                        break;
                    }
                case FormMain.ListViewDisplayType.SOUSFAMILLES:
                    {
                        Controller.DAO.DAOFamilles DaoFamilles = new Controller.DAO.DAOFamilles();

                        List<Model.Famille> Familles = DaoFamilles.GetAll();

                        comboBoxFamilleSousFamille.DisplayMember = "NomFamille";
                        comboBoxFamilleSousFamille.DataSource = Familles;
                        break;
                    }
            }
        }

        /// <summary>
        /// Pré-remplit les données du formulaire si elles existent
        /// </summary>
        private void RemplirData()
        {
            switch (Type)
            {
                case FormMain.ListViewDisplayType.ARTICLES:
                    {
                        if (Objet != null)
                        {
                            Model.Article article = (Model.Article)Objet;
                            textBoxDescription.Text = article.Description;
                            numericUpDownQuantite.Value = article.Quantite;
                            textBoxReferenceArticle.Text = article.Reference;
                            // On empeche la modification du textBox car on ne souhaite pas modifier la clé primaire
                            textBoxReferenceArticle.ReadOnly = true;
                        }
                        else
                        {
                            textBoxReferenceArticle.Text = "";
                            textBoxReferenceArticle.ReadOnly = false;
                        }
                        break;
                    }
                case FormMain.ListViewDisplayType.MARQUES:
                    {
                        if (Objet != null)
                        {
                            Model.Marque marque = (Model.Marque)Objet;
                            textBoxNomMarque.Text = marque.NomMarque;
                            IdObjet = marque.RefMarque;
                        }
                        break;
                    }
                case FormMain.ListViewDisplayType.FAMILLES:
                    {
                        if (Objet != null)
                        {
                            Model.Famille famille = (Model.Famille)Objet;
                            textBoxNomFamille.Text = famille.NomFamille;
                            IdObjet = famille.RefFamille;
                        }
                        break;
                    }
                case FormMain.ListViewDisplayType.SOUSFAMILLES:
                    {
                        if (Objet != null)
                        {
                            Model.SousFamille sousFamille = (Model.SousFamille)Objet;
                            textBoxNomSousFamille.Text = sousFamille.NomSousFamille;
                            comboBoxFamilleSousFamille.Text = sousFamille.Famille.NomFamille;
                            IdObjet = sousFamille.RefSousFamille;
                        }
                        break;
                    }
            }

        }

        /// <summary>
        /// Modifie l'objet avec les informations du formulaire
        /// </summary>
        private void ModifierObjetAvecResultatFormulaire()
        {
            switch (Type)
            {
                case FormMain.ListViewDisplayType.ARTICLES:
                    {
                        Model.Article article;
                        if (Mode == 1)
                        {
                            article = new Model.Article();
                            Objet = article;
                        }
                        else
                        {
                            article = (Model.Article)Objet;
                        }
                        article.Description = textBoxDescription.Text;
                        article.Quantite = (int)numericUpDownQuantite.Value;
                        article.Reference = textBoxReferenceArticle.Text;
                        // Ajouter la marque et la sous famille
                        article.Marque = (Model.Marque)comboBoxMarque.SelectedItem;
                        article.SousFamille = (Model.SousFamille)comboBoxSousFamille.SelectedItem;
                        break;
                    }
                case FormMain.ListViewDisplayType.FAMILLES:
                    {
                        Model.Famille famille;
                        if (Mode == 1)
                        {
                            famille = new Model.Famille();
                            Objet = famille;
                        }
                        else
                        {
                            famille = (Model.Famille)Objet;
                        }
                        famille.NomFamille = textBoxNomFamille.Text;
                        break;
                    }
                case FormMain.ListViewDisplayType.MARQUES:
                    {
                        Model.Marque marque;
                        if (Mode == 1)
                        {
                            marque = new Model.Marque();
                            Objet = marque;
                        }
                        else
                        {
                            marque = (Model.Marque)Objet;
                        }
                        marque.NomMarque = textBoxNomMarque.Text;
                        break;
                    }
                case FormMain.ListViewDisplayType.SOUSFAMILLES:
                    {
                        Model.SousFamille sousFamille;
                        if (Mode == 1)
                        {
                            sousFamille = new Model.SousFamille();
                            Objet = sousFamille;
                        }
                        else
                        {
                            sousFamille = (Model.SousFamille)Objet;
                        }
                        sousFamille.NomSousFamille = textBoxNomSousFamille.Text;
                        // Modifier la famille
                        sousFamille.Famille = (Model.Famille)comboBoxFamilleSousFamille.SelectedItem;
                        break;
                    }
            }
        }

        /// <summary>
        /// Permet de vérifier la validité de l'objet, en vérifiant si tout les paramètres sont bien set.
        /// </summary>
        /// <returns> true si l'objet est valide, false sinon</returns>
        private bool VerifierValiditeObjet()
        {
            bool Valide = true;
            switch (Type)
            {
                case FormMain.ListViewDisplayType.ARTICLES:
                    {
                        Model.Article Article = (Model.Article)Objet;
                        if (Article.Description == "" || Article.Reference == "" || Article.Marque == null || Article.SousFamille == null)
                        {
                            Valide = false;
                        }
                        if (Article.Quantite < 0)
                        {
                            Valide = false;
                        }
                        if (Article.Reference.Length > 8)
                        {
                            Valide = false;
                        }

                        break;
                    }
                case FormMain.ListViewDisplayType.FAMILLES:
                    {
                        Model.Famille Famille = (Model.Famille)Objet;
                        if (Famille.NomFamille == "")
                        {
                            Valide = false;
                        }
                        break;
                    }
                case FormMain.ListViewDisplayType.SOUSFAMILLES:
                    {
                        Model.SousFamille SousFamille = (Model.SousFamille)Objet;
                        if (SousFamille.NomSousFamille == "" || SousFamille.Famille == null)
                        {
                            Valide = false;
                        }
                        break;
                    }
                case FormMain.ListViewDisplayType.MARQUES:
                    {
                        Model.Marque Marque = (Model.Marque)Objet;
                        if (Marque.NomMarque == "")
                        {
                            Valide = false;
                        }
                        break;
                    }


            }

            return Valide;
        }


        /// <summary>
        /// Event handler pour le bouton d'annulation. ferme le formulaire
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAnnuler_Click(object sender, EventArgs e)
        {
            // On ferme la fenêtre
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// Event handler pour le bouton de fin. Va modifier l'objet et vérifier sa validité avant de fermer le formulaire.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonEnd_Click(object sender, EventArgs e)
        {
            // On ferme la fenêtre et on envoie le résultat
            ModifierObjetAvecResultatFormulaire();
            if (VerifierValiditeObjet())
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Objet non valide. Pensez à remplir tout les paramètres. Rien ne peut être vide. Pour un article, la quantité doit être supérieur à 0 et la référence doit être inférieur à 8 caractères.");
            }
            
        }
        
    }
}
