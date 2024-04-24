using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace CharactiniotisTest
{
    internal class Handler_CheckIfProperData
    {
        #region Clients
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
        public static bool Check_Client_INSERT_ProperInfo(string _firstName, string _lastName, string _address, int _postalCode, long _phoneNumber, string _email)
        {
            //bool allElementsAreProper = true;
            // making sure that the vaslues will be appropriate for the tables' columns
            //if (string.IsNullOrEmpty(_firstName) && _firstName.Length > 50 && string.IsNullOrEmpty(_lastName) && _lastName.Length > 50 && string.IsNullOrEmpty(_address) && _address.Length > 100)
            //{
            //    // Improper data
            //    MessageBox.Show("Client info is improper. Please, make sure that you only enter up to 50 characters long First and Last names and up to 100 characters long Address.");
            //    allElementsAreProper = false;
            //}
            //allElementsAreProper = IsValidFirstName(_firstName);
            //allElementsAreProper = IsValidLastName(_lastName);
            //allElementsAreProper = IsValidAddress(_address);
            //if (!string.IsNullOrEmpty(_postalCode.ToString()) && !(_postalCode >= 1000 && _postalCode <= 21999))            
            //{
            //    // Improper data
            //    MessageBox.Show("Postal code is invalid. Please, make sure that you only input 5-digit numbers between 1000 and 21999.");
            //    allElementsAreProper = false;
            //}
            //allElementsAreProper = IsValidPostalCode(_postalCode);
            //if (!string.IsNullOrEmpty(_phoneNumber.ToString()) && !(_phoneNumber.ToString().Length == 10) )
            //{
            //    // Conversion failed
            //    MessageBox.Show("Phone number : " + _phoneNumber.ToString() + " of length (" + _phoneNumber.ToString().Length + ")" + " is invalid. Please, make sure that you only input 10-digit numbers.");
            //    allElementsAreProper = false;
            //}
            //allElementsAreProper = IsValidPhoneNumber(_phoneNumber);
            //if (!string.IsNullOrEmpty(_email) && !IsValidEmail(_email))
            //{
            //    MessageBox.Show("Email is invalid. Please, make sure that you input a proper email type string of up to 320 characters.");
            //    allElementsAreProper = false;
            //}
            //allElementsAreProper = IsValidEmail(_email);

            bool allElementsAreProper = IsValidFirstName(_firstName) && IsValidLastName(_lastName) && IsValidAddress(_address) && IsValidPostalCode(_postalCode) && IsValidPhoneNumber(_phoneNumber) && IsValidEmail(_email);
            return allElementsAreProper;
        }

        public static bool IsValidFirstName(string _firstName) 
        {
            if (string.IsNullOrEmpty(_firstName) || _firstName.Length > 50)
            {
                MessageBox.Show("Client info is improper. Please, make sure that you only enter up to 50 characters long First Name.");
                return false;
            }
            return true;
        }
        public static bool IsValidLastName(string _lastName)
        {
            if (string.IsNullOrEmpty(_lastName) || _lastName.Length > 50)
            {
                MessageBox.Show("Client info is improper. Please, make sure that you only enter up to 50 characters long Last Name.");
                return false;
            }
            return true;
        }
        public static bool IsValidAddress(string _address)
        {
            if (string.IsNullOrEmpty(_address) || _address.Length > 100)
            {
                // Improper data
                MessageBox.Show("Client info is improper. Please, make sure that you only enter up to 100 characters long Address.");
                return false;
            }
            return true;
        }
        public static bool IsValidPostalCode(int _postalCode)
        {
            if (string.IsNullOrEmpty(_postalCode.ToString()) || (_postalCode >= 1000 && _postalCode <= 21999))
            {
                // Improper data
                MessageBox.Show("Postal code is invalid. Please, make sure that you only input 5-digit numbers between 1000 and 21999.");
                return false;
            }
            return true ;
        }
        public static bool IsValidPhoneNumber(long _phoneNumber)
        {
            if (string.IsNullOrEmpty(_phoneNumber.ToString()) || !(_phoneNumber.ToString().Length == 10))
            {
                // Conversion failed
                MessageBox.Show("Phone number : " + _phoneNumber.ToString() + " of length (" + _phoneNumber.ToString().Length + ")" + " is invalid. Please, make sure that you only input 10-digit numbers.");
                return false;
            }
            return true;
        }
        public static bool IsValidEmail(string _email)
        {
            if (string.IsNullOrEmpty(_email) || !isStringAnEmail(_email))
            {
                MessageBox.Show("Email is invalid. Please, make sure that you input a proper email type string of up to 320 characters.");
                return false;
            }
            return true;
        }
        #endregion
        #region Books
        public static bool Check_Book_INSERT_ProperInfo(long _ISBN, string _title, string _author)
        {
            bool allElementsAreProper = IsValidBookISBN(_ISBN) && IsValidBookTitle(_title) && IsValidBookAuthor(_author) ;
            return allElementsAreProper;
        }
        public static bool IsValidBookISBN(long _ISBN)
        {
            if (string.IsNullOrEmpty(_ISBN.ToString()) || !( (_ISBN.ToString().Length == 10) || (_ISBN.ToString().Length == 13) ))
            {
                MessageBox.Show("Book ISBN is improper. Please, make sure that you enter a number of 10 or 13 digits for ISBN.");
                return false;
            }
            return true;
        }
        public static bool IsValidBookTitle(string _Title)
        {
            if (string.IsNullOrEmpty(_Title) || _Title.Length > 100)
            {
                MessageBox.Show("Book title is improper. Please, make sure that you only enter up to 100 characters long Title.");
                return false;
            }
            return true;
        }
        public static bool IsValidBookAuthor(string _Author)
        {
            if (string.IsNullOrEmpty(_Author) || _Author.Length > 50)
            {
                MessageBox.Show("Book author is improper. Please, make sure that you only enter up to 50 characters long Author.");
                return false;
            }
            return true;
        }
        #endregion
        #region Orders
        #endregion
        static private bool isStringAnEmail(string _email)
        {
            if (!string.IsNullOrEmpty(_email))
            {
                // Regular expression pattern for email validation
                string pattern = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";
                Regex regex = new Regex(pattern);
                return (regex.IsMatch(_email)) && (_email.Length <= 320);
            }
            return true;
        }
    }
}
