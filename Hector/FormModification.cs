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
        private object Objet;
        private FormMain.ListViewDisplayType Type;
        private int IdObjet;

        /// <summary>
        /// Constructeur de la fenêtre de modification/d'ajout
        /// </summary>
        /// <param name="type">Type de l'objet que l'on modifie/ajoute</param>
        /// <param name="mode">1 si on creer, 2 si on modifie</param>
        /// <param name="obj">l'objet a modifier, s'il existe</param>
        public FormModification(FormMain.ListViewDisplayType type, int mode = 1, object obj = null)
        {
            InitializeComponent();
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


        private void ModifierObjetAvecResultatFormulaire()
        {
            switch (Type)
            {
                case FormMain.ListViewDisplayType.ARTICLES:
                    {
                        Model.Article article = (Model.Article)Objet;
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
                        Model.Famille famille = (Model.Famille)Objet;
                        famille.NomFamille = textBoxNomFamille.Text;
                        break;
                    }
                case FormMain.ListViewDisplayType.MARQUES:
                    {
                        Model.Marque marque = (Model.Marque)Objet;
                        marque.NomMarque = textBoxNomMarque.Text;
                        break;
                    }
                case FormMain.ListViewDisplayType.SOUSFAMILLES:
                    {
                        Model.SousFamille sousFamille = (Model.SousFamille)Objet;
                        sousFamille.NomSousFamille = textBoxNomSousFamille.Text;
                        // Modifier la famille
                        sousFamille.Famille = (Model.Famille)comboBoxFamilleSousFamille.SelectedItem;
                        break;
                    }
            }
        }


        private void FormModification_Load(object sender, EventArgs e)
        {

        }

        private void buttonAnnuler_Click(object sender, EventArgs e)
        {
            // On ferme la fenêtre
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void buttonEnd_Click(object sender, EventArgs e)
        {
            // On ferme la fenêtre et on envoie le résultat
            ModifierObjetAvecResultatFormulaire();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        
        //TODO : Remplacer par un getter pour l'attribut Objet
        public object returnObjet()
        {
            return Objet;
        }
    }
}
