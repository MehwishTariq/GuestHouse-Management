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
    public partial class GuestDetail : Form
    {
        public GuestDetail()
        {
            InitializeComponent();
            con.Connect();
          
        }

        connection con = new connection();
        
        private void button1_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();

            string query = "Select * from Guest";
            OleDbDataAdapter da = new OleDbDataAdapter(query, con.Connect());
            da.Fill(ds, "Guest");

            string query1 = "Insert into Address(country,city,houseNo,area,zipCode) " +
           "values('"+textBox5.Text+ "','" + textBox6.Text + "','" + Convert.ToInt32(textBox7.Text) + "','" + textBox8.Text + "','" + textBox9.Text + "')";
            OleDbCommand com = new OleDbCommand(query1, con.Connect());
            com.ExecuteNonQuery();
            string queryA = "Select max(addId) from Address";
            OleDbDataAdapter dc = new OleDbDataAdapter(queryA, con.Connect());
            dc.Fill(ds, "AddId");

          
            


            string gender = Convert.ToString(comboBox1.SelectedItem);

            string query2 = "Insert into Guest(firstName,lastName,gender,contact,nic,addId) " +
            "values('"+textBox1.Text+"','"+textBox2.Text +"','" +gender +"','" + Convert.ToInt32(textBox4.Text)+"','" + textBox3.Text+"','"+
            ds.Tables["AddId"].Rows[0]["max(addId)"] + "')";
            OleDbCommand com1 = new OleDbCommand(query2, con.Connect());
            com1.ExecuteNonQuery();

            MessageBox.Show("Guest Details Have Been Entered!");
            Book bi = new Book();
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
            textBox9.Text = "";

        }

        private void button3_Click(object sender, EventArgs e)
        {
            home bi = new home();
            bi.Show();
            this.Hide();
        }

        private void GuestDetail_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Male");
            comboBox1.Items.Add("Female");
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
