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


   

        /// <summary>
        /// Constructeur de la fenêtre de modification/d'ajout
        /// </summary>
        /// <param name="type">Type de l'objet que l'on modifie/ajoute</param>
        /// <param name="mode">1 si on creer, 2 si on modifie</param>
        /// <param name="obj">l'objet a modifier, s'il existe</param>
        public FormModification(FormMain.ListViewDisplayType type, int mode = 1, object obj = null)
        {
            InitializeComponent();
            if(type == FormMain.ListViewDisplayType.NONVALIDE)
            {
                throw new Exception("Erreur : Type est non valide");
            }
            if (mode == 2 && obj == null)
            {
                throw new Exception("Erreur : mode 2 et objet null");
            }
            Objet = obj;
            Type = type;
            if(mode == 1)
            {
                buttonEnd.Text = "Ajouter";
            }
            else if(mode == 2)
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
                        tableLayoutPanelArticle.Dock = DockStyle.Fill;
                        break;
                    }
                case FormMain.ListViewDisplayType.MARQUES:
                    {
                        tableLayoutPanelMarque.Visible = true;
                        tableLayoutPanelMarque.Enabled = true;
                        tableLayoutPanelMarque.Dock = DockStyle.Fill;
                        break;
                    }
                case FormMain.ListViewDisplayType.FAMILLES:
                    {
                        tableLayoutPanelFamille.Visible = true;
                        tableLayoutPanelFamille.Enabled = true;
                        tableLayoutPanelFamille.Dock = DockStyle.Fill;
                        break;
                    }
                case FormMain.ListViewDisplayType.SOUSFAMILLES:
                    {
                        tableLayoutPanelSousFamille.Visible = true;
                        tableLayoutPanelSousFamille.Enabled = true;
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

                        List<string> MarquesString = new List<string>();
                        List<string> SousFamillesString = new List<string>();

                        foreach (Model.Marque Marque in Marques)
                        {
                            MarquesString.Add(Marque.NomMarque);
                        }

                        foreach (Model.SousFamille SousFamille in SousFamilles)
                        {
                            SousFamillesString.Add(SousFamille.NomSousFamille);
                        }


                        comboBoxMarque.DataSource = MarquesString;
                        comboBoxSousFamille.DataSource = SousFamillesString;
                        break;
                    }
                case FormMain.ListViewDisplayType.SOUSFAMILLES:
                    {
                        Controller.DAO.DAOFamilles DaoFamilles = new Controller.DAO.DAOFamilles();

                        List<Model.Famille> Familles = DaoFamilles.GetAll();
                        List<string> FamillesString = new List<string>();

                        foreach (Model.Famille Famille in Familles)
                        {
                            FamillesString.Add(Famille.NomFamille);
                        }

                        comboBoxFamilleSousFamille.DataSource = FamillesString;
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
                        }
                        break;
                    }
                case FormMain.ListViewDisplayType.MARQUES:
                    {
                        if (Objet != null)
                        {
                            Model.Marque marque = (Model.Marque)Objet;
                            textBoxNomMarque.Text = marque.NomMarque;
                        }
                        break;
                    }
                case FormMain.ListViewDisplayType.FAMILLES:
                    {
                        if (Objet != null)
                        {
                            Model.Famille famille = (Model.Famille)Objet;
                            textBoxNomFamille.Text = famille.NomFamille;
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
                        }
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
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
