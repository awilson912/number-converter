using System;
using System.Collections.Generic;

namespace NumberConverter
{
    public class Number
    {
        public const char PLUS_CHAR = '+';
        public const char SLASH_CHAR = '/';


        public string Value { get; set; }
        public int Base { get; set; }

        private Number(string value, int inBase)
        {
            Value = value;
            Base = inBase;
        }

        public Stack<int> ToStack()
        {
            Stack<int> values;
            int digitValue;

            values = new Stack<int>();

            for (int count = 0; count < Value.Length; count++)
            {
                digitValue = GetDigitValue(Value[count]);
                values.Push(digitValue);
            }

            values = values.Reverse();

            return values;
        }

        public static Number ParseNumber(string value, int inBase)
        {
            Number number;
            char current;
            int digitValue;

            if (value.Length > 0)
            {
                for (int count = 0; count < value.Length; count++)
                {
                    current = value[count];
                    if (inBase > 10)
                    {
                        if (current != PLUS_CHAR && current != SLASH_CHAR && !char.IsDigit(current) && !char.IsLetter(current))
                            throw new IllegalNumberException($"Illegal character for the given base: {current}");

                        digitValue = GetDigitValue(current);
                        if (digitValue >= inBase)
                            throw new IllegalNumberException($"Illegal digit for the given base: {current}");
                    }
                    else if (!char.IsDigit(current))
                        throw new IllegalNumberException("Illegal digit for the given base.");
                }
                number = new Number(value, inBase);
            }
            else
                throw new IllegalNumberException("Value must not be empty.");

            return number;
        }

        public static int GetDigitValue(char character)
        {
            int digitValue;

            if (char.IsDigit(character))
                digitValue = character - (int)DigitValue.START_DIGIT;
            else if (character == PLUS_CHAR)
                digitValue = (int)DigitValue.PLUS_VALUE;
            else if (character == SLASH_CHAR)
                digitValue = (int)DigitValue.SLASH_VALUE;
            else
                digitValue = character - (int)DigitValue.NUMBER_TO_CHAR;

            if (character >= 'a')
                digitValue -= (int)DigitValue.UPPER_TO_LOWER_SPACE;

            return digitValue;
        }
    }
    
    class IllegalNumberException : Exception
    {
        public IllegalNumberException()
        {

        }

        public IllegalNumberException(string message) : base(message)
        {

        }

        public IllegalNumberException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
