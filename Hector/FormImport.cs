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
        /// <summary>
        /// Nom du fichier à importer
        /// </summary>
        private string NomDeFichier { get; set; }
        public FormImport()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Surcharge pour afficher la fenetre de dialogue au centre de son parent
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.CenterToParent();
        }

        /// <summary>
        /// Lors de la séléction du fichier on ouvre un OpenFileDialog pour choisir le fichier
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// On va lire le fichier séléctionné pour importer les données dans notre bdd
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            int TotalErreur = 0;
            Controller.LecteurResultat ResultatErreur = new Controller.LecteurResultat();

            Controller.DAO.DAOFamilles DaoFamilles = new Controller.DAO.DAOFamilles();
            foreach (Model.Famille Famille in Resultat.Familles)
            {
                try
                {
                    DaoFamilles.Add(Famille);
                }
                catch (Exception)
                {
                    TotalErreur++;
                    ResultatErreur.Familles.Add(Famille);
                }
                Actuel++;
                UpdateProgressBar(Total, Actuel);
            }
            FixSousFamillesId(Resultat);
            Controller.DAO.DAOSousFamilles DaoSousFamilles = new Controller.DAO.DAOSousFamilles();
            foreach (Model.SousFamille SousFamille in Resultat.SousFamilles)
            {
                try
                {
                    DaoSousFamilles.Add(SousFamille);
                }
                catch (Exception)
                {
                    TotalErreur++;
                    ResultatErreur.SousFamilles.Add(SousFamille);
                }
                Actuel++;
                UpdateProgressBar(Total, Actuel);
            }

            Controller.DAO.DAOMarques DaoMarques = new Controller.DAO.DAOMarques();
            foreach (Model.Marque Marque in Resultat.Marques)
            {
                try
                {
                    DaoMarques.Add(Marque);
                }
                catch (Exception)
                {
                    TotalErreur++;
                    ResultatErreur.Marques.Add(Marque);
                }
                Actuel++;
                UpdateProgressBar(Total, Actuel);
            }

            FixArticlesVariablesId(Resultat);


            Controller.DAO.DAOArticles DaoArticles = new Controller.DAO.DAOArticles();
            foreach (Model.Article Article in Resultat.Articles)
            {
                try
                {
                    DaoArticles.Add(Article);

                }
                catch (Exception)
                {
                    TotalErreur++;
                    ResultatErreur.Articles.Add(Article);
                }
                Actuel++;
                UpdateProgressBar(Total, Actuel);
            }

            if (TotalErreur > 0)
            {
                Message = "Il y a eu " + TotalErreur + " erreurs.\n";
                Message += "Les Objets suivants n'ont pas pu être importés :\n";
                Message += ResultatErreur.ToString();
                Legende = "Erreurs";
                Boutons = MessageBoxButtons.OK;

                MessageBox.Show(Message, Legende, Boutons);
            }
            else
            {
                Message = "L'import s'est bien déroulé.";
                Legende = "Import terminé";
                Boutons = MessageBoxButtons.OK;

                MessageBox.Show(Message, Legende, Boutons);
            }


            this.Close();   
        }

        /// <summary>
        /// Mise à jour de la barre de progression selon le nombre d'item ajoutés
        /// </summary>
        /// <param name="NombreTotal"> nombre total d'item à ajouter à la bdd</param>
        /// <param name="NombreActuel"> nombre actuel d'item ajoutés à la bdd</param>
        private void UpdateProgressBar(int NombreTotal, int NombreActuel)
        {
            int Progres = (int)(((float)NombreActuel / (float)NombreTotal)*100);
            progressBar1.Value = Progres;
        }

        /// <summary>
        /// Compteur pour définir le nombre total d'item à ajouter
        /// </summary>
        /// <param name="Resultat"></param>
        /// <returns></returns>
        private int CompterNombreElement(Controller.LecteurResultat Resultat)
        {
            return Resultat.Familles.Count + Resultat.Marques.Count + Resultat.SousFamilles.Count + Resultat.Articles.Count;
        }

        /// <summary>
        /// Supprime les anciennes données avant d'ajouter les nouvelles
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        
        /// <summary>
        /// Fonctions pour réparer les id des familles des sous familles dans le résultat du lecteur
        /// </summary>
        /// <param name="Resultat"></param>
        private void FixSousFamillesId(Controller.LecteurResultat Resultat)
        {
            foreach (Model.SousFamille SousFamille in Resultat.SousFamilles)
            {
                if (SousFamille.Famille.RefFamille == 0)
                {
                    foreach (Model.Famille Famille in Resultat.Familles)
                    {
                        if (Famille.NomFamille == SousFamille.Famille.NomFamille)
                        {
                            SousFamille.Famille.RefFamille = Famille.RefFamille;
                            break;
                        }
                    }

                }
            }

        }

        /// <summary>
        /// Fonctions pour réparer les id des objets dans les articles dans le résultat du lecteur
        /// </summary>
        /// <param name="Resultat"></param>
        private void FixArticlesVariablesId(Controller.LecteurResultat Resultat)
        {
            foreach (Model.Article Article in Resultat.Articles)
            {
                if (Article.Marque.RefMarque == 0)
                {
                    foreach (Model.Marque Marque in Resultat.Marques)
                    {
                        if (Marque.NomMarque == Article.Marque.NomMarque)
                        {
                            Article.Marque.RefMarque = Marque.RefMarque;
                            break;
                        }
                    }

                }
                if (Article.SousFamille.RefSousFamille == 0)
                {
                    foreach (Model.SousFamille SousFamille in Resultat.SousFamilles)
                    {
                        if (SousFamille.NomSousFamille == Article.SousFamille.NomSousFamille)
                        {
                            Article.SousFamille.RefSousFamille = SousFamille.RefSousFamille;
                            break;
                        }
                    }

                }
            }
        }

    }
}
