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
    public partial class Forgot_Form : Form
    {
        public Forgot_Form()
        {
            InitializeComponent();
        }

        Login_Form lf = new Login_Form();
        public SqlConnection myConnection = default(SqlConnection);
        public SqlCommand myCommand = default(SqlCommand);
        public SqlDataReader rdr;

        private void Form2_Load(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(100, 0, 0, 0);
        }

        private void button_RecoverClick(object sender, EventArgs e)
        {            
            try
            {              
                myConnection = new SqlConnection(lf.connection);
                myCommand = new SqlCommand("SELECT username, password FROM Accounts WHERE email = @email", myConnection);
                myConnection.Open();
                myCommand.Parameters.AddWithValue("@email", textBox1.Text);
                myCommand.ExecuteNonQuery();
                SqlDataReader rdr = myCommand.ExecuteReader();                

                if (rdr.Read())
                {
                    if (panel3.Visible == false)
                    {
                        panel3.Visible = true;
                        textBox2.Text = rdr.GetValue(0).ToString();
                        textBox3.Text = rdr.GetValue(1).ToString();
                    }
                    else
                        panel3.Visible = false;                  
                }
                else 
                {
                    if (!textBox1.Text.Contains("@"))
                        MessageBox.Show("Email must have \"@\" symbol!", "Email error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else if (textBox1.Text.EndsWith("@"))
                        MessageBox.Show("Email must have the mail site after \"@\"!", "Email error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        MessageBox.Show("Email not found!", "Email error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                myConnection.Close();

                if (myConnection.State == ConnectionState.Open)
                    myConnection.Dispose();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_BackToLoginClick(object sender, EventArgs e)
        {
            Login_Form login = new Login_Form();
            login.Show();
            this.Close();
        }
    }
}
