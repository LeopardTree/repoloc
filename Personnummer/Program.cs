using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace PersonalCodeNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            // Declare variables
            long personalCodeNumber;
            string userInput;
            bool isAPersonalCodeNumber;
            
            // Ask for personal code number, 12 digits (swedish)
            Console.WriteLine("Skriv in ditt personnummer:");

            // Read input
            userInput = Console.ReadLine();
            personalCodeNumber = long.Parse(userInput);
            // Method, control right amount of digits
            isAPersonalCodeNumber = ControlTwelveDigits(personalCodeNumber);
            Console.WriteLine("det är 12 siffor");
            // Method, control right year, 1753-2020
            //if (isAPersonalCodeNumber)
            //{
            //    isAPersonalCodeNumber = ControlRightYear(personalCodeNumber);
            //}
            // Method, control month, 1-12

            // Method, leap year

            // Method, control day and check to month. 

            // Method, control birth number 000-999

            // Method, check sex

            // Print if correct or not. (Assuming all are digits) (swedish)

            //stop
            Console.ReadKey();
        }

        static bool ControlTwelveDigits(long PersonalCodeNumber)
        {

            if (Math.Log10(PersonalCodeNumber) == 12)
            {
                return true;
            }
            else
                return false;
        }
        //static bool ControlRightYear(int PersonalCodeNumber)
        //{

        //}
    }
}
