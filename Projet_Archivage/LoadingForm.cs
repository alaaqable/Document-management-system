using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projet_Archivage
{
    public partial class LoadingForm : Form
    {
        DBManager Manager = new DBManager();
        DataSet DsDocument = new DataSet(); 
        public LoadingForm()
        {
            InitializeComponent();
        }

        private void LoadingForm_Load(object sender, EventArgs e)
        {
            if (Manager.Statue() == false)
            {
                Manager.Open_Connection();
                Manager.Query("select * from Documents_Stagiaire");
                Manager.Fill_DataSet(DsDocument, "Documents_Stagiaire");
                Manager.Query("select * from Documents_PV");
                Manager.Fill_DataSet(DsDocument, "Documents_PV");
                Manager.Close_Connection();
                if (DsDocument.Tables["Documents_Stagiaire"].Rows.Count > 0)
                {
                //document stagiaire
                if (!Directory.Exists(DsDocument.Tables["Documents_Stagiaire"].Rows[DsDocument.Tables["Documents_Stagiaire"].Rows.Count-1][3].ToString()))
                {
                for (int i = 0; i < DsDocument.Tables["Documents_Stagiaire"].Rows.Count; i++)
                {
                    if (!Directory.Exists(DsDocument.Tables["Documents_Stagiaire"].Rows[i][3].ToString()))
                    {
                        Directory.CreateDirectory(DsDocument.Tables["Documents_Stagiaire"].Rows[i][3].ToString());
                    }
                }
                for (int i = 0; i < DsDocument.Tables["Documents_Stagiaire"].Rows.Count; i++)
                {
                    if (Directory.Exists(DsDocument.Tables["Documents_Stagiaire"].Rows[i][3].ToString()))
                    {
                        Image image = ConvertToImage((byte[])DsDocument.Tables["Documents_Stagiaire"].Rows[i][2]);
                        image.Save(DsDocument.Tables["Documents_Stagiaire"].Rows[i][3].ToString() + "/" + DsDocument.Tables["Documents_Stagiaire"].Rows[i][1].ToString() + ".jpg");
                        lblchemin.Text = DsDocument.Tables["Documents_Stagiaire"].Rows[i][3].ToString() + "...";
                    }
                }

            }
                }
                if (DsDocument.Tables["Documents_PV"].Rows.Count > 0)
                {
                    //document pv
                    if (!Directory.Exists(DsDocument.Tables["Documents_PV"].Rows[DsDocument.Tables["Documents_PV"].Rows.Count - 1][3].ToString()))
                    {
                        for (int i = 0; i < DsDocument.Tables["Documents_PV"].Rows.Count; i++)
                        {
                            if (!Directory.Exists(DsDocument.Tables["Documents_PV"].Rows[i][3].ToString()))
                            {
                                Directory.CreateDirectory(DsDocument.Tables["Documents_PV"].Rows[i][3].ToString());
                            }
                        }
                        for (int i = 0; i < DsDocument.Tables["Documents_PV"].Rows.Count; i++)
                        {
                            if (Directory.Exists(DsDocument.Tables["Documents_PV"].Rows[i][3].ToString()))
                            {
                                Image image = ConvertToImage((byte[])DsDocument.Tables["Documents_PV"].Rows[i][2]);
                                image.Save(DsDocument.Tables["Documents_PV"].Rows[i][3].ToString() + "/" + DsDocument.Tables["Documents_PV"].Rows[i][1].ToString() + ".jpg");
                                lblchemin.Text = DsDocument.Tables["Documents_PV"].Rows[i][3].ToString() + "...";
                            }
                        }
                    }
                }
            }

            

        }



        private Image ConvertToImage(byte[] v)
        {
            MemoryStream stream = new MemoryStream(v);
            return Image.FromStream(stream);
        }

    }
}
