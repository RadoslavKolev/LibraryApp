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
            textBox7.UseSystemPasswordChar = false;
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
                    if (textBox1.Text == "")
                        MessageBox.Show("Email cannot be empty!", "Empty fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else if (!textBox1.Text.Contains("@"))
                        MessageBox.Show("Email must have \"@\" symbol!", "Missing @ symbol", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else if (textBox1.Text.EndsWith("@"))
                        MessageBox.Show("Email must have the mail site after \"@\"!", "Missing site", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        MessageBox.Show("Email not found!", "Email error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                rdr.Close();
                myConnection.Close();

                if (myConnection.State == ConnectionState.Open)
                    myConnection.Dispose();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_ChangeUsernameClick(object sender, EventArgs e)
        {
            try
            {
                if (textBox5.Text == textBox6.Text)
                {
                    myConnection = new SqlConnection(lf.connection);
                    myCommand = new SqlCommand("UPDATE Accounts SET username = @username WHERE email = @email", myConnection);
                    myConnection.Open();
                    myCommand.Parameters.AddWithValue(parameterName: "@username", value: textBox5.Text);
                    myCommand.Parameters.AddWithValue(parameterName: "@email", value: textBox4.Text);
                    rdr = myCommand.ExecuteReader();
                    rdr.Read();

                    if (textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "")
                        MessageBox.Show("The fields cannot be empty!", "Empty fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else if (!textBox4.Text.Contains("@"))
                        MessageBox.Show("Email must have \"@\" symbol!", "Missing @ symbol", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else if (textBox4.Text.EndsWith("@"))
                        MessageBox.Show("Email must have the mail site after \"@\"!", "Missing site", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        MessageBox.Show("Username change successful");
                    }


                    rdr.Close();
                    myCommand.ExecuteNonQuery();
                    myConnection.Close();

                    if (myConnection.State == ConnectionState.Open)
                        myConnection.Dispose();
                }
                else
                {
                    MessageBox.Show("Usernames did not match or email doesn't exist", "Error Passwords", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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

        private void button3_Click(object sender, EventArgs e) //change password
        {
            try
            {
                if (textBox8.Text == textBox9.Text)
                {
                    myConnection = new SqlConnection(lf.connection);
                    myCommand = new SqlCommand("UPDATE Accounts SET password = @password WHERE email = @email", myConnection);
                    myConnection.Open();
                    myCommand.Parameters.AddWithValue(parameterName: "@password", value: textBox8.Text);
                    myCommand.Parameters.AddWithValue(parameterName: "@email", value: textBox7.Text);
                    rdr = myCommand.ExecuteReader();
                    rdr.Read();

                    if (textBox7.Text == "" || textBox8.Text == "" || textBox9.Text == "")
                        MessageBox.Show("The fields cannot be empty!", "Empty fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else if (!textBox7.Text.Contains("@"))
                        MessageBox.Show("Email must have \"@\" symbol!", "Missing @ symbol", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else if (textBox7.Text.EndsWith("@"))
                        MessageBox.Show("Email must have the mail site after \"@\"!", "Missing site", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        MessageBox.Show("Password change successful");
                    }


                    rdr.Close();
                    myCommand.ExecuteNonQuery();
                    myConnection.Close();

                    if (myConnection.State == ConnectionState.Open)
                        myConnection.Dispose();
                }
                else
                {
                    MessageBox.Show("Passwords did not match or email doesn't exist", "Error Passwords", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            button5.Visible = true;

            if (textBox8.Text.Length >= 0 && textBox8.Text.Length <= 5)
                button5.BackColor = Color.Red;
            else if (textBox8.Text.Length > 5 && textBox8.Text.Length <= 10)
                button5.BackColor = Color.Yellow;
            else
                button5.BackColor = Color.Green;

            if (textBox8.Text == "")
                button5.Visible = false;
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            button6.Visible = true;

            if (textBox9.Text.Length >= 0 && textBox9.Text.Length <= 5)
                button6.BackColor = Color.Red;
            else if (textBox9.Text.Length > 5 && textBox9.Text.Length <= 10)
                button6.BackColor = Color.Yellow;
            else
                button6.BackColor = Color.Green;

            if (textBox9.Text == textBox8.Text && (textBox9.Text != "" || textBox8.Text != ""))
            {
                label9.ForeColor = Color.LightGreen;
                label10.ForeColor = Color.LightGreen;
            }

            if (!textBox9.Text.Equals(textBox8.Text))
            {
                label9.ForeColor = Color.White;
                label10.ForeColor = Color.White;
            }

            if (textBox9.Text == "")
                button6.Visible = false;
        }
    }
}
