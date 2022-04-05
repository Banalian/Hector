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
