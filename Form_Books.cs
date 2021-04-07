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
    public partial class Form_Books : Form
    {
        public Form_Books()
        {
            InitializeComponent();
        }

        public SqlConnection myConnection = default(SqlConnection);
        public SqlCommand myCommand = default(SqlCommand);
        public SqlDataAdapter adapter;
        Form_Login lf = new Form_Login();
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                myConnection = new SqlConnection(lf.connection);
                myCommand = new SqlCommand("INSERT INTO Books VALUES (@book_code,@book_name,@book_author,@book_publisher,@book_year,@book_available,@book_pieces,@book_summary,@book_genre)", myConnection);


                myConnection.Open();
                myCommand.Parameters.AddWithValue("@book_code", textBox1.Text);
                myCommand.Parameters.AddWithValue("@book_name", textBox2.Text);
                myCommand.Parameters.AddWithValue("@book_author", textBox3.Text);
                myCommand.Parameters.AddWithValue("@book_publisher", textBox4.Text);
                myCommand.Parameters.AddWithValue("@book_year", textBox5.Text);
                bool check;
                if (radioButton1.Checked)
                    check = true;
                else
                    check = false;
                myCommand.Parameters.AddWithValue("@book_available", check);
                myCommand.Parameters.AddWithValue("@book_pieces", textBox7.Text);
                myCommand.Parameters.AddWithValue("@book_summary", textBox8.Text);
                myCommand.Parameters.AddWithValue("@book_genre", textBox9.Text);

                SqlDataReader sdr = myCommand.ExecuteReader();

                if (sdr.HasRows)
                {
                    MessageBox.Show("ID is already taken", "Register Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

                else
                {
                    MessageBox.Show("Book inserted successfully!");
                }
                sdr.Close();

                myConnection.Close();
                DisplayData();

                if (myConnection.State == ConnectionState.Open)
                    myConnection.Dispose();

                textBox1.Clear();
                textBox2.Clear();

                textBox3.Clear();
                textBox4.Clear();

                textBox5.Clear();
                

                textBox7.Clear();
                textBox8.Clear();

                textBox9.Clear();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please check your code is duplicate or maybe Genre doesnt exit", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DisplayData()
        {
            myConnection.Open();
            DataTable dataTable = new DataTable();
            adapter = new SqlDataAdapter("SELECT * FROM Books", myConnection);
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            myConnection.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                myConnection = new SqlConnection(lf.connection);
                myCommand = new SqlCommand("UPDATE Books SET book_name =@book_name,book_author=@book_author,book_publisher=@book_publisher,book_year=@book_year,book_available=@book_available,book_pieces=@book_pieces,book_summary=@book_summary,book_genre=@book_genre WHERE book_code=@book_code", myConnection);
                myConnection.Open();
                myCommand.Parameters.AddWithValue("@book_code", textBox1.Text);
                myCommand.Parameters.AddWithValue("@book_name", textBox2.Text);
                myCommand.Parameters.AddWithValue("@book_author", textBox3.Text);
                myCommand.Parameters.AddWithValue("@book_publisher", textBox4.Text);
                myCommand.Parameters.AddWithValue("@book_year", textBox5.Text);
                bool check;
                if (radioButton1.Checked)
                    check = true;
                else
                    check = false;
                myCommand.Parameters.AddWithValue("@book_available", check);
                myCommand.Parameters.AddWithValue("@book_pieces", textBox7.Text);
                myCommand.Parameters.AddWithValue("@book_summary", textBox8.Text);
                myCommand.Parameters.AddWithValue("@book_genre", textBox9.Text);
                SqlDataReader sdr = myCommand.ExecuteReader();

                if (sdr.HasRows)
                {
                    MessageBox.Show("ID is already taken", "Register Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

                else
                {
                    MessageBox.Show("Books updated successfully!");
                }
                sdr.Close();

                myConnection.Close();
                DisplayData();

                if (myConnection.State == ConnectionState.Open)
                    myConnection.Dispose();

                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox7.Clear();
                textBox8.Clear();
                textBox9.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please go back in Books and delete all saves with that id", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                myConnection = new SqlConnection(lf.connection);
                myCommand = new SqlCommand("DELETE Books WHERE book_code = @book_code", myConnection);
                myConnection.Open();
                myCommand.Parameters.AddWithValue("@book_code", textBox1.Text);

                myCommand.ExecuteNonQuery();
                myConnection.Close();

                MessageBox.Show("Books deleted successfully!");
                DisplayData();

                if (myConnection.State == ConnectionState.Open)
                    myConnection.Dispose();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox7.Clear();
                textBox8.Clear();
                textBox9.Clear();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Please go back in Books and delete all saves with that id", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form_Books_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'booksDBDataSet1.Books' table. You can move, or remove it, as needed.
            this.booksTableAdapter.Fill(this.booksDBDataSet1.Books);

            panel1.BackColor = Color.FromArgb(100, 0, 0, 0);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form_MainAdmin admin = new Form_MainAdmin();
            admin.Show();
            this.Close();
        }
    }
}
