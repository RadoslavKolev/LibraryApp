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
    public partial class Form_Accounts : Form
    {
        public Form_Accounts()
        {
            InitializeComponent();
        }

        public SqlConnection myConnection = default(SqlConnection);
        public SqlCommand myCommand = default(SqlCommand);
        public SqlDataAdapter adapter;
        Form_Login lf = new Form_Login();

        private void Account_Form_Load(object sender, EventArgs e)
        {
            this.accountsTableAdapter.Fill(this.libraryDBDataSet.Accounts);
            panel1.BackColor = Color.FromArgb(100, 0, 0, 0);
            DisplayData();
        }

        private void DisplayData()
        {
            myConnection = new SqlConnection(lf.connection);
            myConnection.Open();
            DataTable dataTable = new DataTable();
            adapter = new SqlDataAdapter("SELECT * FROM Accounts", myConnection);
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            myConnection.Close();
        }

        private void backToMainButton_Click(object sender, EventArgs e)
        {
            Form_MainAdmin admin = new Form_MainAdmin();
            admin.Show();
            this.Close();
        }

        private void button_InsertClick(object sender, EventArgs e)
        {
            try
            {
                if (textBox3.Text == "" || textBox4.Text == "")
                    MessageBox.Show("Username and Password cannot be empty!", "Register Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (textBox1.Text.Length < 5 || textBox2.Text.Length < 5 || textBox4.Text.Length < 5)
                    MessageBox.Show("The fields can't be lower than 5 symbols!", "Register Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (!textBox2.Text.Contains("@"))
                    MessageBox.Show("Email must have \"@\" symbol!", "Register Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (textBox2.Text.EndsWith("@"))
                    MessageBox.Show("Email must have the mail site after \"@\"!", "Register Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);             
                else if (!textBox1.Text.Contains(" "))
                    MessageBox.Show("Please enter your both names!", "Register Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                { 
                    myConnection = new SqlConnection(lf.connection);
                    myCommand = new SqlCommand("INSERT INTO Accounts(fullname, email, username, password) VALUES (@fullname, @email, @username, @password)", myConnection);
                    SqlCommand checkEmail = new SqlCommand("SELECT email FROM Accounts WHERE email = @email ", myConnection);
                    SqlCommand checkUsername = new SqlCommand("SELECT username FROM Accounts WHERE username = @username ", myConnection);

                    myConnection.Open();
                    myCommand.Parameters.AddWithValue("@username", textBox3.Text);
                    myCommand.Parameters.AddWithValue("@fullname", textBox1.Text);
                    myCommand.Parameters.AddWithValue("@email", textBox2.Text);
                    myCommand.Parameters.AddWithValue("@password", textBox4.Text);

                    checkEmail.Parameters.AddWithValue("@email", textBox2.Text);
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

                    MessageBox.Show("Account added successfully!");
                    DisplayData();

                    if (myConnection.State == ConnectionState.Open)
                        myConnection.Dispose();

                    textBox1.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox2.Clear(); 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_UpdateClick(object sender, EventArgs e)
        {
            try
            {
                myConnection = new SqlConnection(lf.connection);
                myCommand = new SqlCommand("SELECT username FROM Accounts WHERE username = '" + textBox5.Text + "'", myConnection);
                myConnection.Open();

                SqlDataAdapter sda = new SqlDataAdapter(myCommand);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                myCommand.ExecuteNonQuery();

                if (textBox5.Text == "" || textBox6.Text == "")
                    MessageBox.Show("The fields cannot be empty!", "Empty fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (textBox5.Text == textBox6.Text)
                    MessageBox.Show("Username is still the same!", "Same username", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (dt.Rows.Count > 0)
                {                    
                    SqlCommand updateCommand = new SqlCommand("UPDATE Accounts SET username = '" + textBox6.Text + "' WHERE username = '" + textBox5.Text + "'", myConnection);
                    SqlDataAdapter sda2 = new SqlDataAdapter(updateCommand);
                    DataTable dt2 = new DataTable();
                    sda2.Fill(dt2);
                    updateCommand.ExecuteNonQuery(); 
                    MessageBox.Show("Username changed successfully!");
                }
                else
                    MessageBox.Show("Username not found!", "Username not found", MessageBoxButtons.OK, MessageBoxIcon.Error);

           
                myConnection.Close();
                DisplayData();

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

        private void button_DeleteClick(object sender, EventArgs e)
        {
            try
            {
                myConnection = new SqlConnection(lf.connection);
                myCommand = new SqlCommand("SELECT * FROM Accounts WHERE username = '" + textBox7.Text + "'", myConnection);
                myConnection.Open();

                SqlDataAdapter sda = new SqlDataAdapter(myCommand);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                myCommand.ExecuteNonQuery();

                if (textBox7.Text == "")
                    MessageBox.Show("The field cannot be empty!", "Empty fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (dt.Rows.Count > 0)
                {
                    SqlCommand updateCommand = new SqlCommand("DELETE Accounts WHERE username = '" + textBox7.Text + "'", myConnection);
                    SqlDataAdapter sda2 = new SqlDataAdapter(updateCommand);
                    DataTable dt2 = new DataTable();
                    sda2.Fill(dt2);
                    updateCommand.ExecuteNonQuery();
                    MessageBox.Show("Username deleted successfully!");
                }
                else
                    MessageBox.Show("Username not found!", "Username not found", MessageBoxButtons.OK, MessageBoxIcon.Error);


                myConnection.Close();
                DisplayData();

                if (myConnection.State == ConnectionState.Open)
                    myConnection.Dispose();

                textBox7.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox7.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void button_SaveToTxtClick(object sender, EventArgs e)
        {
            string connectionString = null;
            connectionString = lf.connection;

            DataTable dt = new DataTable();
            foreach (DataGridViewTextBoxColumn column in dataGridView1.Columns)
                dt.Columns.Add(column.Name, column.ValueType);

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                DataRow dr = dt.NewRow();
                foreach (DataGridViewTextBoxColumn column in dataGridView1.Columns)
                    if (row.Cells[column.Name].Value != null)
                        dr[column.Name] = row.Cells[column.Name].Value.ToString();
                dt.Rows.Add(dr);
            }

            string filePath = "D:\\ТУ Варна\\Семестър 6\\ТСП - проект\\LibraryApp\\Справки\\Accounts.txt";
            DataTableToTextFile(dt, filePath);
            MessageBox.Show("Data saved successfully!", "Data saved!");
        }

        private void DataTableToTextFile(DataTable dt, string outputFilePath)
        {
            int[] maxLengths = new int[dt.Columns.Count];
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                maxLengths[i] = dt.Columns[i].ColumnName.Length;
                foreach (DataRow row in dt.Rows)
                {
                    if (!row.IsNull(i))
                    {
                        int length = row[i].ToString().Length;
                        if (length > maxLengths[i])
                            maxLengths[i] = length;
                    }
                }
            }

            try
            {
                using (StreamWriter sw = new StreamWriter(outputFilePath, false))
                {
                    for (int i = 0; i < dt.Columns.Count; i++)
                        sw.Write(dt.Columns[i].ColumnName.PadRight(maxLengths[i] + 2));

                    sw.WriteLine();
                    foreach (DataRow row in dt.Rows)
                    {
                        for (int i = 0; i < dt.Columns.Count; i++)
                        {
                            if (!row.IsNull(i))
                                sw.Write(row[i].ToString().PadRight(maxLengths[i] + 2));
                            else
                                sw.Write(new string(' ', maxLengths[i] + 2));
                        }
                        sw.WriteLine();
                    }
                    sw.Close();
                }
            }
            catch { }
        }
    }
}
