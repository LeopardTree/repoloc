using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
            int year;
            bool leapyear;
            long month;
            long day;
            long birthnumber;
            string sex;
            bool move = true;
            while(move)
            { 
                // Ask for personal code number, 12 digits (swedish)
                Console.WriteLine("Skriv in ditt personnummer:");

                // Read input
                userInput = Console.ReadLine();
                personalCodeNumber = long.Parse(userInput);
                arrayPersonalCodeNumber = ArrayPersonalCodeNumber(personalCodeNumber);

                //(Add) method 
                // Method, control right amount of digits
                isAPersonalCodeNumber = ControlTwelveDigits(arrayPersonalCodeNumber);

                //Method to get the year
                year = Year(personalCodeNumber);
                // Method, control right year, 1753-2020
                //controls if its true from last method
                if (isAPersonalCodeNumber)
                {
                    isAPersonalCodeNumber = ControlRightYear(year);
                }
                // Method, control month, 1-12
                month = PickYourDigits(arrayPersonalCodeNumber, 4, 5);
                //Console.WriteLine(month);
                if (isAPersonalCodeNumber)
                {
                    isAPersonalCodeNumber = ControlMonth(month);
                }
                // Method, leap year
                leapyear = LeapYear(year);

                // Method, control day and check to month. 
                day = PickYourDigits(arrayPersonalCodeNumber, 6, 7);
                if (isAPersonalCodeNumber)
                {
                    isAPersonalCodeNumber = ControlDay(month, day, leapyear);
                }

                // Method, control birth number 000-999
                birthnumber = PickYourDigits(arrayPersonalCodeNumber, 8, 10);
                if (isAPersonalCodeNumber)
                {
                    isAPersonalCodeNumber = ControlBirthNumber(birthnumber);

                }
                // Method, check sex
                if (isAPersonalCodeNumber)
                {
                    sex = ControlSex(birthnumber);
                    Console.WriteLine("Korrekt personnummer med kön {0}.", sex);
                }
                // Print if correct or not. (Assuming all are digits) (swedish)
                else
                {
                    Console.WriteLine("Detta var inte ett korrekt personnummer.");
                    
                }

            }
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
        static bool ControlRightYear(int year)
        {
            //both must be true
            if (year > 1752 && year < 2021)
            {
                return true;
            }
            else
                return false;
        }
        //did this method before i made the array. that's why I don't use the array here.
        static int Year(long personalCodeNumber)
        {
            //divides by 10^(12-4) to get the first four numbers in decimals. Then truncates the decimals.
            double firstFourDecimal = personalCodeNumber / Math.Pow(10, 12 - 4);
            int year = Convert.ToInt32(firstFourDecimal);
            return year;
        }
        static bool ControlMonth(long month)
        {
            //the digits for month are at index 4 and 5 since the array starts at index 0

            if (month < 13 && month > 0)
            {
                return true;
            }
            else
                return false;   
        }
        static long[] ArrayPersonalCodeNumber(long personalCodeNumber)
        {
            //declares an array of 12 elements
            long[] arrayPersonalCodeNumber = new long[12];
            int lengthArray = arrayPersonalCodeNumber.Length;
            long updatenumber = personalCodeNumber;
            int j = lengthArray;
            // 
            for (int i = 0; i < lengthArray; i++)
            {
                arrayPersonalCodeNumber[i] = updatenumber / Convert.ToInt64(Math.Pow(10, j - 1));
                updatenumber = updatenumber - arrayPersonalCodeNumber[i] * Convert.ToInt64(Math.Pow(10, j - 1));
                j = j - 1;
                //Console.WriteLine(arrayPersonalCodeNumber[i]);
            }
            return arrayPersonalCodeNumber;
        }
        static long PickYourDigits(long[] arrayPersonalCodeNumber, int firstIndex, int lastIndex)
        {
            
            long digitsWithZeros = 0;
            int i = 0;
            long digits = 0;
            //Multiplies each digit in the array with 10^(length - place in array)
            //divides with with 10^(length - place in array) for each digit
            for (i = firstIndex; i <= lastIndex; i++)
            {
                digitsWithZeros += arrayPersonalCodeNumber[i] * Convert.ToInt64(Math.Pow(10, 12-i-1));
                digits = digitsWithZeros / Convert.ToInt64(Math.Pow(10, 12 - i - 1));
            }
            
            return digits;
        }
        static bool LeapYear(int year)
        {
            bool leapyear = false;

            if (year % 400 == 0)
            {
                leapyear = true;
            }
            else if (year % 100 == 0)
            {
                leapyear = false;
            }
            else if (year % 4 == 0)
            {
                leapyear = true;
            }
            else
            {
                leapyear = false;
            }
            return leapyear;
        }
        static bool ControlDay(long month, long day, bool leapyear)
        { 
            bool dayIsRight = true;
            //arrays for the months with 31 and 30 days
            int[] array31Days = new int[7] { 1, 3, 5, 7, 8, 10, 12 };
            int[] array30Days = new int[4] { 4, 6, 9, 11 };

            for (int i = 0; i < 7; i++)
            {
                if (array31Days[i] == month & day > 31)
                {
                    dayIsRight = false;
                }   
            }
            for(int i = 0; i < 4; i++)
            {
                if (array30Days[i] == month & day > 30)
                {
                    dayIsRight = false;
                }
            }
            //february
            if (month == 2)
            {
                if(leapyear & day > 29)
                {
                    dayIsRight = false;
                }
                if (leapyear == false & day > 28)
                {
                    dayIsRight = false;
                }
            }
            if (day < 1)
            {
                dayIsRight = false;
            }
            return dayIsRight;
        }
        static bool ControlBirthNumber(long birthnumber)
        {
            //both must be true
            if (birthnumber >= 0 && birthnumber <= 999)
            {
                return true;
            }
            else
                return false;
        }
        static string ControlSex(long birthnumber)
        {
            string sex = "";
            if (birthnumber % 2 == 0 || birthnumber == 0)
            {
                return sex = "kvinna";
            }
            else
                return sex = "man";
        }
    }
}
