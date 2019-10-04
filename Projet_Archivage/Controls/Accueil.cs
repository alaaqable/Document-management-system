using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projet_Archivage
{
    public partial class Accueil : UserControl
    {
        DBManager Manager = new DBManager();
        DataSet Dscount = new DataSet();
        Design design = new Design();
        public Accueil()
        {
            InitializeComponent();
        }

        private void Accueil_Load(object sender, EventArgs e)
        {
            Manager.Open_Connection();
            Manager.Query("select count(*) from Stagiaire");
            lblStagiaireCount.Text = Manager.ExeuteScalar().ToString();
            design.LabelManager(lblStagiaireCount,157,132);
            Manager.Query("select count(*) from Documents_Stagiaire");
            lblDocStagiaireCount.Text = Manager.ExeuteScalar().ToString();
            design.LabelManager(lblDocStagiaireCount, 133, 113);
            Manager.Query("select count(*) from Documents_PV");
            lblDocPVCount.Text = Manager.ExeuteScalar().ToString();
            design.LabelManager(lblDocPVCount, 132, 116);
            Manager.Close_Connection();
            Manager.Chart_Filler(chart1);
        }
    }
}
