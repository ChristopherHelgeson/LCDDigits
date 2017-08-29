using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCDDigits
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] tops = new string[] { " _ ", "   ", " _ ", " _ ", "   ", " _ ", " _ ", " _ ", " _ ", " _ " };
            string[] middles = new string[] { "| |", "  |", " _|", " _|", "|_|", "|_ ", "|_ ", "  |", "|_|", "|_|" };
            string[] bottoms = new string[] { "|_|", "  |", "|_ ", " _|", "  |", " _|", "|_|", "  |", "|_|", "  |" };

            PrintTitle();
            int userNumber = GetUserIntegerAsInt();
            List<int> toPrint = IntegerToList(userNumber);
            for (int i = 0; i < toPrint.Count; i++)
            {
                Console.Write(tops[toPrint[i]] + "  ");
            }
            Console.WriteLine();
            for (int i = 0; i < toPrint.Count; i++)
            {
                Console.Write(middles[toPrint[i]] + "  ");
            }
            Console.WriteLine();
            for (int i = 0; i < toPrint.Count; i++)
            {
                Console.Write(bottoms[toPrint[i]] + "  ");
            }
            Console.WriteLine("\n\n\nHere you go. Enjoy.");
            Console.ReadLine();

        }

        private static List<int> IntegerToList(int number)
        {
            List<int> digits = new List<int>();

            while (number > 0)
            {
                digits.Add(number % 10);
                number /= 10;
            }
            digits.Reverse();
            return digits;
        }

        private static void PrintTitle()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the LCD Digit Generator!\nWhere your input is displayed in LCD font.\n");
        }

        private static int GetUserIntegerAsInt()
        {
            int numVal = -1;
            bool repeat = true;

            while (repeat == true)
            {
                Console.Write("\nPlease enter a positive integer: ");

                string input = Console.ReadLine();
                
                // ToInt32 can throw FormatException or OverflowException. 
                try
                {
                    numVal = Convert.ToInt32(input);
                    if (numVal < 0)
                    {
                        Console.WriteLine("\nThat is an integer, but it is negative.");
                        repeat = true;
                    }
                    else
                    {
                        repeat = false;
                    }
                }
                catch (FormatException e)
                {
                    Console.WriteLine("\nThat is not an integer.");
                }
                catch (OverflowException e)
                {
                    Console.WriteLine("\nThat number is too large. Maximum value is 2147483647.");
                }
                catch (Exception e)
                {
                    Console.WriteLine("\nNot sure why that input failed, but it did. Try again.");
                }
            }
            return numVal;
        }
    }
}
