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
    public partial class Form_MainUser : Form
    {
        public Form_MainUser()
        {
            InitializeComponent();
        }

        private void MainUser_Form_Load(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Do you want to exit the app?", "Exit", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
                Application.Exit();
        }
    }
}
