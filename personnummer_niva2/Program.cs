using System;
using System.Collections.Generic;
using System.Data;
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
            bool isAPersonalCodeNumber = false;
            long[] arrayPersonalCodeNumber;
            int year;
            bool leapyear;
            long month;
            long day;
            long birthnumber;
            string sex;
            bool move = true;
            Console.WriteLine("tryck escape om du vill avsluta programmet");
            while (move)
            {
                // Ask for personal code number, 12 digits or 10 digits (with punctuation mark)
                personalCodeNumber = UserInput();
                
                if (personalCodeNumber == -09999)
                {
                    break;
                }
                //method for creating an array of 
                arrayPersonalCodeNumber = ArrayPersonalCodeNumber(personalCodeNumber);

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
                // Method, check the verificationdigit
                if (isAPersonalCodeNumber)
                {
                    isAPersonalCodeNumber = ControlVerificationDigit(arrayPersonalCodeNumber);
                }
                // Method, check sex and print if correct
                if (isAPersonalCodeNumber)
                {
                    sex = ControlSex(birthnumber);
                    Console.WriteLine("Korrekt personnummer med kön {0}.", sex);
                }
                // Print if not correct  
                else
                {
                    Console.WriteLine("Detta var inte ett korrekt personnummer.");
                }
                //stop
                if (Console.ReadKey().Key == ConsoleKey.Escape)
                {
                    move = false;
                }
            }

            
        }
        static bool ControlTwelveDigits(long[] arrayPersonalCodeNumber)
        {
            if (arrayPersonalCodeNumber.Length == 12)
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
                
            }
            return arrayPersonalCodeNumber;
        }
        static long PickYourDigits(long[] arrayPersonalCodeNumber, int firstIndex, int lastIndex)
        {

            //long digitsWithZeros = 0;
            int i = 0;
            long digits = 0;
            int tenthpower = lastIndex - firstIndex;
            int j = 0;
            //
            for (i = firstIndex; i <= lastIndex; i++)
            {
                digits += arrayPersonalCodeNumber[i] * Convert.ToInt64(Math.Pow(10, tenthpower - j));
                //digits = digitsWithZeros / Convert.ToInt64(Math.Pow(10, tenthpower - j));
                j++;
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
            for (int i = 0; i < 4; i++)
            {
                if (array30Days[i] == month & day > 30)
                {
                    dayIsRight = false;
                }
            }
            //february
            if (month == 2)
            {
                if (leapyear & day > 29)
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

            if (birthnumber % 2 == 0 || birthnumber == 0)
            {
                return "kvinna";
            }
            else
                return "man";
        }
        //static bool CheckControlDigit(long [] arrayPersonalCodeNumber)
        //{

        //}
        static bool TroubleshootingTen(string userInput)
        {
            bool inputIsOk = true;
            //array with the positions for where the digits should be in the tendigits personalcodenumber
            int[] arrayTenDigits = new int[10] { 0, 1, 2, 3, 4, 5, 7, 8, 9, 10 };

            for (int i = 0; i < 10; i++)
            {
                if (Char.IsDigit(userInput[arrayTenDigits[i]]) == false)
                {
                    inputIsOk = false;
                }
            }
            //The 6th index in userInput should be a punctuation mark.
            //43 is asci for + and 45 is asci for - . 
            if (userInput[6] == (char)43 ^ userInput[6] == (char)45)
            {
                inputIsOk = true;
            }
            return inputIsOk;
        }
        static long UserInput()
        {
            bool isAPersonalCodeNumber = false;
            string userInput = "";
            long personalCodeNumber = 0;

            while (isAPersonalCodeNumber == false)
            {
                Console.WriteLine("Skriv in ett personnummer:");
                if (Console.ReadKey().Key == ConsoleKey.Escape)
                {
                    personalCodeNumber = -09999;
                    isAPersonalCodeNumber = true;
                    break;
                }
                userInput = Console.ReadLine();
                if (userInput.Length == 11)
                {
                    //method for checking if the characters are right
                    isAPersonalCodeNumber = TroubleshootingTen(userInput);
                    if (isAPersonalCodeNumber)
                    {
                        //if the characters are right. convert to a twelve digit number
                        personalCodeNumber = ConvertTenToTwelve(userInput);
                    }
                }
                else
                {
                    isAPersonalCodeNumber = Int64.TryParse(userInput, out personalCodeNumber);
                }
            }
            return personalCodeNumber;
        }
        static long ConvertTenToTwelve(string userInput)
        {
            long personalCodeNumber;
            bool more = true;
            //first the string is 11 char long
            //if the first digit is 0, 1 or 2: 
            // {if index 6 is - ,  add 20
            // else , add 19  }
            //else 
            // {if index 6 is - add 19
            // else, add 18}

            for (int i = 0; i < 3; i++)
            {
                if (userInput[0] == (char)(48 + i))
                {
                    if (userInput[6] == (char)45)
                    {
                        userInput = "20" + userInput;
                        more = false;
                    }
                    else if (userInput[6] == (char)43)
                    {
                        userInput = "19" + userInput;
                        more = false;
                    }
                }
                if (more == false)
                {
                    break;
                }
            }
            if (more == true)
            {
                if (userInput[6] == (char)45)
                {
                    userInput = "19" + userInput;
                }
                else
                    userInput = "18" + userInput;
            }
            //now the string is 13 char long
            //remove 1 char  at index 8, the punctuation mark
            userInput = userInput.Remove(8, 1);
            return personalCodeNumber = Int64.Parse(userInput);
        }
        static bool ControlVerificationDigit(long[] arrayPersonalCodeNumber)
        {
            //calculates and verifies the verificationdigit with the Luhn-algoritm
            // does arrays for digits at even index and digits at odd index
            int[] arrayEven = new int[5];
            int[] arrayOdd = new int[4];
            int j = 0;
            int i = 0;
            int verificationDigit;
            int additionnumber = 0;
            for (i = 2; i < 11; i = i + 2)
            {
                arrayEven[j] = 2* Convert.ToInt32(arrayPersonalCodeNumber[i]);
                j++;
            }
            j = 0;
            for(i = 3; i < 10; i = i + 2)
            {
                arrayOdd[j] = Convert.ToInt32(arrayPersonalCodeNumber[i]);
                // starts adding the numbers together. first the ones from odd index
                additionnumber = additionnumber + arrayOdd[j];
                j++;
            }
            for(i = 0; i < 5; i++)
            {
                if ( arrayEven[i] > 9)
                {  
                    //split up a number between 10-19 and add together is the same as subtract 9 from it.
                    arrayEven[i] = arrayEven[i] - 9;  
                }
                additionnumber = additionnumber + arrayEven[i];
            }
            verificationDigit = (10 - (additionnumber % 10)) % 10;

            if (verificationDigit == arrayPersonalCodeNumber[11])
            {
                return true;
            }
            else
                return false;
        }
    }
}
