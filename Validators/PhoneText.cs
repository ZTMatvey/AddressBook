using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AddressBook.Validators
{
    internal sealed class PhoneText : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var str = value as string;
            if (str != null)
            {
                if (!IsValid(str)) return new ValidationResult(false, $"Input does not correct");
            }
            return new ValidationResult(true, null);
        }

        public static bool IsValid(string str)
        {
            if(str  == null) return true;

            return Regex.IsMatch(str, "^\\+7-\\d\\d\\d-\\d\\d\\d-\\d\\d-\\d\\d$"); ;
        }
    }
}
