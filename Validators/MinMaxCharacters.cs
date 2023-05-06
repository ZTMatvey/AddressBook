using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AddressBook.Validators
{
    internal sealed class MinMaxCharacters : ValidationRule
    {
        private const int MINIMUM_CHARACTERS = 2;
        private const int MAXIMUM_CHARACTERS = 50;

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var str = value as string;
            if (str != null)
            {
                if (str.Length < MINIMUM_CHARACTERS) return new ValidationResult(false, $"Use at least {MINIMUM_CHARACTERS} characters");
                if (str.Length > MAXIMUM_CHARACTERS) return new ValidationResult(false, $"Use less than {MAXIMUM_CHARACTERS} characters");
            }
            return new ValidationResult(true, null);
        }
    }
}
