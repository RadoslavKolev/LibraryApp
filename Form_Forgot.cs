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
    public partial class Form_Forgot : Form
    {
        public Form_Forgot()
        {
            InitializeComponent();
        }

        Form_Login lf = new Form_Login();
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
                myConnection = new SqlConnection(lf.connection);
                myCommand = new SqlCommand("SELECT username FROM Accounts WHERE username = '" + textBox4.Text + "'", myConnection);
                myConnection.Open();

                SqlDataAdapter sda = new SqlDataAdapter(myCommand);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                myCommand.ExecuteNonQuery();

                if (textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "")
                    MessageBox.Show("The fields cannot be empty!", "Empty fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (textBox4.Text == textBox5.Text || textBox4.Text == textBox6.Text)
                    MessageBox.Show("Username is still the same!", "Same username", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (dt.Rows.Count > 0)
                {
                    if (textBox5.Text != textBox6.Text)
                        MessageBox.Show("Usernames dont't match!", "Usernames don't match", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        SqlCommand updateCommand = new SqlCommand("UPDATE Accounts SET username = '" + textBox5.Text + "' WHERE username = '" + textBox4.Text + "'", myConnection);
                        SqlDataAdapter sda2 = new SqlDataAdapter(updateCommand);
                        DataTable dt2 = new DataTable();
                        sda2.Fill(dt2);
                        updateCommand.ExecuteNonQuery();
                        MessageBox.Show("Username changed successfully!");
                    }
                }
                else
                    MessageBox.Show("Username not found!", "Username not found", MessageBoxButtons.OK, MessageBoxIcon.Error);


                myConnection.Close();

                if (myConnection.State == ConnectionState.Open)
                    myConnection.Dispose();

                textBox5.Clear();
                textBox6.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button_ChangePasswordClick(object sender, EventArgs e)
        {
            try
            {
                myConnection = new SqlConnection(lf.connection);
                myCommand = new SqlCommand("SELECT password FROM Accounts WHERE password = '" + textBox7.Text + "'", myConnection);
                myConnection.Open();
                SqlDataAdapter sda = new SqlDataAdapter(myCommand);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                myCommand.ExecuteNonQuery();

                if (textBox7.Text == "" || textBox8.Text == "" || textBox9.Text == "")
                    MessageBox.Show("The fields cannot be empty!", "Empty fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (textBox7.Text == textBox8.Text || textBox7.Text == textBox9.Text)
                    MessageBox.Show("The password is still the same!", "Same password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (dt.Rows.Count > 0)
                {
                    if (textBox8.Text != textBox9.Text)
                        MessageBox.Show("Passwords dont't match!", "Passwords don't match", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        SqlCommand updateCommand = new SqlCommand("UPDATE Accounts SET password = '" + textBox8.Text + "' WHERE password = '" + textBox7.Text + "'", myConnection);
                        SqlDataAdapter sda2 = new SqlDataAdapter(updateCommand);
                        DataTable dt2 = new DataTable();
                        sda2.Fill(dt2);
                        updateCommand.ExecuteNonQuery();
                        MessageBox.Show("Password changed successfully!");
                    }
                }
                else
                    MessageBox.Show("Password not found!", "Password not found", MessageBoxButtons.OK, MessageBoxIcon.Error);

                myConnection.Close();

                if (myConnection.State == ConnectionState.Open)
                    myConnection.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            button4.Visible = true;
            if (textBox7.Text == "")
                button4.Visible = false;
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

            if (textBox8.Text == textBox9.Text && (textBox8.Text != "" || textBox9.Text != ""))
            {
                label11.ForeColor = Color.LightGreen;
                label12.ForeColor = Color.LightGreen;
            }

            if (!textBox8.Text.Equals(textBox9.Text))
            {
                label11.ForeColor = Color.White;
                label12.ForeColor = Color.White;
            }

            if (textBox9.Text == "")
                button6.Visible = false;
        }

     

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox8.UseSystemPasswordChar == true)
                textBox8.UseSystemPasswordChar = false;
            else
                textBox8.UseSystemPasswordChar = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox9.UseSystemPasswordChar == true)
                textBox9.UseSystemPasswordChar = false;
            else
                textBox9.UseSystemPasswordChar = true;
        }

        private void button_BackToLoginClick(object sender, EventArgs e)
        {
            lf.Show();
            this.Close();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            if (textBox7.UseSystemPasswordChar == true)
                textBox7.UseSystemPasswordChar = false;
            else
                textBox7.UseSystemPasswordChar = true;
        }
    }
}
