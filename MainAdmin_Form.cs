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
    public partial class MainAdmin_Form : Form
    {
        public MainAdmin_Form()
        {
            InitializeComponent();
        }

        private void MainAdmin_Form_Load(object sender, EventArgs e)
        {
       

        }


        private void изходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
