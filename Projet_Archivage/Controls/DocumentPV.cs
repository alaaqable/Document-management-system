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
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System.Runtime.InteropServices;
using WIA;

namespace Projet_Archivage
{
    public partial class DocumentPV : UserControl
    {
        Design design = new Design();
        DBManager Manager = new DBManager();
        DataSet dsPV, dsType, dsSession, dsGroupe, dsFiliere;
        List<int> listdoc = new List<int>();
        List<Image> listImages = new List<Image>();
        int coun = 0;
        int p = 0;
        public DocumentPV()
        {
            InitializeComponent();
        }

        private void DocumentPV_Load(object sender, EventArgs e)
        {
            dsType = new DataSet();
            dsSession = new DataSet();
            dsPV = new DataSet();
            dsGroupe = new DataSet();
            dsFiliere = new DataSet();
            if (Manager.Statue() == false) { 
                // remplir combobox et dataset et datagridview type document stagiaire 
                Datasetfiller("select * from Type_Documents_PV", "TypePV", dsType);
            Manager.Fill_Combobox(comboType, dsType.Tables["TypePV"], "Nom_Type_PV", "Nom_Type_PV");
            // remplir dataset et combosession
            Datasetfiller("select * from Annee_Etude", "Session", dsSession);
            Manager.Fill_Combobox(ComboSession, dsSession.Tables["Session"], "Session_Etude","ID_Annee");

            // remplir dataset et combosessionGESTION
            Manager.Fill_Combobox(comboSessionGestion, dsSession.Tables["Session"], "Session_Etude", "ID_Annee");

            // remplir dataset and combofiliere
            Datasetfiller("select * from Filiere", "Filiere", dsFiliere);
            Manager.Fill_Combobox(comboFiliere, dsFiliere.Tables["Filiere"], "Nom_Filiere", "ID_Filiere");

            // remplir dataset and datagridviewpv
            Datasetfiller("SELECT TOP 10 * FROM Documents_PV ORDER BY ID_PV DESC", "Documents_PV", dsPV);
            Datasetfiller("DocPV", "DocPV", dsPV);
            Manager.Fill_DataGridView(dataGridViewDocPV, dsPV.Tables["DocPV"]);


            // remplir dataset and comboGroupe 
            Datasetfiller("select * from Groupe ", "GroupeGestion", dsGroupe);
            Manager.Fill_Combobox(comboGroupeGestion, dsGroupe.Tables["GroupeGestion"], "Nom_Groupe", "ID_Groupe");

            if (dataGridViewDocPV.Rows.Count == 0)
            {
                DocumentViewer.ImageLocation = "Icons/AddImage.png";
            }
            if (dataGridViewDocPV.Rows.Count > 0)
            {
                LblCount.Text = p + 1 + "/" + dataGridViewDocPV.Rows.Count;
            }
            }

        }
        //Navigation
        #region BTNFirst Hover
        private void BTNFirst_MouseDown(object sender, MouseEventArgs e)
        {
            design.BTNUPDown(BTNFirst, Image.FromFile("Icons/First1.png"));
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

        private void BTNCloseList_Click(object sender, EventArgs e)
        {
            panelList.Height = 0;
            EnabledCheck(true);
        }
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
            dataGridViewDocPV.Enabled = check;
            BTNFirst.Enabled = check;
            BTNPrevious.Enabled = check;
            DisplayList.Enabled = check;
        }
        private void BTNImport_Click(object sender, EventArgs e)
        {
            
                txtID.Clear();
                picDoc.ImageLocation = "Icons/AddImage.png";
                picDoc.SizeMode = PictureBoxSizeMode.CenterImage;
                
            panelGestion.Height = 376;
            lblTitle.Text = "Ajouté un document";
            btnAjouter.BringToFront();
            EnabledCheck(false);
        }

        private void BTNCloseAddEdit_Click(object sender, EventArgs e)
        {
            panelGestion.Height = 0;
            EnabledCheck(true);
        }

        private void BTNEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewDocPV.Rows.Count > 0)
            {
                panelGestion.Height = 376;
                lblTitle.Text = "Modifié un document";
                btnModifier.BringToFront();
                FillTextBox();
                EnabledCheck(false);
            }
        }
        #region FillTextBox
        private void FillTextBox()
        {
            try
            {
                int index = dataGridViewDocPV.SelectedCells[0].OwningRow.Index;
                txtID.Text = dsPV.Tables["Documents_PV"].Rows[index]["ID_PV"].ToString();
                comboSessionGestion.SelectedValue = dsPV.Tables["Documents_PV"].Rows[index]["ID_Annee"];
                comboGroupeGestion.SelectedValue = dsPV.Tables["Documents_PV"].Rows[index]["ID_Groupe"];
                comboType.SelectedValue = dsPV.Tables["Documents_PV"].Rows[index]["Nom_Type_PV"];
                picDoc.Image = ConvertToImage((byte[])dsPV.Tables["Documents_PV"].Rows[index]["Document_PV"]);
                picDoc.SizeMode = PictureBoxSizeMode.Zoom;
            }
            catch { }
        }
        #endregion
        #region ConvertToImage
        private XImage ConvertToXimage(byte[] v)
        {
            MemoryStream stream = new MemoryStream(v);
            return XImage.FromStream(stream);
        }

        private void comboFiliere_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
            if (dsGroupe.Tables["Groupe"] != null) dsGroupe.Tables["Groupe"].Rows.Clear();
            // remplir dataset and comboGroupe 
            Datasetfiller("select * from Groupe where ID_Filiere = " + comboFiliere.SelectedValue, "Groupe", dsGroupe);
            Manager.Fill_Combobox(comboGroupe, dsGroupe.Tables["Groupe"], "Nom_Groupe", "ID_Groupe");
            }
            catch { }

        }

        private Image ConvertToImage(byte[] v)
        {
            MemoryStream stream = new MemoryStream(v);
            return Image.FromStream(stream);
        }

        private void BTNSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if(dsPV.Tables["Documents_PV"] != null && dsPV.Tables["DocPV"] != null)
                {
                    dsPV.Tables["Documents_PV"].Rows.Clear();
                    dsPV.Tables["DocPV"].Rows.Clear();
                }
            Datasetfiller("select * from Documents_PV where ID_Annee =" + ComboSession.SelectedValue + " and ID_Groupe=" + comboGroupe.SelectedValue , "Documents_PV", dsPV);
                Manager.Open_Connection();
                Manager.Query("DocPVSearch");
            Manager.Command.CommandType = CommandType.StoredProcedure;
            Manager.Command.Parameters.AddWithValue("@Annee",ComboSession.SelectedValue);
            Manager.Command.Parameters.AddWithValue("@Groupe", comboGroupe.SelectedValue);
            Manager.Fill_DataSet(dsPV, "DocPV");
            Manager.Fill_DataGridView(dataGridViewDocPV, dsPV.Tables["DocPV"]);
                Manager.Close_Connection();
                if (dataGridViewDocPV.Rows.Count == 0)
                {
                    DocumentViewer.ImageLocation = "Icons/AddImage.png";
                    DocumentViewer.SizeMode = PictureBoxSizeMode.CenterImage;
                }
                if (dataGridViewDocPV.Rows.Count == 0)
                {
                    LblCount.Text = "0/0";
                }
            }
            catch { }

        }

        private void BTNDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewDocPV.Rows.Count > 0)
            {
                int position_Doc_PV = Manager.SearchForExistence(dsPV.Tables["Documents_PV"], dataGridViewDocPV.CurrentRow.Cells[0].Value.ToString(), "ID_PV");
            if (position_Doc_PV != -1)
            {
                try
                {
                    DialogResult dialog = MessageBox.Show("Voulez-vous supprimer cette document ?", "Supprimer confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialog == DialogResult.Yes)
                    {
                        Manager.Query("delete from Documents_PV where ID_PV = @id");
                        Manager.Command.Parameters.AddWithValue("@id", dataGridViewDocPV.CurrentRow.Cells[0].Value);
                        Manager.Open_Connection();
                        Manager.ExecuteQuery();
                        Manager.Close_Connection();
                        MessageBox.Show("Supprimé avec succés", "Supprimer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (dsPV.Tables["Documents_PV"].Rows.Count > 0)
                        {
                            dsPV.Tables["Documents_PV"].Rows.Clear();
                            dsPV.Tables["DocPV"].Rows.Clear();
                        }
                        Datasetfiller("SELECT TOP 10 * FROM Documents_PV ORDER BY ID_PV DESC", "Documents_PV", dsPV);
                        Datasetfiller("DocPV", "DocPV", dsPV);
                        Manager.Fill_DataGridView(dataGridViewDocPV, dsPV.Tables["DocPV"]);
                        if (dataGridViewDocPV.Rows.Count == 0)
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

        private void BTNExport_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewDocPV.Rows.Count > 0)
                {
                    int po = dataGridViewDocPV.CurrentCell.RowIndex;
                    Image image = ConvertToImage((byte[])dsPV.Tables["Documents_PV"].Rows[po]["Document_PV"]);
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
            if(dataGridViewDocPV.Rows.Count > 0) { 
                PdfDocument document = new PdfDocument();
                document.Info.Title = "New Document";
                try
                {
               
                    int index = dataGridViewDocPV.CurrentCell.RowIndex;
                    PdfPage page = document.AddPage();
                    XGraphics graphics = XGraphics.FromPdfPage(page);
                    XImage image = ConvertToXimage((byte[])dsPV.Tables["Documents_PV"].Rows[index]["Document_PV"]);
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

        private void BTNPrint_Click(object sender, EventArgs e)
        {
            if (dataGridViewDocPV.Rows.Count > 0)
            {
                printDialog1.Document = printDocument1;
                if (printDialog1.ShowDialog() == DialogResult.OK) printDocument1.Print();
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int index = dataGridViewDocPV.CurrentCell.RowIndex;

            Image image = ConvertToImage((byte[])dsPV.Tables["Documents_PV"].Rows[index]["Document_PV"]);
            if (image.Width > e.PageBounds.Width && image.Width > image.Height)
            {
                image.RotateFlip(RotateFlipType.Rotate270FlipXY);
            }
            e.Graphics.DrawImage(image, 0, 0, e.PageBounds.Width, e.PageBounds.Height);
        }

        private void BTNAddlist_Click(object sender, EventArgs e)
        {
            if(dataGridViewDocPV.Rows.Count > 0) {
            try
            {
                int po = Rechecher(dataGridViewDocPV.CurrentRow.Cells[0].Value.ToString());
                if (po == -1)
                {
                    listdoc.Add((int)dataGridViewDocPV.CurrentRow.Cells[0].Value);
                    for (int i = 0; i < dsPV.Tables["Documents_PV"].Rows.Count; i++)
                    {
                        if (listdoc[listdoc.Count - 1].ToString() == dsPV.Tables["Documents_PV"].Rows[i]["ID_PV"].ToString())
                        {
                            dataGridViewListDoc.Rows.Add(dsPV.Tables["Documents_PV"].Rows[i]["ID_PV"].ToString(), dsPV.Tables["Documents_PV"].Rows[i]["Nom_Type_PV"].ToString());
                            listImages.Add(ConvertToImage((byte[])dsPV.Tables["Documents_PV"].Rows[i]["Document_PV"]));

                        }
                    }
                }
            }
            catch { }
            }
        }
        #endregion
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
                    for (int i = 0; i < dsPV.Tables["Documents_PV"].Rows.Count; i++)
                    {
                        for (int j = 0; j < listdoc.Count; j++)
                        {
                            if (listdoc[j].ToString() == dsPV.Tables["Documents_PV"].Rows[i]["ID_PV"].ToString())
                            {
                                dataGridViewListDoc.Rows.Add(dsPV.Tables["Documents_PV"].Rows[i]["ID_PV"].ToString(), dsPV.Tables["Documents_PV"].Rows[i]["Nom_Type_PV"].ToString());
                            }

                        }
                    }
                }
            }
            catch { }
        }

        private void btnViderListe_Click(object sender, EventArgs e)
        {
            if (listdoc.Count > 0)
            {
                listdoc.Clear();
                listImages.Clear();
                dataGridViewListDoc.Rows.Clear();
            }
        }

        private void btnImprimerList_Click(object sender, EventArgs e)
        {
            if (listImages.Count > 0)
            {
                printDialog1.Document = printDocument2;
                coun = 0;
                if (printDialog1.ShowDialog() == DialogResult.OK) printDocument2.Print();

            }
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            int position_pv = Manager.SearchForExistence(dsPV.Tables["Documents_PV"], comboSessionGestion.SelectedValue.ToString(), comboGroupeGestion.SelectedValue.ToString(), comboType.SelectedValue.ToString(), "ID_Annee", "ID_Groupe", "Nom_Type_PV");

            if (position_pv == -1)
            {
                try
                {
                    Manager.Query("update Documents_PV set Nom_Type_PV = @Nom,Document_PV = @Doc,ID_Groupe = @Groupe,ID_Annee = @Session where ID_PV = @id");
                    Manager.Command.Parameters.AddWithValue("@Nom", comboType.SelectedValue);
                    Manager.Command.Parameters.AddWithValue("@Doc", ConvertToByte(picDoc.Image));
                    Manager.Command.Parameters.AddWithValue("@Session", comboSessionGestion.SelectedValue);
                    Manager.Command.Parameters.AddWithValue("@Groupe", comboGroupeGestion.SelectedValue);
                    Manager.Command.Parameters.AddWithValue("@id", txtID.Text);
                    Manager.Open_Connection();
                    Manager.ExecuteQuery();
                    Manager.Close_Connection();
                    MessageBox.Show("Modifié avec succés", "Modifier", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (dsPV.Tables["Documents_PV"].Rows.Count > 0)
                    {
                        dsPV.Tables["Documents_PV"].Rows.Clear();
                        dsPV.Tables["DocPV"].Rows.Clear();
                    }
                    Manager.Open_Connection();
                    Datasetfiller("SELECT TOP 10 * FROM Documents_PV ORDER BY ID_PV DESC", "Documents_PV", dsPV);
                    Datasetfiller("DocPV", "DocPV", dsPV);
                    Manager.Fill_DataGridView(dataGridViewDocPV, dsPV.Tables["DocPV"]);
                    Manager.Close_Connection();
                    panelGestion.Height = 0;
                    EnabledCheck(true);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Edit Doc Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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

        private void btnExporterListe_Click(object sender, EventArgs e)
        {
            if (listdoc.Count > 0)
            {
                PdfDocument document = new PdfDocument();
                document.Info.Title = "New Document";
                try
                {
                    for (int j = 0; j < dsPV.Tables["Documents_PV"].Rows.Count; j++)
                    {
                        for (int i = 0; i < listdoc.Count; i++)
                        {
                            if (dsPV.Tables["Documents_PV"].Rows[j]["ID_PV"].ToString() == listdoc[i].ToString())
                            {
                                PdfPage page = document.AddPage();
                                XGraphics graphics = XGraphics.FromPdfPage(page);
                                XImage image = ConvertToXimage((byte[])dsPV.Tables["Documents_PV"].Rows[j]["Document_PV"]);
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

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            int position_pv = Manager.SearchForExistence(dsPV.Tables["Documents_PV"], comboSessionGestion.SelectedValue.ToString(), comboGroupeGestion.SelectedValue.ToString(),comboType.SelectedValue.ToString(), "ID_Annee", "ID_Groupe", "Nom_Type_PV");

            if (position_pv == -1)
            {
                try
                {
                    Manager.Query("insert into Documents_PV values(@Nom,@Doc,null,@Groupe,@Session)");
                    Manager.Command.Parameters.AddWithValue("@Nom", comboType.SelectedValue);
                    Manager.Command.Parameters.AddWithValue("@Doc", ConvertToByte(picDoc.Image));
                    Manager.Command.Parameters.AddWithValue("@Groupe", comboGroupeGestion.SelectedValue);
                    Manager.Command.Parameters.AddWithValue("@Session", comboSessionGestion.SelectedValue);
                    Manager.Open_Connection();
                     Manager.ExecuteQuery();
                    Manager.Close_Connection();
                    MessageBox.Show("Ajouté avec succés", "Ajouter", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (dsPV.Tables["Documents_PV"].Rows.Count > 0)
                    {
                        dsPV.Tables["Documents_PV"].Rows.Clear();
                        dsPV.Tables["DocPV"].Rows.Clear();
                    }
                    Manager.Open_Connection();
                    Datasetfiller("SELECT TOP 10 * FROM Documents_PV ORDER BY ID_PV DESC", "Documents_PV", dsPV);
                    Datasetfiller("DocPV", "DocPV", dsPV);
                    Manager.Fill_DataGridView(dataGridViewDocPV, dsPV.Tables["DocPV"]);
                    Manager.Close_Connection();
                    panelGestion.Height = 0;
                    EnabledCheck(true);
                    picDoc.ImageLocation = "Icons/AddImage.png";
                    picDoc.SizeMode = PictureBoxSizeMode.CenterImage;
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Add Doc Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dataGridViewDocPV_SelectionChanged(object sender, EventArgs e)
        {
            int index;
            FillTextBox();
            try
            {

                if (dsPV.Tables["Documents_PV"] != null && dataGridViewDocPV.SelectedRows.Count > 0)
                {
                   index = dataGridViewDocPV.SelectedCells[0].OwningRow.Index;
                    DocumentViewer.Image = ConvertToImage((byte[])dsPV.Tables["Documents_PV"].Rows[index]["Document_PV"]);
                    DocumentViewer.SizeMode = PictureBoxSizeMode.Zoom;
                    p = index;
                    LblCount.Text = p + 1 + "/" + dsPV.Tables["Documents_PV"].Rows.Count;
                }
        }
            catch { }
}

        private void BTNFirst_Click(object sender, EventArgs e)
        {
            if (dataGridViewDocPV.Rows.Count > 0)
            {
                p = 0;
                design.First(dataGridViewDocPV, p, LblCount);
            }
        }

        private void BTNPrevious_Click(object sender, EventArgs e)
        {
            if (dataGridViewDocPV.Rows.Count > 0)
            {
                p = dataGridViewDocPV.SelectedCells[0].OwningRow.Index;
                p--;
                design.Previous(dataGridViewDocPV, p, LblCount);
            }
        }

        private void BTNNext_Click(object sender, EventArgs e)
        {
            if (dataGridViewDocPV.Rows.Count > 0)
            {
                p = dataGridViewDocPV.SelectedCells[0].OwningRow.Index;
                p++;
                design.Next(dataGridViewDocPV, p, LblCount);
            }
        }

        private void BTNLast_Click(object sender, EventArgs e)
        {
            if (dataGridViewDocPV.Rows.Count > 0)
            {
                p = dataGridViewDocPV.Rows.Count - 1;
                design.Last(dataGridViewDocPV, p, LblCount);
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
                if (device != null)
                {
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
            catch (COMException) { }
        }

        #region ConvertToByte method
        private byte[] ConvertToByte(Image image)
        {
            MemoryStream stream = new MemoryStream();
            image.Save(stream, image.RawFormat);
            return stream.GetBuffer();
        }
        #endregion
        // method to fill the dataset
        #region  Datasetfiller
        private void Datasetfiller(string query, string tableau, DataSet dataSet)
        {
            Manager.Open_Connection();
            Manager.Query(query);
            Manager.Fill_DataSet(dataSet, tableau);
            Manager.Close_Connection();
        }
        private void Datasetfiller(string query, string parm, string tableau, DataSet dataSet)
        {
            Manager.Open_Connection();
            Manager.Query(query);
            Manager.Command.CommandType = CommandType.StoredProcedure;
            Manager.Command.Parameters.AddWithValue("@CIN", parm);
            Manager.Fill_DataSet(dataSet, tableau);
            Manager.Close_Connection();
        }
        #endregion
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
    }
}
