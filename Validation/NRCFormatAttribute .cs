using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace LicenseApp.Validation
{
    public class NRCFormatAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
                return false;

            string nrcPattern = @"^\d{1,14}/[A-Za-z]{10}\(Naing\)\d{6}$";

            return Regex.IsMatch(value.ToString(), nrcPattern);
        }
    }
}
