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
    public partial class Form_MainAdmin : Form
    {
        public Form_MainAdmin()
        {
            InitializeComponent();
        }

        private void MainAdmin_Form_Load(object sender, EventArgs e)
        {
       
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Do you want to exit the app?", "Exit", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)          
                Application.Exit();
            
        }

        private void accountsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Accounts account = new Form_Accounts();
            account.Show();
            this.Hide();
        }

        private void readersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Readers readers = new Form_Readers();
            readers.Show();
            this.Hide();
        }

        private void genreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Genre genre = new Form_Genre();
            genre.Show();
            this.Hide();
        }

        private void booksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Books book = new Form_Books();
            book.Show();
            this.Hide();
        }

        private void backToLoginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Login login = new Form_Login();
            login.Show();
            this.Hide();
        }

        private void catalogueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Catalogue catalog= new Form_Catalogue();
            catalog.Show();
            this.Hide();
        }

        private void borrowedBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Borrowed borrow = new Form_Borrowed();
            borrow.Show();
            this.Hide();
        }
    }
}
