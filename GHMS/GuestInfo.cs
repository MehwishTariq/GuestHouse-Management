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
    public partial class GuestInfo : Form
    {
        public GuestInfo()
        {
            InitializeComponent();
            con.Connect();     
        }
        connection con = new connection();

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void GuestInfo_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nid = textBox1.Text;
            DataSet ds = new DataSet();
            string query = "Select * from Guest where nic="+nid;
            OleDbDataAdapter da = new OleDbDataAdapter(query,con.Connect());
            da.Fill(ds, "Guest");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = ds.Tables[0].TableName;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            home bi = new home();
            bi.Show();
            this.Hide();
        }
    }
}
