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
    public partial class Form_Forgot : Form
    {
        public Form_Forgot()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(100, 0, 0, 0);
        }

        private void button_RecoverClick(object sender, EventArgs e)
        {
            panel3.Visible = true;
        }

        private void button_BackToLoginClick(object sender, EventArgs e)
        {
            Form_Login login = new Form_Login();
            login.Show();
            this.Close();
        }
    }
}
