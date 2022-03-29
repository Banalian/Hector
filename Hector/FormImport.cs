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
    public partial class FormImport : Form
    {

        private string NomDeFichier { get; set; }
        public FormImport()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.CenterToParent();
        }

        private void SelectFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenFileDialog = new OpenFileDialog();
            OpenFileDialog.Filter = "Fichier csv (*.csv)|*.csv";
            OpenFileDialog.Title = "Ouvrir un fichier csv";

            if (OpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                NomDeFichier = OpenFileDialog.FileName;
                if (NomDeFichier != null)
                {
                    labelNomFichier.Text = NomDeFichier;
                }
            }
        }
        private void IntegrationButton_Click(object sender, EventArgs e)
        {
            string Message;
            string Legende;
            MessageBoxButtons Boutons;

            if(NomDeFichier == null)
            {
                Message = "Vous n'avez pas choisi de fichier.";
                Legende = "Pas de fichier choisi";
                Boutons = MessageBoxButtons.OK;

                MessageBox.Show(Message, Legende, Boutons);
                return;
            }

            Controller.LecteurCSV Lecteur = new Controller.LecteurCSV(NomDeFichier);
            Controller.LecteurResultat Resultat = Lecteur.Lire();

            int Total = CompterNombreElement(Resultat);
            int Actuel = 0;

            Controller.DAO.DAOFamilles DaoFamilles = new Controller.DAO.DAOFamilles();
            foreach (Model.Famille Famille in Resultat.Familles)
            {
                DaoFamilles.Add(Famille);
                Actuel++;
                UpdateProgressBar(Total, Actuel);
            }

            Controller.DAO.DAOSousFamilles DaoSousFamilles = new Controller.DAO.DAOSousFamilles();
            foreach (Model.SousFamille SousFamille in Resultat.SousFamilles)
            {
                DaoSousFamilles.Add(SousFamille);
                Actuel++;
                UpdateProgressBar(Total, Actuel);
            }

            Controller.DAO.DAOMarques DaoMarques = new Controller.DAO.DAOMarques();
            foreach (Model.Marque Marque in Resultat.Marques)
            {
                DaoMarques.Add(Marque);
                Actuel++;
                UpdateProgressBar(Total, Actuel);
            }

            Controller.DAO.DAOArticles DaoArticles = new Controller.DAO.DAOArticles();
            foreach (Model.Article Article in Resultat.Articles)
            {
                DaoArticles.Add(Article);
                Actuel++;
                UpdateProgressBar(Total, Actuel);
            }

            Message = "Réussite de l'import !";
            Legende = "Success";
            Boutons = MessageBoxButtons.OK;

            MessageBox.Show(Message, Legende, Boutons);

            this.Close();   
        }


        private void UpdateProgressBar(int NombreTotal, int NombreActuel)
        {
            int Progres = (int)(((float)NombreActuel / (float)NombreTotal)*100);
            progressBar1.Value = Progres;
        }

        private int CompterNombreElement(Controller.LecteurResultat Resultat)
        {
            return Resultat.Familles.Count + Resultat.Marques.Count + Resultat.SousFamilles.Count + Resultat.Articles.Count;
        }

        private void IntegrationEcrasementButton_Click(object sender, EventArgs e)
        {
            // On demande confirmation à l'utilisateur
            string Message = "Vous allez écraser toutes les données existantes.\nEtes-vous sûr de vouloir continuer ?";
            string Legende = "Confirmation";
            MessageBoxButtons Boutons = MessageBoxButtons.YesNo;

            DialogResult Resultat = MessageBox.Show(Message, Legende, Boutons);

            if (Resultat == DialogResult.No)
            {
                return;
            }
            // On drop les données de la base
            Controller.DAO.DAOArticles DaoArticles = new Controller.DAO.DAOArticles();
            DaoArticles.DropDonnees();

            Controller.DAO.DAOSousFamilles DaoSousFamilles = new Controller.DAO.DAOSousFamilles();
            DaoSousFamilles.DropDonnees();

            Controller.DAO.DAOFamilles DaoFamilles = new Controller.DAO.DAOFamilles();
            DaoFamilles.DropDonnees();

            Controller.DAO.DAOMarques DaoMarques = new Controller.DAO.DAOMarques();
            DaoMarques.DropDonnees();

            

            // On peux maintenant importer les données
            IntegrationButton_Click(sender, e);
        }
    }
}
