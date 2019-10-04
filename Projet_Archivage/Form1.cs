using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projet_Archivage
{
    public partial class Form1 : Form
    {
        DBManager Manager = new DBManager();
        Design design = new Design();
        bool IsDrag = false;
        Point point = new Point(0,0);
        Thread thread;
        bool AccueilTest = true, DocumentStaTest = false, DocumentPVTest = false, CentergestionTest = false;
        public Form1()
        {
            thread = new Thread(new ThreadStart(StartApp));
            thread.Start();
            Thread.Sleep(3000);
            InitializeComponent();
            thread.Abort();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void PanelTop_MouseDown(object sender, MouseEventArgs e)
        {
            IsDrag = true;
            point = new Point(e.X,e.Y);
        }

        private void PanelTop_MouseUp(object sender, MouseEventArgs e)
        {
          IsDrag = false;
        }

        private void PanelTop_MouseMove(object sender, MouseEventArgs e)
        {
              if (IsDrag)
            {
                Point pnt = PointToScreen(e.Location);
                this.Location = new Point(pnt.X - point.X, pnt.Y - point.Y);
            }
        }

        private async void BtnDocumentStagiaire_Click(object sender, EventArgs e)
        {
            if (DocumentStaTest == false)
            {
                design.HoverTextChanger(BtnDocumentStagiaire, "Icons/Document2.png", BtnAccueil, "Icons/Accueil.png", BtnDocumentPV, "Icons/documents_PV.png", BtnCentreDeGestion, "Icons/Controlcentre.png", PanelHover);
                await Task.Run(() => { Thread.Sleep(10); });
                Document_Stagaire document_Stagaire = new Document_Stagaire();
                design.UserControlChanger(PanelMain, document_Stagaire);
                AccueilTest = false; DocumentStaTest = true; DocumentPVTest = false; CentergestionTest = false;
            }
        }

        private async void BtnAccueil_Click(object sender, EventArgs e)
        {
            if (AccueilTest == false)
            {
                design.HoverTextChanger(BtnAccueil, "Icons/Accueil2.png", BtnDocumentStagiaire, "Icons/Document.png", BtnDocumentPV, "Icons/documents_PV.png", BtnCentreDeGestion, "Icons/Controlcentre.png", PanelHover);
                await Task.Run(() => { Thread.Sleep(10); });
                Accueil accueil = new Accueil();
                design.UserControlChanger(PanelMain, accueil);
                AccueilTest = true; DocumentStaTest = false; DocumentPVTest = false; CentergestionTest = false;
            }
        }

        private async void BtnDocumentPV_Click(object sender, EventArgs e)
        {
            if (DocumentPVTest == false)
            {
                design.HoverTextChanger(BtnDocumentPV, "Icons/documents_PV2.png", BtnAccueil, "Icons/Accueil.png", BtnDocumentStagiaire, "Icons/Document.png", BtnCentreDeGestion, "Icons/Controlcentre.png", PanelHover);
                await Task.Run(() => { Thread.Sleep(10); });
                DocumentPV documentPV = new DocumentPV();
                design.UserControlChanger(PanelMain, documentPV);
                AccueilTest = false; DocumentStaTest = false; DocumentPVTest = true; CentergestionTest = false;
            }
        }

        private async void BtnCentreDeGestion_Click(object sender, EventArgs e)
        {
            if (CentergestionTest == false)
            {
                design.HoverTextChanger(BtnCentreDeGestion, "Icons/Controlcentre2.png", BtnDocumentPV, "Icons/documents_PV.png", BtnAccueil, "Icons/Accueil.png", BtnDocumentStagiaire, "Icons/Document.png", PanelHover);
                await Task.Run(() => { Thread.Sleep(10); });
                Centre_Gestion centre_Gestion = new Centre_Gestion();
                design.UserControlChanger(PanelMain, centre_Gestion);
                AccueilTest = false; DocumentStaTest = false; DocumentPVTest = false; CentergestionTest = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
        private void StartApp()
        {
            try {
                    Application.Run(new LoadingForm());
                }
            catch(ThreadAbortException ex) {}
        }
    }
}
