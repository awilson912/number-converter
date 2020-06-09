using System;
using System.Collections.Generic;

namespace NumberConverter
{
    public class Program
    {
        public const int MIN_BASE = 2;
        public const int MAX_BASE = 64;

        public static void Main(string[] args)
        {
            string message = "Internet Explorer is the best!";
            int toBase = 2;

            Console.WriteLine(BaseConverter.ConvertAscii(message, toBase));
            /*
            Stack<int> stack;
            Number number;
            string value, output;
            int fromBase, toBase;

            value = GetValue();
            fromBase = GetFromBase();
            toBase = GetToBase();

            try
            {
                number = Number.ParseNumber(value, fromBase);
                stack = BaseConverter.Convert(number, toBase);
                output = BaseConverter.DigitToString(stack, number);
                Console.WriteLine($"{number.Value} from base {number.Base} to base {toBase} is:  {output}");
            }
            catch (IllegalNumberException ex)
            {
                Console.WriteLine(ex.Message);
            }
            */
        }

        public static string GetValue()
        {
            string value;

            Console.Write("Enter a value to convert to another base (min 1, max 64):  ");
            value = Console.ReadLine();

            return value;
        }

        public static int GetFromBase()
        {
            int fromBase;

            do
            {
                Console.Write("Enter the base to convert from (min {0}, max {1}):  ", MIN_BASE, MAX_BASE);
                fromBase = Convert.ToInt32(Console.ReadLine());
            } while (!IsValidBase(fromBase));
            

            return fromBase;
        }

        public static int GetToBase()
        {
            int toBase;

            do
            {
                Console.Write("Enter the base to convert to (min {0}, max {1}):  ", MIN_BASE, MAX_BASE);
                toBase = Convert.ToInt32(Console.ReadLine()); 
            } while (!IsValidBase(toBase));

            return toBase;
        }

        private static bool IsValidBase(int givenBase)
        {
            bool validBase;

            validBase = (givenBase >= MIN_BASE && givenBase <= MAX_BASE);

            return validBase;
        }
    }
}