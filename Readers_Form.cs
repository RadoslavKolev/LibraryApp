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
    public partial class Readers_Form : Form
    {
        public Readers_Form()
        {
            InitializeComponent();
        }

        private void Readers_Form_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'readersDataSet1.Readers' table. You can move, or remove it, as needed.
            this.readersTableAdapter.Fill(this.readersDataSet1.Readers);
            panel1.BackColor = Color.FromArgb(100, 0, 0, 0);
        }
    }
}
