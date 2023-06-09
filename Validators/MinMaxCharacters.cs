﻿using System;
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
        public int MinChars { get; set; }
        public int MaxChars { get; set; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var str = value as string;
            if (str != null)
            {
                if (!IsValid(str, MinChars, MaxChars)) return new ValidationResult(false, $"The input string does not correct");
            }
            return new ValidationResult(true, null);
        }

        public static bool IsValid(string str, int minChars, int maxChars)
        {
            if (str == null) return true;

            return str.Length >= minChars && str.Length <= maxChars;
        }
    }
}
