using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test.Model
{
    public class Person
    {        
        public int ConvertToAge(DateTime birth, DateTime current) // not build method for unit test
        {
            int age = 0;
            age = current.Year - birth.Year;
           
            if ((current.Year % 4 == 0 && birth.Year % 4 != 0) || (current.Year % 4 != 0 && birth.Year % 4 == 0))
            { // Birth Year has leak day or Current Year has leak day
                int currentDayOfYear = current.DayOfYear;

                if (current.Year % 4 == 0)
                { // current Year has leak day
                    if (current > new DateTime(current.Year, 2, 28))
                    {
                        currentDayOfYear--;
                    }
                }
                else
                { // birth Year has leak day 
                    if (current > new DateTime(current.Year, 2, 28)) // if current day is over 28 Feb, then calculate current day + 1
                    {
                        currentDayOfYear++;
                    }
                }

                Console.WriteLine("Birth(" + birth + "), Current(" + current + ") = " + birth.DayOfYear + ", " + currentDayOfYear);
                if (currentDayOfYear < birth.DayOfYear)
                    age -= 1;
            }
            else
            { // Birth Year and Current Year both has leak day or Both does not have leak day (29 Feb)
                if (current.DayOfYear < birth.DayOfYear)
                    age -= 1;
            }


            return age;
        }

        /*
        public int ConvertToAge(DateTime birth, DateTime current)
        {
            int age = 0;
            age = current.Subtract(birth).Days;
            age = age / 365;
            return age;            
        }*/
        /*
        public int ConvertToAge(DateTime birth, DateTime current)
        {
            int age = 0;
            age = current.AddYears(-birth.Year).Year;
            return age;
        }*/
    }
}
