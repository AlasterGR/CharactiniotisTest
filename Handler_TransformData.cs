using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CharactiniotisTest
{
    internal partial class Handler_TransformData
    {
        #region CLIENTS table
        public static int SetID(string _iD)
        {
            int _iD_Integer = 0;
            if (!string.IsNullOrWhiteSpace(_iD))
            {
                _iD = _iD.Trim();
                _iD = _iD.Replace(" ", "");
                _iD = _iD.Replace("\t", "");
                _iD = _iD.Replace("\n", "");
                if (!int.TryParse(_iD, out _iD_Integer))
                {
                    MessageBox.Show("ID could not be parsed as number. Please, make sure you are inputing numeric digits only.");
                }
            }
            //else MessageBox.Show("ID is empty.");
            return _iD_Integer;
        }
        public static string SetFirstName(string _firstName)
        {
            if (!string.IsNullOrWhiteSpace(_firstName))
            {
                _firstName = _firstName.Trim();
                _firstName = _firstName.Replace(" ", "");
                _firstName = _firstName.Replace("\t", "");
                _firstName = _firstName.Replace("\n", "");
                _firstName = char.ToUpper(_firstName[0]) + _firstName[1..];
            }
            //else MessageBox.Show("First Name is empty");
            return _firstName;
        }
        public static string SetLastName(string _lastName)
        {
            if (!string.IsNullOrWhiteSpace(_lastName))
            {
                _lastName = _lastName.Trim();
                _lastName = _lastName.Replace(" ", "");
                _lastName = _lastName.Replace("\t", "");
                _lastName = _lastName.Replace("\n", "");
                _lastName = char.ToUpper(_lastName[0]) + _lastName.Substring(1);
            }
            //else MessageBox.Show("Last Name is empty");
            return _lastName;
        }
        public static string SetAddress(string _address)
        {
            if (!string.IsNullOrWhiteSpace(_address))
            {
                _address = _address.Trim();
                _address = Regex_RemoveConsecutiveSpaces().Replace(_address, " ");
            }
            //else MessageBox.Show("Last Name is empty");
            return _address;
        }

        public static int SetPostalCode(string _postalCode)
        {
            int _postalCodeInteger = 0;
            if (!string.IsNullOrWhiteSpace(_postalCode))
            {
                _postalCode = _postalCode.Trim();
                _postalCode = _postalCode.Replace(" ", "");
                _postalCode = _postalCode.Replace("\t", "");
                _postalCode = _postalCode.Replace("\n", "");
                if (!int.TryParse(_postalCode, out _postalCodeInteger))
                {
                    MessageBox.Show("Postal Code could not be parsed as number. Please, make sure you are inputing numeric digits only.");
                }
            }
           //else MessageBox.Show("Postal Code is empty.");
           return _postalCodeInteger;
        }
        public static long SetPhoneNumber(string _phoneNumber)
        {
            long _phoneNumberInteger = 0;
            if (!string.IsNullOrWhiteSpace(_phoneNumber))
            {
                _phoneNumber = _phoneNumber.Trim();
                _phoneNumber = _phoneNumber.Replace(" ", "");
                _phoneNumber = _phoneNumber.Replace("\t", "");
                _phoneNumber = _phoneNumber.Replace("\n", "");
                if (!long.TryParse(_phoneNumber, out _phoneNumberInteger))
                {
                    MessageBox.Show("Phone Number could not be parsed as number. Please, make sure you are inputing numeric digits only.");
                }
            }
            //else MessageBox.Show("Phone Number is empty.");
            return _phoneNumberInteger;
        }
        public static string SetEmail(string _email)
        {
            if (!string.IsNullOrWhiteSpace(_email))
            {
                _email = _email.Trim();
                _email = _email.Replace(" ", "");
                _email = _email.Replace("\t", "");
                _email = _email.Replace("\n", "");
            }               
            return _email;
        }
        #endregion
        #region BOOKS table
        public static long SetISBN(string _isbn)
        {
            long _isbn_Number = 0;
            if (!string.IsNullOrWhiteSpace(_isbn))
            {
                _isbn = _isbn.Trim();
                _isbn = _isbn.Replace(" ", "");
                _isbn = _isbn.Replace("\t", "");
                _isbn = _isbn.Replace("\n", "");
                if (!long.TryParse(_isbn, out _isbn_Number))
                {
                    MessageBox.Show("ISBN could not be parsed as number. Please, make sure you are inputing numeric digits only.");
                }
            }
            //else MessageBox.Show("ISBN is empty.");
            return _isbn_Number;
        }
        public static string SetBookTitle(string _title)
        {
            if (!string.IsNullOrWhiteSpace(_title))
            {
                _title = _title.Trim();
                _title = _title.Replace(" ", "");
                _title = _title.Replace("\t", "");
                _title = _title.Replace("\n", "");
                _title = char.ToUpper(_title[0]) + _title.Substring(1);
            }
            //else MessageBox.Show("Book Title is empty");
            return _title;
        }
        public static string SetBookAuthor(string _author)
        {
            if (!string.IsNullOrWhiteSpace(_author))
            {
                _author = _author.Trim();
                _author = _author.Replace(" ", "");
                _author = _author.Replace("\t", "");
                _author = _author.Replace("\n", "");
                _author = char.ToUpper(_author[0]) + _author.Substring(1);
            }
            //else MessageBox.Show("Book Author is empty");
            return _author;
        }
        #endregion
        #region ORDERS header table
        public static string SetOrderDate(string _date)
        {
            if (!string.IsNullOrWhiteSpace(_date))
            {
                _date = _date.Trim();
                _date = _date.Replace(" ", "");
                _date = _date.Replace("\t", "");
                _date = _date.Replace("\n", "");
            }
            //else MessageBox.Show("Order Date is empty");
            return _date;
        }
        #endregion
        #region ORDERS details table

        #endregion
        [System.Text.RegularExpressions.GeneratedRegex(@"\s+")]
        private static partial System.Text.RegularExpressions.Regex Regex_RemoveConsecutiveSpaces();
    }


}
