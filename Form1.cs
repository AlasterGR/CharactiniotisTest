using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;
using Npgsql;

namespace CharactiniotisTest
{
    public partial class Form1 : Form
    {
        // Connection string for your SQL Server
        private string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=postgres;Database=postgres";
        //SqlServer.Connection("YourLocalServerName", "Database", "Your Query here...");

        public Form1()
        {
            InitializeComponent();
            FormMainMethod();
        }

        // Load data into DataGridView when the form loads
        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Here !");
            LoadClients();
            //LoadBooks();
            //LoadOrders();
        }

        private void FormMainMethod()
        {
            MessageBox.Show("Here !");
            LoadClients();
            //LoadBooks();
            //LoadOrders();
        }

        // Load clients into DataGridView
        private void LoadClients()
        {    
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                string query = "SELECT * FROM Clients";
                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(query, connection);
                DataTable table = new DataTable();
                adapter.Fill(table);
                //dgvClients.DataSource = table;
            }
        }

        // Load books into DataGridView
        private void LoadBooks()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Books";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable table = new DataTable();
                adapter.Fill(table);
                //dgvBooks.DataSource = table;
            }
        }

        // Load orders into DataGridView
        private void LoadOrders()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM OrderHeader";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable table = new DataTable();
                adapter.Fill(table);
                //dgvOrders.DataSource = table;
            }
        }

        // Example of inserting a new client
        private void btnAddClient_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Clients (FirstName, LastName, Address, PostalCode, PhoneNumber, Email) VALUES (@FirstName, @LastName, @Address, @PostalCode, @PhoneNumber, @Email)";
                SqlCommand command = new SqlCommand(query, connection);
                //command.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                //command.Parameters.AddWithValue("@LastName", txtLastName.Text);
                //command.Parameters.AddWithValue("@Address", txtAddress.Text);
                //command.Parameters.AddWithValue("@PostalCode", txtPostalCode.Text);
                //command.Parameters.AddWithValue("@PhoneNumber", txtPhoneNumber.Text);
                //command.Parameters.AddWithValue("@Email", txtEmail.Text);

                connection.Open();
                command.ExecuteNonQuery();
            }

            // Reload clients data after insertion
            LoadClients();
        }

        // Example of updating a client
        private void btnUpdateClient_Click(object sender, EventArgs e)
        {
            // Get the selected client's ID
            //int clientId = Convert.ToInt32(dgvClients.CurrentRow.Cells["ClientID"].Value);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Clients SET FirstName = @FirstName, LastName = @LastName, Address = @Address, PostalCode = @PostalCode, PhoneNumber = @PhoneNumber, Email = @Email WHERE ClientID = @ClientID";
                SqlCommand command = new SqlCommand(query, connection);
                //command.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                //command.Parameters.AddWithValue("@LastName", txtLastName.Text);
                //command.Parameters.AddWithValue("@Address", txtAddress.Text);
                //command.Parameters.AddWithValue("@PostalCode", txtPostalCode.Text);
                //command.Parameters.AddWithValue("@PhoneNumber", txtPhoneNumber.Text);
                //command.Parameters.AddWithValue("@Email", txtEmail.Text);
                //command.Parameters.AddWithValue("@ClientID", clientId);

                connection.Open();
                command.ExecuteNonQuery();
            }

            // Reload clients data after update
            LoadClients();
        }

        // Example of deleting a client
        private void btnDeleteClient_Click(object sender, EventArgs e)
        {
            // Get the selected client's ID
            //int clientId = Convert.ToInt32(dgvClients.CurrentRow.Cells["ClientID"].Value);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Clients WHERE ClientID = @ClientID";
                SqlCommand command = new SqlCommand(query, connection);
               // command.Parameters.AddWithValue("@ClientID", clientId);

                connection.Open();
                command.ExecuteNonQuery();
            }

            // Reload clients data after deletion
            LoadClients();
        }
    }
}
