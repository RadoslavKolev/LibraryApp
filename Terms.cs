using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryApp
{
    public partial class Terms : Form
    {
        public Terms()
        {
            InitializeComponent();
         
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Terms_Load(object sender, EventArgs e)
        {
            label1.Select();
            this.FormBorderStyle = FormBorderStyle.None;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Boolean p = true;
            if (p == true)
            {
                this.Close();

            }
            else
            {
                MessageBox.Show("The rules are not accepted");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Boolean p = true;
            if (p == true)
            {
                MessageBox.Show("The rules are not accepted");
                this.Close();

            }
            else
            {
                MessageBox.Show("The rules are not accepted");
            }
        }


      
    }
}
