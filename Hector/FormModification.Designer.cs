namespace Hector
{
    partial class FormModification
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
            this.panelGeneral = new System.Windows.Forms.Panel();
            this.buttonAnnuler = new System.Windows.Forms.Button();
            this.buttonEnd = new System.Windows.Forms.Button();
            this.tableLayoutPanelSousFamille = new System.Windows.Forms.TableLayoutPanel();
            this.labelFamilleSousFamille = new System.Windows.Forms.Label();
            this.labelNomSousFamille = new System.Windows.Forms.Label();
            this.textBoxNomSousFamille = new System.Windows.Forms.TextBox();
            this.comboBoxFamilleSousFamille = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanelMarque = new System.Windows.Forms.TableLayoutPanel();
            this.labelNomMarque = new System.Windows.Forms.Label();
            this.textBoxNomMarque = new System.Windows.Forms.TextBox();
            this.tableLayoutPanelFamille = new System.Windows.Forms.TableLayoutPanel();
            this.labelNomFamille = new System.Windows.Forms.Label();
            this.textBoxNomFamille = new System.Windows.Forms.TextBox();
            this.tableLayoutPanelArticle = new System.Windows.Forms.TableLayoutPanel();
            this.labelReference = new System.Windows.Forms.Label();
            this.labelDescription = new System.Windows.Forms.Label();
            this.labelMarque = new System.Windows.Forms.Label();
            this.labelSousFamille = new System.Windows.Forms.Label();
            this.labelQuantite = new System.Windows.Forms.Label();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.numericUpDownQuantite = new System.Windows.Forms.NumericUpDown();
            this.comboBoxMarque = new System.Windows.Forms.ComboBox();
            this.comboBoxSousFamille = new System.Windows.Forms.ComboBox();
            this.textBoxReferenceArticle = new System.Windows.Forms.TextBox();
            this.panelGeneral.SuspendLayout();
            this.tableLayoutPanelSousFamille.SuspendLayout();
            this.tableLayoutPanelMarque.SuspendLayout();
            this.tableLayoutPanelFamille.SuspendLayout();
            this.tableLayoutPanelArticle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownQuantite)).BeginInit();
            this.SuspendLayout();
            // 
            // panelGeneral
            // 
            this.panelGeneral.Controls.Add(this.buttonAnnuler);
            this.panelGeneral.Controls.Add(this.buttonEnd);
            this.panelGeneral.Controls.Add(this.tableLayoutPanelSousFamille);
            this.panelGeneral.Controls.Add(this.tableLayoutPanelMarque);
            this.panelGeneral.Controls.Add(this.tableLayoutPanelFamille);
            this.panelGeneral.Controls.Add(this.tableLayoutPanelArticle);
            this.panelGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGeneral.Location = new System.Drawing.Point(0, 0);
            this.panelGeneral.Name = "panelGeneral";
            this.panelGeneral.Size = new System.Drawing.Size(415, 369);
            this.panelGeneral.TabIndex = 0;
            // 
            // buttonAnnuler
            // 
            this.buttonAnnuler.AccessibleName = "";
            this.buttonAnnuler.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonAnnuler.Location = new System.Drawing.Point(12, 334);
            this.buttonAnnuler.Name = "buttonAnnuler";
            this.buttonAnnuler.Size = new System.Drawing.Size(75, 23);
            this.buttonAnnuler.TabIndex = 5;
            this.buttonAnnuler.Text = "Annuler";
            this.buttonAnnuler.UseVisualStyleBackColor = true;
            this.buttonAnnuler.Click += new System.EventHandler(this.buttonAnnuler_Click);
            // 
            // buttonEnd
            // 
            this.buttonEnd.AccessibleName = "";
            this.buttonEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonEnd.Location = new System.Drawing.Point(93, 334);
            this.buttonEnd.Name = "buttonEnd";
            this.buttonEnd.Size = new System.Drawing.Size(75, 23);
            this.buttonEnd.TabIndex = 4;
            this.buttonEnd.Text = "button1";
            this.buttonEnd.UseVisualStyleBackColor = true;
            this.buttonEnd.Click += new System.EventHandler(this.buttonEnd_Click);
            // 
            // tableLayoutPanelSousFamille
            // 
            this.tableLayoutPanelSousFamille.ColumnCount = 2;
            this.tableLayoutPanelSousFamille.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelSousFamille.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tableLayoutPanelSousFamille.Controls.Add(this.labelFamilleSousFamille, 0, 1);
            this.tableLayoutPanelSousFamille.Controls.Add(this.labelNomSousFamille, 0, 0);
            this.tableLayoutPanelSousFamille.Controls.Add(this.textBoxNomSousFamille, 1, 0);
            this.tableLayoutPanelSousFamille.Controls.Add(this.comboBoxFamilleSousFamille, 1, 1);
            this.tableLayoutPanelSousFamille.Enabled = false;
            this.tableLayoutPanelSousFamille.Location = new System.Drawing.Point(12, 239);
            this.tableLayoutPanelSousFamille.Name = "tableLayoutPanelSousFamille";
            this.tableLayoutPanelSousFamille.Padding = new System.Windows.Forms.Padding(0, 0, 20, 15);
            this.tableLayoutPanelSousFamille.RowCount = 2;
            this.tableLayoutPanelSousFamille.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelSousFamille.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelSousFamille.Size = new System.Drawing.Size(358, 67);
            this.tableLayoutPanelSousFamille.TabIndex = 3;
            this.tableLayoutPanelSousFamille.Visible = false;
            // 
            // labelFamilleSousFamille
            // 
            this.labelFamilleSousFamille.AutoSize = true;
            this.labelFamilleSousFamille.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelFamilleSousFamille.Location = new System.Drawing.Point(3, 26);
            this.labelFamilleSousFamille.Name = "labelFamilleSousFamille";
            this.labelFamilleSousFamille.Size = new System.Drawing.Size(78, 26);
            this.labelFamilleSousFamille.TabIndex = 10;
            this.labelFamilleSousFamille.Text = "Famille";
            this.labelFamilleSousFamille.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelNomSousFamille
            // 
            this.labelNomSousFamille.AutoSize = true;
            this.labelNomSousFamille.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelNomSousFamille.Location = new System.Drawing.Point(3, 0);
            this.labelNomSousFamille.Name = "labelNomSousFamille";
            this.labelNomSousFamille.Size = new System.Drawing.Size(78, 26);
            this.labelNomSousFamille.TabIndex = 0;
            this.labelNomSousFamille.Text = "Nom de la sous famille";
            this.labelNomSousFamille.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxNomSousFamille
            // 
            this.textBoxNomSousFamille.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxNomSousFamille.Location = new System.Drawing.Point(87, 3);
            this.textBoxNomSousFamille.Name = "textBoxNomSousFamille";
            this.textBoxNomSousFamille.Size = new System.Drawing.Size(248, 20);
            this.textBoxNomSousFamille.TabIndex = 9;
            // 
            // comboBoxFamilleSousFamille
            // 
            this.comboBoxFamilleSousFamille.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxFamilleSousFamille.FormattingEnabled = true;
            this.comboBoxFamilleSousFamille.Location = new System.Drawing.Point(87, 29);
            this.comboBoxFamilleSousFamille.Name = "comboBoxFamilleSousFamille";
            this.comboBoxFamilleSousFamille.Size = new System.Drawing.Size(248, 21);
            this.comboBoxFamilleSousFamille.TabIndex = 11;
            // 
            // tableLayoutPanelMarque
            // 
            this.tableLayoutPanelMarque.ColumnCount = 2;
            this.tableLayoutPanelMarque.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelMarque.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tableLayoutPanelMarque.Controls.Add(this.labelNomMarque, 0, 0);
            this.tableLayoutPanelMarque.Controls.Add(this.textBoxNomMarque, 1, 0);
            this.tableLayoutPanelMarque.Enabled = false;
            this.tableLayoutPanelMarque.Location = new System.Drawing.Point(12, 196);
            this.tableLayoutPanelMarque.Name = "tableLayoutPanelMarque";
            this.tableLayoutPanelMarque.Padding = new System.Windows.Forms.Padding(0, 0, 20, 15);
            this.tableLayoutPanelMarque.RowCount = 1;
            this.tableLayoutPanelMarque.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMarque.Size = new System.Drawing.Size(357, 37);
            this.tableLayoutPanelMarque.TabIndex = 2;
            this.tableLayoutPanelMarque.Visible = false;
            // 
            // labelNomMarque
            // 
            this.labelNomMarque.AutoSize = true;
            this.labelNomMarque.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelNomMarque.Location = new System.Drawing.Point(3, 0);
            this.labelNomMarque.Name = "labelNomMarque";
            this.labelNomMarque.Size = new System.Drawing.Size(78, 22);
            this.labelNomMarque.TabIndex = 0;
            this.labelNomMarque.Text = "Nom de la Marque";
            this.labelNomMarque.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxNomMarque
            // 
            this.textBoxNomMarque.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxNomMarque.Location = new System.Drawing.Point(87, 3);
            this.textBoxNomMarque.Name = "textBoxNomMarque";
            this.textBoxNomMarque.Size = new System.Drawing.Size(247, 20);
            this.textBoxNomMarque.TabIndex = 9;
            // 
            // tableLayoutPanelFamille
            // 
            this.tableLayoutPanelFamille.ColumnCount = 2;
            this.tableLayoutPanelFamille.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelFamille.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tableLayoutPanelFamille.Controls.Add(this.labelNomFamille, 0, 0);
            this.tableLayoutPanelFamille.Controls.Add(this.textBoxNomFamille, 1, 0);
            this.tableLayoutPanelFamille.Enabled = false;
            this.tableLayoutPanelFamille.Location = new System.Drawing.Point(12, 155);
            this.tableLayoutPanelFamille.Name = "tableLayoutPanelFamille";
            this.tableLayoutPanelFamille.Padding = new System.Windows.Forms.Padding(0, 0, 20, 15);
            this.tableLayoutPanelFamille.RowCount = 1;
            this.tableLayoutPanelFamille.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelFamille.Size = new System.Drawing.Size(357, 35);
            this.tableLayoutPanelFamille.TabIndex = 1;
            this.tableLayoutPanelFamille.Visible = false;
            // 
            // labelNomFamille
            // 
            this.labelNomFamille.AutoSize = true;
            this.labelNomFamille.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelNomFamille.Location = new System.Drawing.Point(3, 0);
            this.labelNomFamille.Name = "labelNomFamille";
            this.labelNomFamille.Size = new System.Drawing.Size(78, 20);
            this.labelNomFamille.TabIndex = 0;
            this.labelNomFamille.Text = "Nom de la famille";
            this.labelNomFamille.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxNomFamille
            // 
            this.textBoxNomFamille.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxNomFamille.Location = new System.Drawing.Point(87, 3);
            this.textBoxNomFamille.Name = "textBoxNomFamille";
            this.textBoxNomFamille.Size = new System.Drawing.Size(247, 20);
            this.textBoxNomFamille.TabIndex = 9;
            // 
            // tableLayoutPanelArticle
            // 
            this.tableLayoutPanelArticle.ColumnCount = 2;
            this.tableLayoutPanelArticle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelArticle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tableLayoutPanelArticle.Controls.Add(this.labelReference, 0, 0);
            this.tableLayoutPanelArticle.Controls.Add(this.labelDescription, 0, 1);
            this.tableLayoutPanelArticle.Controls.Add(this.labelMarque, 0, 2);
            this.tableLayoutPanelArticle.Controls.Add(this.labelSousFamille, 0, 3);
            this.tableLayoutPanelArticle.Controls.Add(this.labelQuantite, 0, 4);
            this.tableLayoutPanelArticle.Controls.Add(this.textBoxDescription, 1, 1);
            this.tableLayoutPanelArticle.Controls.Add(this.numericUpDownQuantite, 1, 4);
            this.tableLayoutPanelArticle.Controls.Add(this.comboBoxMarque, 1, 2);
            this.tableLayoutPanelArticle.Controls.Add(this.comboBoxSousFamille, 1, 3);
            this.tableLayoutPanelArticle.Controls.Add(this.textBoxReferenceArticle, 1, 0);
            this.tableLayoutPanelArticle.Enabled = false;
            this.tableLayoutPanelArticle.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanelArticle.Name = "tableLayoutPanelArticle";
            this.tableLayoutPanelArticle.Padding = new System.Windows.Forms.Padding(0, 0, 20, 15);
            this.tableLayoutPanelArticle.RowCount = 5;
            this.tableLayoutPanelArticle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelArticle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelArticle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelArticle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelArticle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelArticle.Size = new System.Drawing.Size(358, 137);
            this.tableLayoutPanelArticle.TabIndex = 0;
            this.tableLayoutPanelArticle.Visible = false;
            // 
            // labelReference
            // 
            this.labelReference.AutoSize = true;
            this.labelReference.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelReference.Location = new System.Drawing.Point(3, 0);
            this.labelReference.Name = "labelReference";
            this.labelReference.Size = new System.Drawing.Size(78, 24);
            this.labelReference.TabIndex = 0;
            this.labelReference.Text = "Reference";
            this.labelReference.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelDescription.Location = new System.Drawing.Point(3, 24);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(78, 24);
            this.labelDescription.TabIndex = 1;
            this.labelDescription.Text = "Description";
            this.labelDescription.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelMarque
            // 
            this.labelMarque.AutoSize = true;
            this.labelMarque.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelMarque.Location = new System.Drawing.Point(3, 48);
            this.labelMarque.Name = "labelMarque";
            this.labelMarque.Size = new System.Drawing.Size(78, 24);
            this.labelMarque.TabIndex = 2;
            this.labelMarque.Text = "Marque";
            this.labelMarque.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelSousFamille
            // 
            this.labelSousFamille.AutoSize = true;
            this.labelSousFamille.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelSousFamille.Location = new System.Drawing.Point(3, 72);
            this.labelSousFamille.Name = "labelSousFamille";
            this.labelSousFamille.Size = new System.Drawing.Size(78, 24);
            this.labelSousFamille.TabIndex = 3;
            this.labelSousFamille.Text = "Sous Famille";
            this.labelSousFamille.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelQuantite
            // 
            this.labelQuantite.AutoSize = true;
            this.labelQuantite.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelQuantite.Location = new System.Drawing.Point(3, 96);
            this.labelQuantite.Name = "labelQuantite";
            this.labelQuantite.Size = new System.Drawing.Size(78, 26);
            this.labelQuantite.TabIndex = 4;
            this.labelQuantite.Text = "Quantité";
            this.labelQuantite.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxDescription.Location = new System.Drawing.Point(87, 27);
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(248, 20);
            this.textBoxDescription.TabIndex = 5;
            // 
            // numericUpDownQuantite
            // 
            this.numericUpDownQuantite.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericUpDownQuantite.Location = new System.Drawing.Point(87, 99);
            this.numericUpDownQuantite.Name = "numericUpDownQuantite";
            this.numericUpDownQuantite.Size = new System.Drawing.Size(248, 20);
            this.numericUpDownQuantite.TabIndex = 6;
            // 
            // comboBoxMarque
            // 
            this.comboBoxMarque.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxMarque.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMarque.Location = new System.Drawing.Point(87, 51);
            this.comboBoxMarque.Name = "comboBoxMarque";
            this.comboBoxMarque.Size = new System.Drawing.Size(248, 21);
            this.comboBoxMarque.TabIndex = 7;
            // 
            // comboBoxSousFamille
            // 
            this.comboBoxSousFamille.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxSousFamille.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSousFamille.FormattingEnabled = true;
            this.comboBoxSousFamille.Location = new System.Drawing.Point(87, 75);
            this.comboBoxSousFamille.Name = "comboBoxSousFamille";
            this.comboBoxSousFamille.Size = new System.Drawing.Size(248, 21);
            this.comboBoxSousFamille.TabIndex = 8;
            // 
            // textBoxReferenceArticle
            // 
            this.textBoxReferenceArticle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxReferenceArticle.Location = new System.Drawing.Point(87, 3);
            this.textBoxReferenceArticle.Name = "textBoxReferenceArticle";
            this.textBoxReferenceArticle.Size = new System.Drawing.Size(248, 20);
            this.textBoxReferenceArticle.TabIndex = 9;
            // 
            // FormModification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 369);
            this.Controls.Add(this.panelGeneral);
            this.Name = "FormModification";
            this.Text = "FormModification";
            this.Load += new System.EventHandler(this.FormModification_Load);
            this.panelGeneral.ResumeLayout(false);
            this.tableLayoutPanelSousFamille.ResumeLayout(false);
            this.tableLayoutPanelSousFamille.PerformLayout();
            this.tableLayoutPanelMarque.ResumeLayout(false);
            this.tableLayoutPanelMarque.PerformLayout();
            this.tableLayoutPanelFamille.ResumeLayout(false);
            this.tableLayoutPanelFamille.PerformLayout();
            this.tableLayoutPanelArticle.ResumeLayout(false);
            this.tableLayoutPanelArticle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownQuantite)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelGeneral;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelArticle;
        private System.Windows.Forms.Label labelReference;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.Label labelMarque;
        private System.Windows.Forms.Label labelSousFamille;
        private System.Windows.Forms.Label labelQuantite;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelFamille;
        private System.Windows.Forms.Label labelNomFamille;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.NumericUpDown numericUpDownQuantite;
        private System.Windows.Forms.ComboBox comboBoxMarque;
        private System.Windows.Forms.ComboBox comboBoxSousFamille;
        private System.Windows.Forms.TextBox textBoxNomFamille;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMarque;
        private System.Windows.Forms.Label labelNomMarque;
        private System.Windows.Forms.TextBox textBoxNomMarque;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelSousFamille;
        private System.Windows.Forms.Label labelFamilleSousFamille;
        private System.Windows.Forms.Label labelNomSousFamille;
        private System.Windows.Forms.TextBox textBoxNomSousFamille;
        private System.Windows.Forms.ComboBox comboBoxFamilleSousFamille;
        private System.Windows.Forms.Button buttonAnnuler;
        private System.Windows.Forms.Button buttonEnd;
        private System.Windows.Forms.TextBox textBoxReferenceArticle;
    }
}