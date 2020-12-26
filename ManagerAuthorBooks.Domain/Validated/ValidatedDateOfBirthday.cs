using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerAuthorBooks.Domain.Validated
{
    public static class ValidatedDateOfBirthday
    {
        public static bool IsValidDateOfBirthday(DateTime dateOfBirthday)
        {
            const int minimunAge = 30;
            int age = DateTime.Now.Year - dateOfBirthday.Year;
            if (DateTime.Now.Year < dateOfBirthday.DayOfYear)
            {
                age = age - 1;
            }

            return age < minimunAge ? false : true;

        }
    }
}
