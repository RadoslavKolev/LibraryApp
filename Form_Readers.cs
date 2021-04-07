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
    public partial class Form_Readers : Form
    {
        public Form_Readers()
        {
            InitializeComponent();
        }

        public SqlConnection myConnection = default(SqlConnection);
        public SqlCommand myCommand = default(SqlCommand);
        public SqlDataAdapter adapter, adapter2;
        Form_Login lf = new Form_Login();

        private void Readers_Form_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'libraryDBDataSet.Accounts' table. You can move, or remove it, as needed.
            this.accountsTableAdapter.Fill(this.libraryDBDataSet.Accounts);
            // TODO: This line of code loads data into the 'readersDataSet1.Readers' table. You can move, or remove it, as needed.
            this.readersTableAdapter.Fill(this.readersDataSet1.Readers);
            panel1.BackColor = Color.FromArgb(100, 0, 0, 0);
        }

        public void DisplayData()
        {
            myConnection.Open();
            DataTable dataTable = new DataTable();
            adapter = new SqlDataAdapter("SELECT * FROM Readers", myConnection);
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;

            adapter2 = new SqlDataAdapter("SELECT * FROM Accounts", myConnection);
            adapter2.Fill(dataTable);
            dataGridView2.DataSource = dataTable;
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
                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "")
                    MessageBox.Show("You must fill all of the fields!", "Register Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (!textBox2.Text.Contains(" "))
                    MessageBox.Show("Please enter your both names!", "Register Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (textBox5.Text.Length != 10)
                    MessageBox.Show("Phone number must be 10 symbols, not more or less", "Register Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    myConnection = new SqlConnection(lf.connection);
                    myCommand = new SqlCommand("INSERT INTO Readers VALUES (@reader_code,@reader_fullname,@reader_city,@reader_address, @reader_phone, @reader_sex,@reader_username)", myConnection);
                    SqlCommand checkUsername = new SqlCommand("SELECT * FROM Accounts WHERE username = @reader_username ", myConnection);                  

                    myConnection.Open();
                    myCommand.Parameters.AddWithValue("@reader_code", textBox1.Text);
                    myCommand.Parameters.AddWithValue("@reader_fullname", textBox2.Text);
                    myCommand.Parameters.AddWithValue("@reader_city", textBox3.Text);
                    myCommand.Parameters.AddWithValue("@reader_address", textBox4.Text);
                    myCommand.Parameters.AddWithValue("@reader_phone", textBox5.Text);

                    bool check;
                    if (radioButton1.Checked)
                        check = true;
                    else
                        check = false;
                    myCommand.Parameters.AddWithValue("@reader_sex", check);
                    myCommand.Parameters.AddWithValue("@reader_username", textBox6.Text);

                    checkUsername.Parameters.AddWithValue("@reader_username", textBox6.Text);
                    SqlDataReader sdr = checkUsername.ExecuteReader();

                    if (sdr.HasRows)
                    {
                        MessageBox.Show("Reader inserted successfully!");
                    }
                       
                    else
                    {
                        MessageBox.Show("Username is already taken", "Register Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                sdr.Close();

                    myCommand.ExecuteNonQuery();
                    myConnection.Close();
                    DisplayData();

                    if (myConnection.State == ConnectionState.Open)
                        myConnection.Dispose();

                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                    textBox6.Clear();
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
                myCommand = new SqlCommand("SELECT * FROM Readers WHERE reader_username = '" + textBox6.Text + "'", myConnection);
                myConnection.Open();
                SqlDataAdapter sda = new SqlDataAdapter(myCommand);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                bool check;
                if (radioButton1.Checked)
                    check = true;
                else
                    check = false;
                if (dt.Rows.Count > 0)
                {
                    SqlCommand myCommand2 = new SqlCommand("UPDATE Readers SET reader_code = '" + textBox1.Text + "',reader_fullname='" + textBox2.Text + "',reader_city='" + textBox3.Text + "',reader_address='" + textBox4.Text + "',reader_phone='" + textBox1.Text + "',reader_sex='"+check+"' WHERE reader_username = '" + textBox6.Text + "'", myConnection);
                    SqlDataAdapter sda2 = new SqlDataAdapter(myCommand2);
                    DataTable dt2 = new DataTable();
                    sda2.Fill(dt2);
                    myCommand2.ExecuteNonQuery();
                    MessageBox.Show("Update changed successfully!");
                }
                else
                    MessageBox.Show("Update is not successful!", "UpdateError", MessageBoxButtons.OK, MessageBoxIcon.Error);


                myConnection.Close();
                DisplayData();

                if (myConnection.State == ConnectionState.Open)
                    myConnection.Dispose();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please go back in borrow and delete all saves with that code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_DeleteClick(object sender, EventArgs e)
        {
            try
            {
                myConnection = new SqlConnection(lf.connection);
                myCommand = new SqlCommand("DELETE Readers WHERE reader_username = @username", myConnection);
                myConnection.Open();
                myCommand.Parameters.AddWithValue("@username", textBox6.Text);

                myCommand.ExecuteNonQuery();
                myConnection.Close();

                MessageBox.Show("Account deleted successfully!");
                DisplayData();

                if (myConnection.State == ConnectionState.Open)
                    myConnection.Dispose();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please go back in borrow and delete all saves with that code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

            string filePath = "D:\\ТУ Варна\\Семестър 6\\ТСП - проект\\LibraryApp\\Справки\\Readers.txt";
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

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
        }

        private void dataGridView2_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox2.Text = dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox6.Text = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
        }
    }
}
