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
    public partial class Form_Return : Form
    {
        public Form_Return()
        {
            InitializeComponent();
        }
        public SqlConnection myConnection = default(SqlConnection);
        public SqlCommand myCommand = default(SqlCommand);
        public SqlDataAdapter adapter, adapter2;
        Form_Login lf = new Form_Login();

        private void button4_Click(object sender, EventArgs e)
        {
            Form_MainUser user = new Form_MainUser();
            user.Show();
            this.Close();
        }

        private void Form_Return_Load(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(100, 0, 0, 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string p = "Yes";
              
                myConnection = new SqlConnection(lf.connection);
                myCommand = new SqlCommand("UPDATE Borrowed SET borrow_returned='"+p+ "' WHERE book_code = (Select Books.book_code from Books where book_name = '" + textBox2.Text + "')", myConnection);
                myConnection.Open();
                if (textBox1.Text == "" || textBox2.Text == "")
                    MessageBox.Show("The fields cannot be empty!", "Empty fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    myCommand.ExecuteNonQuery();
                    myConnection.Close();

                    MessageBox.Show("Book Returned successful!");
               
                }

                if (myConnection.State == ConnectionState.Open)
                    myConnection.Dispose();

                textBox1.Clear();
                textBox2.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
