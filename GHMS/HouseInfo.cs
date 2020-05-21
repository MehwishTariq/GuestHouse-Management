using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace GHMS
{
    public partial class HouseInfo : Form
    {
        connection con = new connection();
        public HouseInfo()
        {
            InitializeComponent();
            con.Connect();

        }
       
       
        private void HouseInfo_Load(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            home bi = new home();
            bi.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            string query = "Select * from Service";
            OleDbDataAdapter da = new OleDbDataAdapter(query, con.Connect());
            da.Fill(ds, "Service");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = ds.Tables[0].TableName;
        }
    }
}
