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
using System.Text.RegularExpressions;

namespace LibraryApp
{
    public partial class Form_Borrowed : Form
    {
        public Form_Borrowed()
        {
            InitializeComponent();
        }
        public SqlConnection myConnection = default(SqlConnection);
        public SqlCommand myCommand = default(SqlCommand);
        public SqlDataAdapter adapter, adapter2;
        Form_Login lf = new Form_Login();
        private void button5_Click(object sender, EventArgs e)
        {
            Form_MainAdmin admin = new Form_MainAdmin();
            admin.Show();
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!textBox1.Text.Equals(" "))
            {
                String p = textBox1.Text;

                myConnection = new SqlConnection(lf.connection);
                myConnection.Open();
                DataTable dataTable = new DataTable();
                adapter = new SqlDataAdapter("SELECT * FROM Borrowed where reader_code LIKE '%" + p + "%'", myConnection);
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
                myConnection.Close();
            }
        }

        private void Form_Borrowed_Load(object sender, EventArgs e)
        {
            DisplayData();
        }

        public void DisplayData()
        {
            myConnection = new SqlConnection(lf.connection);
            myConnection.Open();
            DataTable dataTable = new DataTable();
            adapter = new SqlDataAdapter("SELECT * FROM Borrowed", myConnection);
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            myConnection.Close();
        }
    }
}
