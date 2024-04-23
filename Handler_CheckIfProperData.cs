using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CharactiniotisTest
{
    internal class Handler_CheckIfProperData
    {
        public static bool Check_Client_ID_ProperInfo(int _ID)
        {
            bool is_Client_ID_Correct = true;
            if (_ID == 0) 
            {
                MessageBox.Show("Client ID is not correct or not found");
                is_Client_ID_Correct = false; 
            }
            return is_Client_ID_Correct;
        }
        public static bool Check_Client_ADD_ProperInfo(string _firstName, string _lastName, string _address, int _postalCode, long _phoneNumber, string _email)
        {
            bool allElementsAreProper = true;
            // making sure that the vaslues will be appropriate for the tables' columns
            if (string.IsNullOrEmpty(_firstName) && _firstName.Length > 50 && string.IsNullOrEmpty(_lastName) && _lastName.Length > 50 && string.IsNullOrEmpty(_address) && _address.Length > 100)
            {
                // Improper data
                MessageBox.Show("Client info is improper. Please, make sure that you only enter up to 50 characters long First and Last names and up to 100 characters long Address.");
                allElementsAreProper = false;
            }
            if (!string.IsNullOrEmpty(_postalCode.ToString()) && !(_postalCode >= 1000 && _postalCode <= 21999))            
            {
                // Improper data
                MessageBox.Show("Postal code is invalid. Please, make sure that you only input 5-digit numbers between 1000 and 21999.");
                allElementsAreProper = false;
            }
            if (!string.IsNullOrEmpty(_phoneNumber.ToString()) && !(_phoneNumber.ToString().Length == 10) )
            {
                // Conversion failed
                MessageBox.Show("Phone number : " + _phoneNumber.ToString() + " of length (" + _phoneNumber.ToString().Length + ")" + " is invalid. Please, make sure that you only input 10-digit numbers.");
                allElementsAreProper = false;
            }
            if (!string.IsNullOrEmpty(_email) && !IsValidEmail(_email))
            {
                MessageBox.Show("Email is invalid. Please, make sure that you input a proper email type string of up to 320 characters.");
                allElementsAreProper = false;
            }
            return allElementsAreProper;
        }

        static bool IsValidEmail(string email)
        {
            // Regular expression pattern for email validation
            string pattern = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";
            Regex regex = new Regex(pattern);
            return (regex.IsMatch(email)) && (email.Length <= 320);
        }
    }
}
