using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;
using Npgsql;
using System.Text.RegularExpressions;

namespace CharactiniotisTest
{
    public partial class Form1 : Form
    {
        // Connection string for your SQL Server
        private string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=postgres;Database=postgres";
        //SqlServer.Connection("YourLocalServerName", "Database", "Your Query here...");

        public DataGridView table_Clients, table_Books, table_OrdersHeader, table_OrdersDetails;
        public Label label_SystemMessage;
        public Form1()
        {
            InitializeComponent();

            InitializeAbstractObjects();
        }

        private void InitializeAbstractObjects()
        {
            table_Clients = dataGridView1;
            //table_Books, table_OrdersHeader, table_OrdersDetails;
            label_SystemMessage = label1;
        }

        // Load data into DataGridView when the form loads
        private void Form1_Load(object sender, EventArgs e)
        {
            label_SystemMessage.Text = "Application initialized.";
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
                table_Clients.DataSource = table;
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


        // Example of updating a client
        private void btnUpdateClient_Click(object sender, EventArgs e)
        {
            // Get the selected client's ID
            int client_ID = Convert.ToInt32(table_Clients.CurrentRow.Cells["ClientID"].Value);


            //Handler_Database.UpdateClient(client_ID, client_FirstName, client_LastName, client_Address, client_PostalCode, _client_PhoneNumber, client_Email);

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

        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadClients();
            //LoadBooks();
            //LoadOrders();
        }


        private void Button_Insert_Click(object sender, EventArgs e)
        {
            string client_FirstName = Handler_TransformData.SetFirstName(toolStripTextBox2.Text);
            string client_LastName = Handler_TransformData.SetLastName(toolStripTextBox3.Text);
            string client_Address = Handler_TransformData.SetAddress(toolStripTextBox4.Text);
            int client_PostalCode = Handler_TransformData.SetPostalCode(toolStripTextBox5.Text);
            long client_PhoneNumber = Handler_TransformData.SetPhoneNumber(toolStripTextBox6.Text);
            string client_Email = Handler_TransformData.SetEmail(toolStripTextBox7.Text);

            bool allElementsAreProper = Handler_CheckIfProperData.Check_Client_ADD_ProperInfo(client_FirstName, client_LastName, client_Address, client_PostalCode, client_PhoneNumber, client_Email);

            if (allElementsAreProper) Handler_Database.AddClient(client_FirstName, client_LastName, client_Address, client_PostalCode, client_PhoneNumber, client_Email);
            // Reload clients data after insertion
            LoadClients();
        }



        private void Button_Update_Click(object sender, EventArgs e)
        {
            //int client_ID = Handler_TransformData.SetID(toolStripTextBox8.Text);
            //string client_FirstName = Handler_TransformData.SetFirstName(toolStripTextBox9.Text);
            //string client_LastName = Handler_TransformData.SetLastName(toolStripTextBox10.Text);
            //string client_Address = Handler_TransformData.SetAddress(toolStripTextBox12.Text);
            //int client_PostalCode = Handler_TransformData.SetPostalCode(toolStripTextBox11.Text);
            //long client_PhoneNumber = Handler_TransformData.SetPhoneNumber(toolStripTextBox13.Text);
            //string client_Email = Handler_TransformData.SetEmail(toolStripTextBox14.Text);

            //bool is_Client_ID_Correct = Handler_CheckIfProperData.Check_Client_ID_ProperInfo(client_ID);
            //if (is_Client_ID_Correct) Handler_Database.UpdateClient(client_ID, client_FirstName, client_LastName, client_Address, client_PostalCode, client_PhoneNumber, client_Email);
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView table_Clients = sender as DataGridView;

            string newValue = table_Clients.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            string columnName = table_Clients.Columns[e.ColumnIndex].Name;
            int clientID = Convert.ToInt32(table_Clients.Rows[e.RowIndex].Cells["ClientID"].Value); // Assuming there's a ClientID column
            
            bool isValueProper = true;             
            if (columnName == "firstname") { string client_FirstName = Handler_TransformData.SetFirstName(newValue); isValueProper = Handler_CheckIfProperData.IsValidFirstName(client_FirstName); }
            if (columnName == "lastname") { string client_LastName = Handler_TransformData.SetLastName(newValue); isValueProper = Handler_CheckIfProperData.IsValidLastName(client_LastName); }
            if (columnName == "address") { string client_Address = Handler_TransformData.SetAddress(newValue); isValueProper = Handler_CheckIfProperData.IsValidAddress(client_Address); }
            if (columnName == "postalcode") { int client_PostalCode = Handler_TransformData.SetPostalCode(newValue); isValueProper = Handler_CheckIfProperData.IsValidPostalCode(client_PostalCode); }
            if (columnName == "phonenumber") { long client_PhoneNumber = Handler_TransformData.SetPhoneNumber(newValue); isValueProper = Handler_CheckIfProperData.IsValidPhoneNumber(client_PhoneNumber); }
            if (columnName == "email") { string client_Email = Handler_TransformData.SetEmail(newValue); isValueProper = Handler_CheckIfProperData.IsValidEmail(client_Email); }
            
            if (isValueProper)
            {
                // Update the database based on the changed value
                string query = $"UPDATE Clients SET {columnName} = @NewValue WHERE ClientID = @ClientID";

                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@NewValue", newValue);
                        command.Parameters.AddWithValue("@ClientID", clientID);
                        command.ExecuteNonQuery();
                    }
                }
            }
            // need to reload the table
        }
    }    
}
