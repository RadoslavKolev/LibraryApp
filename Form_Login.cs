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

namespace LibraryApp
{
    public partial class Form_Login : Form
    {
        public static String LoginName { get; set; }
        public Form_Login()
        {
            InitializeComponent();
        }

        //public string connection = @" Data Source = (localdb)\MSSQLLocalDB;AttachDbFilename=D:\C# projects\LibraryApp\LibraryDB.mdf;Integrated Security = True";
        public string connection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\ТУ Варна\Семестър 6\ТСП - проект\LibraryApp\LibraryDB.mdf;Integrated Security=True";
        public SqlConnection myConnection = default(SqlConnection);
        public SqlCommand myCommand = default(SqlCommand);
        private void Form1_Load(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(100, 0, 0, 0);
        }

        private void label_termsClick(object sender, EventArgs e)
        {
            Form_Terms terms = new Form_Terms();
            terms.Show();
        }

        private void label_forgotClick(object sender, EventArgs e)
        {
            Form_Forgot forgot = new Form_Forgot();
            forgot.Show();
            this.Hide();
        }

        private void button_SignInClick(object sender, EventArgs e)
        {
            try
            {
                myConnection = new SqlConnection(connection);
                myCommand = new SqlCommand("SELECT username, password FROM Accounts WHERE username = @username AND password = @password", myConnection);
                SqlParameter username = new SqlParameter("@username", SqlDbType.VarChar);
                SqlParameter password = new SqlParameter("@password", SqlDbType.VarChar);

                username.Value = textBox1.Text;
                password.Value = textBox2.Text;

                myCommand.Parameters.Add(username);
                myCommand.Parameters.Add(password);

                myCommand.Connection.Open();
                SqlDataReader myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection);

                if (myReader.Read() == true)
                { 
                    if(textBox1.Text == "admin" && textBox2.Text == "admin")
                    {
                        MessageBox.Show("Admin Login Successfull!", "Login Success");
                        Form_MainAdmin admin = new Form_MainAdmin();
                        admin.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Login Successfull!", "Login Success");
                        Form_Login.LoginName = textBox1.Text;
                        Form_MainUser user = new Form_MainUser();
                        user.Show();
                        this.Hide();
                    }
                }
                else
                {
                    if (textBox1.Text == "" && textBox2.Text == "")
                        MessageBox.Show("Username and Password cannot be empty!", "Login Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else if (textBox1.Text == "")
                        MessageBox.Show("Username cannot be empty!", "Login Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else if (textBox2.Text == "")
                        MessageBox.Show("Password cannot be empty!", "Login Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);                   
                    else if(textBox1.Text != username.ToString())
                        MessageBox.Show("Username or Password not found!", "Login Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        MessageBox.Show("Login failed! Try again!", "Login Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);                   
                }

                if (myConnection.State == ConnectionState.Open)
                    myConnection.Dispose();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_SignUpClick(object sender, EventArgs e)
        {
            try
            {
                if(textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "")
                    MessageBox.Show("You must fill all of the fields!", "Register Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (textBox4.Text.Length < 5 || textBox5.Text.Length < 5 || textBox6.Text.Length < 5 || textBox7.Text.Length < 5)
                    MessageBox.Show("The fields can't be lower than 5 symbols!", "Register Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if(!textBox4.Text.Contains("@"))
                    MessageBox.Show("Email must have \"@\" symbol!", "Register Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (textBox4.Text.EndsWith("@"))
                    MessageBox.Show("Email must have the mail site after \"@\"!", "Register Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (textBox5.Text != textBox6.Text)
                    MessageBox.Show("Passwords don't match!", "Register Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (textBox3.Text.Length > 30)
                    MessageBox.Show("Username can't have more than 30 characters!", "Register Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (textBox4.Text.Length > 50)
                    MessageBox.Show("Email can't have more than 50 characters!", "Register Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (textBox5.Text.Length > 256)
                    MessageBox.Show("Password can't have more than 256 characters!", "Register Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (textBox7.Text.Length > 50)
                    MessageBox.Show("Your name can't be higher than 50 characters", "Register Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if(!textBox7.Text.Contains(" "))
                    MessageBox.Show("Please enter your both names!", "Register Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {

                    myConnection = new SqlConnection(connection);

                    myCommand = new SqlCommand("INSERT INTO Accounts(fullname, email, username, password) VALUES(@fullname, @email, @username, @password)", myConnection);
                    SqlCommand checkEmail = new SqlCommand("SELECT email FROM Accounts WHERE email = @email ", myConnection);
                    SqlCommand checkUsername = new SqlCommand("SELECT username FROM Accounts WHERE username = @username ", myConnection);

                    myConnection.Open();
                    myCommand.Parameters.AddWithValue("@fullname", textBox7.Text);
                    myCommand.Parameters.AddWithValue("@email", textBox4.Text);
                    myCommand.Parameters.AddWithValue("@username", textBox3.Text);                   
                    myCommand.Parameters.AddWithValue("@password", textBox5.Text); 
                    
                    checkEmail.Parameters.AddWithValue("@email", textBox4.Text);
                    checkUsername.Parameters.AddWithValue("@username", textBox3.Text);

                    SqlDataReader sdr = checkEmail.ExecuteReader();

                    if (sdr.HasRows)
                        MessageBox.Show("Email is already taken", "Register Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        sdr.Close();
                  
                    SqlDataReader sdr2 = checkUsername.ExecuteReader();

                    if (sdr2.HasRows)
                        MessageBox.Show("Username is already taken", "Register Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        sdr2.Close();

                    myCommand.ExecuteNonQuery();
                    myConnection.Close();

                    MessageBox.Show("Account created successfully!");

                    if (myConnection.State == ConnectionState.Open)
                        myConnection.Dispose();

                    if (myConnection.State == ConnectionState.Open)
                        myConnection.Dispose();

                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                    textBox6.Clear();
                    textBox7.Clear();
                    button3.Visible = false;
                    button4.Visible = false;
                    label9.ForeColor = Color.White;
                    label10.ForeColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

            button3.Visible = true;           

            if (textBox5.Text.Length >= 0 && textBox5.Text.Length <= 5)
                button3.BackColor = Color.Red;
            else if (textBox5.Text.Length > 5 && textBox5.Text.Length <= 10)
                button3.BackColor = Color.Yellow;
            else
                button3.BackColor = Color.Green;

            if (textBox5.Text == "")
                button3.Visible = false;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            button4.Visible = true;

            if (textBox6.Text.Length >= 0 && textBox6.Text.Length <= 5)
                button4.BackColor = Color.Red;
            else if (textBox6.Text.Length > 5 && textBox6.Text.Length <= 10)
                button4.BackColor = Color.Yellow;
            else
                button4.BackColor = Color.Green;

            if (textBox5.Text == textBox6.Text && (textBox5.Text != "" || textBox6.Text != ""))
            {
                label9.ForeColor = Color.LightGreen;
                label10.ForeColor = Color.LightGreen;
            }

            if (!textBox5.Text.Equals(textBox6.Text))
            {
                label9.ForeColor = Color.White;
                label10.ForeColor = Color.White;
            }

            if (textBox6.Text == "")
                button4.Visible = false;

        }

        private void button3_ShowPassword(object sender, EventArgs e)
        {
            if (textBox5.UseSystemPasswordChar == true)
                textBox5.UseSystemPasswordChar = false;
            else
                textBox5.UseSystemPasswordChar = true;
        }

        private void button4_ShowPassword(object sender, EventArgs e)
        {
            if (textBox6.UseSystemPasswordChar == true)
                textBox6.UseSystemPasswordChar = false;
            else
                textBox6.UseSystemPasswordChar = true;
        }

        private void button5_ShowPassword(object sender, EventArgs e)
        {
            if (textBox2.UseSystemPasswordChar == true)
                textBox2.UseSystemPasswordChar = false;
            else
                textBox2.UseSystemPasswordChar = true;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            button5.Visible = true;
            if(textBox2.Text == "")
                button5.Visible = false;
        }
   
    }
}
