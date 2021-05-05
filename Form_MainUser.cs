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

        private void backToLoginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Login login = new Form_Login();
            login.Show();
            this.Hide();
        }

        private void catalogueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Catalogue catalog = new Form_Catalogue();
            catalog.Show();
            this.Hide();
        }

        private void borrowABookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_BorrowedClient borrow = new Form_BorrowedClient();
            borrow.Show();
            this.Hide();
        }

        private void returnABookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Return ret = new Form_Return();
            ret.Show();
            this.Hide();
        }

        private void yourBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_YourBooks book = new Form_YourBooks();
            book.Show();
            this.Hide();
        }
    }
}
