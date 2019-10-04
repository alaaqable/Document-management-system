using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using WIA;
using System.Runtime.InteropServices;

namespace Projet_Archivage
{
    public partial class Document_Stagaire : UserControl
    {
        Design design = new Design();
        DBManager Manager = new DBManager();
        DataSet dsDoc, dsType,dsStagiaire;
        List<int> listdoc = new List<int>();
        List<Image> listImages = new List<Image>();
        int coun = 0;
        int p = 0;
        public Document_Stagaire()
        {
            InitializeComponent();
        }

        private void Document_Stagaire_Load(object sender, EventArgs e)
        {
            dsType = new DataSet();
            dsStagiaire = new DataSet();
            dsDoc = new DataSet();
            if (Manager.Statue() == false)
            {
                // remplir combobox et dataset et datagridview type document stagiaire 
                Datasetfiller("select * from Type_Documents_Stagiaire", "TypeDoc", dsType);
                Manager.Fill_Combobox(comboType, dsType.Tables["TypeDoc"], "Nom_Doc_Type", "Nom_Doc_Type");
                // remplir dataset stagiaire
                Datasetfiller("select * from Stagiaire", "Stagiaire", dsStagiaire);

                //// remplir dataset document stagiaire
                Datasetfiller("DocStag", "DocStag", dsDoc);
                Datasetfiller("select top 10 * from Documents_Stagiaire ORDER BY ID_Doc_Stagiaire DESC", "Document_Stagiaire", dsDoc);
                Manager.Fill_DataGridView(dataGridViewDocStag, dsDoc.Tables["DocStag"]);
                //LBL COUNT 
                if (dataGridViewDocStag.Rows.Count > 0)
                {
                    LblCount.Text = p + 1 + "/" + dataGridViewDocStag.Rows.Count;
                }
                AutoCompleteStringCollection auto = new AutoCompleteStringCollection();
                for (int i = 0; i < dsStagiaire.Tables["Stagiaire"].Rows.Count; i++)
                {
                    auto.Add(dsStagiaire.Tables["Stagiaire"].Rows[i][0].ToString());
                }
                txtCIN.AutoCompleteMode = AutoCompleteMode.Suggest;
                txtCIN.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtCIN.AutoCompleteCustomSource = auto;
            }

        }
        //Navigation
        #region BTNFirst Hover
        private void BTNFirst_MouseDown(object sender, MouseEventArgs e)
        {
            design.BTNUPDown(BTNFirst,Image.FromFile("Icons/First1.png"));
        }

        private void BTNFirst_MouseUp(object sender, MouseEventArgs e)
        {
            design.BTNUPDown(BTNFirst, Image.FromFile("Icons/First.png"));
        }
        #endregion
        #region BTNPrevious Hover
        private void BTNPrevious_MouseDown(object sender, MouseEventArgs e)
        {
            design.BTNUPDown(BTNPrevious, Image.FromFile("Icons/Previous1.png"));
        }

        private void BTNPrevious_MouseUp(object sender, MouseEventArgs e)
        {
            design.BTNUPDown(BTNPrevious, Image.FromFile("Icons/Previous.png"));
        }
        #endregion
        #region BTNNext Hover
        private void BTNNext_MouseDown(object sender, MouseEventArgs e)
        {
            design.BTNUPDown(BTNNext, Image.FromFile("Icons/Next1.png"));
        }

        private void BTNNext_MouseUp(object sender, MouseEventArgs e)
        {
            design.BTNUPDown(BTNNext, Image.FromFile("Icons/Next.png"));
        }
        #endregion
        #region BTNLast Hover
        private void BTNLast_MouseDown(object sender, MouseEventArgs e)
        {
            design.BTNUPDown(BTNLast, Image.FromFile("Icons/Last1.png"));
        }

        private void BTNLast_MouseUp(object sender, MouseEventArgs e)
        {
            design.BTNUPDown(BTNLast, Image.FromFile("Icons/Last.png"));
        }
        #endregion
        //Import,Edit,Delete
        #region BTNImport Hover
        private void BTNImport_MouseDown(object sender, MouseEventArgs e)
        {
            design.BTNUPDown(BTNImport, Image.FromFile("Icons/Importer1.png"), "#636262");
        }

        private void BTNImport_MouseUp(object sender, MouseEventArgs e)
        {
            design.BTNUPDown(BTNImport, Image.FromFile("Icons/Importer.png"), "#444444");
        }
        #endregion
        #region BTNEdit Hover
        private void BTNEdit_MouseDown(object sender, MouseEventArgs e)
        {
            design.BTNUPDown(BTNEdit, Image.FromFile("Icons/Edit1.png"), "#636262");
        }

        private void BTNEdit_MouseUp(object sender, MouseEventArgs e)
        {
            design.BTNUPDown(BTNEdit, Image.FromFile("Icons/Edit.png"), "#444444");
        }
        #endregion
        #region BTNDelete Hover
        private void BTNDelete_MouseDown(object sender, MouseEventArgs e)
        {
            design.BTNUPDown(BTNDelete, Image.FromFile("Icons/Supprimer.png"), "#636262");
        }

        private void BTNDelete_MouseUp(object sender, MouseEventArgs e)
        {
            design.BTNUPDown(BTNDelete, Image.FromFile("Icons/Supprimer1.png"), "#444444");
        }
        #endregion
        //Export(JPG),Export(PDF),Print
        #region BTNExport Hover
        private void BTNExport_MouseDown(object sender, MouseEventArgs e)
        {
            design.BTNUPDown(BTNExport, Image.FromFile("Icons/Exporter1.png"), "#636262");
        }

        private void BTNExport_MouseUp(object sender, MouseEventArgs e)
        {
            design.BTNUPDown(BTNExport, Image.FromFile("Icons/Exporter.png"), "#444444");
        }
        #endregion
        #region BTNPDF Hover
        private void BTNPDF_MouseDown(object sender, MouseEventArgs e)
        {
            design.BTNUPDown(BTNPDF, Image.FromFile("Icons/Export_pdf1.png"), "#636262");
        }

        private void BTNPDF_MouseUp(object sender, MouseEventArgs e)
        {
            design.BTNUPDown(BTNPDF, Image.FromFile("Icons/Export_pdf.png"), "#444444");
        }
        #endregion
        #region BTNPrint Hover
        private void BTNPrint_MouseDown(object sender, MouseEventArgs e)
        {
            design.BTNUPDown(BTNPrint, Image.FromFile("Icons/Imprimer1.png"), "#636262");
        }

        private void BTNPrint_MouseUp(object sender, MouseEventArgs e)
        {
            design.BTNUPDown(BTNPrint, Image.FromFile("Icons/Imprimer.png"), "#444444");
        }
        #endregion
        //Add to the list,Display the list
        #region BTNAddlist Hover
        private void BTNAddlist_MouseDown(object sender, MouseEventArgs e)
        {
           design.BTNUPDown(BTNAddlist, Image.FromFile("Icons/AddList1.png"), "#636262");
        }

        private void BTNAddlist_MouseUp(object sender, MouseEventArgs e)
        {
            design.BTNUPDown(BTNAddlist, Image.FromFile("Icons/AddList.png"), "#444444");
        }
        #endregion
        #region DisplayList Hover
        private void DisplayList_MouseDown(object sender, MouseEventArgs e)
        {
            design.BTNUPDown(DisplayList, Image.FromFile("Icons/DisplayList1.png"), "#636262");
        }

        private void DisplayList_MouseUp(object sender, MouseEventArgs e)
        {
            design.BTNUPDown(DisplayList, Image.FromFile("Icons/DisplayList.png"), "#444444");
        }
        #endregion
        // textsearch
        #region Text search text changing
        private void TXTSearch_Enter(object sender, EventArgs e)
        {
            design.TextBox_PlaceHolder(TXTSearch, "  Recherche avec CIN ou CNE de stagiaire");
        }

        private void TXTSearch_Leave(object sender, EventArgs e)
        {
            design.TextBox_PlaceHolder(TXTSearch, "  Recherche avec CIN ou CNE de stagiaire");
           
        }
        #endregion
        //  Btncloselist
        #region close list panel
        private void button1_Click(object sender, EventArgs e)
        {
            panelList.Height = 0;
            EnabledCheck(true);
        }
        #endregion
        // btnDisplaylist and Enabled checked method
        #region show list panel
        private void DisplayList_Click(object sender, EventArgs e)
        {
            panelList.Height = 479;
            EnabledCheck(false);
        }
        private void EnabledCheck(bool check)
        {
            BTNImport.Enabled = check;
            BTNEdit.Enabled = check;
            BTNDelete.Enabled = check;
            BTNExport.Enabled = check;
            BTNPDF.Enabled = check;
            BTNLast.Enabled = check;
            BTNAddlist.Enabled = check;
            BTNNext.Enabled = check;
            BTNPrint.Enabled = check;
            dataGridViewDocStag.Enabled = check;
            BTNFirst.Enabled = check;
            BTNPrevious.Enabled = check;
            DisplayList.Enabled = check;
            TXTSearch.Enabled = check;
            BTNSearch.Enabled = check;
        }
        #endregion
        // btn close panel gestion
        #region btncloseaddedit
        private void BTNCloseAddEdit_Click(object sender, EventArgs e)
        {
            panelGestion.Height = 0 ;
            EnabledCheck(true);
        }
        #endregion
        // btn add and edit document stagiaire
        #region BTNImport
        private void BTNImport_Click(object sender, EventArgs e)
        {
            if (txtCIN.Text.Trim() != "")
            {
                txtID.Clear();
                txtCIN.Clear();
                picDoc.ImageLocation = "Icons/AddImage.png";
                picDoc.SizeMode = PictureBoxSizeMode.CenterImage;
            }
            panelGestion.Height = 350;
                lblTitle.Text = "Ajouté un document";
                btnAjouter.BringToFront();
            EnabledCheck(false);

        }
        #endregion
        #region BTNEdit
        private void BTNEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewDocStag.Rows.Count > 0)
            {
                panelGestion.Height = 350;
                lblTitle.Text = "Modifié un document";
                btnModifier.BringToFront();
                FillTextBox();
                EnabledCheck(false);

            }
        }
        #endregion
        //btnajouter document ,convert to byte methode ,picturebox that bring document ,edit document button and convert to image method
        #region btnAjouter
        private void btnAjouter_Click(object sender, EventArgs e)
        {
            int position_stag = Manager.SearchForExistence(dsStagiaire.Tables["Stagiaire"],txtCIN.Text.ToUpper(),"CIN");
            int position_Doc = Manager.SearchForExistence(dsDoc.Tables["Document_Stagiaire"], comboType.SelectedValue.ToString(),txtCIN.Text, "Nom_Doc_Type","CIN");
            Manager.Query("select count(*) from Stagiaire_Groupe_Session where CIN='"+txtCIN.Text.ToUpper()+"'");
            Manager.Open_Connection();
            int po = Manager.ExeuteScalar();
            Manager.Close_Connection();
            if (position_stag != -1 && po > 0 && txtCIN.Text.Trim() != "" && position_Doc == -1)
            {
                try
                {
                Manager.Query("insert into Documents_Stagiaire values(@Nom,@Doc,null,@Cin)");
                Manager.Command.Parameters.AddWithValue("@Nom",comboType.SelectedValue);
                Manager.Command.Parameters.AddWithValue("@Doc", ConvertToByte(picDoc.Image));
                Manager.Command.Parameters.AddWithValue("@Cin", txtCIN.Text.ToUpper());
                Manager.Open_Connection();
                Manager.ExecuteQuery();
                Manager.Close_Connection();
                    MessageBox.Show("Ajouté avec succés", "Ajouter", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (dsDoc.Tables["DocStag"].Rows.Count > 0)
                    {
                        dsDoc.Tables["DocStag"].Rows.Clear();
                        dsDoc.Tables["Document_Stagiaire"].Rows.Clear();
                    }
                    Datasetfiller("select top 10 * from Documents_Stagiaire ORDER BY ID_Doc_Stagiaire DESC", "Document_Stagiaire", dsDoc);
                    Datasetfiller("DocStag", "DocStag", dsDoc);
                    Manager.Fill_DataGridView(dataGridViewDocStag, dsDoc.Tables["DocStag"]);
                    panelGestion.Height = 0;
                    EnabledCheck(true);
                    picDoc.ImageLocation = "Icons/AddImage.png";
                    picDoc.SizeMode = PictureBoxSizeMode.CenterImage;
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message, "Add Doc Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Ereurs listes :\n-Ce stagiaire n'existe pas ou bien il ne pas affecté a un groupe\n-Tu dois remplir tous les champs", "Add Doc Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        #endregion
        #region ConvertToByte method
        private byte[] ConvertToByte(Image image)
        {
            MemoryStream stream = new MemoryStream();
            image.Save(stream, image.RawFormat);
            return stream.GetBuffer();
        }
        #endregion
        #region picDoc
        private void picDoc_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image File(*.jpg *.png)|*.jpg;*.png; ";
            openFileDialog1.FileName = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                picDoc.ImageLocation = openFileDialog1.FileName;
                picDoc.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }
        #endregion
        #region btnModifier
        private void btnModifier_Click(object sender, EventArgs e)
        {
            int position_stag = Manager.SearchForExistence(dsStagiaire.Tables["Stagiaire"], txtCIN.Text.ToUpper(), "CIN");
            int position_Doc = Manager.SearchForExistence(dsDoc.Tables["Document_Stagiaire"], comboType.SelectedValue.ToString(), txtCIN.Text, "Nom_Doc_Type", "CIN");
            int position_Doc_Stag = Manager.SearchForExistence(dsDoc.Tables["Document_Stagiaire"], txtID.Text, "ID_Doc_Stagiaire");
            Manager.Query("select count(*) from Stagiaire_Groupe_Session where CIN='" + txtCIN.Text.ToUpper() + "'");
            Manager.Open_Connection();
            int po = Manager.ExeuteScalar();
            Manager.Close_Connection();
            if (position_stag != -1 && txtCIN.Text.Trim() != "" && position_Doc_Stag != -1 && po > 0 && position_Doc == -1)
            {
                try
                {
                    Manager.Query("update Documents_Stagiaire set Nom_Doc_Type = @Nom,Document_Stagiaire = @Doc,CIN = @Cin where ID_Doc_Stagiaire = @id");
                    Manager.Command.Parameters.AddWithValue("@Nom", comboType.SelectedValue);
                    Manager.Command.Parameters.AddWithValue("@Doc", ConvertToByte(picDoc.Image));
                    Manager.Command.Parameters.AddWithValue("@Cin", txtCIN.Text.ToUpper());
                    Manager.Command.Parameters.AddWithValue("@id", txtID.Text);
                    Manager.Open_Connection();
                    Manager.ExecuteQuery();
                    Manager.Close_Connection();
                    MessageBox.Show("Modifié avec succés", "Modifier", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (dsDoc.Tables["Document_Stagiaire"] != null && dsDoc.Tables["DocStag"] != null)
                    {
                        dsDoc.Tables["Document_Stagiaire"].Rows.Clear();
                        dsDoc.Tables["DocStag"].Rows.Clear();
                    }
                    //// remplir dataset document stagiaire
                    Datasetfiller("select top 10 * from Documents_Stagiaire ORDER BY ID_Doc_Stagiaire DESC", "Document_Stagiaire", dsDoc);
                    Datasetfiller("DocStag", "DocStag", dsDoc);
                    Manager.Fill_DataGridView(dataGridViewDocStag, dsDoc.Tables["DocStag"]);
                    panelGestion.Height = 0;
                    EnabledCheck(true);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Edit Doc Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Ereurs listes :\n-Ce stagiaire n'existe pas ou bien il ne pas affecté a un groupe\n-Ce Documents n'existe pas\n-Tu dois remplir tous les champs", "Edit Doc Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
        #region ConvertToImage
        private XImage ConvertToXimage(byte[] v)
        {
            MemoryStream stream = new MemoryStream(v);
            return XImage.FromStream(stream);
        }
        private Image ConvertToImage(byte[] v)
        {
            MemoryStream stream = new MemoryStream(v);
            return Image.FromStream(stream);
        }
        #endregion
        // dataGridViewDocStag
        #region dataGridViewDocStag
        private void dataGridViewDocStag_SelectionChanged(object sender, EventArgs e)
        {
            FillTextBox();
            int index;
            try
            {
                if(dsDoc.Tables["Document_Stagiaire"] != null && dataGridViewDocStag.SelectedRows.Count > 0)
                {
                    index = dataGridViewDocStag.SelectedCells[0].OwningRow.Index;
                   DocumentViewer.Image = ConvertToImage((byte[])dsDoc.Tables["Document_Stagiaire"].Rows[index]["Document_Stagiaire"]);
                    DocumentViewer.SizeMode = PictureBoxSizeMode.Zoom;
                    p = index;
                    LblCount.Text = p + 1 + "/" + dsDoc.Tables["Document_Stagiaire"].Rows.Count;
                }
            }
            catch { }
        }
        #endregion
        // method to fill the dataset
        #region  Datasetfiller
        private void Datasetfiller(string query,string tableau,DataSet dataSet)
        {
            Manager.Open_Connection();
            Manager.Query(query);
            Manager.Fill_DataSet(dataSet, tableau);
            Manager.Close_Connection();
        }
        private void Datasetfiller(string query,string parm,string parm2, string tableau, DataSet dataSet)
        {
            Manager.Open_Connection();
            Manager.Query(query);
            Manager.Command.CommandType = CommandType.StoredProcedure;
            Manager.Command.Parameters.AddWithValue("@CIN", parm);
            Manager.Command.Parameters.AddWithValue("@CNE", parm2);
            Manager.Fill_DataSet(dataSet, tableau);
            Manager.Close_Connection();
        }
        #endregion
        // buttonDelete to delete document stagiaire
        #region BTNDelete
        private void BTNDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewDocStag.Rows.Count > 0)
            {
                int position_Doc_Stag = Manager.SearchForExistence(dsDoc.Tables["Document_Stagiaire"], dataGridViewDocStag.CurrentRow.Cells[0].Value.ToString(), "ID_Doc_Stagiaire");
                if (position_Doc_Stag != -1)
                {
                    try
                    {
                        DialogResult dialog = MessageBox.Show("Voulez-vous supprimer cette document ?", "Supprimer confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialog == DialogResult.Yes)
                        {
                            Manager.Query("delete from Documents_Stagiaire where ID_Doc_Stagiaire = @id");
                            Manager.Command.Parameters.AddWithValue("@id", dataGridViewDocStag.CurrentRow.Cells[0].Value);
                            Manager.Open_Connection();
                            Manager.ExecuteQuery();
                            Manager.Close_Connection();
                            MessageBox.Show("Supprimé avec succés", "Supprimer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (dsDoc.Tables["Document_Stagiaire"] != null && dsDoc.Tables["DocStag"] != null)
                            {
                                dsDoc.Tables["Document_Stagiaire"].Rows.Clear();
                                dsDoc.Tables["DocStag"].Rows.Clear();
                            }
                            //// remplir dataset document stagiaire
                            Datasetfiller("select top 10 * from Documents_Stagiaire ORDER BY ID_Doc_Stagiaire DESC", "Document_Stagiaire", dsDoc);
                            Datasetfiller("DocStag", "DocStag", dsDoc);
                            Manager.Fill_DataGridView(dataGridViewDocStag, dsDoc.Tables["DocStag"]);
                            panelGestion.Height = 0;
                            if (dataGridViewDocStag.Rows.Count == 0)
                            {
                                DocumentViewer.ImageLocation = "Icons/AddImage.png";
                                DocumentViewer.SizeMode = PictureBoxSizeMode.CenterImage;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Delete Doc Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        #endregion
        // BTNAddlist to add an item to the list of items choosen and btnexport jpg and pdf
        #region BTNManager
        private void BTNAddlist_Click(object sender, EventArgs e)
        {
            if(dataGridViewDocStag.Rows.Count > 0) { 
            try
            {
            int po = Rechecher(dataGridViewDocStag.CurrentRow.Cells[0].Value.ToString());
        if(po == -1)
            {
                listdoc.Add((int)dataGridViewDocStag.CurrentRow.Cells[0].Value);
                for (int i = 0; i < dsDoc.Tables["Document_Stagiaire"].Rows.Count; i++)
                {
                    if (listdoc[listdoc.Count - 1].ToString() == dsDoc.Tables["Document_Stagiaire"].Rows[i]["ID_Doc_Stagiaire"].ToString())
                    {
                        dataGridViewListDoc.Rows.Add(dsDoc.Tables["Document_Stagiaire"].Rows[i]["ID_Doc_Stagiaire"].ToString(), dsDoc.Tables["Document_Stagiaire"].Rows[i]["Nom_Doc_Type"].ToString());
                         listImages.Add(ConvertToImage((byte[])dsDoc.Tables["Document_Stagiaire"].Rows[i]["Document_Stagiaire"]));

                        }
                    }
            }
            }
            catch { }
            }
        }

        private void BTNExport_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewDocStag.Rows.Count > 0)
                {
                    int po = dataGridViewDocStag.CurrentCell.RowIndex;
                    Image image = ConvertToImage((byte[])dsDoc.Tables["Document_Stagiaire"].Rows[po]["Document_Stagiaire"]);
                    if (saveJPG.ShowDialog() == DialogResult.OK)
                    {
                        image.Save(saveJPG.FileName);
                    }
                }
            }
            catch { }
           
        }

        private void BTNPDF_Click(object sender, EventArgs e)
        {
            if (dataGridViewDocStag.Rows.Count > 0)
            {
                PdfDocument document = new PdfDocument();
                document.Info.Title = "New Document";
                try
                {
                    int index = dataGridViewDocStag.CurrentCell.RowIndex;
                    PdfPage page = document.AddPage();
                    XGraphics graphics = XGraphics.FromPdfPage(page);
                    XImage image = ConvertToXimage((byte[])dsDoc.Tables["Document_Stagiaire"].Rows[index]["Document_Stagiaire"]);
                    graphics.DrawImage(image, 0, 0, page.Width, page.Height);

                    if (document.PageCount > 0)
                    {
                        if (saveExportPDF.ShowDialog() == DialogResult.OK)
                        {
                            document.Save(saveExportPDF.FileName);
                        }
                    }
                }
                catch { }
            }
        }

        #endregion
        //BTN LISTE
        #region Listprint
        private void btnViderListe_Click(object sender, EventArgs e)
        {
            if (listdoc.Count > 0)
            {
                listdoc.Clear();
                listImages.Clear();
                dataGridViewListDoc.Rows.Clear();
            }

        }

        private void btnSupprimerListe_Click(object sender, EventArgs e)
        {
            try
            {
                int po = Rechecher(dataGridViewListDoc.CurrentRow.Cells[0].Value.ToString());
                if (po != -1)
                {
                    listdoc.RemoveAt(po);
                    listImages.RemoveAt(po);
                    dataGridViewListDoc.Rows.Clear();
                    for (int i = 0; i < dsDoc.Tables["Document_Stagiaire"].Rows.Count; i++)
                    {
                        for (int j = 0; j < listdoc.Count; j++)
                        {
                            if (listdoc[j].ToString() == dsDoc.Tables["Document_Stagiaire"].Rows[i]["ID_Doc_Stagiaire"].ToString())
                            {
                                dataGridViewListDoc.Rows.Add(dsDoc.Tables["Document_Stagiaire"].Rows[i]["ID_Doc_Stagiaire"].ToString(), dsDoc.Tables["Document_Stagiaire"].Rows[i]["Nom_Doc_Type"].ToString());
                            }

                        }
                    }
                }
            }
            catch { }
            
        }

        private int Rechecher(string value)
        {
            if (listdoc.Count > 0)
            {
                for (int j = 0; j < listdoc.Count; j++)
                {
                    if (value == listdoc[j].ToString())
                    {
                        return j;
                    }
                }
            }
            return -1;
        }

        private void btnExporterListe_Click(object sender, EventArgs e)
        {
            if (listdoc.Count > 0)
            {
                PdfDocument document = new PdfDocument();
                document.Info.Title = "New Document";
                try
                {
                    for (int j = 0; j < dsDoc.Tables["Document_Stagiaire"].Rows.Count; j++)
                    {
                        for (int i = 0; i < listdoc.Count; i++)
                        {
                            if (dsDoc.Tables["Document_Stagiaire"].Rows[j]["ID_Doc_Stagiaire"].ToString() == listdoc[i].ToString())
                            {
                                PdfPage page = document.AddPage();
                                XGraphics graphics = XGraphics.FromPdfPage(page);
                                XImage image = ConvertToXimage((byte[])dsDoc.Tables["Document_Stagiaire"].Rows[j]["Document_Stagiaire"]);
                                graphics.DrawImage(image, 0, 0, page.Width, page.Height);
                            }
                        }
                    }
                    if (document.PageCount > 0)
                    {
                        if (saveExportPDF.ShowDialog() == DialogResult.OK)
                        {
                            document.Save(saveExportPDF.FileName);
                        }
                    }
                }
                catch { }
            }
        }

        private void BTNPrint_Click(object sender, EventArgs e)
        {
            if (dataGridViewDocStag.Rows.Count > 0)
            {
                printDialog1.Document = printDocument1;
                if (printDialog1.ShowDialog() == DialogResult.OK) printDocument1.Print();
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int index = dataGridViewDocStag.CurrentCell.RowIndex;

            Image image = ConvertToImage((byte[])dsDoc.Tables["Document_Stagiaire"].Rows[index]["Document_Stagiaire"]);
           if(image.Width > e.PageBounds.Width && image.Width > image.Height)
            {
                image.RotateFlip(RotateFlipType.Rotate270FlipXY);
            }
            e.Graphics.DrawImage(image,0 ,0, e.PageBounds.Width, e.PageBounds.Height);
        }

        private void btnImprimerList_Click(object sender, EventArgs e)
        {
            if(listImages.Count > 0)
            {
             printDialog1.Document = printDocument2;
            coun = 0;
                if (printDialog1.ShowDialog() == DialogResult.OK) printDocument2.Print();
               
            }
        
        }

        private void printDocument2_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
             Image image = listImages[coun];
            if (image.Width > e.PageBounds.Width && image.Width > image.Height)
            {
                image.RotateFlip(RotateFlipType.Rotate270FlipXY);
            }
            e.Graphics.DrawImage(image, 0, 0, e.PageBounds.Width, e.PageBounds.Height);
            ++coun;

                if (coun < listImages.Count)
                {
                    e.HasMorePages = true;
                }
                else
                {
                    e.HasMorePages = false;
                }
        }

        private void BTNSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (TXTSearch.Text != "  Recherche avec CIN ou CNE de stagiaire")
                {
                if (dsDoc.Tables["Document_Stagiaire"] != null && dsDoc.Tables["DocStag"] != null )
                {
                        dsDoc.Tables["Document_Stagiaire"].Rows.Clear();
                        dsDoc.Tables["DocStag"].Rows.Clear();
                }
                    Datasetfiller("select DS.* from Documents_Stagiaire as DS inner join Stagiaire as S on DS.CIN = S.CIN where S.CIN like '" + TXTSearch.Text + "' or S.CNE ='" + TXTSearch.Text + "'", "Document_Stagiaire", dsDoc);
                    Datasetfiller("DocStagSearch", TXTSearch.Text, TXTSearch.Text, "DocStag", dsDoc);
                    Manager.Fill_DataGridView(dataGridViewDocStag, dsDoc.Tables["DocStag"]);
                    if (dataGridViewDocStag.Rows.Count == 0)
                    {
                        LblCount.Text = "0/0";
                    }
                }
                else
                {
                    if (dsDoc.Tables["Document_Stagiaire"] != null && dsDoc.Tables["DocStag"] != null)
                    {
                        dsDoc.Tables["Document_Stagiaire"].Rows.Clear();
                        dsDoc.Tables["DocStag"].Rows.Clear();
                    }
                    //// remplir dataset document stagiaire
                    Datasetfiller("DocStag", "DocStag", dsDoc);
                    Datasetfiller("select top 10 * from Documents_Stagiaire ORDER BY ID_Doc_Stagiaire DESC", "Document_Stagiaire", dsDoc);
                    Manager.Fill_DataGridView(dataGridViewDocStag, dsDoc.Tables["DocStag"]);
                    // update lblcount
                        LblCount.Text = p + 1 + "/" + dataGridViewDocStag.Rows.Count;
                }
                    
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            if (dataGridViewDocStag.Rows.Count == 0)
            {
                DocumentViewer.ImageLocation = "Icons/AddImage.png";
                DocumentViewer.SizeMode = PictureBoxSizeMode.CenterImage;
            }
        }

        private void BTNFirst_Click(object sender, EventArgs e)
        {
            if (dataGridViewDocStag.Rows.Count > 0)
            {
                p = 0;
                design.First(dataGridViewDocStag, p, LblCount);
            }
        }

        private void BTNPrevious_Click(object sender, EventArgs e)
        {
            if (dataGridViewDocStag.Rows.Count > 0)
            {
                p = dataGridViewDocStag.SelectedCells[0].OwningRow.Index;
                p--;
                design.Previous(dataGridViewDocStag, p, LblCount);
            }
        }

        private void BTNNext_Click(object sender, EventArgs e)
        {
            if (dataGridViewDocStag.Rows.Count > 0)
            {
                p = dataGridViewDocStag.SelectedCells[0].OwningRow.Index;
                p++;
                design.Next(dataGridViewDocStag, p, LblCount);
            }
        }

        private void BTNLast_Click(object sender, EventArgs e)
        {
            if (dataGridViewDocStag.Rows.Count > 0)
            {
                p = dataGridViewDocStag.Rows.Count - 1;
                design.Last(dataGridViewDocStag, p, LblCount);
            }
        }

        private void BTNScan_Click(object sender, EventArgs e)
        {
            try
            {
                var devices = new DeviceManager();
                DeviceInfo device = null;
                for (int i = 0; i < devices.DeviceInfos.Count; i++)
                {
                    if (devices.DeviceInfos[i].Type != WiaDeviceType.ScannerDeviceType)
                    {
                        continue;
                    }
                    device = devices.DeviceInfos[i];
                    break;
                }
                if(device != null){
                    var deviceConnect = device.Connect();
                    var SelectScan = deviceConnect.Items[1];
                    var image = (ImageFile)SelectScan.Transfer(FormatID.wiaFormatJPEG);
                    if (File.Exists("Scan.jpg"))
                    {
                        File.Delete("Scan.jpg");
                    }
                    image.SaveFile("Scan.jpg");
                    picDoc.ImageLocation = "Scan.jpg";
                }
            }
            catch (COMException){ }
        }



        #endregion
        // RemplirDGV method
        #region RemplirDGV
        private void RemplirDGV(DataGridView DGV, string query, DataSet dataset, string table)
        {
            Manager.Open_Connection();
            Manager.Query(query);
            Manager.Fill_DataSet(dataset, table);
            Manager.Fill_DataGridView(DGV, dataset.Tables[table]);
            Manager.Close_Connection();
        }
        #endregion
        // method FillTextBox to fill textbox in gestion panel while modification
        #region FillTextBox
        private void FillTextBox()
        {
                try
            {
                int index = dataGridViewDocStag.SelectedCells[0].OwningRow.Index;
                txtID.Text = dsDoc.Tables["Document_Stagiaire"].Rows[index]["ID_Doc_Stagiaire"].ToString();
                txtCIN.Text = dsDoc.Tables["Document_Stagiaire"].Rows[index]["CIN"].ToString();
                comboType.SelectedValue = dsDoc.Tables["Document_Stagiaire"].Rows[index]["Nom_Doc_Type"];
               picDoc.Image = ConvertToImage((byte[])dsDoc.Tables["Document_Stagiaire"].Rows[index]["Document_Stagiaire"]);
                picDoc.SizeMode = PictureBoxSizeMode.Zoom;
            }
            catch { }
        }
        #endregion
    }
}