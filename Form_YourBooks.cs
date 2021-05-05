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
    public partial class Form_YourBooks : Form
    {
        public Form_YourBooks()
        {
            InitializeComponent();
         
        }
      
        public SqlConnection myConnection = default(SqlConnection);
        public SqlCommand myCommand = default(SqlCommand);
        public SqlDataAdapter adapter, adapter2;
        Form_Login lf = new Form_Login();

        private void Form_YourBooks_Load(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(100, 0, 0, 0);
            DisplayData();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form_MainUser user = new Form_MainUser();
            user.Show();
            this.Hide();
        }
     
        private void DisplayData()
        {
            myConnection = new SqlConnection(lf.connection);
            myConnection.Open();
            DataTable dataTable = new DataTable();
            adapter = new SqlDataAdapter("SELECT book_name,book_genre,book_author,borrow_returned FROM Borrowed bo join Books b on bo.book_code=b.book_code where reader_code=(SELECT Accounts.code FROM Accounts WHERE username='" + Form_Login.LoginName + "') ", myConnection);
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            myConnection.Close();
        }
    }
}
