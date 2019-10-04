namespace Projet_Archivage
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.PanelTop = new System.Windows.Forms.Panel();
            this.BtnMinimize = new System.Windows.Forms.Button();
            this.BtnClose = new System.Windows.Forms.Button();
            this.PanelSide = new System.Windows.Forms.Panel();
            this.PanelHover = new System.Windows.Forms.Panel();
            this.BtnCentreDeGestion = new System.Windows.Forms.Button();
            this.BtnDocumentPV = new System.Windows.Forms.Button();
            this.BtnDocumentStagiaire = new System.Windows.Forms.Button();
            this.BtnAccueil = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.PanelMain = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.accueil1 = new Projet_Archivage.Accueil();
            this.PanelTop.SuspendLayout();
            this.PanelSide.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.PanelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelTop
            // 
            this.PanelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.PanelTop.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PanelTop.BackgroundImage")));
            this.PanelTop.Controls.Add(this.BtnMinimize);
            this.PanelTop.Controls.Add(this.BtnClose);
            this.PanelTop.Location = new System.Drawing.Point(202, 0);
            this.PanelTop.Name = "PanelTop";
            this.PanelTop.Size = new System.Drawing.Size(996, 35);
            this.PanelTop.TabIndex = 0;
            this.PanelTop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PanelTop_MouseDown);
            this.PanelTop.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PanelTop_MouseMove);
            this.PanelTop.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PanelTop_MouseUp);
            // 
            // BtnMinimize
            // 
            this.BtnMinimize.BackColor = System.Drawing.Color.Transparent;
            this.BtnMinimize.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnMinimize.FlatAppearance.BorderSize = 0;
            this.BtnMinimize.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.BtnMinimize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BtnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnMinimize.Image = ((System.Drawing.Image)(resources.GetObject("BtnMinimize.Image")));
            this.BtnMinimize.Location = new System.Drawing.Point(920, 0);
            this.BtnMinimize.Name = "BtnMinimize";
            this.BtnMinimize.Size = new System.Drawing.Size(38, 35);
            this.BtnMinimize.TabIndex = 1;
            this.BtnMinimize.UseVisualStyleBackColor = false;
            this.BtnMinimize.Click += new System.EventHandler(this.BtnMinimize_Click);
            // 
            // BtnClose
            // 
            this.BtnClose.BackColor = System.Drawing.Color.Transparent;
            this.BtnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnClose.FlatAppearance.BorderSize = 0;
            this.BtnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BtnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BtnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnClose.Image = ((System.Drawing.Image)(resources.GetObject("BtnClose.Image")));
            this.BtnClose.Location = new System.Drawing.Point(958, 0);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(38, 35);
            this.BtnClose.TabIndex = 0;
            this.BtnClose.UseVisualStyleBackColor = false;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // PanelSide
            // 
            this.PanelSide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.PanelSide.Controls.Add(this.PanelHover);
            this.PanelSide.Controls.Add(this.BtnCentreDeGestion);
            this.PanelSide.Controls.Add(this.BtnDocumentPV);
            this.PanelSide.Controls.Add(this.BtnDocumentStagiaire);
            this.PanelSide.Controls.Add(this.BtnAccueil);
            this.PanelSide.Controls.Add(this.pictureBox1);
            this.PanelSide.Dock = System.Windows.Forms.DockStyle.Left;
            this.PanelSide.Location = new System.Drawing.Point(0, 0);
            this.PanelSide.Name = "PanelSide";
            this.PanelSide.Size = new System.Drawing.Size(202, 645);
            this.PanelSide.TabIndex = 1;
            // 
            // PanelHover
            // 
            this.PanelHover.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(74)))), ((int)(((byte)(147)))));
            this.PanelHover.Location = new System.Drawing.Point(193, 190);
            this.PanelHover.Name = "PanelHover";
            this.PanelHover.Size = new System.Drawing.Size(10, 54);
            this.PanelHover.TabIndex = 5;
            // 
            // BtnCentreDeGestion
            // 
            this.BtnCentreDeGestion.FlatAppearance.BorderSize = 0;
            this.BtnCentreDeGestion.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BtnCentreDeGestion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCentreDeGestion.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCentreDeGestion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(132)))), ((int)(((byte)(132)))));
            this.BtnCentreDeGestion.Image = ((System.Drawing.Image)(resources.GetObject("BtnCentreDeGestion.Image")));
            this.BtnCentreDeGestion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCentreDeGestion.Location = new System.Drawing.Point(0, 364);
            this.BtnCentreDeGestion.Name = "BtnCentreDeGestion";
            this.BtnCentreDeGestion.Size = new System.Drawing.Size(192, 52);
            this.BtnCentreDeGestion.TabIndex = 4;
            this.BtnCentreDeGestion.Text = "      Centre de gestion";
            this.BtnCentreDeGestion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCentreDeGestion.UseVisualStyleBackColor = true;
            this.BtnCentreDeGestion.Click += new System.EventHandler(this.BtnCentreDeGestion_Click);
            // 
            // BtnDocumentPV
            // 
            this.BtnDocumentPV.FlatAppearance.BorderSize = 0;
            this.BtnDocumentPV.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BtnDocumentPV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnDocumentPV.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDocumentPV.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(132)))), ((int)(((byte)(132)))));
            this.BtnDocumentPV.Image = ((System.Drawing.Image)(resources.GetObject("BtnDocumentPV.Image")));
            this.BtnDocumentPV.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnDocumentPV.Location = new System.Drawing.Point(0, 306);
            this.BtnDocumentPV.Name = "BtnDocumentPV";
            this.BtnDocumentPV.Size = new System.Drawing.Size(192, 52);
            this.BtnDocumentPV.TabIndex = 3;
            this.BtnDocumentPV.Text = "      Document PV";
            this.BtnDocumentPV.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnDocumentPV.UseVisualStyleBackColor = true;
            this.BtnDocumentPV.Click += new System.EventHandler(this.BtnDocumentPV_Click);
            // 
            // BtnDocumentStagiaire
            // 
            this.BtnDocumentStagiaire.FlatAppearance.BorderSize = 0;
            this.BtnDocumentStagiaire.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BtnDocumentStagiaire.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnDocumentStagiaire.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDocumentStagiaire.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(132)))), ((int)(((byte)(132)))));
            this.BtnDocumentStagiaire.Image = ((System.Drawing.Image)(resources.GetObject("BtnDocumentStagiaire.Image")));
            this.BtnDocumentStagiaire.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnDocumentStagiaire.Location = new System.Drawing.Point(0, 248);
            this.BtnDocumentStagiaire.Name = "BtnDocumentStagiaire";
            this.BtnDocumentStagiaire.Size = new System.Drawing.Size(192, 52);
            this.BtnDocumentStagiaire.TabIndex = 2;
            this.BtnDocumentStagiaire.Text = "      Document stagiaire";
            this.BtnDocumentStagiaire.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnDocumentStagiaire.UseVisualStyleBackColor = true;
            this.BtnDocumentStagiaire.Click += new System.EventHandler(this.BtnDocumentStagiaire_Click);
            // 
            // BtnAccueil
            // 
            this.BtnAccueil.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.BtnAccueil.FlatAppearance.BorderSize = 0;
            this.BtnAccueil.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BtnAccueil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAccueil.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAccueil.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(74)))), ((int)(((byte)(147)))));
            this.BtnAccueil.Image = ((System.Drawing.Image)(resources.GetObject("BtnAccueil.Image")));
            this.BtnAccueil.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnAccueil.Location = new System.Drawing.Point(0, 189);
            this.BtnAccueil.Name = "BtnAccueil";
            this.BtnAccueil.Size = new System.Drawing.Size(192, 52);
            this.BtnAccueil.TabIndex = 1;
            this.BtnAccueil.Text = "      Accueil";
            this.BtnAccueil.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnAccueil.UseVisualStyleBackColor = false;
            this.BtnAccueil.Click += new System.EventHandler(this.BtnAccueil_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(15, 26);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(172, 127);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // PanelMain
            // 
            this.PanelMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.PanelMain.Controls.Add(this.accueil1);
            this.PanelMain.Location = new System.Drawing.Point(202, 35);
            this.PanelMain.Name = "PanelMain";
            this.PanelMain.Size = new System.Drawing.Size(996, 575);
            this.PanelMain.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(836, 619);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(350, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Gestion d\'archivage des documents GAD - 2018/2019";
            // 
            // accueil1
            // 
            this.accueil1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.accueil1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.accueil1.Location = new System.Drawing.Point(0, 0);
            this.accueil1.Name = "accueil1";
            this.accueil1.Size = new System.Drawing.Size(996, 575);
            this.accueil1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.ClientSize = new System.Drawing.Size(1198, 645);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PanelMain);
            this.Controls.Add(this.PanelSide);
            this.Controls.Add(this.PanelTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.PanelTop.ResumeLayout(false);
            this.PanelSide.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.PanelMain.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel PanelTop;
        private System.Windows.Forms.Button BtnMinimize;
        private System.Windows.Forms.Button BtnClose;
        private System.Windows.Forms.Panel PanelSide;
        private System.Windows.Forms.Panel PanelMain;
        private System.Windows.Forms.Button BtnDocumentPV;
        private System.Windows.Forms.Button BtnDocumentStagiaire;
        private System.Windows.Forms.Button BtnAccueil;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button BtnCentreDeGestion;
        private System.Windows.Forms.Panel PanelHover;
        private Accueil accueil1;
        private System.Windows.Forms.Label label1;
    }
}

