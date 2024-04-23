using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Npgsql;
using System.Text.RegularExpressions;

namespace CharactiniotisTest
{
    internal class Handler_Database
    {
        // Connection string for your SQL Server
        private static string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=postgres;Database=postgres";

        // Inserting a new client
        public static void AddClient(string _firstName, string _lastName, string _address, int _postalCode, long _phoneNumber, string _email)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                string query = "INSERT INTO Clients (FirstName, LastName, Address, PostalCode, PhoneNumber, Email) VALUES (@FirstName, @LastName, @Address, @PostalCode, @PhoneNumber, @Email)";
                NpgsqlCommand command = new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("@FirstName", _firstName);
                command.Parameters.AddWithValue("@LastName", _lastName);
                command.Parameters.AddWithValue("@Address", _address);
                command.Parameters.AddWithValue("@PostalCode", _postalCode);
                command.Parameters.AddWithValue("@PhoneNumber", _phoneNumber);
                command.Parameters.AddWithValue("@Email", _email);

                connection.Open();
                command.ExecuteNonQuery();
            }

        }

        public static void UpdateClient(int _clientId, string _firstName, string _lastName, string _address, int _postalCode, long _phoneNumber, string _email)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                string query = "UPDATE Clients SET FirstName = @FirstName, LastName = @LastName, Address = @Address, PostalCode = @PostalCode, PhoneNumber = @PhoneNumber, Email = @Email WHERE ClientID = @ClientID";
                NpgsqlCommand command = new NpgsqlCommand(query, connection);
                if (!string.IsNullOrWhiteSpace(_firstName)) command.Parameters.AddWithValue("@FirstName", _firstName);
                if (string.IsNullOrWhiteSpace(_firstName)) command.Parameters.Remove("@FirstName");
                if (!string.IsNullOrWhiteSpace(_lastName)) command.Parameters.AddWithValue("@LastName", _lastName);
                if (string.IsNullOrWhiteSpace(_lastName)) command.Parameters.Remove("@LastName");
                if (!string.IsNullOrWhiteSpace(_address)) command.Parameters.AddWithValue("@Address", _address);
                if (string.IsNullOrWhiteSpace(_address)) command.Parameters.Remove("@Address");
                if (!string.IsNullOrWhiteSpace(_postalCode.ToString())) command.Parameters.AddWithValue("@PostalCode", _postalCode);
                if (string.IsNullOrWhiteSpace(_postalCode.ToString())) command.Parameters.Remove("@PostalCode");
                if (!string.IsNullOrWhiteSpace(_phoneNumber.ToString())) command.Parameters.AddWithValue("@PhoneNumber", _phoneNumber);
                if (string.IsNullOrWhiteSpace(_phoneNumber.ToString())) command.Parameters.Remove("@PhoneNumber");
                if (!string.IsNullOrWhiteSpace(_email)) command.Parameters.AddWithValue("@Email", _email);
                if (string.IsNullOrWhiteSpace(_email)) command.Parameters.Remove("@Email");

                if (!string.IsNullOrWhiteSpace(_clientId.ToString())) command.Parameters.AddWithValue("@ClientID", _clientId);

                connection.Open();
                command.ExecuteNonQuery();
            }

        }
    }
}
