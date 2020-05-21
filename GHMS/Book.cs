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
    public partial class Book : Form
    {
        public Book()
        {
            InitializeComponent();
            con.Connect();
        }
        connection con = new connection();
        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            string query = "Select * from Guest";
            OleDbDataAdapter da = new OleDbDataAdapter(query, con.Connect());
            da.Fill(ds, "Guest");
            string query3 = "Select * from Reservation";
            OleDbDataAdapter db = new OleDbDataAdapter(query3, con.Connect());
            db.Fill(ds, "Reservation");

            string indate = dateTimePicker1.Text;
            string outdate = dateTimePicker2.Text;
            string resvdate = dateTimePicker3.Text;
            string guestid = "select guestId from Guest where nic=" + textBox1.Text;
            OleDbDataAdapter dc = new OleDbDataAdapter(guestid,con.Connect());
            dc.Fill(ds, "GuestId");
            string query2 = "Insert into Reservation(guestId,reservationDate,noOfGuests," +
               "noOfServices,checkIn,checkOut,advance,due)" +
           "values('" + ds.Tables["GuestId"].Rows[0]["guestId"] + "','" + resvdate + "','" + Convert.ToInt32(textBox2.Text) + "','" + Convert.ToInt32(textBox3.Text) + "','"
           + indate + "','" + outdate + "','" + Convert.ToInt32(textBox4.Text) + "','" + Convert.ToInt32(textBox5.Text) + "')";

            OleDbCommand com = new OleDbCommand(query2, con.Connect());
            com.ExecuteNonQuery();
            MessageBox.Show("Reservation Has Been Made!");
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
            dateTimePicker1.Text = "";
            dateTimePicker2.Text = "";
            dateTimePicker3.Text = "";

        }

        private void button3_Click(object sender, EventArgs e)
        {
            home bi = new home();
            bi.Show();
            this.Hide();
        }

        private void Book_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
