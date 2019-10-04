using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Collections;
using System.Windows.Forms.DataVisualization.Charting;

namespace Projet_Archivage
{
    class DBManager
    {
        SqlConnection Connection;
        public SqlCommand Command;
        SqlDataAdapter Adapter;
        public DBManager()
        {
            Connection = new SqlConnection(@"Data Source=.;Initial Catalog=ArchiveDB;Integrated Security=True");
            if (ConnectionState.Closed == Connection.State)
                Connection.Open();
        }
        //Close connection
        public void Close_Connection()
        {
            if (ConnectionState.Open == Connection.State)
                Connection.Close();
        }
        //
        //Open connection
        public void Open_Connection()
        {
            if (ConnectionState.Closed == Connection.State && Connection.State != ConnectionState.Broken)
                Connection.Open();
        }
        //For query
        public void Query(string query)
        {
         Command = new SqlCommand(query,Connection);
        }
        //Execute non query
        public void ExecuteQuery()
        {

                Command.ExecuteNonQuery();
        }
        // to fill Dataset
        public void Fill_DataSet(DataSet dataSet,string TableName)
        {
            Adapter = new SqlDataAdapter(Command);
            Adapter.Fill(dataSet,TableName);
        }
        // to fill Datagridview
        public void Fill_DataGridView(DataGridView dataGridView, DataTable dataTable)
        {
            dataGridView.DataSource = dataTable;
        }
        // to fill combobox
        public void Fill_Combobox(ComboBox comboBox,DataTable dataTable,string display,string Value)
        {
            comboBox.DataSource = dataTable;
            comboBox.ValueMember = Value;
            comboBox.DisplayMember = display;
        }
        public int SearchForExistence(DataTable dataTable,string Value,string Champs)
        {
            for (int i=0;i<dataTable.Rows.Count;i++)
            {
                if (dataTable.Rows[i][Champs].ToString() == Value)
                {
                    return i;
                }
            }
            return -1;
        }
        public int SearchForExistence(DataTable dataTable, string Value1,string Value2, string Champs1, string Champs2)
        {
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                if (dataTable.Rows[i][Champs1].ToString() == Value1 && dataTable.Rows[i][Champs2].ToString() == Value2)
                {
                    return i;
                }
            }
            return -1;
        }
        public int SearchForExistence(DataTable dataTable, string Value1, string Value2, string Value3, string Champs1, string Champs2, string Champs3)
        {
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                if (dataTable.Rows[i][Champs1].ToString() == Value1 && dataTable.Rows[i][Champs2].ToString() == Value2 && dataTable.Rows[i][Champs3].ToString() == Value3)
                {
                    return i;
                }
            }
            return -1;
        }
        public int ExeuteScalar()
        {
            if (ConnectionState.Open == Connection.State)
            {
               return (int) Command.ExecuteScalar();
            }
            return 0;
        }
        public bool Statue()
        {
            if (Connection.State == ConnectionState.Broken)
            {
                return true;
            }
            return false;
        }
        public void Chart_Filler(Chart chart)
        {
            try
            {
                Open_Connection();
                ArrayList ChartX = new ArrayList();
                ArrayList ChartY = new ArrayList();
                DataSet dsChart = new DataSet();
                Query("ChartFiller");
                Fill_DataSet(dsChart,"Chart");
                Close_Connection();

                for (int i = 0; i < dsChart.Tables["Chart"].Rows.Count; i++)
                {
                    ChartX.Add(dsChart.Tables["Chart"].Rows[i][0].ToString());
                    ChartY.Add(int.Parse(dsChart.Tables["Chart"].Rows[i][1].ToString()));
                }
                chart.Series[0].Points.DataBindXY(ChartX, ChartY);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fill Chart Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
