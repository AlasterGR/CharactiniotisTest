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
            table_Books = dataGridView2;
            table_OrdersHeader = dataGridView3;
            table_OrdersDetails = dataGridView4;
            label_SystemMessage = label1;
        }

        // Load data into DataGridView when the form loads
        private void Form1_Load(object sender, EventArgs e)
        {
            label_SystemMessage.Text = "Application initialized.";
            LoadAllTables();
        }
       
        public void LoadAllTables()
        {
            LoadClients();
            LoadBooks();
            LoadOrders();
            LoadDetails();
            label_SystemMessage.Text = "Reloaded all tables.";
        }

        #region (Re)Load the tables
        // We use BeginInvoke to avoid crashing the app :execute asynchronously, allowing the event handler to complete before the reload is executed, thus avoiding the reentrant call issue.
        private void LoadClients()
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                string query = "SELECT * FROM Clients";
                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(query, connection);
                DataTable table = new DataTable();
                adapter.Fill(table);
                BeginInvoke(new Action(() =>
                {
                    table_Clients.DataSource = table;
                    table_Clients.Columns["ClientID"].ReadOnly = true; // have the primary key columns non-editable
                    table_Clients.AllowUserToAddRows = false;
                }));
            }
        }
        private void LoadBooks()
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                string query = "SELECT * FROM Books";
                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(query, connection);
                DataTable table = new DataTable();
                adapter.Fill(table);
                BeginInvoke(new Action(() =>
                {
                    table_Books.DataSource = table;
                    table_Books.Columns["ISBN"].ReadOnly = true; // have the primary key columns non-editable
                    table_Books.AllowUserToAddRows = false;
                }));
            }
        }
        private void LoadOrders()
        {           
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                string deleteQuery = "DELETE FROM OrderHeader WHERE NOT EXISTS (SELECT 1 FROM OrderDetails WHERE OrderDetails.OrderID = OrderHeader.OrderID)";
                using (NpgsqlCommand deleteCommand = new NpgsqlCommand(deleteQuery, connection))
                {
                    connection.Open();
                    deleteCommand.ExecuteNonQuery(); // Delete orphaned rows from OrderHeader
                }

                string query = "SELECT * FROM OrderHeader";
                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(query, connection);
                DataTable table = new DataTable();
                adapter.Fill(table);
                BeginInvoke(new Action(() =>
                {
                    table_OrdersHeader.DataSource = table;
                    table_OrdersHeader.Columns["OrderID"].ReadOnly = true; // have the primary key columns non-editable
                    table_OrdersHeader.AllowUserToAddRows = false;
                }));
            }
        }
        private void LoadDetails()
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                string query = "SELECT * FROM OrderDetails";
                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(query, connection);
                DataTable table = new DataTable();
                adapter.Fill(table);
                BeginInvoke(new Action(() =>
                {
                    table_OrdersDetails.DataSource = table;
                    table_OrdersDetails.Columns["OrderID"].ReadOnly = true; // have the primary key columns non-editable
                    table_OrdersDetails.Columns["ISBN"].ReadOnly = true; // have the primary key columns non-editable
                    table_OrdersDetails.AllowUserToAddRows = false;
                }));
            }
        }
        #endregion
        #region Buttons
        private void Button_CONNECT_Click(object sender, EventArgs e)
        {
            LoadAllTables();
        }

        private void Button_Client_Insert_Click(object sender, EventArgs e)
        {
            string client_FirstName = Handler_TransformData.SetFirstName(toolStripTextBox2.Text);
            string client_LastName = Handler_TransformData.SetLastName(toolStripTextBox3.Text);
            string client_Address = Handler_TransformData.SetAddress(toolStripTextBox4.Text);
            int client_PostalCode = Handler_TransformData.SetPostalCode(toolStripTextBox5.Text);
            long client_PhoneNumber = Handler_TransformData.SetPhoneNumber(toolStripTextBox6.Text);
            string client_Email = Handler_TransformData.SetEmail(toolStripTextBox7.Text);

            bool allElementsAreProper = Handler_CheckIfProperData.Check_Client_INSERT_ProperInfo(client_FirstName, client_LastName, client_Address, client_PostalCode, client_PhoneNumber, client_Email);
            if (allElementsAreProper) Handler_Database.AddClient(client_FirstName, client_LastName, client_Address, client_PostalCode, client_PhoneNumber, client_Email);

            // Reload clients data after insertion
            LoadClients(); // reload the table
        }
        private void Button_Book_Insert_Click(object sender, EventArgs e)
        {
            long book_ISBN = Handler_TransformData.SetISBN(toolStripTextBox8.Text);
            string book_Title = Handler_TransformData.SetBookTitle(toolStripTextBox9.Text);
            string book_Author = Handler_TransformData.SetBookAuthor(toolStripTextBox10.Text);
            string book_Summary = toolStripTextBox11.Text;

            bool allElementsAreProper = Handler_CheckIfProperData.Check_Book_INSERT_ProperInfo(book_ISBN, book_Title, book_Author);
            if (allElementsAreProper) Handler_Database.AddBook(book_ISBN, book_Title, book_Author, book_Summary);

            // Reload clients data after insertion
            LoadBooks(); // reload the table
        }
        private void Button_Order_Create_Click(object sender, EventArgs e)
        {
            long client_ID = Handler_TransformData.SetClientID(toolStripTextBox15.Text);
            long book_ISBN = Handler_TransformData.SetISBN(toolStripTextBox13.Text);            
            Handler_Database.CreateOrder(client_ID,book_ISBN);

            // Reload clients data after insertion
            LoadOrders(); // reload the table
            LoadDetails();
        }
        private void Button_Order_Append_Click(object sender, EventArgs e)
        {
            long order_ID = Handler_TransformData.SetOrderID(toolStripTextBox14.Text);
            long book_ISBN = Handler_TransformData.SetISBN(toolStripTextBox16.Text);
            Handler_Database.AppendOrder(order_ID, book_ISBN);
            LoadOrders(); // reload the table
            LoadDetails();
        }
        #endregion

        private void Table_CLIENTS_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView table_Clients = sender as DataGridView;

            string newValue = table_Clients.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            string columnName = table_Clients.Columns[e.ColumnIndex].Name;
            int clientID = Convert.ToInt32(table_Clients.Rows[e.RowIndex].Cells["ClientID"].Value);

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
            LoadClients(); // reload the table
        }
        private void Table_CLIENTS_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            // Retrieve the ClientID of the deleted row
            int clientID = Convert.ToInt32(table_Clients.Rows[e.RowIndex].Cells["ClientID"].Value);

            // Delete the corresponding row from the database table
            string query = "DELETE FROM Clients WHERE ClientID = @ClientID";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ClientID", clientID);
                    command.ExecuteNonQuery();
                }
            }
            LoadClients();
        }

        private void Table_BOOKS_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView table_Books = sender as DataGridView;

            string newValue = table_Books.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            string columnName = table_Books.Columns[e.ColumnIndex].Name;
            long ISBN = Convert.ToInt64(table_Books.Rows[e.RowIndex].Cells["ISBN"].Value);

            bool isValueProper = true;
            if (columnName == "title") { string book_Title = Handler_TransformData.SetBookTitle(newValue); isValueProper = Handler_CheckIfProperData.IsValidBookTitle(book_Title); }
            if (columnName == "author") { string book_Author = Handler_TransformData.SetBookAuthor(newValue); isValueProper = Handler_CheckIfProperData.IsValidBookAuthor(book_Author); }

            if (isValueProper)
            {
                // Update the database based on the changed value
                string query = $"UPDATE Books SET {columnName} = @NewValue WHERE ISBN = @ISBN";

                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@NewValue", newValue);
                        command.Parameters.AddWithValue("@ISBN", ISBN);
                        command.ExecuteNonQuery();
                    }
                }
            }
            LoadBooks(); // reload the table
        }
        private void Table_ORDERS_Header_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView table_OrdersHeader = sender as DataGridView;

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
            LoadOrders(); // reload the table
            LoadDetails();
        }
        private void Table_ORDERS_Details_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView table_OrdersDetails = sender as DataGridView;

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
            LoadOrders();
            LoadDetails(); // reload the table
        }

        private void Table_CLIENTS_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            // Retrieve the ClientID of the deleted row
            int clientID = Convert.ToInt32(table_Clients.Rows[e.Row.Index].Cells["ClientID"].Value);

            // Delete the corresponding row from the database table
            string query = "DELETE FROM Clients WHERE ClientID = @ClientID";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ClientID", clientID);
                    command.ExecuteNonQuery();
                }
            }
            LoadClients();
        }
        private void Table_BOOKS_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            // Retrieve the ID of the deleted row
            long ISBN = Convert.ToInt64(table_Books.Rows[e.Row.Index].Cells["ISBN"].Value);

            // Delete the corresponding row from the database table
            string query = "DELETE FROM Books WHERE ISBN = @ISBN";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ISBN", ISBN);
                    command.ExecuteNonQuery();
                }
            }
            LoadBooks();
        }
        private void Table_ORDERHeader_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            // Retrieve the ID of the deleted row
            int OrderID = Convert.ToInt32(table_OrdersHeader.Rows[e.Row.Index].Cells["OrderID"].Value);

            // Delete the corresponding row from the database table
            string query = "DELETE FROM OrderHeader WHERE OrderID = @OrderID";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@OrderID", OrderID);
                    command.ExecuteNonQuery();
                }
            }
            LoadOrders(); // reload the table
            LoadDetails();
        }
        private void Table_ORDERDetails_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            // Retrieve the ID of the deleted row
            int OrderID = Convert.ToInt32(table_OrdersDetails.Rows[e.Row.Index].Cells["OrderID"].Value);
            long ISBN = Convert.ToInt64(table_OrdersDetails.Rows[e.Row.Index].Cells["ISBN"].Value);

            // Delete the corresponding row from the database table
            string query = "DELETE FROM OrderDetails WHERE OrderID = @OrderID AND ISBN = @ISBN";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@OrderID", OrderID);
                    command.Parameters.AddWithValue("@ISBN", ISBN);
                    command.ExecuteNonQuery();
                }
            }
            LoadOrders(); // reload the table
            LoadDetails();
        }

    }
}
