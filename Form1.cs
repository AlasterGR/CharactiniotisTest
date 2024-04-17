using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace CharactiniotisTest
{
    public partial class Form1 : Form
    {
        // Connection string for your SQL Server
        private string connectionString = "YourConnectionStringHere";

        public Form1()
        {
            InitializeComponent();
        }

        // Load data into DataGridView when the form loads
        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadClients();
            LoadBooks();
            LoadOrders();
        }

        // Load clients into DataGridView
        private void LoadClients()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Clients";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dgvClients.DataSource = table;
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
                dgvBooks.DataSource = table;
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
                dgvOrders.DataSource = table;
            }
        }

        // Example of inserting a new client
        private void btnAddClient_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Clients (FirstName, LastName, Address, PostalCode, PhoneNumber, Email) VALUES (@FirstName, @LastName, @Address, @PostalCode, @PhoneNumber, @Email)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                command.Parameters.AddWithValue("@LastName", txtLastName.Text);
                command.Parameters.AddWithValue("@Address", txtAddress.Text);
                command.Parameters.AddWithValue("@PostalCode", txtPostalCode.Text);
                command.Parameters.AddWithValue("@PhoneNumber", txtPhoneNumber.Text);
                command.Parameters.AddWithValue("@Email", txtEmail.Text);

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
            int clientId = Convert.ToInt32(dgvClients.CurrentRow.Cells["ClientID"].Value);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Clients SET FirstName = @FirstName, LastName = @LastName, Address = @Address, PostalCode = @PostalCode, PhoneNumber = @PhoneNumber, Email = @Email WHERE ClientID = @ClientID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                command.Parameters.AddWithValue("@LastName", txtLastName.Text);
                command.Parameters.AddWithValue("@Address", txtAddress.Text);
                command.Parameters.AddWithValue("@PostalCode", txtPostalCode.Text);
                command.Parameters.AddWithValue("@PhoneNumber", txtPhoneNumber.Text);
                command.Parameters.AddWithValue("@Email", txtEmail.Text);
                command.Parameters.AddWithValue("@ClientID", clientId);

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
            int clientId = Convert.ToInt32(dgvClients.CurrentRow.Cells["ClientID"].Value);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Clients WHERE ClientID = @ClientID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ClientID", clientId);

                connection.Open();
                command.ExecuteNonQuery();
            }

            // Reload clients data after deletion
            LoadClients();
        }
    }
}
