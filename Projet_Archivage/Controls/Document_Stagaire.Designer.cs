namespace Projet_Archivage
{
    partial class Document_Stagaire
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Document_Stagaire));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DocumentViewer = new System.Windows.Forms.PictureBox();
            this.dataGridViewDocStag = new System.Windows.Forms.DataGridView();
            this.TXTSearch = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.DisplayList = new System.Windows.Forms.Button();
            this.BTNAddlist = new System.Windows.Forms.Button();
            this.LblCount = new System.Windows.Forms.Label();
            this.BTNLast = new System.Windows.Forms.Button();
            this.BTNNext = new System.Windows.Forms.Button();
            this.BTNPrevious = new System.Windows.Forms.Button();
            this.BTNFirst = new System.Windows.Forms.Button();
            this.BTNImport = new System.Windows.Forms.Button();
            this.BTNExport = new System.Windows.Forms.Button();
            this.BTNDelete = new System.Windows.Forms.Button();
            this.BTNPrint = new System.Windows.Forms.Button();
            this.BTNPDF = new System.Windows.Forms.Button();
            this.BTNEdit = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panelList = new System.Windows.Forms.Panel();
            this.dataGridViewListDoc = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nom_document = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnExporterListe = new System.Windows.Forms.Button();
            this.btnViderListe = new System.Windows.Forms.Button();
            this.btnSupprimerListe = new System.Windows.Forms.Button();
            this.btnImprimerList = new System.Windows.Forms.Button();
            this.btnCloseList = new System.Windows.Forms.Button();
            this.panelGestion = new System.Windows.Forms.Panel();
            this.BTNCloseAddEdit = new System.Windows.Forms.Button();
            this.btnAjouter = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.comboType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCIN = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.picDoc = new System.Windows.Forms.PictureBox();
            this.btnModifier = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveExportPDF = new System.Windows.Forms.SaveFileDialog();
            this.saveJPG = new System.Windows.Forms.SaveFileDialog();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printDocument2 = new System.Drawing.Printing.PrintDocument();
            this.BTNSearch = new System.Windows.Forms.Button();
            this.BTNScan = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DocumentViewer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDocStag)).BeginInit();
            this.panel1.SuspendLayout();
            this.panelList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewListDoc)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panelGestion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picDoc)).BeginInit();
            this.SuspendLayout();
            // 
            // DocumentViewer
            // 
            this.DocumentViewer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.DocumentViewer.Image = ((System.Drawing.Image)(resources.GetObject("DocumentViewer.Image")));
            this.DocumentViewer.InitialImage = null;
            this.DocumentViewer.Location = new System.Drawing.Point(660, 20);
            this.DocumentViewer.Name = "DocumentViewer";
            this.DocumentViewer.Size = new System.Drawing.Size(309, 432);
            this.DocumentViewer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.DocumentViewer.TabIndex = 0;
            this.DocumentViewer.TabStop = false;
            // 
            // dataGridViewDocStag
            // 
            this.dataGridViewDocStag.AllowUserToAddRows = false;
            this.dataGridViewDocStag.AllowUserToDeleteRows = false;
            this.dataGridViewDocStag.AllowUserToResizeRows = false;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(243)))), ((int)(((byte)(233)))));
            this.dataGridViewDocStag.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle13;
            this.dataGridViewDocStag.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewDocStag.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.dataGridViewDocStag.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewDocStag.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewDocStag.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.dataGridViewDocStag.ColumnHeadersHeight = 30;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(107)))), ((int)(((byte)(107)))));
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewDocStag.DefaultCellStyle = dataGridViewCellStyle15;
            this.dataGridViewDocStag.EnableHeadersVisualStyles = false;
            this.dataGridViewDocStag.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(229)))), ((int)(((byte)(222)))));
            this.dataGridViewDocStag.Location = new System.Drawing.Point(9, 57);
            this.dataGridViewDocStag.MultiSelect = false;
            this.dataGridViewDocStag.Name = "dataGridViewDocStag";
            this.dataGridViewDocStag.ReadOnly = true;
            this.dataGridViewDocStag.RowHeadersVisible = false;
            this.dataGridViewDocStag.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewDocStag.Size = new System.Drawing.Size(621, 395);
            this.dataGridViewDocStag.TabIndex = 1;
            this.dataGridViewDocStag.SelectionChanged += new System.EventHandler(this.dataGridViewDocStag_SelectionChanged);
            // 
            // TXTSearch
            // 
            this.TXTSearch.BackColor = System.Drawing.SystemColors.ControlLight;
            this.TXTSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TXTSearch.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXTSearch.ForeColor = System.Drawing.Color.Gray;
            this.TXTSearch.Location = new System.Drawing.Point(239, 20);
            this.TXTSearch.Name = "TXTSearch";
            this.TXTSearch.Size = new System.Drawing.Size(347, 26);
            this.TXTSearch.TabIndex = 3;
            this.TXTSearch.Text = "  Recherche avec CIN ou CNE de stagiaire";
            this.TXTSearch.Enter += new System.EventHandler(this.TXTSearch_Enter);
            this.TXTSearch.Leave += new System.EventHandler(this.TXTSearch_Leave);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(206)))), ((int)(((byte)(206)))));
            this.panel1.Controls.Add(this.DisplayList);
            this.panel1.Controls.Add(this.BTNAddlist);
            this.panel1.Controls.Add(this.LblCount);
            this.panel1.Controls.Add(this.BTNLast);
            this.panel1.Controls.Add(this.BTNNext);
            this.panel1.Controls.Add(this.BTNPrevious);
            this.panel1.Controls.Add(this.BTNFirst);
            this.panel1.Location = new System.Drawing.Point(9, 453);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(960, 31);
            this.panel1.TabIndex = 4;
            // 
            // DisplayList
            // 
            this.DisplayList.FlatAppearance.BorderSize = 0;
            this.DisplayList.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.DisplayList.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.DisplayList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DisplayList.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DisplayList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.DisplayList.Image = ((System.Drawing.Image)(resources.GetObject("DisplayList.Image")));
            this.DisplayList.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DisplayList.Location = new System.Drawing.Point(136, 4);
            this.DisplayList.Name = "DisplayList";
            this.DisplayList.Size = new System.Drawing.Size(120, 23);
            this.DisplayList.TabIndex = 31;
            this.DisplayList.Text = "Afficher la list";
            this.DisplayList.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.DisplayList.UseVisualStyleBackColor = true;
            this.DisplayList.Click += new System.EventHandler(this.DisplayList_Click);
            this.DisplayList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DisplayList_MouseDown);
            this.DisplayList.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DisplayList_MouseUp);
            // 
            // BTNAddlist
            // 
            this.BTNAddlist.FlatAppearance.BorderSize = 0;
            this.BTNAddlist.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.BTNAddlist.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.BTNAddlist.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNAddlist.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNAddlist.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.BTNAddlist.Image = ((System.Drawing.Image)(resources.GetObject("BTNAddlist.Image")));
            this.BTNAddlist.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BTNAddlist.Location = new System.Drawing.Point(5, 4);
            this.BTNAddlist.Name = "BTNAddlist";
            this.BTNAddlist.Size = new System.Drawing.Size(128, 23);
            this.BTNAddlist.TabIndex = 30;
            this.BTNAddlist.Text = "Ajouter à la list";
            this.BTNAddlist.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BTNAddlist.UseVisualStyleBackColor = true;
            this.BTNAddlist.Click += new System.EventHandler(this.BTNAddlist_Click);
            this.BTNAddlist.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BTNAddlist_MouseDown);
            this.BTNAddlist.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BTNAddlist_MouseUp);
            // 
            // LblCount
            // 
            this.LblCount.AutoSize = true;
            this.LblCount.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.LblCount.Location = new System.Drawing.Point(786, 7);
            this.LblCount.Name = "LblCount";
            this.LblCount.Size = new System.Drawing.Size(28, 16);
            this.LblCount.TabIndex = 4;
            this.LblCount.Text = "0/0";
            // 
            // BTNLast
            // 
            this.BTNLast.BackColor = System.Drawing.Color.Transparent;
            this.BTNLast.FlatAppearance.BorderSize = 0;
            this.BTNLast.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.BTNLast.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.BTNLast.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.BTNLast.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNLast.Image = ((System.Drawing.Image)(resources.GetObject("BTNLast.Image")));
            this.BTNLast.Location = new System.Drawing.Point(913, 4);
            this.BTNLast.Name = "BTNLast";
            this.BTNLast.Size = new System.Drawing.Size(36, 22);
            this.BTNLast.TabIndex = 3;
            this.BTNLast.UseVisualStyleBackColor = false;
            this.BTNLast.Click += new System.EventHandler(this.BTNLast_Click);
            this.BTNLast.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BTNLast_MouseDown);
            this.BTNLast.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BTNLast_MouseUp);
            // 
            // BTNNext
            // 
            this.BTNNext.BackColor = System.Drawing.Color.Transparent;
            this.BTNNext.FlatAppearance.BorderSize = 0;
            this.BTNNext.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.BTNNext.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.BTNNext.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.BTNNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNNext.Image = ((System.Drawing.Image)(resources.GetObject("BTNNext.Image")));
            this.BTNNext.Location = new System.Drawing.Point(840, 4);
            this.BTNNext.Name = "BTNNext";
            this.BTNNext.Size = new System.Drawing.Size(36, 22);
            this.BTNNext.TabIndex = 2;
            this.BTNNext.UseVisualStyleBackColor = false;
            this.BTNNext.Click += new System.EventHandler(this.BTNNext_Click);
            this.BTNNext.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BTNNext_MouseDown);
            this.BTNNext.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BTNNext_MouseUp);
            // 
            // BTNPrevious
            // 
            this.BTNPrevious.BackColor = System.Drawing.Color.Transparent;
            this.BTNPrevious.FlatAppearance.BorderSize = 0;
            this.BTNPrevious.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.BTNPrevious.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.BTNPrevious.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.BTNPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNPrevious.Image = ((System.Drawing.Image)(resources.GetObject("BTNPrevious.Image")));
            this.BTNPrevious.Location = new System.Drawing.Point(730, 4);
            this.BTNPrevious.Name = "BTNPrevious";
            this.BTNPrevious.Size = new System.Drawing.Size(36, 22);
            this.BTNPrevious.TabIndex = 1;
            this.BTNPrevious.UseVisualStyleBackColor = false;
            this.BTNPrevious.Click += new System.EventHandler(this.BTNPrevious_Click);
            this.BTNPrevious.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BTNPrevious_MouseDown);
            this.BTNPrevious.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BTNPrevious_MouseUp);
            // 
            // BTNFirst
            // 
            this.BTNFirst.BackColor = System.Drawing.Color.Transparent;
            this.BTNFirst.FlatAppearance.BorderSize = 0;
            this.BTNFirst.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.BTNFirst.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.BTNFirst.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.BTNFirst.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNFirst.Image = ((System.Drawing.Image)(resources.GetObject("BTNFirst.Image")));
            this.BTNFirst.Location = new System.Drawing.Point(657, 4);
            this.BTNFirst.Name = "BTNFirst";
            this.BTNFirst.Size = new System.Drawing.Size(36, 22);
            this.BTNFirst.TabIndex = 0;
            this.BTNFirst.UseVisualStyleBackColor = false;
            this.BTNFirst.Click += new System.EventHandler(this.BTNFirst_Click);
            this.BTNFirst.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BTNFirst_MouseDown);
            this.BTNFirst.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BTNFirst_MouseUp);
            // 
            // BTNImport
            // 
            this.BTNImport.FlatAppearance.BorderSize = 0;
            this.BTNImport.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.BTNImport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.BTNImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNImport.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNImport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.BTNImport.Image = ((System.Drawing.Image)(resources.GetObject("BTNImport.Image")));
            this.BTNImport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BTNImport.Location = new System.Drawing.Point(11, 486);
            this.BTNImport.Name = "BTNImport";
            this.BTNImport.Size = new System.Drawing.Size(87, 24);
            this.BTNImport.TabIndex = 5;
            this.BTNImport.Text = "Importer";
            this.BTNImport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BTNImport.UseVisualStyleBackColor = true;
            this.BTNImport.Click += new System.EventHandler(this.BTNImport_Click);
            this.BTNImport.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BTNImport_MouseDown);
            this.BTNImport.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BTNImport_MouseUp);
            // 
            // BTNExport
            // 
            this.BTNExport.FlatAppearance.BorderSize = 0;
            this.BTNExport.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.BTNExport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.BTNExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNExport.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNExport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.BTNExport.Image = ((System.Drawing.Image)(resources.GetObject("BTNExport.Image")));
            this.BTNExport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BTNExport.Location = new System.Drawing.Point(633, 486);
            this.BTNExport.Name = "BTNExport";
            this.BTNExport.Size = new System.Drawing.Size(117, 24);
            this.BTNExport.TabIndex = 6;
            this.BTNExport.Text = "Exporter(JPG)";
            this.BTNExport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BTNExport.UseVisualStyleBackColor = true;
            this.BTNExport.Click += new System.EventHandler(this.BTNExport_Click);
            this.BTNExport.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BTNExport_MouseDown);
            this.BTNExport.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BTNExport_MouseUp);
            // 
            // BTNDelete
            // 
            this.BTNDelete.FlatAppearance.BorderSize = 0;
            this.BTNDelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.BTNDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.BTNDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNDelete.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNDelete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.BTNDelete.Image = ((System.Drawing.Image)(resources.GetObject("BTNDelete.Image")));
            this.BTNDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BTNDelete.Location = new System.Drawing.Point(188, 486);
            this.BTNDelete.Name = "BTNDelete";
            this.BTNDelete.Size = new System.Drawing.Size(98, 24);
            this.BTNDelete.TabIndex = 7;
            this.BTNDelete.Text = "Supprimer";
            this.BTNDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BTNDelete.UseVisualStyleBackColor = true;
            this.BTNDelete.Click += new System.EventHandler(this.BTNDelete_Click);
            this.BTNDelete.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BTNDelete_MouseDown);
            this.BTNDelete.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BTNDelete_MouseUp);
            // 
            // BTNPrint
            // 
            this.BTNPrint.FlatAppearance.BorderSize = 0;
            this.BTNPrint.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.BTNPrint.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.BTNPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNPrint.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNPrint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.BTNPrint.Image = ((System.Drawing.Image)(resources.GetObject("BTNPrint.Image")));
            this.BTNPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BTNPrint.Location = new System.Drawing.Point(878, 486);
            this.BTNPrint.Name = "BTNPrint";
            this.BTNPrint.Size = new System.Drawing.Size(90, 24);
            this.BTNPrint.TabIndex = 9;
            this.BTNPrint.Text = "Imprimer";
            this.BTNPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BTNPrint.UseVisualStyleBackColor = true;
            this.BTNPrint.Click += new System.EventHandler(this.BTNPrint_Click);
            this.BTNPrint.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BTNPrint_MouseDown);
            this.BTNPrint.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BTNPrint_MouseUp);
            // 
            // BTNPDF
            // 
            this.BTNPDF.FlatAppearance.BorderSize = 0;
            this.BTNPDF.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.BTNPDF.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.BTNPDF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNPDF.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNPDF.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.BTNPDF.Image = ((System.Drawing.Image)(resources.GetObject("BTNPDF.Image")));
            this.BTNPDF.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BTNPDF.Location = new System.Drawing.Point(755, 486);
            this.BTNPDF.Name = "BTNPDF";
            this.BTNPDF.Size = new System.Drawing.Size(118, 24);
            this.BTNPDF.TabIndex = 8;
            this.BTNPDF.Text = "Exporter(PDF)";
            this.BTNPDF.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BTNPDF.UseVisualStyleBackColor = true;
            this.BTNPDF.Click += new System.EventHandler(this.BTNPDF_Click);
            this.BTNPDF.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BTNPDF_MouseDown);
            this.BTNPDF.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BTNPDF_MouseUp);
            // 
            // BTNEdit
            // 
            this.BTNEdit.FlatAppearance.BorderSize = 0;
            this.BTNEdit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.BTNEdit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.BTNEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNEdit.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNEdit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.BTNEdit.Image = ((System.Drawing.Image)(resources.GetObject("BTNEdit.Image")));
            this.BTNEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BTNEdit.Location = new System.Drawing.Point(100, 486);
            this.BTNEdit.Name = "BTNEdit";
            this.BTNEdit.Size = new System.Drawing.Size(86, 24);
            this.BTNEdit.TabIndex = 10;
            this.BTNEdit.Text = "Modifier";
            this.BTNEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BTNEdit.UseVisualStyleBackColor = true;
            this.BTNEdit.Click += new System.EventHandler(this.BTNEdit_Click);
            this.BTNEdit.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BTNEdit_MouseDown);
            this.BTNEdit.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BTNEdit_MouseUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.label2.Image = ((System.Drawing.Image)(resources.GetObject("label2.Image")));
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.Location = new System.Drawing.Point(17, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(201, 21);
            this.label2.TabIndex = 12;
            this.label2.Text = "       Document stagiaire :";
            // 
            // panelList
            // 
            this.panelList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.panelList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelList.Controls.Add(this.dataGridViewListDoc);
            this.panelList.Controls.Add(this.label1);
            this.panelList.Controls.Add(this.groupBox1);
            this.panelList.Controls.Add(this.btnCloseList);
            this.panelList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.panelList.Location = new System.Drawing.Point(86, 13);
            this.panelList.Name = "panelList";
            this.panelList.Size = new System.Drawing.Size(757, 0);
            this.panelList.TabIndex = 13;
            // 
            // dataGridViewListDoc
            // 
            this.dataGridViewListDoc.AllowUserToAddRows = false;
            this.dataGridViewListDoc.AllowUserToDeleteRows = false;
            this.dataGridViewListDoc.AllowUserToResizeRows = false;
            dataGridViewCellStyle16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(243)))), ((int)(((byte)(233)))));
            this.dataGridViewListDoc.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle16;
            this.dataGridViewListDoc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewListDoc.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.dataGridViewListDoc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewListDoc.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle17.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewListDoc.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle17;
            this.dataGridViewListDoc.ColumnHeadersHeight = 30;
            this.dataGridViewListDoc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Nom_document});
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle18.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(107)))), ((int)(((byte)(107)))));
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewListDoc.DefaultCellStyle = dataGridViewCellStyle18;
            this.dataGridViewListDoc.EnableHeadersVisualStyles = false;
            this.dataGridViewListDoc.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(229)))), ((int)(((byte)(222)))));
            this.dataGridViewListDoc.Location = new System.Drawing.Point(30, 60);
            this.dataGridViewListDoc.MultiSelect = false;
            this.dataGridViewListDoc.Name = "dataGridViewListDoc";
            this.dataGridViewListDoc.ReadOnly = true;
            this.dataGridViewListDoc.RowHeadersVisible = false;
            this.dataGridViewListDoc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewListDoc.Size = new System.Drawing.Size(706, 268);
            this.dataGridViewListDoc.TabIndex = 14;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            // 
            // Nom_document
            // 
            this.Nom_document.HeaderText = "Nom de document";
            this.Nom_document.Name = "Nom_document";
            this.Nom_document.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(20, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(250, 21);
            this.label1.TabIndex = 13;
            this.label1.Text = "       Liste des Documents choisi :";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.groupBox1.Controls.Add(this.btnExporterListe);
            this.groupBox1.Controls.Add(this.btnViderListe);
            this.groupBox1.Controls.Add(this.btnSupprimerListe);
            this.groupBox1.Controls.Add(this.btnImprimerList);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.groupBox1.Location = new System.Drawing.Point(24, 346);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(712, 116);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Géstion de la liste";
            // 
            // btnExporterListe
            // 
            this.btnExporterListe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.btnExporterListe.FlatAppearance.BorderSize = 0;
            this.btnExporterListe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExporterListe.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExporterListe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.btnExporterListe.Image = ((System.Drawing.Image)(resources.GetObject("btnExporterListe.Image")));
            this.btnExporterListe.Location = new System.Drawing.Point(493, 34);
            this.btnExporterListe.Name = "btnExporterListe";
            this.btnExporterListe.Size = new System.Drawing.Size(207, 58);
            this.btnExporterListe.TabIndex = 0;
            this.btnExporterListe.Text = " Exporter la liste(PDF)";
            this.btnExporterListe.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExporterListe.UseVisualStyleBackColor = false;
            this.btnExporterListe.Click += new System.EventHandler(this.btnExporterListe_Click);
            // 
            // btnViderListe
            // 
            this.btnViderListe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.btnViderListe.FlatAppearance.BorderSize = 0;
            this.btnViderListe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViderListe.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViderListe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.btnViderListe.Image = ((System.Drawing.Image)(resources.GetObject("btnViderListe.Image")));
            this.btnViderListe.Location = new System.Drawing.Point(154, 34);
            this.btnViderListe.Name = "btnViderListe";
            this.btnViderListe.Size = new System.Drawing.Size(148, 58);
            this.btnViderListe.TabIndex = 0;
            this.btnViderListe.Text = " Vider la liste";
            this.btnViderListe.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnViderListe.UseVisualStyleBackColor = false;
            this.btnViderListe.Click += new System.EventHandler(this.btnViderListe_Click);
            // 
            // btnSupprimerListe
            // 
            this.btnSupprimerListe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.btnSupprimerListe.FlatAppearance.BorderSize = 0;
            this.btnSupprimerListe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSupprimerListe.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSupprimerListe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.btnSupprimerListe.Image = ((System.Drawing.Image)(resources.GetObject("btnSupprimerListe.Image")));
            this.btnSupprimerListe.Location = new System.Drawing.Point(14, 34);
            this.btnSupprimerListe.Name = "btnSupprimerListe";
            this.btnSupprimerListe.Size = new System.Drawing.Size(133, 58);
            this.btnSupprimerListe.TabIndex = 0;
            this.btnSupprimerListe.Text = "  Supprimer";
            this.btnSupprimerListe.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSupprimerListe.UseVisualStyleBackColor = false;
            this.btnSupprimerListe.Click += new System.EventHandler(this.btnSupprimerListe_Click);
            // 
            // btnImprimerList
            // 
            this.btnImprimerList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.btnImprimerList.FlatAppearance.BorderSize = 0;
            this.btnImprimerList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImprimerList.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimerList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.btnImprimerList.Image = ((System.Drawing.Image)(resources.GetObject("btnImprimerList.Image")));
            this.btnImprimerList.Location = new System.Drawing.Point(309, 34);
            this.btnImprimerList.Name = "btnImprimerList";
            this.btnImprimerList.Size = new System.Drawing.Size(177, 58);
            this.btnImprimerList.TabIndex = 0;
            this.btnImprimerList.Text = " Imprimer la liste";
            this.btnImprimerList.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnImprimerList.UseVisualStyleBackColor = false;
            this.btnImprimerList.Click += new System.EventHandler(this.btnImprimerList_Click);
            // 
            // btnCloseList
            // 
            this.btnCloseList.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.btnCloseList.FlatAppearance.BorderSize = 0;
            this.btnCloseList.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.btnCloseList.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.btnCloseList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseList.Image = ((System.Drawing.Image)(resources.GetObject("btnCloseList.Image")));
            this.btnCloseList.Location = new System.Drawing.Point(711, 4);
            this.btnCloseList.Name = "btnCloseList";
            this.btnCloseList.Size = new System.Drawing.Size(37, 40);
            this.btnCloseList.TabIndex = 0;
            this.btnCloseList.UseVisualStyleBackColor = true;
            this.btnCloseList.Click += new System.EventHandler(this.button1_Click);
            // 
            // panelGestion
            // 
            this.panelGestion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelGestion.Controls.Add(this.BTNCloseAddEdit);
            this.panelGestion.Controls.Add(this.BTNScan);
            this.panelGestion.Controls.Add(this.btnAjouter);
            this.panelGestion.Controls.Add(this.lblTitle);
            this.panelGestion.Controls.Add(this.comboType);
            this.panelGestion.Controls.Add(this.label5);
            this.panelGestion.Controls.Add(this.txtID);
            this.panelGestion.Controls.Add(this.label4);
            this.panelGestion.Controls.Add(this.txtCIN);
            this.panelGestion.Controls.Add(this.label3);
            this.panelGestion.Controls.Add(this.picDoc);
            this.panelGestion.Controls.Add(this.btnModifier);
            this.panelGestion.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelGestion.Location = new System.Drawing.Point(117, 74);
            this.panelGestion.Name = "panelGestion";
            this.panelGestion.Size = new System.Drawing.Size(706, 0);
            this.panelGestion.TabIndex = 14;
            // 
            // BTNCloseAddEdit
            // 
            this.BTNCloseAddEdit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.BTNCloseAddEdit.FlatAppearance.BorderSize = 0;
            this.BTNCloseAddEdit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.BTNCloseAddEdit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.BTNCloseAddEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNCloseAddEdit.Image = ((System.Drawing.Image)(resources.GetObject("BTNCloseAddEdit.Image")));
            this.BTNCloseAddEdit.Location = new System.Drawing.Point(661, 7);
            this.BTNCloseAddEdit.Name = "BTNCloseAddEdit";
            this.BTNCloseAddEdit.Size = new System.Drawing.Size(37, 32);
            this.BTNCloseAddEdit.TabIndex = 9;
            this.BTNCloseAddEdit.UseVisualStyleBackColor = true;
            this.BTNCloseAddEdit.Click += new System.EventHandler(this.BTNCloseAddEdit_Click);
            // 
            // btnAjouter
            // 
            this.btnAjouter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.btnAjouter.FlatAppearance.BorderSize = 0;
            this.btnAjouter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAjouter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.btnAjouter.Location = new System.Drawing.Point(522, 296);
            this.btnAjouter.Name = "btnAjouter";
            this.btnAjouter.Size = new System.Drawing.Size(146, 41);
            this.btnAjouter.TabIndex = 8;
            this.btnAjouter.Text = "Ajouter";
            this.btnAjouter.UseVisualStyleBackColor = false;
            this.btnAjouter.Click += new System.EventHandler(this.btnAjouter_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.lblTitle.Location = new System.Drawing.Point(274, 42);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(310, 33);
            this.lblTitle.TabIndex = 7;
            this.lblTitle.Text = "Ajouter un document :";
            // 
            // comboType
            // 
            this.comboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.comboType.FormattingEnabled = true;
            this.comboType.Location = new System.Drawing.Point(427, 149);
            this.comboType.Name = "comboType";
            this.comboType.Size = new System.Drawing.Size(234, 25);
            this.comboType.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.label5.Location = new System.Drawing.Point(260, 154);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(137, 17);
            this.label5.TabIndex = 5;
            this.label5.Text = "Type de document :";
            // 
            // txtID
            // 
            this.txtID.Enabled = false;
            this.txtID.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.txtID.Location = new System.Drawing.Point(427, 102);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(234, 23);
            this.txtID.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.label4.Location = new System.Drawing.Point(275, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "ID de document :";
            // 
            // txtCIN
            // 
            this.txtCIN.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCIN.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.txtCIN.Location = new System.Drawing.Point(427, 198);
            this.txtCIN.Name = "txtCIN";
            this.txtCIN.Size = new System.Drawing.Size(234, 23);
            this.txtCIN.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.label3.Location = new System.Drawing.Point(277, 203);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "CIN de stagiaire :";
            // 
            // picDoc
            // 
            this.picDoc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.picDoc.Image = ((System.Drawing.Image)(resources.GetObject("picDoc.Image")));
            this.picDoc.Location = new System.Drawing.Point(19, 30);
            this.picDoc.Name = "picDoc";
            this.picDoc.Size = new System.Drawing.Size(202, 270);
            this.picDoc.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picDoc.TabIndex = 0;
            this.picDoc.TabStop = false;
            this.picDoc.Click += new System.EventHandler(this.picDoc_Click);
            // 
            // btnModifier
            // 
            this.btnModifier.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.btnModifier.FlatAppearance.BorderSize = 0;
            this.btnModifier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModifier.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.btnModifier.Location = new System.Drawing.Point(523, 296);
            this.btnModifier.Name = "btnModifier";
            this.btnModifier.Size = new System.Drawing.Size(146, 41);
            this.btnModifier.TabIndex = 8;
            this.btnModifier.Text = "Modifier";
            this.btnModifier.UseVisualStyleBackColor = false;
            this.btnModifier.Click += new System.EventHandler(this.btnModifier_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // saveExportPDF
            // 
            this.saveExportPDF.Filter = "PDF | *.pdf";
            // 
            // saveJPG
            // 
            this.saveJPG.Filter = "JPEG | *.jpg";
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printDocument2
            // 
            this.printDocument2.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument2_PrintPage);
            // 
            // BTNSearch
            // 
            this.BTNSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.BTNSearch.FlatAppearance.BorderSize = 0;
            this.BTNSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNSearch.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.BTNSearch.Image = ((System.Drawing.Image)(resources.GetObject("BTNSearch.Image")));
            this.BTNSearch.Location = new System.Drawing.Point(588, 20);
            this.BTNSearch.Name = "BTNSearch";
            this.BTNSearch.Size = new System.Drawing.Size(38, 26);
            this.BTNSearch.TabIndex = 15;
            this.BTNSearch.UseVisualStyleBackColor = false;
            this.BTNSearch.Click += new System.EventHandler(this.BTNSearch_Click);
            // 
            // BTNScan
            // 
            this.BTNScan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.BTNScan.FlatAppearance.BorderSize = 0;
            this.BTNScan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNScan.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNScan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.BTNScan.Image = ((System.Drawing.Image)(resources.GetObject("BTNScan.Image")));
            this.BTNScan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BTNScan.Location = new System.Drawing.Point(19, 307);
            this.BTNScan.Name = "BTNScan";
            this.BTNScan.Size = new System.Drawing.Size(202, 36);
            this.BTNScan.TabIndex = 8;
            this.BTNScan.Text = "   Scan document";
            this.BTNScan.UseVisualStyleBackColor = false;
            this.BTNScan.Click += new System.EventHandler(this.BTNScan_Click);
            // 
            // Document_Stagaire
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.Controls.Add(this.panelGestion);
            this.Controls.Add(this.panelList);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BTNEdit);
            this.Controls.Add(this.BTNPrint);
            this.Controls.Add(this.BTNPDF);
            this.Controls.Add(this.BTNDelete);
            this.Controls.Add(this.BTNExport);
            this.Controls.Add(this.BTNImport);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.TXTSearch);
            this.Controls.Add(this.dataGridViewDocStag);
            this.Controls.Add(this.DocumentViewer);
            this.Controls.Add(this.BTNSearch);
            this.Name = "Document_Stagaire";
            this.Size = new System.Drawing.Size(996, 583);
            this.Load += new System.EventHandler(this.Document_Stagaire_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DocumentViewer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDocStag)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelList.ResumeLayout(false);
            this.panelList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewListDoc)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.panelGestion.ResumeLayout(false);
            this.panelGestion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picDoc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox DocumentViewer;
        private System.Windows.Forms.DataGridView dataGridViewDocStag;
        private System.Windows.Forms.TextBox TXTSearch;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LblCount;
        private System.Windows.Forms.Button BTNLast;
        private System.Windows.Forms.Button BTNNext;
        private System.Windows.Forms.Button BTNPrevious;
        private System.Windows.Forms.Button BTNFirst;
        private System.Windows.Forms.Button BTNImport;
        private System.Windows.Forms.Button BTNExport;
        private System.Windows.Forms.Button BTNDelete;
        private System.Windows.Forms.Button BTNPrint;
        private System.Windows.Forms.Button BTNPDF;
        private System.Windows.Forms.Button BTNEdit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button DisplayList;
        private System.Windows.Forms.Button BTNAddlist;
        private System.Windows.Forms.Panel panelList;
        private System.Windows.Forms.Button btnCloseList;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnExporterListe;
        private System.Windows.Forms.Button btnViderListe;
        private System.Windows.Forms.Button btnSupprimerListe;
        private System.Windows.Forms.Button btnImprimerList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelGestion;
        private System.Windows.Forms.Button btnAjouter;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ComboBox comboType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCIN;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox picDoc;
        private System.Windows.Forms.Button btnModifier;
        private System.Windows.Forms.Button BTNCloseAddEdit;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveExportPDF;
        private System.Windows.Forms.DataGridView dataGridViewListDoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nom_document;
        private System.Windows.Forms.SaveFileDialog saveJPG;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Drawing.Printing.PrintDocument printDocument2;
        private System.Windows.Forms.Button BTNSearch;
        private System.Windows.Forms.Button BTNScan;
    }
}
