using System.Text.RegularExpressions;

namespace Application.Usecases.Users
{
    public class RegexValidation
    {
        private string mobileNumberPattern = @"^01[0125]\d{8}$";
        //private string NIDPattern = @"^[23]\d{2}(0[1-9]|1[0-2])(0[1-9]|[12]\d|3[01])\d{4}\d{3}\d$";
        private string NIDPattern = @"^[10]\d";
        private string _mobileNumber;
        private string _nid;

        public bool IsMobileNumber(string MobileNumber)
        {
            _mobileNumber = MobileNumber;
            bool isValid = Regex.IsMatch(_mobileNumber, mobileNumberPattern);
            return isValid;
        }
        public bool IsNID(string NID)
        {
            _nid = NID;
            bool isValid = Regex.IsMatch(_nid, NIDPattern);
            return isValid;
        }
    }
}
