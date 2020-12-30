using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ManagerAuthorBooks.Domain.Validated
{
    public static class ValidatedISBN
    {
        public static bool IsValidISBN(string isbn)
        {
            var regex = new Regex(@"^[A-Z0-9]{3}\-[A-Z0-9]{2}\-[A-Z0-9]{3}\-[A-Z0-9]{4}\-[A-Z0-9]{1}$");

            if (regex.IsMatch(isbn.ToString()))
            {
                return true;
            }

            return false;
        }
    }
}
