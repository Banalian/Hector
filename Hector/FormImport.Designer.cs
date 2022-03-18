namespace Hector
{
    partial class FormImport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SelectFIleButton = new System.Windows.Forms.Button();
            this.labelNomFichier = new System.Windows.Forms.Label();
            this.IntegrationEcrasementButton = new System.Windows.Forms.Button();
            this.IntegrationButton = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // SelectFIleButton
            // 
            this.SelectFIleButton.Location = new System.Drawing.Point(3, 3);
            this.SelectFIleButton.Name = "SelectFIleButton";
            this.SelectFIleButton.Size = new System.Drawing.Size(123, 23);
            this.SelectFIleButton.TabIndex = 0;
            this.SelectFIleButton.Text = "Selectionner un Fichier";
            this.SelectFIleButton.UseVisualStyleBackColor = true;
            this.SelectFIleButton.Click += new System.EventHandler(this.SelectFIleButton_Click);
            // 
            // labelNomFichier
            // 
            this.labelNomFichier.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelNomFichier.AutoSize = true;
            this.labelNomFichier.Location = new System.Drawing.Point(132, 8);
            this.labelNomFichier.Name = "labelNomFichier";
            this.labelNomFichier.Size = new System.Drawing.Size(72, 13);
            this.labelNomFichier.TabIndex = 1;
            this.labelNomFichier.Text = "<NomFichier>";
            // 
            // IntegrationEcrasementButton
            // 
            this.IntegrationEcrasementButton.Location = new System.Drawing.Point(3, 3);
            this.IntegrationEcrasementButton.Name = "IntegrationEcrasementButton";
            this.IntegrationEcrasementButton.Size = new System.Drawing.Size(138, 23);
            this.IntegrationEcrasementButton.TabIndex = 2;
            this.IntegrationEcrasementButton.Text = "Intégration (écrasement)";
            this.IntegrationEcrasementButton.UseVisualStyleBackColor = true;
            // 
            // IntegrationButton
            // 
            this.IntegrationButton.Location = new System.Drawing.Point(147, 3);
            this.IntegrationButton.Name = "IntegrationButton";
            this.IntegrationButton.Size = new System.Drawing.Size(75, 23);
            this.IntegrationButton.TabIndex = 3;
            this.IntegrationButton.Text = "Intégration";
            this.IntegrationButton.UseVisualStyleBackColor = true;
            this.IntegrationButton.Click += new System.EventHandler(this.IntegrationButton_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.IntegrationEcrasementButton);
            this.flowLayoutPanel1.Controls.Add(this.IntegrationButton);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 49);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(339, 42);
            this.flowLayoutPanel1.TabIndex = 4;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.SelectFIleButton);
            this.flowLayoutPanel2.Controls.Add(this.labelNomFichier);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(339, 40);
            this.flowLayoutPanel2.TabIndex = 5;
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressBar1.Location = new System.Drawing.Point(20, 99);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(20, 5, 20, 5);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(305, 23);
            this.progressBar1.TabIndex = 6;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.progressBar1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 48.64865F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 51.35135F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(345, 127);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // FormImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 127);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FormImport";
            this.Text = "Importer un fichier";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button SelectFIleButton;
        private System.Windows.Forms.Label labelNomFichier;
        private System.Windows.Forms.Button IntegrationEcrasementButton;
        private System.Windows.Forms.Button IntegrationButton;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}