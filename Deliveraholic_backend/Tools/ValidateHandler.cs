using System.Text.RegularExpressions;

namespace deliveraholic_backend.Tools
{
    public class ValidateHandler
    {
        public bool ValidateNames(string name)
        {
            // Validate names (letters only with spaces, 2 min 75 max).

            Regex regex = new Regex(@"^[a-zA-Z ]{2,75}$");
            bool isValid = regex.IsMatch(name.Trim());

            if (!isValid)
            {
                return false;
            }
            return true;
        }


        public bool ValidateEmail(string email)
        {
            // Validate email.

            Regex regex = new Regex(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
            bool isValid = regex.IsMatch(email.Trim());

            if (!isValid)
            {
                return false;
            }
            return true;
        }


        public bool ValidatePassword(string password)
        {
            // Validate password (letters and numbers, 8 min).

            Regex regex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$");
            bool isValid = regex.IsMatch(password.Trim());

            if (!isValid)
            {
                return false;
            }
            return true;
        }


        public bool ValidatePhonenumber(string phonenumber)
        {
            // Validate dutch phonenumbers (+316 & 06)

            Regex regex = new Regex(@"(^\+[0-9]{2}|^\+[0-9]{2}\(0\)|^\(\+[0-9]{2}\)\(0\)|^00[0-9]{2}|^0)([0-9]{9}$|[0-9\-\s]{10}$)");
            bool isValid = regex.IsMatch(phonenumber);

            if (!isValid)
            {
                return false;
            }
            return true;
        }
    }
}