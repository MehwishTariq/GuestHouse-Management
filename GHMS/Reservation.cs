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
    public partial class Reservation : Form
    {
        public Reservation()
        {
            InitializeComponent();
            con.Connect();
        }
        connection con = new connection();
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nic = textBox1.Text;
            DataSet ds = new DataSet();
            string query = "Select * from Reservation r, guest g where r.guestId=g.guestId and g.nic=" + nic;
            OleDbDataAdapter da = new OleDbDataAdapter(query, con.Connect());
            da.Fill(ds, "Reservation");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = ds.Tables[0].TableName;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Reservation_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            home bi = new home();
            bi.Show();
            this.Hide();
        }
    }
}
