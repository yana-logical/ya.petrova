using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise4
{
    public class Phone
    {
        private readonly string _cityCode;
        private readonly string _phoneNumber;

        public Phone(string cityCode, string phoneNumber)
        {
            _cityCode = cityCode;
            _phoneNumber = phoneNumber;
        }

        public string GetPhone()
        {
            if (string.IsNullOrEmpty(_cityCode))
            {
                return (_phoneNumber);
            }
            else
            {
                return ("("+_cityCode+") "+_phoneNumber);
            }
        } 
    }
}
