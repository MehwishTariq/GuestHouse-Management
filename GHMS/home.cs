using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GHMS
{
    public partial class home : Form
    {
        public home()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

         private void button4_Click(object sender, EventArgs e)
        {
            Bill bi = new Bill();
            bi.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            GuestDetail f = new GuestDetail();
            f.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Reservation r = new Reservation();
            r.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Book b = new Book();
            b.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            HouseInfo h = new HouseInfo();
            h.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GuestInfo g = new GuestInfo();
            g.Show();
            this.Hide();
        }

        private void home_Load(object sender, EventArgs e)
        {

        }
    }
}
