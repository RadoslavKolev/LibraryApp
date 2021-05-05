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
    public partial class Form_BorrowedClient : Form
    {
        public Form_BorrowedClient()
        {
            InitializeComponent();

        }
        public SqlConnection myConnection = default(SqlConnection);
        public SqlCommand myCommand = default(SqlCommand);
        public SqlDataAdapter adapter, adapter2;
        Form_Login lf = new Form_Login();

        private void Form_BorrowedClient_Load(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(100, 0, 0, 0);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form_MainUser user = new Form_MainUser();
            user.Show();
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
                    MessageBox.Show("The first 4 fields cannot be empty", "Empty fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
         
                else
                {
                    string p = "No";
                    
                    myConnection = new SqlConnection(lf.connection);
                    myCommand = new SqlCommand("INSERT INTO Borrowed (reader_code,book_code,loan_date,borrow_returned) VALUES((SELECT Accounts.code FROM Accounts WHERE username='"+textBox1.Text+"'),(Select Books.book_code from Books where book_name = '" + textBox2.Text + "'), '"+textBox3.Text+"', '"+p+"')", myConnection);                
                    myConnection.Open();
            

                    myCommand.ExecuteNonQuery();
                    MessageBox.Show("Borrow successfully!");

                    myConnection.Close();
             

                    if (myConnection.State == ConnectionState.Open)
                        myConnection.Dispose();

                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                  
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
