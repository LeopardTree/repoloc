using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GuessNumber
{
    class Program
    {
        static void Main(string[] args)
        {

            //              Gissa talet
            //Leken ”Gissa talet” bygger på att en person tänker på ett tal från 1 till och med 100.Sedan
            //ska den andra personen gissa vilket talet är. Den som tänker får bara svar ’För högt’ om
            //gissningen är för hög eller ’För lågt’ om gissningen är för låg.Det gället att göra så få
            //gissningar som möjligt.
            //              Genomförande
            //Du ska nu göra ett program som fungerar på ett liknade sätt.Datorn ’tänker’ på ett tal från
            //och med 1 till och med 100.Användaren skriver in sin gissning och datorn anger om
            //gissningen var ”to high” or ”to low”.
            //Datorn ska också hålla reda på antalet gissningar och när användaren gissat rätt ska antalet
            //gissningar skrivas ut.
            //Om användaren gissar utanför området 1 - 100 ska dator inte räkna detta som en gissning
            //utan meddela användaren om att gissningen inte var tillåten och som då får göra om sin
            //gissning.
            //Beroende på antalet gissningar ska dator skriva ut ett meddelande som anger hur bra
            //spelaren var.

            //slumpa ett tal mellan 1-100
            Random rnd = new Random();
            int randomnumber = rnd.Next(1, 101);
            string userInput = "";
            //bool success;
            int guess;
            Console.WriteLine("Jag tänker på ett tal mellan 1 och 100.");
            guess = TryNumber();

            //testa om gissningen är rätt, för låg eller för hög
            //gör detta i en metod

            //om det är för lågt skriv gissa högre
            //om det var för högt skriv gissa lägre


            //räkna antal gissningar i en for-loop (gör sist)
            //om det är rätt, skriv ut, det var rätt och antal gissningar




            Console.ReadKey();
        }
        //static int Test(int guess, int randomnumber)
        //{
        //    if( guess == randomnumber)
        //    {
        //        Console.WriteLine("det var rätt");
        //        return 1;
        //    }
        //    else if( guess)
        //}
        static int TryNumber()
        {
            Console.WriteLine("Gissa vilket det är:");
            string userInput = "";
            int guess;
            userInput = Console.ReadLine();
            while (int.TryParse(userInput, out guess) == false)
            {
                Console.WriteLine("Felaktig inmatning. Gissa igen:");
                userInput = Console.ReadLine();
            }
            if (guess < 101 || guess > 0)
            {
                return guess;
            }
            else
            {
                Console.WriteLine("Talet är inte i intervall 1 till 100. Pröva igen:");
                guess = int.Parse(Console.ReadLine());
            }
        }

            //stop
        
        
    }
}
