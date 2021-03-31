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
    public partial class Login_Form : Form
    {
        public Login_Form()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(100, 0, 0, 0);
        }

        private void label_termsClick(object sender, EventArgs e)
        {
            Terms_Form terms = new Terms_Form();
            terms.Show();
        }

        private void label_forgotClick(object sender, EventArgs e)
        {
            Forgot_Form forgot = new Forgot_Form();
            forgot.Show();
            this.Hide();
        }
    }
}
