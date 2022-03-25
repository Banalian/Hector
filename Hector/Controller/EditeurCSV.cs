using System;
using System.IO;
using Hector.Model;
using System.Collections.Generic;

namespace Hector.Controller
{
    public class EditeurCSV
    {
        private String Chemin { get; set; }
        private StreamReader StreamWriter { get; set; }
        private List<char> Separateurs { get; set; }

        public EditeurCSV(String chemin)
        {
            Chemin = chemin;
            StreamWriter = new StreamWriter();
        }

        public void EcrireCSV(LecteurResultat objets)
        {

        }

    }
}
