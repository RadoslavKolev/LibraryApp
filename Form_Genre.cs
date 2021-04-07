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
    public partial class Form_Genre : Form
    {
        public Form_Genre()
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
                myCommand = new SqlCommand("INSERT INTO Genre VALUES (@genre_id,@genre_name)", myConnection);
            

                myConnection.Open();
                myCommand.Parameters.AddWithValue("@genre_id", textBox1.Text);
                myCommand.Parameters.AddWithValue("@genre_name", textBox2.Text);
                SqlDataReader sdr = myCommand.ExecuteReader();

                if (sdr.HasRows)
                {
                    MessageBox.Show("ID is already taken", "Register Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                   
                }

                else
                {
                    MessageBox.Show("Genre inserted successfully!");
                }
                sdr.Close();

                myConnection.Close();
                DisplayData();

                if (myConnection.State == ConnectionState.Open)
                    myConnection.Dispose();

                textBox1.Clear();
                textBox2.Clear();
            }
            catch(Exception ex){ MessageBox.Show("Please check your id is duplicate or delete it from Books", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                myConnection = new SqlConnection(lf.connection);
                myCommand = new SqlCommand("UPDATE Genre SET genre_name =@genre_name WHERE genre_id=@genre_id", myConnection);
                myConnection.Open();
                myCommand.Parameters.AddWithValue("@genre_id", textBox1.Text);
                myCommand.Parameters.AddWithValue("@genre_name", textBox2.Text);
                SqlDataReader sdr = myCommand.ExecuteReader();

                if (sdr.HasRows)
                {
                    MessageBox.Show("ID is already taken", "Register Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

                else
                {
                    MessageBox.Show("Genre updated successfully!");
                }
                sdr.Close();

                myConnection.Close();
                DisplayData();

                if (myConnection.State == ConnectionState.Open)
                    myConnection.Dispose();

                textBox1.Clear();
                textBox2.Clear();
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
                myCommand = new SqlCommand("DELETE Genre WHERE genre_id = @genre_id", myConnection);
                myConnection.Open();
                myCommand.Parameters.AddWithValue("@genre_id", textBox1.Text);

                myCommand.ExecuteNonQuery();
                myConnection.Close();

                MessageBox.Show("Genre deleted successfully!");
                DisplayData();

                if (myConnection.State == ConnectionState.Open)
                    myConnection.Dispose();
                textBox1.Clear();
                textBox2.Clear();
            
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please go back in Books and delete all saves with that id", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DisplayData()
        {
            myConnection.Open();
            DataTable dataTable = new DataTable();
            adapter = new SqlDataAdapter("SELECT * FROM Genre", myConnection);
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            myConnection.Close();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            Form_MainAdmin admin = new Form_MainAdmin();
            admin.Show();
            this.Close();
        }

        private void Genre_Load(object sender, EventArgs e)
        {
          

            // TODO: This line of code loads data into the 'readersDataSet1.Readers' table. You can move, or remove it, as needed.
          this.genreTableAdapter.Fill(this.genreDBDataSet1.Genre);
            panel1.BackColor = Color.FromArgb(100, 0, 0, 0);
        }
    }
}
