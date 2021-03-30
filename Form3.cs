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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(100, 0, 0, 0);
            label1.Text = "Register";
            label2.BackColor = Color.FromArgb(100, 0, 0, 0);
            label2.Font = new Font(label2.Font, FontStyle.Underline);
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Form_Login frm1 = new Form_Login();
            frm1.Show();
            this.Hide();
        }
    }
}
