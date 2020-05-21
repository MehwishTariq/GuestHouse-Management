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
    public partial class Bill : Form
    {
        public Bill()
        {
            InitializeComponent();
            con.Connect();
        }
        connection con = new connection();
        private void Bill_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            string query = "Select * from Guest";
            OleDbDataAdapter da = new OleDbDataAdapter(query, con.Connect());
            da.Fill(ds, "Guest");
            string query3 = "Select * from Bill";
            OleDbDataAdapter db = new OleDbDataAdapter(query3, con.Connect());
            db.Fill(ds, "Bill");
            string query4 = "Select * from Penalty";
            OleDbDataAdapter dc = new OleDbDataAdapter(query4, con.Connect());
            dc.Fill(ds, "Penalty");

            string date = dateTimePicker1.Text;
            string guestid = "select guestId from Guest where nic=" + textBox3.Text;
            OleDbDataAdapter de = new OleDbDataAdapter(guestid, con.Connect());
            de.Fill(ds, "GuestId");
            if (textBox7.Text == "" && textBox8.Text == "")
            {
                string query2 = "Insert into Bill(guestId,rentOfServices,rentOfHouse," +
                   "totalCharges,penaltyId,creditcardNo,paymentMethod,paymentDate)" +
               "values('" + ds.Tables["GuestId"].Rows[0]["guestId"] + "','" + Convert.ToInt32(textBox2.Text) + "','" + Convert.ToInt32(textBox1.Text) +
               "','" + Convert.ToInt32(textBox4.Text) + "','" + null + "','" + Convert.ToInt32(textBox6.Text) +
               "','" + textBox5.Text + "','" + date + "')";
                OleDbCommand com = new OleDbCommand(query2, con.Connect());
                com.ExecuteNonQuery();
            }
            else
            {
                string query8 = "Insert into Penalty penaltyName,penaltyCharges) " +
                    "values('" + textBox7.Text + "','" + textBox8.Text + "')";
                OleDbCommand com2 = new OleDbCommand(query8, con.Connect());
                com2.ExecuteNonQuery();
                string penaltyId = "select max(penaltyId) from Penalty";
                OleDbDataAdapter dp = new OleDbDataAdapter(penaltyId, con.Connect());
                dp.Fill(ds, "PenId");
                string query2 = "Insert into Bill(guestId,rentOfServices,rentOfHouse," +
                   "totalCharges,penaltyId,creditcardNo,paymentMethod,paymentDate)" +
                "values('" + ds.Tables["GuestId"].Rows[0]["guestId"] + "','" + Convert.ToInt32(textBox2.Text) + "','" + Convert.ToInt32(textBox1.Text) + 
                "','" + Convert.ToInt32(textBox4.Text) + "','"+ ds.Tables["PenId"].Rows[0]["penaltyId"]
                + "','" + Convert.ToInt32(textBox6.Text) + "','" + textBox5.Text + "','" + date + "')";

                OleDbCommand com = new OleDbCommand(query2, con.Connect());
                com.ExecuteNonQuery();
            }
            home bi = new home();
            bi.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            dateTimePicker1.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            home bi = new home();
            bi.Show();
            this.Hide();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
