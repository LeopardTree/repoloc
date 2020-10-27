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
            long[] arrayPersonalCodeNumber;
            int firstIndex, lastIndex;

            
            // Ask for personal code number, 12 digits (swedish)
            Console.WriteLine("Skriv in ditt personnummer:");

            // Read input
            userInput = Console.ReadLine();
            personalCodeNumber = long.Parse(userInput);
            arrayPersonalCodeNumber = ArrayPersonalCodeNumber(personalCodeNumber);

            //(Add) method 
            // Method, control right amount of digits
            isAPersonalCodeNumber = ControlTwelveDigits(arrayPersonalCodeNumber);

            // Method, control right year, 1753-2020
            //controls if its true from last method
            if (isAPersonalCodeNumber)
            {
                isAPersonalCodeNumber = ControlRightYear(personalCodeNumber);
            }
            // Method, control month, 1-12

            // Method, leap year

            // Method, control day and check to month. 

            // Method, control birth number 000-999

            // Method, check sex

            // Print if correct or not. (Assuming all are digits) (swedish)

            //stop
            Console.ReadKey();
        }

        static bool ControlTwelveDigits(long[] arrayPersonalCodeNumber)
        {

            int lengthPersonalCodenum = arrayPersonalCodeNumber.Length;

            if (lengthPersonalCodenum == 12)
            {
                return true;
            }
            else
                return false;
        }

        //did this method before i made the array. that's why I don't use the array here.
        static bool ControlRightYear(long personalCodeNumber)
        {
            int lengthOfPersonalCodeNumber = 12;
            //divides by 10^(12-4) to get the first four numbers in decimals. Then truncates the decimals.
            double firstFourDecimal = personalCodeNumber / Math.Pow(10, lengthOfPersonalCodeNumber - 4);
            int firstFour = Convert.ToInt32(firstFourDecimal);

            if (firstFour > 1752 || firstFour < 2021)
            {
                return true;
            }
            else
                return false;
        }
        //static bool ControlMonthOneToTwelve(long[] arrayPersonalCodeNumber)
        //{

        //    long month = PickYourDigits(arrayPersonalCodeNumber, 4, 5);

            


        //}
        static long[] ArrayPersonalCodeNumber(long personalCodeNumber)
        {

            long[] arrayPersonalCodeNumber = new long[12];
            int lengthArray = arrayPersonalCodeNumber.Length;
            long updatenumber = personalCodeNumber;
            int j = lengthArray;
            for (int i = 0; i < lengthArray; i++)
            {


                arrayPersonalCodeNumber[i] = updatenumber / Convert.ToInt64(Math.Pow(10, j));
                updatenumber = updatenumber - arrayPersonalCodeNumber[i] * Convert.ToInt64(Math.Pow(10, j));
                j = j - 1;


            }

            return arrayPersonalCodeNumber;

        }
        static long PickYourDigits(long[] arrayPersonalCodeNumber, int firstIndex, int lastIndex)
        {
            int firstpower = 12 - firstIndex;
            long digits = 0;
            
            
            for (int i = firstIndex; i <= lastIndex; i++)
            {
                digits += arrayPersonalCodeNumber[i] * Convert.ToInt64(Math.Pow(10, 12-(i+1)));
            }
            return digits;
        }
    }
}
