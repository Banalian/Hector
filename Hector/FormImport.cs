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

        private void SelectFIleButton_Click(object sender, EventArgs e)
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
            this.Close();   
        }
    }
}
