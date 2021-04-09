using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace LibraryApp
{
    public partial class Form_Books : Form
    {
        public Form_Books()
        {
            InitializeComponent();
        }

        public SqlConnection myConnection = default(SqlConnection);
        public SqlCommand myCommand = default(SqlCommand);
        public SqlDataAdapter adapter, adapter2;
        Form_Login lf = new Form_Login();

        private void Form_Books_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'libraryDBDataSet1.Books' table. You can move, or remove it, as needed.
            this.booksTableAdapter1.Fill(this.libraryDBDataSet1.Books);
            // TODO: This line of code loads data into the 'genreDBDataSet1.Genre' table. You can move, or remove it, as needed.
            this.genreTableAdapter.Fill(this.genreDBDataSet1.Genre);
            panel1.BackColor = Color.FromArgb(100, 0, 0, 0);
            DisplayData();
        }

        public void DisplayData()
        {
            myConnection = new SqlConnection(lf.connection);
            myConnection.Open();
            DataTable dataTable = new DataTable();
            DataTable dataTable2 = new DataTable();
            adapter = new SqlDataAdapter("SELECT * FROM Books", myConnection);
            adapter2 = new SqlDataAdapter("SELECT * FROM Genre", myConnection);
            adapter.Fill(dataTable);
            adapter2.Fill(dataTable2);
            dataGridView1.DataSource = dataTable;
            dataGridView2.DataSource = dataTable2;
            myConnection.Close();
        }

    }
}
