using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Projet_Archivage
{
    public partial class Centre_Gestion : UserControl
    {
        Design design = new Design();
        DBManager Manager = new DBManager();
        DataSet DsStagiaire, DsSession, DsGroupe, DsAffectation,dsFiliere, dsTypeDocStagiaire, dsTypeDocPV;
        int pStag = 0;
        int pAffe = 0;
        int pSess = 0;
        int pGr = 0;
        public Centre_Gestion()
        {
            InitializeComponent();
        }

        private void Centre_Gestion_Load(object sender, EventArgs e)
        {
            // DATASET
            DsStagiaire = new DataSet();
            DsAffectation = new DataSet();
            DsSession = new DataSet();
            DsGroupe = new DataSet();
            dsFiliere = new DataSet();
            dsTypeDocStagiaire = new DataSet();
            dsTypeDocPV = new DataSet();
            //
            comboGender.SelectedIndex = 0;
            if (Manager.Statue() == false)
            {
                //Remplir DGV de Stagiaire
                RemplirDGV(dataGridViewStagiaire, "select top 5 CIN, CNE, Nom, Prenom, Sexe, Date_Naissance as 'Date Naissance' from stagiaire ", DsStagiaire, "Stagiaire");
                try
                {
                    //ComboAnnee Filling
                    Manager.Open_Connection();
                    Manager.Query("select ID_Annee as 'ID',Session_Etude as 'Session' from Annee_Etude");
                    Manager.Fill_DataSet(DsSession, "SessionAffectation");
                    Manager.Fill_Combobox(comboSessionAffectation, DsSession.Tables["SessionAffectation"], "Session", "ID");

                    RemplirDGV(dataGridViewSession, "select top 10 ID_Annee as 'ID', Session_Etude as 'Session' from Annee_Etude order by ID_Annee DESC", DsSession, "Session");
                    //ComboGroupe Filling

                    Manager.Query("select * from Groupe");
                    Manager.Fill_DataSet(DsGroupe, "Groupe");
                    Manager.Fill_Combobox(comboGroupAffectation, DsGroupe.Tables["Groupe"], "Nom_Groupe", "ID_Groupe");

                    RemplirDGV(dataGridViewGroupe, "GroupeDGV", DsGroupe, "GroupeDGV");

                    //comboFiliere Filling
                    Manager.Query("select * from Filiere");
                    Manager.Fill_DataSet(dsFiliere, "FiliereCombo");
                    Manager.Fill_Combobox(comboFiliere, dsFiliere.Tables["FiliereCombo"], "Nom_Filiere", "ID_Filiere");

                    RemplirDGV(dataGridViewFiliere, "select ID_Filiere as 'ID',Nom_Filiere as 'Filière' from Filiere", dsFiliere, "Filiere");

                    //Filling the Dataset from the Table Stagiaire_Groupe_Session

                    Manager.Query("select top 10 * from Stagiaire_Groupe_Session");
                    Manager.Fill_DataSet(DsAffectation, "AffectationTest");
                    RemplirDGV(dataGridViewAffectation, "Affectation", DsAffectation, "Affectation");

                    //Type doc stagiaire DGV filling
                    RemplirDGV(DGVTypeDocStag, "select Nom_Doc_Type as 'Nom de Type' from Type_Documents_Stagiaire", dsTypeDocStagiaire, "TypeDocStag");

                    //Type doc PV DGV filling
                    RemplirDGV(DGVTypeDocPV, "select Nom_Type_PV as 'Nom de Type' from Type_Documents_PV", dsTypeDocPV, "TypeDocPV");

                    Manager.Close_Connection();
                    //LBL COUNT Stagiaire
                    if (dataGridViewStagiaire.Rows.Count > 0)
                    {
                        LblCountStagiaire.Text = pStag + 1 + "/" + dataGridViewStagiaire.Rows.Count;
                    }
                    //lbl count Affection
                    if (dataGridViewAffectation.Rows.Count > 0)
                    {
                        lblCountAffectation.Text = pStag + 1 + "/" + dataGridViewAffectation.Rows.Count;
                    }
                    //lbl count Session
                    if (dataGridViewSession.Rows.Count > 0)
                    {
                        LblCountSession.Text = pSess + 1 + "/" + dataGridViewSession.Rows.Count;
                    }
                    //lbl count Groupe
                    //lbl count Session
                    if (dataGridViewGroupe.Rows.Count > 0)
                    {
                        LblCountGroupe.Text = pGr + 1 + "/" + dataGridViewGroupe.Rows.Count;
                    }
                    Manager.Close_Connection();
                    //remplir automatiquement le textbox affectation
                    Manager.Query("Select * from Stagiaire");
                    Manager.Fill_DataSet(DsStagiaire,"StagiaireAuto");
                    AutoCompleteStringCollection auto = new AutoCompleteStringCollection();
                    for (int i = 0; i < DsStagiaire.Tables["StagiaireAuto"].Rows.Count; i++)
                    {
                        auto.Add(DsStagiaire.Tables["StagiaireAuto"].Rows[i][0].ToString());
                    }
                    txtCINAffectation.AutoCompleteMode = AutoCompleteMode.Suggest;
                    txtCINAffectation.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    txtCINAffectation.AutoCompleteCustomSource = auto;
                }
                catch{ }
            }
       }
        #region menuTop
        private void BTNStagiaire_Click(object sender, EventArgs e)
        {
            design.CenterGestionPanelChanger(panelMain, panelStagiaire);
            design.Clickchanger(BTNStagiaire, "Icons/Stagiaire1.png", BTNAnnee, "Icons/Session.png", BTNFiliere, "Icons/Filiere.png", BTNGroupe, "Icons/Groupe.png", BTNTypeStagiaire, "Icons/DocStag.png", BTNTypePV, "Icons/DocPV.png", btnAffectation, "Icons/Affecter1.png");
        }

        private void BTNAnnee_Click(object sender, EventArgs e)
        {
            design.CenterGestionPanelChanger(panelMain, panelSession);
            design.Clickchanger(BTNAnnee, "Icons/Session1.png", BTNFiliere, "Icons/Filiere.png", BTNStagiaire, "Icons/Stagiaire.png", BTNGroupe, "Icons/Groupe.png", BTNTypeStagiaire, "Icons/DocStag.png", BTNTypePV, "Icons/DocPV.png", btnAffectation, "Icons/Affecter1.png");
        }

        private void BTNFiliere_Click(object sender, EventArgs e)
        {
            design.CenterGestionPanelChanger(panelMain, panelFiliere);
            design.Clickchanger(BTNFiliere, "Icons/Filiere1.png", BTNStagiaire, "Icons/Stagiaire.png", BTNAnnee, "Icons/Session.png", BTNGroupe, "Icons/Groupe.png", BTNTypeStagiaire, "Icons/DocStag.png", BTNTypePV, "Icons/DocPV.png", btnAffectation, "Icons/Affecter1.png");
        }

        private void BTNGroupe_Click(object sender, EventArgs e)
        {
            try
            {
                //comboFiliere Filling
                Manager.Open_Connection();
                if (dsFiliere.Tables["FiliereCombo"].Rows.Count > 0) dsFiliere.Tables["FiliereCombo"].Rows.Clear();
                Manager.Query("select * from Filiere");
                Manager.Fill_DataSet(dsFiliere, "FiliereCombo");
                Manager.Fill_Combobox(comboFiliere, dsFiliere.Tables["FiliereCombo"], "Nom_Filiere", "ID_Filiere");
                Manager.Close_Connection();
            }
            catch { }
            design.CenterGestionPanelChanger(panelMain, panelGroupe);
            design.Clickchanger(BTNGroupe, "Icons/Groupe1.png", BTNStagiaire, "Icons/Stagiaire.png", BTNAnnee, "Icons/Session.png", BTNFiliere, "Icons/Filiere.png", BTNTypeStagiaire, "Icons/DocStag.png", BTNTypePV, "Icons/DocPV.png", btnAffectation, "Icons/Affecter1.png");
        }

        private void BTNTypeStagiaire_Click(object sender, EventArgs e)
        {
            design.CenterGestionPanelChanger(panelMain, panelTypeDocStagiaire);
            design.Clickchanger(BTNTypeStagiaire, "Icons/DocStag1.png", BTNStagiaire, "Icons/Stagiaire.png", BTNAnnee, "Icons/Session.png", BTNFiliere, "Icons/Filiere.png", BTNGroupe, "Icons/Groupe.png", BTNTypePV, "Icons/DocPV.png", btnAffectation, "Icons/Affecter1.png");
        }

        private void BTNTypePV_Click(object sender, EventArgs e)
        {
            design.CenterGestionPanelChanger(panelMain, panelTypeDocPV);
            design.Clickchanger(BTNTypePV, "Icons/DocPV1.png", BTNStagiaire, "Icons/Stagiaire.png", BTNAnnee, "Icons/Session.png", BTNFiliere, "Icons/Filiere.png", BTNGroupe, "Icons/Groupe.png", BTNTypeStagiaire, "Icons/DocStag.png", btnAffectation, "Icons/Affecter1.png");
        }

        private void BTNAffectation_Click(object sender, EventArgs e)
        {
            try
            {
                Manager.Open_Connection();
                //stagiaire DGV filling
                if (DsAffectation.Tables["Affectation"].Rows.Count > 0)
                {
                    DsAffectation.Tables["AffectationTest"].Rows.Clear();
                    DsAffectation.Tables["Affectation"].Rows.Clear();
                }

                Manager.Query("select top 10 * from Stagiaire_Groupe_Session");
                Manager.Fill_DataSet(DsAffectation, "AffectationTest");
                RemplirDGV(dataGridViewAffectation, "Affectation", DsAffectation, "Affectation");
                //session combo filling
                if (DsSession.Tables["SessionAffectation"].Rows.Count > 0) DsSession.Tables["SessionAffectation"].Rows.Clear();
                Manager.Query("select ID_Annee as 'ID',Session_Etude as 'Session' from Annee_Etude");
                Manager.Fill_DataSet(DsSession, "SessionAffectation");
                Manager.Fill_Combobox(comboSessionAffectation, DsSession.Tables["SessionAffectation"], "Session", "ID");
                //groupe combo filling
                //ComboGroupe Filling
                if (DsGroupe.Tables["Groupe"].Rows.Count > 0) DsGroupe.Tables["Groupe"].Rows.Clear();
                Manager.Query("select * from Groupe");
                Manager.Fill_DataSet(DsGroupe, "Groupe");
                Manager.Fill_Combobox(comboGroupAffectation, DsGroupe.Tables["Groupe"], "Nom_Groupe", "ID_Groupe");
                //remplir automatiquement le textbox affectation
                if (dsFiliere.Tables.Contains("StagiaireAuto"))
                {
                    dsFiliere.Tables["StagiaireAuto"].Clear();
                }
                Manager.Query("Select * from Stagiaire");
                Manager.Fill_DataSet(DsStagiaire, "StagiaireAuto");
                AutoCompleteStringCollection auto = new AutoCompleteStringCollection();
                for (int i = 0; i < DsStagiaire.Tables["StagiaireAuto"].Rows.Count; i++)
                {
                    auto.Add(DsStagiaire.Tables["StagiaireAuto"].Rows[i][0].ToString());
                }
                txtCINAffectation.AutoCompleteMode = AutoCompleteMode.Suggest;
                txtCINAffectation.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtCINAffectation.AutoCompleteCustomSource = auto;
                Manager.Close_Connection();
            }
            catch { }

            design.CenterGestionPanelChanger(panelMain, panelAffectation);
            design.Clickchanger(btnAffectation, "Icons/Affecter.png", BTNTypePV, "Icons/DocPV.png", BTNStagiaire, "Icons/Stagiaire.png", BTNAnnee, "Icons/Session.png", BTNFiliere, "Icons/Filiere.png", BTNGroupe, "Icons/Groupe.png", BTNTypeStagiaire, "Icons/DocStag.png");
        }

        #endregion
        #region searchTextbox
        private void TXTSearchStagiaire_Enter(object sender, EventArgs e)
        {
            design.TextBox_PlaceHolder(TXTSearchStagiaire, "  Recherche par CIN ou CNE");
        }

        private void TXTSearchStagiaire_Leave(object sender, EventArgs e)
        {
            design.TextBox_PlaceHolder(TXTSearchStagiaire, "  Recherche par CIN ou CNE");
        }
        #endregion
        #region searchTextbox
        private void TXTSearchAffectation_Enter(object sender, EventArgs e)
        {
            design.TextBox_PlaceHolder(TXTSearchAffectation, "  Recherche par CIN de Stagiaire");
        }

        private void TXTSearchAffectation_Leave(object sender, EventArgs e)
        {
            design.TextBox_PlaceHolder(TXTSearchAffectation, "  Recherche par CIN de Stagiaire");
        }
        #endregion
        #region searchTextbox
        private void TXTSearchSession_Enter(object sender, EventArgs e)
        {
            design.TextBox_PlaceHolder(TXTSearchSession, "  Recherche par Session");
        }

        private void TXTSearchSession_Leave(object sender, EventArgs e)
        {
            design.TextBox_PlaceHolder(TXTSearchSession, "  Recherche par Session");
        }
        #endregion
        #region searchTextbox
        private void TXTSearchGroupe_Enter(object sender, EventArgs e)
        {
            design.TextBox_PlaceHolder(TXTSearchGroupe, "  Recherche par Groupe");
        }

        private void TXTSearchGroupe_Leave(object sender, EventArgs e)
        {
            design.TextBox_PlaceHolder(TXTSearchGroupe, "  Recherche par Groupe");
        }
        #endregion
        //Stagiaire
        #region BTNFirstStagiaire Hover
        private void BTNFirstStagiaire_MouseDown(object sender, MouseEventArgs e)
        {
            design.BTNUPDown(BTNFirstStagiaire, Image.FromFile("Icons/First1.png"));
        }

        private void BTNFirstStagiaire_MouseUp(object sender, MouseEventArgs e)
        {
            design.BTNUPDown(BTNFirstStagiaire, Image.FromFile("Icons/First.png"));
        }
        #endregion
        #region BTNPreviousStagiaire Hover 
        private void BTNPreviousStagiaire_MouseDown(object sender, MouseEventArgs e)
        {
            design.BTNUPDown(BTNPreviousStagiaire, Image.FromFile("Icons/Previous1.png"));
        }

        private void BTNPreviousStagiaire_MouseUp(object sender, MouseEventArgs e)
        {
            design.BTNUPDown(BTNPreviousStagiaire, Image.FromFile("Icons/Previous.png"));
        }
        #endregion
        #region BTNNextStagiaire Hover
        private void BTNNextStagiaire_MouseDown(object sender, MouseEventArgs e)
        {
            design.BTNUPDown(BTNNextStagiaire, Image.FromFile("Icons/Next1.png"));
        }

        private void BTNNextStagiaire_MouseUp(object sender, MouseEventArgs e)
        {
            design.BTNUPDown(BTNNextStagiaire, Image.FromFile("Icons/Next.png"));
        }
        #endregion
        #region BTNLastStagiaire Hover
        private void BTNLastStagiaire_MouseDown(object sender, MouseEventArgs e)
        {
            design.BTNUPDown(BTNLastStagiaire, Image.FromFile("Icons/Last1.PNG"));
        }

        private void BTNLastStagiaire_MouseUp(object sender, MouseEventArgs e)
        {
            design.BTNUPDown(BTNLastStagiaire, Image.FromFile("Icons/Last.PNG"));
        }
        #endregion
        //Session
        #region btnFirstSession Hover
        private void btnFirstSession_MouseDown(object sender, MouseEventArgs e)
        {
            design.BTNUPDown(btnFirstSession, Image.FromFile("Icons/First1.png"));
        }

        private void btnFirstSession_MouseUp(object sender, MouseEventArgs e)
        {
            design.BTNUPDown(btnFirstSession, Image.FromFile("Icons/First.png"));
        }
        #endregion
        #region btnPreSession Hover
        private void btnPreSession_MouseDown(object sender, MouseEventArgs e)
        {
            design.BTNUPDown(btnPreSession, Image.FromFile("Icons/Previous1.png"));
        }

        private void btnPreSession_MouseUp(object sender, MouseEventArgs e)
        {
            design.BTNUPDown(btnPreSession, Image.FromFile("Icons/Previous.png"));
        }
        #endregion
        #region btnNextSession
        private void btnNextSession_MouseDown(object sender, MouseEventArgs e)
        {
            design.BTNUPDown(btnNextSession, Image.FromFile("Icons/Next1.png"));
        }

        private void btnNextSession_MouseUp(object sender, MouseEventArgs e)
        {
            design.BTNUPDown(btnNextSession, Image.FromFile("Icons/Next.png"));
        }
        #endregion
        #region btnLastSession Hover
        private void btnLastSession_MouseDown(object sender, MouseEventArgs e)
        {
            design.BTNUPDown(btnLastSession, Image.FromFile("Icons/Last1.PNG"));
        }

        private void btnLastSession_MouseUp(object sender, MouseEventArgs e)
        {
            design.BTNUPDown(btnLastSession, Image.FromFile("Icons/Last.PNG"));
        }
        #endregion
        //Groupe
        #region btnFirstGroupe Hover
        private void btnFirstGroupe_MouseDown(object sender, MouseEventArgs e)
        {
            design.BTNUPDown(btnFirstGroupe, Image.FromFile("Icons/First1.png"));
        }

        private void btnFirstGroupe_MouseUp(object sender, MouseEventArgs e)
        {
            design.BTNUPDown(btnFirstGroupe, Image.FromFile("Icons/First.png"));
        }
        #endregion
        #region btnPrevGroupe Hover
        private void btnPrevGroupe_MouseDown(object sender, MouseEventArgs e)
        {
            design.BTNUPDown(btnPrevGroupe, Image.FromFile("Icons/Previous1.png"));
        }

        private void btnPrevGroupe_MouseUp(object sender, MouseEventArgs e)
        {
            design.BTNUPDown(btnPrevGroupe, Image.FromFile("Icons/Previous.png"));
        }
        #endregion
        #region btnNextGroupe Hover
        private void btnNextGroupe_MouseDown(object sender, MouseEventArgs e)
        {
            design.BTNUPDown(btnNextGroupe, Image.FromFile("Icons/Next1.png"));
        }

        private void btnNextGroupe_MouseUp(object sender, MouseEventArgs e)
        {
            design.BTNUPDown(btnNextGroupe, Image.FromFile("Icons/Next.png"));
        }
        #endregion
        #region btnLastGroupe Hover
        private void btnLastGroupe_MouseDown(object sender, MouseEventArgs e)
        {
            design.BTNUPDown(btnLastGroupe, Image.FromFile("Icons/Last1.PNG"));
        }

        private void btnLastGroupe_MouseUp(object sender, MouseEventArgs e)
        {
            design.BTNUPDown(btnLastGroupe, Image.FromFile("Icons/Last" +
                ".PNG"));
        }
        #endregion
        //btnAffectation
        #region btnFirstAffectation
        private void btnFirstAffectation_MouseUp(object sender, MouseEventArgs e)
        {
            design.BTNUPDown(btnFirstAffectation, Image.FromFile("Icons/First.png"));
        }

        private void btnFirstAffectation_MouseDown(object sender, MouseEventArgs e)
        {
            design.BTNUPDown(btnFirstAffectation, Image.FromFile("Icons/First1.png"));
        }
        #endregion
        #region btnPrevAffectation
        private void btnPrevAffectation_MouseDown(object sender, MouseEventArgs e)
        {
            design.BTNUPDown(btnPrevAffectation, Image.FromFile("Icons/Previous1.png"));
        }

        private void btnPrevAffectation_MouseUp(object sender, MouseEventArgs e)
        {
            design.BTNUPDown(btnPrevAffectation, Image.FromFile("Icons/Previous.png"));
        }

        #endregion
        #region btnNextAffectation
        private void btnNextAffectation_MouseDown(object sender, MouseEventArgs e)
        {
            design.BTNUPDown(btnNextAffectation, Image.FromFile("Icons/Next1.png"));
        }

        private void btnNextAffectation_MouseUp(object sender, MouseEventArgs e)
        {
            design.BTNUPDown(btnNextAffectation, Image.FromFile("Icons/Next.png"));
        }

        #endregion
        #region btnLastAffectation
        private void btnLastAffectation_MouseDown(object sender, MouseEventArgs e)
        {
            design.BTNUPDown(btnLastAffectation, Image.FromFile("Icons/Last1.PNG"));
        }

        private void btnLastAffectation_MouseUp(object sender, MouseEventArgs e)
        {
            design.BTNUPDown(btnLastAffectation, Image.FromFile("Icons/Last.PNG"));
        }

        #endregion
        // Panel Affectation
        #region Affectation
        private void btnNewAffectation_Click(object sender, EventArgs e)
        {
            if (txtCINAffectation.Text != "")
            {
                txtCINAffectation.Clear();
            }
        }

        private void btnAddAffectation_Click(object sender, EventArgs e)
        {
            int position = Manager.SearchForExistence(DsAffectation.Tables["AffectationTest"], txtCINAffectation.Text.ToUpper(), comboSessionAffectation.SelectedValue.ToString(), "CIN", "ID_Annee");
            if (position == -1 && txtCINAffectation.Text.Trim() != "")
            {
                try
                {
                    if (Regex.IsMatch(TXTCIN.Text, "^[A-Za-z]{2}[0-9]{6}$"))
                    {
                        Manager.Query("insert into Stagiaire_Groupe_Session Values(@CIN,@IDGroupe,@Annee,null)");
                    Manager.Command.Parameters.AddWithValue("@CIN", txtCINAffectation.Text.ToUpper());
                    Manager.Command.Parameters.AddWithValue("@IDGroupe", comboGroupAffectation.SelectedValue);
                    Manager.Command.Parameters.AddWithValue("@Annee", comboSessionAffectation.SelectedValue);
                    Manager.Open_Connection();
                    Manager.ExecuteQuery();
                    Manager.Close_Connection();
                    MessageBox.Show("Ajouté avec succès", "Ajouter", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (DsAffectation.Tables["Affectation"].Rows.Count > 0)
                        {
                            DsAffectation.Tables["AffectationTest"].Rows.Clear();
                            DsAffectation.Tables["Affectation"].Rows.Clear();
                        }
                        Manager.Open_Connection();
                        Manager.Query("select top 10 * from Stagiaire_Groupe_Session");
                        Manager.Fill_DataSet(DsAffectation, "AffectationTest");
                        RemplirDGV(dataGridViewAffectation, "Affectation", DsAffectation, "Affectation");
                        Manager.Close_Connection();

                    }
                    else
                    {
                        MessageBox.Show("Tu dois saisir des information correcte \nEX: CIN : WA213364", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message, "Add affectation error", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            }

        }
        private void btnEditAffectation_Click(object sender, EventArgs e)
        {
            int position = Manager.SearchForExistence(DsAffectation.Tables["AffectationTest"], txtCINAffectation.Text.ToUpper(), comboSessionAffectation.SelectedValue.ToString(), "CIN", "ID_Annee");
            if (position != -1 && txtCINAffectation.Text.Trim() != "")
            {
                try
                {
                    if (Regex.IsMatch(TXTCIN.Text, "^[A-Za-z]{2}[0-9]{6}$"))
                    {
                        Manager.Query("update Stagiaire_Groupe_Session set  CIN = @CIN,ID_Groupe = @ID_Groupe,ID_Annee = @ID_Annee Where CIN=@CIN and ID_Annee = @ID_Annee");
                    Manager.Command.Parameters.AddWithValue("@CIN", txtCINAffectation.Text.ToUpper());
                    Manager.Command.Parameters.AddWithValue("@ID_Groupe", comboGroupAffectation.SelectedValue);
                    Manager.Command.Parameters.AddWithValue("@ID_Annee", comboSessionAffectation.SelectedValue);
                    Manager.Open_Connection();
                    Manager.ExecuteQuery();
                    Manager.Close_Connection();
                    MessageBox.Show("Modifié avec succès", "Modifier", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (DsAffectation.Tables["Affectation"].Rows.Count > 0)
                        {
                            DsAffectation.Tables["AffectationTest"].Rows.Clear();
                            DsAffectation.Tables["Affectation"].Rows.Clear();
                        }
                        Manager.Open_Connection();
                        Manager.Query("select top 10 * from Stagiaire_Groupe_Session");
                        Manager.Fill_DataSet(DsAffectation, "AffectationTest");
                        RemplirDGV(dataGridViewAffectation, "Affectation", DsAffectation, "Affectation");
                        Manager.Close_Connection();
                    }
                    else
                    {
                        MessageBox.Show("Tu dois saisir des information correcte \nEX: CIN : WA213364", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message, "Edit affectation error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void btnDeleteAffectation_Click(object sender, EventArgs e)
        {
            int position = Manager.SearchForExistence(DsAffectation.Tables["AffectationTest"], txtCINAffectation.Text.ToUpper(), comboSessionAffectation.SelectedValue.ToString(), "CIN", "ID_Annee");
            if (position != -1 && txtCINAffectation.Text.Trim() != "")
            {
                try
                {
                    DialogResult dialog = MessageBox.Show("Voulez-vous supprimer cette element ?", "Supprimer Comfirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialog == DialogResult.Yes)
                    {
                        Manager.Query("delete from Stagiaire_Groupe_Session Where CIN=@CIN and ID_Groupe = @ID_Groupe and ID_Annee = @ID_Annee");
                        Manager.Command.Parameters.AddWithValue("@CIN", txtCINAffectation.Text.ToUpper());
                        Manager.Command.Parameters.AddWithValue("@ID_Groupe", comboGroupAffectation.SelectedValue);
                        Manager.Command.Parameters.AddWithValue("@ID_Annee", comboSessionAffectation.SelectedValue);
                        Manager.Open_Connection();
                        Manager.ExecuteQuery();
                        Manager.Close_Connection();
                        MessageBox.Show("Supprimée avec succès", "Supprimer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (DsAffectation.Tables["Affectation"].Rows.Count > 0)
                        {
                            DsAffectation.Tables["AffectationTest"].Rows.Clear();
                            DsAffectation.Tables["Affectation"].Rows.Clear();
                        }
                        Manager.Open_Connection();
                        Manager.Query("select top 10 * from Stagiaire_Groupe_Session");
                        Manager.Fill_DataSet(DsAffectation, "AffectationTest");
                        RemplirDGV(dataGridViewAffectation, "Affectation", DsAffectation, "Affectation");
                        Manager.Close_Connection();

                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message, "Delete affectation error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }
        #endregion
        //PANEL Stagiaire
        #region Stagiaire
        private void btnEditStagiaire_Click(object sender, EventArgs e)
        {
            int position = Manager.SearchForExistence(DsStagiaire.Tables["Stagiaire"], TXTCIN.Text.ToUpper(), "CIN");
            if (position != -1 && TXTCIN.Text.Trim() != "" && TXTCNE.Text.Trim() != "" && TXTNom.Text.Trim() != "" && TXTPrenom.Text.Trim() != "")
            {
                try
                {
                    if (Regex.IsMatch(TXTCIN.Text, "^[A-Za-z]{2}[0-9]{6}$") && Regex.IsMatch(TXTCNE.Text, "^[0-9]{8}$"))
                    {
                        Manager.Query("update Stagiaire set  CNE = @CNE,Nom = @Nom,Prenom = @Prenom,Sexe =  @Sexe,Date_Naissance = @Date_Naissance Where CIN=@CIN");
                        Manager.Command.Parameters.AddWithValue("@CIN", TXTCIN.Text.ToUpper());
                        Manager.Command.Parameters.AddWithValue("@CNE", TXTCNE.Text);
                        Manager.Command.Parameters.AddWithValue("@Nom", TXTNom.Text.ToUpper());
                        Manager.Command.Parameters.AddWithValue("@Prenom", TXTPrenom.Text.ToUpper());
                        Manager.Command.Parameters.AddWithValue("@Sexe", comboGender.SelectedItem);
                        Manager.Command.Parameters.AddWithValue("@Date_Naissance", DTPDateNaissance.Value.ToShortDateString());
                        Manager.Open_Connection();
                        Manager.ExecuteQuery();
                        Manager.Close_Connection();
                        MessageBox.Show("Modifié avec succès", "Modifier", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        if (DsStagiaire.Tables["Stagiaire"].Rows.Count > 0) DsStagiaire.Tables["Stagiaire"].Rows.Clear();
                        RemplirDGV(dataGridViewStagiaire, "select top 5 CIN, CNE, Nom, Prenom, Sexe, Date_Naissance as 'Date Naissance' from stagiaire", DsStagiaire, "Stagiaire");
                    }
                    else
                    {
                        MessageBox.Show("Tu dois saisir des information correcte \nEX: CIN : WA213364 et CNE : 11223344","Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message," Edit trainee error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void btnNewStagiaire_Click(object sender, EventArgs e)
        {
            if (TXTCIN.Text != "")
            {
                TXTCIN.Clear();
                TXTCNE.Clear();
                TXTNom.Clear();
                TXTPrenom.Clear();
                comboGender.SelectedIndex = 0;
                DTPDateNaissance.Value = DateTime.Now;
            }
        }

        private void btnDeleteStagiaire_Click(object sender, EventArgs e)
        {
            int position = Manager.SearchForExistence(DsStagiaire.Tables["Stagiaire"], TXTCIN.Text, "CIN");
            if (position != -1 && TXTCIN.Text.Trim() != "" && TXTCNE.Text.Trim() != "" && TXTNom.Text.Trim() != "" && TXTPrenom.Text.Trim() != "")
            {
                try
                {
                    DialogResult dialog = MessageBox.Show("Voulez-vous supprimer cette element ?", "Supprimer Comfirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialog == DialogResult.Yes)
                    {
                        Manager.Query("delete from Stagiaire Where CIN=@CIN");
                        Manager.Command.Parameters.AddWithValue("@CIN", TXTCIN.Text);
                        Manager.Open_Connection();
                        Manager.ExecuteQuery();
                        Manager.Close_Connection();
                        MessageBox.Show("Supprimée avec succès", "Supprimer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (DsStagiaire.Tables["Stagiaire"].Rows.Count > 0) DsStagiaire.Tables["Stagiaire"].Rows.Clear();
                        RemplirDGV(dataGridViewStagiaire, "select top 5 CIN, CNE, Nom, Prenom, Sexe, Date_Naissance as 'Date Naissance' from stagiaire", DsStagiaire, "Stagiaire");
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message,"Delete trainee error",MessageBoxButtons.OK,MessageBoxIcon.Error); }
            }
        }
        // TXT SEARCH STAGIAIRE
        private void TXTSearchStagiaire_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (TXTSearchStagiaire.Text != "  Recherche par CIN ou CNE")
                {

                    if (DsStagiaire.Tables["Stagiaire"].Rows.Count > 0) DsStagiaire.Tables["Stagiaire"].Rows.Clear();
                    RemplirDGV(dataGridViewStagiaire, "select top 5 CIN,CNE,Nom,Prenom,Sexe,Date_Naissance as 'Date Naissance' from stagiaire where CIN like '" + TXTSearchStagiaire.Text + "%' or CNE like '" + TXTSearchStagiaire.Text + "%'", DsStagiaire, "Stagiaire");
                    if(dataGridViewStagiaire.Rows.Count == 0)
                    {
                        LblCountStagiaire.Text =  "0/0";
                    }
                }
            }
            catch { }

        }

        private void btnAddStagiaire_Click(object sender, EventArgs e)
        {
            int position = Manager.SearchForExistence(DsStagiaire.Tables["Stagiaire"], TXTCIN.Text, "CIN");
            if (position == -1 && TXTCIN.Text.Trim() != "" && TXTCNE.Text.Trim() != "" && TXTNom.Text.Trim() != "" && TXTPrenom.Text.Trim() != "")
            {
                try
                {
                    if (Regex.IsMatch(TXTCIN.Text,"^[A-Za-z]{2}[0-9]{6}$") && Regex.IsMatch(TXTCNE.Text,"^[0-9]{8}$"))
                    {
                    Manager.Query("insert into Stagiaire Values(@CIN,@CNE,@Nom,@Prenom,@Sexe,@Date_Naissance)");
                    Manager.Command.Parameters.AddWithValue("@CIN", TXTCIN.Text.ToUpper());
                    Manager.Command.Parameters.AddWithValue("@CNE", TXTCNE.Text);
                    Manager.Command.Parameters.AddWithValue("@Nom", TXTNom.Text.ToUpper());
                    Manager.Command.Parameters.AddWithValue("@Prenom", TXTPrenom.Text.ToUpper());
                    Manager.Command.Parameters.AddWithValue("@Sexe", comboGender.SelectedItem);
                    Manager.Command.Parameters.AddWithValue("@Date_Naissance", DTPDateNaissance.Value.ToShortDateString());
                    Manager.Open_Connection();
                    Manager.ExecuteQuery();
                    Manager.Close_Connection();
                    MessageBox.Show("Ajouté avec succès", "Ajouter", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (DsStagiaire.Tables["Stagiaire"].Rows.Count > 0) DsStagiaire.Tables["Stagiaire"].Rows.Clear();
                    RemplirDGV(dataGridViewStagiaire, "select top 5 CIN, CNE, Nom, Prenom, Sexe, Date_Naissance as 'Date Naissance' from stagiaire", DsStagiaire, "Stagiaire");
                    }
                    else
                    {
                        MessageBox.Show("Tu dois saisir des information correcte \nEX: CIN : WA213364 et CNE : 11223344", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message,"Add trainee error", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            }
        }

        #endregion
        //Panel Filiere
        #region Filiere
        private void btnDeleteFiliere_Click(object sender, EventArgs e)
        {
            int position = Manager.SearchForExistence(dsFiliere.Tables["Filiere"], txtFiliereID.Text, "ID");
            if (position != -1 && txtFiliereNom.Text.Trim() != "" && txtFiliereID.Text.Trim() != "")
            {
                try
                {
                    DialogResult dialog = MessageBox.Show("Voulez-vous supprimer cette element ?", "Supprimer Comfirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialog == DialogResult.Yes)
                    {
                        Manager.Query("delete from Filiere where ID_Filiere = @ID_Filiere");
                        Manager.Command.Parameters.AddWithValue("@ID_Filiere", txtFiliereID.Text);
                        Manager.Open_Connection();
                        Manager.ExecuteQuery();
                        Manager.Close_Connection();
                        MessageBox.Show("Supprimé avec succès", "Supprimer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (dsFiliere.Tables["Filiere"].Rows.Count > 0) dsFiliere.Tables["Filiere"].Rows.Clear();
                        RemplirDGV(dataGridViewFiliere, "select ID_Filiere as 'ID',Nom_Filiere as 'Filière' from Filiere", dsFiliere, "Filiere");
                    }

                }
                catch (Exception ex) { MessageBox.Show(ex.Message, "Delete fil error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }
        private void btnEditFiliere_Click(object sender, EventArgs e)
        {
            int position = Manager.SearchForExistence(dsFiliere.Tables["Filiere"], txtFiliereID.Text, "ID");
            int position2 = Manager.SearchForExistence(dsFiliere.Tables["Filiere"], txtFiliereNom.Text.ToUpper(), "Filière");
            if (position != -1 && txtFiliereNom.Text.Trim() != "" && txtFiliereID.Text.Trim() != "" && position2 == -1)
            {
                try
                {
                    Manager.Query("update Filiere Set Nom_Filiere = @Nom_Filiere where ID_Filiere = @ID_Filiere");
                    Manager.Command.Parameters.AddWithValue("@Nom_Filiere", txtFiliereNom.Text.ToUpper());
                    Manager.Command.Parameters.AddWithValue("@ID_Filiere", txtFiliereID.Text);
                    Manager.Open_Connection();
                    Manager.ExecuteQuery();
                    Manager.Close_Connection();
                    MessageBox.Show("Modifié avec succès", "Modifier", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (dsFiliere.Tables["Filiere"].Rows.Count > 0) dsFiliere.Tables["Filiere"].Rows.Clear();
                    RemplirDGV(dataGridViewFiliere, "select ID_Filiere as 'ID',Nom_Filiere as 'Filière' from Filiere", dsFiliere, "Filiere");

                }
                catch (Exception ex) { MessageBox.Show(ex.Message, "Edit fil error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }

        }
        private void btnNewFiliere_Click(object sender, EventArgs e)
        {
            if (txtFiliereID.Text.Trim() != "" || txtFiliereNom.Text.Trim() != "")
            {
                txtFiliereID.Clear();
                txtFiliereNom.Clear();
            }
        }

        private void btnAddFiliere_Click(object sender, EventArgs e)
        {
            int position = Manager.SearchForExistence(dsFiliere.Tables["Filiere"], txtFiliereNom.Text.ToUpper(), "Filière");
            if (position == -1 && txtFiliereNom.Text.Trim() != "")
            {
                try
                {
                        Manager.Query("insert into Filiere Values(@Filiere)");
                        Manager.Command.Parameters.AddWithValue("@Filiere", txtFiliereNom.Text.ToUpper());
                        Manager.Open_Connection();
                        Manager.ExecuteQuery();
                        Manager.Close_Connection();
                        MessageBox.Show("Ajouté avec succès", "Ajouter", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (dsFiliere.Tables["Filiere"].Rows.Count > 0) dsFiliere.Tables["Filiere"].Rows.Clear();
                        RemplirDGV(dataGridViewFiliere, "select ID_Filiere as 'ID',Nom_Filiere as 'Filière' from Filiere", dsFiliere, "Filiere");

                }
                catch (Exception ex) { MessageBox.Show(ex.Message, "Add fil error", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            }
        }
        #endregion
        //DATAGRIDVIEW METHODES
        #region Datagridview manage
        private void dataGridViewStagiaire_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (DsStagiaire.Tables["Stagiaire"] != null && dataGridViewStagiaire.SelectedRows.Count > 0)
                {
                    int index = dataGridViewStagiaire.SelectedCells[0].OwningRow.Index;
                    TXTCIN.Text = DsStagiaire.Tables["Stagiaire"].Rows[index]["CIN"].ToString();
                    TXTCNE.Text = DsStagiaire.Tables["Stagiaire"].Rows[index]["CNE"].ToString();
                    TXTNom.Text = DsStagiaire.Tables["Stagiaire"].Rows[index]["Nom"].ToString();
                    TXTPrenom.Text = DsStagiaire.Tables["Stagiaire"].Rows[index]["Prenom"].ToString();
                    comboGender.SelectedItem = DsStagiaire.Tables["Stagiaire"].Rows[index]["Sexe"].ToString();
                    DTPDateNaissance.Text = DsStagiaire.Tables["Stagiaire"].Rows[index]["Date Naissance"].ToString();
                    //LBL COUNT 
                    pStag = index;
                    if (dataGridViewStagiaire.Rows.Count > 0)
                    {
                        LblCountStagiaire.Text = pStag + 1 + "/" + DsStagiaire.Tables["Stagiaire"].Rows.Count;
                    }
                }
            }
            catch (Exception) { }
        }

        private void dataGridViewAffectation_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (DsAffectation.Tables["AffectationTest"] != null && dataGridViewAffectation.SelectedRows.Count > 0)
                {
                    int index = dataGridViewAffectation.SelectedCells[0].OwningRow.Index;
                    txtCINAffectation.Text = DsAffectation.Tables["AffectationTest"].Rows[index]["CIN"].ToString();
                    comboGroupAffectation.SelectedValue = DsAffectation.Tables["AffectationTest"].Rows[index]["ID_Groupe"];
                    comboSessionAffectation.SelectedValue = DsAffectation.Tables["AffectationTest"].Rows[index]["ID_Annee"];
                    pAffe = index;
                    if (dataGridViewAffectation.Rows.Count > 0)
                    {
                        lblCountAffectation.Text = pAffe + 1 + "/" + DsAffectation.Tables["AffectationTest"].Rows.Count;
                    }
                }
            }
            catch { }
        }
        private void dataGridViewSession_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (DsSession.Tables["Session"] != null && dataGridViewSession.SelectedRows.Count > 0)
                {
                    int index = dataGridViewSession.SelectedCells[0].OwningRow.Index;
                    txtSessionID.Text = DsSession.Tables["Session"].Rows[index]["ID"].ToString();
                    txtSession.Text = DsSession.Tables["Session"].Rows[index]["Session"].ToString();
                    //LBL COUNT 
                    pSess = index;
                    if (dataGridViewSession.Rows.Count > 0)
                    {
                        LblCountSession.Text = pSess + 1 + "/" + DsSession.Tables["Session"].Rows.Count;
                    }
                }
            }
            catch { }
        }
        private void RemplirDGV(DataGridView DGV, string query, DataSet dataset, string table)
        {
            Manager.Open_Connection();
            Manager.Query(query);
            Manager.Fill_DataSet(dataset, table);
            Manager.Fill_DataGridView(DGV, dataset.Tables[table]);
            Manager.Close_Connection();
        }

        private void dataGridViewFiliere_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dsFiliere.Tables["Filiere"] != null && dataGridViewFiliere.SelectedRows.Count > 0)
                {
                    int index = dataGridViewFiliere.SelectedCells[0].OwningRow.Index;
                    txtFiliereID.Text = dsFiliere.Tables["Filiere"].Rows[index]["ID"].ToString();
                    txtFiliereNom.Text = dsFiliere.Tables["Filiere"].Rows[index]["Filière"].ToString();
                }

            }
            catch (Exception ex) { }
        }
        private void dataGridViewGroupe_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (DsGroupe.Tables["Groupe"] != null && dataGridViewGroupe.SelectedRows.Count > 0)
                {
                    int index = dataGridViewGroupe.SelectedCells[0].OwningRow.Index;
                    txtGroupeID.Text = DsGroupe.Tables["Groupe"].Rows[index]["ID_Groupe"].ToString();
                    txtNomGroupe.Text = DsGroupe.Tables["Groupe"].Rows[index]["Nom_Groupe"].ToString();
                    comboFiliere.SelectedValue = DsGroupe.Tables["Groupe"].Rows[index]["ID_Filiere"];
                    //LBL COUNT 
                    pGr = index;
                    if (dataGridViewGroupe.Rows.Count > 0)
                    {
                        LblCountGroupe.Text = pGr + 1 + "/" + DsGroupe.Tables["Groupe"].Rows.Count;
                    }
                }
            }
            catch { }
        }
        private void DGVTypeDocStag_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dsTypeDocStagiaire.Tables["TypeDocStag"] != null && DGVTypeDocStag.SelectedRows.Count > 0)
                {
                    int index = DGVTypeDocStag.SelectedCells[0].OwningRow.Index;
                    txtTypeDocStagiaire.Text = dsTypeDocStagiaire.Tables["TypeDocStag"].Rows[index]["Nom de Type"].ToString();
                }
            }
            catch { }
        }
        private void DGVTypeDocPV_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dsTypeDocPV.Tables["TypeDocPV"] != null && DGVTypeDocPV.SelectedRows.Count > 0)
                {
                    int index = DGVTypeDocPV.SelectedCells[0].OwningRow.Index;
                    txtTypeDocPV.Text = dsTypeDocPV.Tables["TypeDocPV"].Rows[index]["Nom de Type"].ToString();
                }
            }
            catch { }
        }
        #endregion
        //Panel Groupe
        #region Groupe
        private void btnNewGroupe_Click(object sender, EventArgs e)
        {
            if (txtNomGroupe.Text.Trim() != "" || txtGroupeID.Text.Trim() != "")
            {
                txtNomGroupe.Clear();
                txtGroupeID.Clear();
            }
        }

        private void btnAddGroupe_Click(object sender, EventArgs e)
        {
            int position = Manager.SearchForExistence(DsGroupe.Tables["Groupe"], txtNomGroupe.Text.ToUpper(), "Nom_Groupe");
            if (position == -1 && txtNomGroupe.Text.Trim() != "")
            {
                try
                {
                    if (Regex.IsMatch(txtNomGroupe.Text, "^[A-Za-z]+[0-9]+$"))
                    {
                        Manager.Query("insert into Groupe Values(@Nom_Groupe,@ID_Filiere)");
                        Manager.Command.Parameters.AddWithValue("@Nom_Groupe", txtNomGroupe.Text.ToUpper());
                        Manager.Command.Parameters.AddWithValue("@ID_Filiere", comboFiliere.SelectedValue);
                        Manager.Open_Connection();
                        Manager.ExecuteQuery();
                        Manager.Close_Connection();
                        MessageBox.Show("Ajouté avec succès", "Ajouter", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (DsGroupe.Tables["GroupeDGV"].Rows.Count > 0) {
                            DsGroupe.Tables["GroupeDGV"].Rows.Clear();
                            DsGroupe.Tables["Groupe"].Rows.Clear();
                        }
                        Manager.Open_Connection();
                        Manager.Query("select top 10 * from Groupe order by ID_Groupe desc");
                        Manager.Fill_DataSet(DsGroupe, "Groupe");
                        RemplirDGV(dataGridViewGroupe, "GroupeDGV", DsGroupe, "GroupeDGV");
                        Manager.Close_Connection();
                    }
                    else
                    {
                        MessageBox.Show("Tu dois saisir un nom de groupe valide EX : TDI101","Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message, "Add group error", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            }
        }

        private void btnEditGroupe_Click(object sender, EventArgs e)
        {
            int position = Manager.SearchForExistence(DsGroupe.Tables["Groupe"], txtGroupeID.Text, "ID_Groupe");
            if (position != -1 && txtGroupeID.Text.Trim() != "" && txtNomGroupe.Text.Trim() != "")
            {
                try
                {
                    if (Regex.IsMatch(txtNomGroupe.Text, "^[A-Za-z]+[0-9]+$"))
                    {
                        Manager.Query("update Groupe set Nom_Groupe = @Nom_Groupe,ID_Filiere = @ID_Filiere where ID_Groupe = @ID_Groupe");
                        Manager.Command.Parameters.AddWithValue("@ID_Groupe", txtGroupeID.Text);
                        Manager.Command.Parameters.AddWithValue("@Nom_Groupe", txtNomGroupe.Text.ToUpper());
                        Manager.Command.Parameters.AddWithValue("@ID_Filiere", comboFiliere.SelectedValue);
                        Manager.Open_Connection();
                        Manager.ExecuteQuery();
                        Manager.Close_Connection();
                        MessageBox.Show("Modifié avec succès", "Modifier", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (DsGroupe.Tables["GroupeDGV"].Rows.Count > 0)
                        {
                            DsGroupe.Tables["GroupeDGV"].Rows.Clear();
                            DsGroupe.Tables["Groupe"].Rows.Clear();
                        }
                        Manager.Open_Connection();
                        Manager.Query("select top 10 * from Groupe order by ID_Groupe desc");
                        Manager.Fill_DataSet(DsGroupe, "Groupe");
                        RemplirDGV(dataGridViewGroupe, "GroupeDGV", DsGroupe, "GroupeDGV");
                        Manager.Close_Connection();
                    }
                    else
                    {
                        MessageBox.Show("Tu dois saisir un nom de groupe valide EX : TDI101", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message, "Edit group error", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            }
        }

        private void btnDeleteGroupe_Click(object sender, EventArgs e)
        {
            int position = Manager.SearchForExistence(DsGroupe.Tables["Groupe"], txtGroupeID.Text, "ID_Groupe");
            if (position != -1 && txtGroupeID.Text.Trim() != "" && txtNomGroupe.Text.Trim() != "")
            {
                try
                {
                    DialogResult dialog = MessageBox.Show("Voulez-vous supprimer cette element ?", "Supprimer Comfirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialog == DialogResult.Yes)
                    {
                        Manager.Query("delete from Groupe where ID_Groupe = @ID_Groupe");
                        Manager.Command.Parameters.AddWithValue("@ID_Groupe", txtGroupeID.Text);
                        Manager.Open_Connection();
                        Manager.ExecuteQuery();
                        Manager.Close_Connection();
                        MessageBox.Show("Supprimé avec succès", "Supprimer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (DsGroupe.Tables["GroupeDGV"].Rows.Count > 0)
                        {
                            DsGroupe.Tables["GroupeDGV"].Rows.Clear();
                            DsGroupe.Tables["Groupe"].Rows.Clear();
                        }
                        Manager.Open_Connection();
                        Manager.Query("select top 10 * from Groupe order by ID_Groupe desc");
                        Manager.Fill_DataSet(DsGroupe, "Groupe");
                        RemplirDGV(dataGridViewGroupe, "GroupeDGV", DsGroupe, "GroupeDGV");
                        Manager.Close_Connection();
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message, "Delete group error", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            }
        }

        #endregion
        //Panel Type Doc Stagiaire
        #region Type Doc Stagiaire
        private void btnNewTypeDocStagiaire_Click(object sender, EventArgs e)
        {
            if (txtTypeDocStagiaire.Text.Trim() != "")
            {
                txtTypeDocStagiaire.Clear();
            }
        }

        private void btnEditTypeDocStagiaire_Click(object sender, EventArgs e)
        {
            int position = Manager.SearchForExistence(dsTypeDocStagiaire.Tables["TypeDocStag"], txtTypeDocStagiaire.Text.ToUpper(), "Nom de Type");
            if (position != -1 && txtTypeDocStagiaire.Text.Trim() != "")
            {
                try
                {
                    Manager.Query("update Type_Documents_Stagiaire set Nom_Doc_Type = @Type where Nom_Doc_Type = @Type");
                    Manager.Command.Parameters.AddWithValue("@Type", txtTypeDocStagiaire.Text.ToUpper());
                    Manager.Open_Connection();
                    Manager.ExecuteQuery();
                    Manager.Close_Connection();
                    MessageBox.Show("Modifié avec succès", "Modifier", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (dsTypeDocStagiaire.Tables["TypeDocStag"].Rows.Count > 0)
                    {
                        dsTypeDocStagiaire.Tables["TypeDocStag"].Rows.Clear();
                    }
                    RemplirDGV(DGVTypeDocStag, "select Nom_Doc_Type as 'Nom de Type' from Type_Documents_Stagiaire", dsTypeDocStagiaire, "TypeDocStag");
                }
                catch (Exception ex) { MessageBox.Show(ex.Message, "Edit Type document trainee error", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            }
        }

        private void btnDeleteTypeDocStagiaire_Click(object sender, EventArgs e)
        {
            int position = Manager.SearchForExistence(dsTypeDocStagiaire.Tables["TypeDocStag"], txtTypeDocStagiaire.Text.ToUpper(), "Nom de Type");
            if (position != -1 && txtTypeDocStagiaire.Text.Trim() != "")
            {
                try
                {
                    DialogResult dialog = MessageBox.Show("Voulez-vous supprimer cette element ?", "Supprimer Comfirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialog == DialogResult.Yes) {
                    Manager.Query("delete from Type_Documents_Stagiaire where Nom_Doc_Type = @Type");
                    Manager.Command.Parameters.AddWithValue("@Type", txtTypeDocStagiaire.Text.ToUpper());
                    Manager.Open_Connection();
                    Manager.ExecuteQuery();
                    Manager.Close_Connection();
                    MessageBox.Show("Supprimé avec succès", "Supprimer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (dsTypeDocStagiaire.Tables["TypeDocStag"].Rows.Count > 0)
                    {
                        dsTypeDocStagiaire.Tables["TypeDocStag"].Rows.Clear();
                    }
                    RemplirDGV(DGVTypeDocStag, "select Nom_Doc_Type as 'Nom de Type' from Type_Documents_Stagiaire", dsTypeDocStagiaire, "TypeDocStag");
                }
                }
                catch (Exception ex) { MessageBox.Show("Vous ne pouvez pas supprimer un type déja utilise", "Delete Type document trainee error", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            }
        }
        private void btnAddTypeDocStagiaire_Click(object sender, EventArgs e)
        {
            int position = Manager.SearchForExistence(dsTypeDocStagiaire.Tables["TypeDocStag"], txtTypeDocStagiaire.Text.ToUpper(), "Nom de Type");
            if (position == -1 && txtTypeDocStagiaire.Text.Trim() != "")
            {
                try
                {
                        Manager.Query("insert into Type_Documents_Stagiaire Values(@Type)");
                        Manager.Command.Parameters.AddWithValue("@Type", txtTypeDocStagiaire.Text.ToUpper());
                        Manager.Open_Connection();
                        Manager.ExecuteQuery();
                        Manager.Close_Connection();
                        MessageBox.Show("Ajouté avec succès", "Ajouter", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (dsTypeDocStagiaire.Tables["TypeDocStag"].Rows.Count > 0)
                        {
                            dsTypeDocStagiaire.Tables["TypeDocStag"].Rows.Clear();
                        }
                    RemplirDGV(DGVTypeDocStag, "select Nom_Doc_Type as 'Nom de Type' from Type_Documents_Stagiaire", dsTypeDocStagiaire, "TypeDocStag");
                }
                catch (Exception ex) { MessageBox.Show(ex.Message, "Add Type document trainee error", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            }
        }
        #endregion
        //Panel Type Doc PV
        #region Type Doc PV
        private void btnNewTypeDocPV_Click(object sender, EventArgs e)
        {
            if (txtTypeDocPV.Text.Trim() != "")
            {
                txtTypeDocPV.Clear();
            }
        }
        private void btnAddTypeDocPV_Click(object sender, EventArgs e)
        {
            int position = Manager.SearchForExistence(dsTypeDocPV.Tables["TypeDocPV"], txtTypeDocPV.Text.ToUpper(), "Nom de Type");
            if (position == -1 && txtTypeDocPV.Text.Trim() != "")
            {
                try
                {
                    Manager.Query("insert into Type_Documents_PV Values(@Type)");
                    Manager.Command.Parameters.AddWithValue("@Type", txtTypeDocPV.Text.ToUpper());
                    Manager.Open_Connection();
                    Manager.ExecuteQuery();
                    Manager.Close_Connection();
                    MessageBox.Show("Ajouté avec succès", "Ajouter", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (dsTypeDocPV.Tables["TypeDocPV"].Rows.Count > 0)
                    {
                        dsTypeDocPV.Tables["TypeDocPV"].Rows.Clear();
                    }
                    RemplirDGV(DGVTypeDocPV, "select Nom_Type_PV as 'Nom de Type' from Type_Documents_PV", dsTypeDocPV, "TypeDocPV");
                }
                catch (Exception ex) { MessageBox.Show(ex.Message, "Add Type document PV error", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            }
        }

        private void BTNFirstStagiaire_Click(object sender, EventArgs e)
        {
            if (dataGridViewStagiaire.Rows.Count > 0)
            {
                pStag = 0;
                design.First(dataGridViewStagiaire, pStag, LblCountStagiaire);
            }
        }

        private void BTNPreviousStagiaire_Click(object sender, EventArgs e)
        {
            if (dataGridViewStagiaire.Rows.Count > 0)
            {
                pStag = dataGridViewStagiaire.SelectedCells[0].OwningRow.Index;
                pStag--;
                design.Previous(dataGridViewStagiaire, pStag, LblCountStagiaire);
            }
        }

        private void BTNNextStagiaire_Click(object sender, EventArgs e)
        {
            if (dataGridViewStagiaire.Rows.Count > 0)
            {
                pStag = dataGridViewStagiaire.SelectedCells[0].OwningRow.Index;
                pStag++;
                design.Next(dataGridViewStagiaire, pStag, LblCountStagiaire);
            }
        }

        private void BTNLastStagiaire_Click(object sender, EventArgs e)
        {
            if (dataGridViewStagiaire.Rows.Count > 0)
            {
                pStag = dataGridViewStagiaire.Rows.Count - 1;
                design.Last(dataGridViewStagiaire, pStag, LblCountStagiaire);
            }
        }

        private void btnFirstAffectation_Click(object sender, EventArgs e)
        {
            if (dataGridViewAffectation.Rows.Count > 0)
            {
                pAffe = 0;
                design.First(dataGridViewAffectation, pAffe, lblCountAffectation);
            }
        }

        private void btnPrevAffectation_Click(object sender, EventArgs e)
        {
            if (dataGridViewAffectation.Rows.Count > 0)
            {
                pAffe = dataGridViewAffectation.SelectedCells[0].OwningRow.Index;
                pAffe--;
                design.Previous(dataGridViewAffectation, pAffe, lblCountAffectation);
            }
        }

        private void btnNextAffectation_Click(object sender, EventArgs e)
        {
            if (dataGridViewAffectation.Rows.Count > 0)
            {
                pAffe = dataGridViewAffectation.SelectedCells[0].OwningRow.Index;
                pAffe++;
                design.Next(dataGridViewAffectation, pAffe, lblCountAffectation);
            }
        }

        private void btnLastAffectation_Click(object sender, EventArgs e)
        {
            if (dataGridViewAffectation.Rows.Count > 0)
            {
                pAffe = dataGridViewAffectation.Rows.Count - 1;
                design.Last(dataGridViewAffectation, pAffe, lblCountAffectation);
            }
        }

        private void TXTSearchAffectation_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (TXTSearchAffectation.Text != "  Recherche par CIN de Stagiaire")
                {

                    if (DsAffectation.Tables["Affectation"].Rows.Count > 0) {
                        DsAffectation.Tables["Affectation"].Rows.Clear();
                        DsAffectation.Tables["AffectationTest"].Rows.Clear();
                    }
                    Manager.Open_Connection();
                    Manager.Query("select top 10 * from Stagiaire_Groupe_Session where CIN like '" + TXTSearchAffectation.Text+"%'");
                    Manager.Fill_DataSet(DsAffectation, "AffectationTest");
                    RemplirDGV(dataGridViewAffectation, "AffectationSearch '" + TXTSearchAffectation.Text+"'" , DsAffectation, "Affectation");
                    Manager.Close_Connection();
                    if (dataGridViewAffectation.Rows.Count == 0)
                    {
                        lblCountAffectation.Text = "0/0";
                    }
                }
            }
            catch { }

        }

        private void btnFirstSession_Click(object sender, EventArgs e)
        {
            if (dataGridViewSession.Rows.Count > 0)
            {
                pSess = 0;
                design.First(dataGridViewSession, pSess, LblCountSession);
            }
        }

        private void btnPreSession_Click(object sender, EventArgs e)
        {
            if (dataGridViewSession.Rows.Count > 0)
            {
                pSess = dataGridViewSession.SelectedCells[0].OwningRow.Index;
                pSess--;
                design.Previous(dataGridViewSession, pSess, LblCountSession);
            }
        }

        private void btnNextSession_Click(object sender, EventArgs e)
        {
            if (dataGridViewSession.Rows.Count > 0)
            {
                pSess = dataGridViewSession.SelectedCells[0].OwningRow.Index;
                pSess++;
                design.Next(dataGridViewSession, pSess, LblCountSession);
            }
        }

        private void btnLastSession_Click(object sender, EventArgs e)
        {
            if (dataGridViewSession.Rows.Count > 0)
            {
                pSess = dataGridViewSession.Rows.Count - 1;
                design.Last(dataGridViewSession, pSess, LblCountSession);
            }
        }

        private void TXTSearchSession_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (TXTSearchSession.Text != "  Recherche par Session" )
                {

                    if (DsSession.Tables["Session"].Rows.Count > 0)
                    {
                        DsSession.Tables["Session"].Rows.Clear();
                    }
                    RemplirDGV(dataGridViewSession, "select top 10 ID_Annee as 'ID', Session_Etude as 'Session' from Annee_Etude where Session_Etude like '" + TXTSearchSession.Text + "%'",DsSession, "Session");
                    if (dataGridViewSession.Rows.Count == 0)
                    {
                        LblCountSession.Text = "0/0";
                    }
                }
            }
            catch { }
        }

        private void TXTSearchGroupe_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (TXTSearchGroupe.Text != "  Recherche par Groupe")
                {

                    if (DsGroupe.Tables["Groupe"].Rows.Count > 0)
                    {
                        DsGroupe.Tables["GroupeDGV"].Rows.Clear();
                        DsGroupe.Tables["Groupe"].Rows.Clear();
                    }
                    Manager.Open_Connection();
                    Manager.Query("select top 10 * from Groupe where Nom_Groupe like '" + TXTSearchGroupe.Text + "%'");
                    Manager.Fill_DataSet(DsGroupe, "Groupe");
                    Manager.Close_Connection();
                    RemplirDGV(dataGridViewGroupe, "GroupeDGVSearch '" + TXTSearchGroupe.Text + "'", DsGroupe, "GroupeDGV");
                    if (dataGridViewGroupe.Rows.Count == 0)
                    {
                        LblCountGroupe.Text = "0/0";
                    }
                }
            }
            catch { }
        }

        private void btnFirstGroupe_Click(object sender, EventArgs e)
        {
            if (dataGridViewGroupe.Rows.Count > 0)
            {
                pGr = 0;
                design.First(dataGridViewGroupe, pGr, LblCountGroupe);
            }
        }

        private void btnPrevGroupe_Click(object sender, EventArgs e)
        {
            if (dataGridViewGroupe.Rows.Count > 0)
            {
                pGr = dataGridViewGroupe.SelectedCells[0].OwningRow.Index;
                pGr--;
                design.Previous(dataGridViewGroupe, pGr, LblCountGroupe);
            }
        }

        private void btnNextGroupe_Click(object sender, EventArgs e)
        {
            if (dataGridViewGroupe.Rows.Count > 0)
            {
                pGr = dataGridViewGroupe.SelectedCells[0].OwningRow.Index;
                pGr++;
                design.Next(dataGridViewGroupe, pGr, LblCountGroupe);
            }
        }

        private void btnLastGroupe_Click(object sender, EventArgs e)
        {
            if (dataGridViewGroupe.Rows.Count > 0)
            {
                pGr = dataGridViewGroupe.Rows.Count - 1;
                design.Last(dataGridViewGroupe, pGr, LblCountGroupe);
            }
        }

        private void btnEditTypeDocPV_Click(object sender, EventArgs e)
        {
            int position = Manager.SearchForExistence(dsTypeDocPV.Tables["TypeDocPV"], txtTypeDocPV.Text.ToUpper(), "Nom de Type");
            if (position != -1 && txtTypeDocPV.Text.Trim() != "")
            {
                try
                {
                    Manager.Query("update Type_Documents_PV set Nom_Type_PV = @Type where Nom_Type_PV = @Type");
                    Manager.Command.Parameters.AddWithValue("@Type", txtTypeDocPV.Text.ToUpper());
                    Manager.Open_Connection();
                    Manager.ExecuteQuery();
                    Manager.Close_Connection();
                    MessageBox.Show("Modifié avec succès", "Modifier", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (dsTypeDocPV.Tables["TypeDocPV"].Rows.Count > 0)
                    {
                        dsTypeDocPV.Tables["TypeDocPV"].Rows.Clear();
                    }
                    RemplirDGV(DGVTypeDocPV, "select Nom_Type_PV as 'Nom de Type' from Type_Documents_PV", dsTypeDocPV, "TypeDocPV");
                }
                catch (Exception ex) { MessageBox.Show(ex.Message, "Edit Type document PV error", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            }
        }
        private void btnDeleteTypeDocPV_Click(object sender, EventArgs e)
        {
            int position = Manager.SearchForExistence(dsTypeDocPV.Tables["TypeDocPV"], txtTypeDocPV.Text.ToUpper(), "Nom de Type");
            if (position != -1 && txtTypeDocPV.Text.Trim() != "")
            {
                try
                {
                    DialogResult dialog = MessageBox.Show("Voulez-vous supprimer cette element ?", "Supprimer Comfirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialog == DialogResult.Yes)
                    {
                        Manager.Query("delete from Type_Documents_PV where Nom_Type_PV = @Type");
                        Manager.Command.Parameters.AddWithValue("@Type", txtTypeDocPV.Text.ToUpper());
                        Manager.Open_Connection();
                        Manager.ExecuteQuery();
                        Manager.Close_Connection();
                        MessageBox.Show("Supprimé avec succès", "Supprimer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (dsTypeDocPV.Tables["TypeDocPV"].Rows.Count > 0)
                        {
                            dsTypeDocPV.Tables["TypeDocPV"].Rows.Clear();
                        }
                        RemplirDGV(DGVTypeDocPV, "select Nom_Type_PV as 'Nom de Type' from Type_Documents_PV", dsTypeDocPV, "TypeDocPV");
                    }
                }
                catch (Exception ex) { MessageBox.Show("Vous ne pouvez pas supprimer un type déja utilise", "Delete Type document PV error", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            }
        }
        #endregion
        // Panel Session
        #region Session

        private void btnNewSession_Click(object sender, EventArgs e)
        {
            if (txtSessionID.Text.Trim() != "" || txtSession.Text.Trim() != "")
            {
                txtSessionID.Clear();
                txtSession.Clear();
            }
        }
        private void btnAddSession_Click(object sender, EventArgs e)
        {
            int position = Manager.SearchForExistence(DsSession.Tables["Session"], txtSession.Text, "Session");
            if (position == -1 && txtSession.Text.Trim() != "")
            {
                try
                {
                    if (Regex.IsMatch(txtSession.Text, "^[1-9]{1}[0-9]{3}-[1-9]{1}[0-9]{3}$"))
                    {
                    Manager.Query("insert into Annee_Etude Values(@Session)");
                    Manager.Command.Parameters.AddWithValue("@Session", txtSession.Text);
                    Manager.Open_Connection();
                    Manager.ExecuteQuery();
                    Manager.Close_Connection();
                    MessageBox.Show("Ajouté avec succès", "Ajouter", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (DsSession.Tables["Session"].Rows.Count > 0) DsSession.Tables["Session"].Rows.Clear();
                    RemplirDGV(dataGridViewSession, "select top 10 ID_Annee as 'ID', Session_Etude as 'Session' from Annee_Etude order by ID_Annee DESC", DsSession, "Session");
                    }
                    else
                    {
                        MessageBox.Show("Tu dois saisir une Session valide EX: 2018-2019","Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message, "Add Periode error", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            }

        }
        private void btnEditSession_Click(object sender, EventArgs e)
        {
            int position = Manager.SearchForExistence(DsSession.Tables["Session"], txtSessionID.Text, "ID");
            if (position != -1 && txtSession.Text != "" && txtSessionID.Text.Trim() != "")
            {
                try
                {
                    if (Regex.IsMatch(txtSession.Text, "^[1-9]{1}[0-9]{3}-[1-9]{1}[0-9]{3}$"))
                    {
                    Manager.Query("UPDATE Annee_Etude SET Session_Etude = @Session_Etude where ID_Annee = @ID_Annee");
                    Manager.Command.Parameters.AddWithValue("@Session_Etude", txtSession.Text);
                    Manager.Command.Parameters.AddWithValue("@ID_Annee", txtSessionID.Text);
                    Manager.Open_Connection();
                    Manager.ExecuteQuery();
                    Manager.Close_Connection();
                    MessageBox.Show("Modifié avec succès", "Ajouter", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (DsSession.Tables["Session"].Rows.Count > 0) DsSession.Tables["Session"].Rows.Clear();
                    RemplirDGV(dataGridViewSession, "select top 10 ID_Annee as 'ID', Session_Etude as 'Session' from Annee_Etude order by ID_Annee DESC", DsSession, "Session");
                    }
                    else
                    {
                        MessageBox.Show("Tu dois saisir une Session valide EX: 2018-2019", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message, "Edit Periode error", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            }
        }
        private void btnSupprimerSession_Click(object sender, EventArgs e)
        {
            int position = Manager.SearchForExistence(DsSession.Tables["Session"], txtSessionID.Text, "ID");
            if (position != -1 && txtSession.Text != "")
            {
                try
                {
                    DialogResult dialog = MessageBox.Show("Voulez-vous supprimer cette element ?", "Supprimer Comfirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialog == DialogResult.Yes)
                    {
                    Manager.Query("DELETE FROM Annee_Etude where ID_Annee = @ID_Annee");
                    Manager.Command.Parameters.AddWithValue("@ID_Annee", txtSessionID.Text);
                    Manager.Open_Connection();
                    Manager.ExecuteQuery();
                    Manager.Close_Connection();
                    MessageBox.Show("Supprimé avec succès", "Supprimer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (DsSession.Tables["Session"].Rows.Count > 0) DsSession.Tables["Session"].Rows.Clear();
                    RemplirDGV(dataGridViewSession, "select top 10 ID_Annee as 'ID', Session_Etude as 'Session' from Annee_Etude order by ID_Annee DESC", DsSession, "Session");
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message, "Delete Periode error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            
          
        }
        #endregion
    }
}