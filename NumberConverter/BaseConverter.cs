using System.Collections.Generic;
using System.Text;

namespace NumberConverter
{
    public static class BaseConverter
    {
        public static Stack<int> Convert(Number number, int toBase)
        {
            Stack<int> remainders;

            if (number.Base == toBase)
                remainders = number.ToStack();
            else if (number.Base == 1)
                remainders = ConvertToBaseOne(number);
            else
                remainders = ConvertToBase(ConvertToDecimal(number), toBase);

            return remainders;
        }

        public static string ConvertAscii(string message, int toBase)
        {
            StringBuilder output;
            Stack<int> remainders;
            int decimalValue, remainder;

            output = new StringBuilder();
            for (int count = 0; count < message.Length; count++)
            {
                decimalValue = (int)message[count];
                remainders = ConvertToBase(decimalValue, toBase);
                do
                {
                    remainder = remainders.Pop();
                    if (remainder >= (int)DigitValue.START_ALPHA)
                    {
                        if (remainder == (int)DigitValue.PLUS_VALUE)
                            output.Append(Number.PLUS_CHAR);
                        else if (remainder == (int)DigitValue.SLASH_VALUE)
                            output.Append(Number.SLASH_CHAR);
                        else
                        {
                            remainder += (int)DigitValue.NUMBER_TO_CHAR;
                            if (remainder > (int)DigitValue.UPPER_END)
                                remainder += (int)DigitValue.UPPER_TO_LOWER_SPACE;
                            output.Append((char)(remainder));
                        }
                    }
                    else
                        output.Append(remainder);
                } while (remainders.Count > 0);
                if (count != message.Length - 1)
                    output.Append(" ");
            }

            return output.ToString();
        }

        public static string ConvertToAscii(Number[] numbers)
        {
            StringBuilder ascii;

            ascii = new StringBuilder();
            foreach (Number number in numbers)
                ascii.Append(ConvertToAscii(number));

            return ascii.ToString();
        }

        public static string ConvertToAscii(Number number)
        {
            StringBuilder ascii;
            int decimalValue;

            decimalValue = ConvertToDecimal(number);
            ascii = new StringBuilder();
            ascii.Append((char)decimalValue);


            return ascii.ToString();
        }

        private static int ConvertToDecimal(Number number)
        {
            int sum, power, digitValue;
            string value;

            sum = 0;
            value = number.Value;
            power = value.Length - 1;
            for (int count = 0; count < value.Length; count++, power--)
            {
                digitValue = Number.GetDigitValue(value[count]);
                sum += Pow(number.Base, power) * digitValue;
            }

            return sum;
        }

        private static int Pow(int number, int exponent)
        {
            int result;

            if (exponent == 0)
                result = 1;
            else
                result = number * Pow(number, exponent - 1);

            return result;
        }

        private static Stack<int> ConvertToBaseOne(Number number)
        {
            Stack<int> remainders;

            remainders = new Stack<int>();

            return remainders;
        }

        private static Stack<int> ConvertToBase(int number, int toBase)
        {
            Stack<int> remainders;
            int remainder;

            remainders = new Stack<int>();
            while (number != 0)
            {
                remainder = number % toBase;
                remainders.Push(remainder);
                number /= toBase;
            }

            return remainders;
        }

        private static bool IsZero(Number number)
        {
            bool zero;
            string value;
            int numZeros;

            numZeros = 0;
            value = number.Value;
            for (int count = 0; count < value.Length; count++)
            {
                if (value[count] == '0')
                    numZeros++;
            }

            zero = numZeros == value.Length;

            return zero;
        }

        public static string DigitToString(Stack<int> remainders, Number number)
        {
            StringBuilder output;
            int remainder;

            output = new StringBuilder();
            if (!remainders.IsEmpty() && !IsZero(number))
            {
                do
                {
                    remainder = remainders.Pop();
                    if (remainder >= (int)DigitValue.START_ALPHA)
                    {
                        if (remainder == (int)DigitValue.PLUS_VALUE)
                            output.Append(Number.PLUS_CHAR);
                        else if (remainder == (int)DigitValue.SLASH_VALUE)
                            output.Append(Number.SLASH_CHAR);
                        else
                        {
                            remainder += (int)DigitValue.NUMBER_TO_CHAR;
                            if (remainder > (int)DigitValue.UPPER_END)
                                remainder += (int)DigitValue.UPPER_TO_LOWER_SPACE;
                            output.Append((char)(remainder));
                        }
                    }
                    else
                        output.Append(remainder);
                } while (remainders.Count > 0);
                output.AppendLine();
            }
            else
                output.AppendLine("0");

            return output.ToString();
        }
    }
}
