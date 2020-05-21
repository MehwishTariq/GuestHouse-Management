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
    public partial class Updatedata : Form
    {
        public Updatedata()
        {
            InitializeComponent();
            con.Connect();
        }
        connection con = new connection();
        private void Updatedata_Load(object sender, EventArgs e)
        {
            string[] fields = new string[9];
            fields[0] = "First name";
            fields[1] = "Last name";
            fields[2] = "Contact";
            fields[3] = "Country";
            fields[4] = "City";
            fields[5] = "House No";
            fields[6] = "Area";
            fields[7] = "zip Code";
            fields[8] = "Gender";
            comboBox1.Items.AddRange(fields);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
          //  string query = "Select * from Guest";
           // OleDbDataAdapter da = new OleDbDataAdapter(query, con.Connect());
            //da.Fill(ds, "Guest");
            
            string gid = "select guestId from Guest where nic=" + textBox2.Text;
            OleDbDataAdapter dc = new OleDbDataAdapter(gid, con.Connect());
            dc.Fill(ds, "GuestId");
            string update = "update Guest Set " + comboBox1.SelectedItem + "="+textBox1.Text+" from Guest where guestId="+ds.Tables["GuestId"].Rows[0]["guestId"];
            OleDbCommand com2 = new OleDbCommand(update, con.Connect());
            com2.ExecuteNonQuery();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label2.Text = Convert.ToString(comboBox1.SelectedItem);
        }
    }
}
