using Hector.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Hector
{
    internal static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());

            
            LecteurCSV lecteur = new LecteurCSV("C:\\Users\\Administrateur\\Downloads\\Données à intégrer.csv");
            LecteurResultat rez = new LecteurResultat();
            rez = lecteur.Lire();

            Debug.WriteLine(rez);


            EditeurCSV editeur = new EditeurCSV("C:\\Users\\Administrateur\\Downloads\\Données exportées.csv");
            editeur.Ecrire(rez.Articles);


            Debug.WriteLine(rez);

        }
    }
}
