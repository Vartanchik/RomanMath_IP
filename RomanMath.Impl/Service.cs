using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace RomanMath.Impl
{
    public static class Service
    {
        /// <summary>
        /// See TODO.txt file for task details.
        /// Do not change contracts: input and output arguments, method name and access modifiers
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>

        public static int Evaluate(string expression)
        {
            // checking for null or empty value
            if (string.IsNullOrEmpty(expression))
            {
                throw new ArgumentException("The input string is invalid. String is null or empty.");
            }

            // characters checking
            if (!expression.All(c => "+-*MDCLXVI".Contains(c)))
            {
                throw new ArgumentException("The input string is invalid. String must contain only: +-*MDCLXVI");
            }

            // array of roman numbers from expression
            char[] separatorChars = { '+', '-', '*' };

            var romanNum = expression.Split(separatorChars);

            // list of operators from expression
            var operators = new List<char>();

            foreach (char c in expression)
            {
                if (c == '+' || c == '-' || c == '*')
                {
                    operators.Add(c);
                }
            }

            // math expression converted to arabic numbers
            var expressionArabic = string.Empty;

            for (int i = 0; i < romanNum.Length - 1; i++)
            {
                expressionArabic += RomanToInteger(romanNum[i]);
                expressionArabic += operators[i];
            }

            expressionArabic += RomanToInteger(romanNum[romanNum.Length-1]);

            // expression evaluating
            var dt = new DataTable();

            return (int) dt.Compute(expressionArabic, "");
        }

        public static int RomanToInteger(string roman)
        {
            int number = 0;

            for (int i = 0; i < roman.Length; i++)
            {
                if (i + 1 < roman.Length && RomanMap[roman[i]] < RomanMap[roman[i + 1]])
                {
                    number -= RomanMap[roman[i]];
                }
                else
                {
                    number += RomanMap[roman[i]];
                }
            }
            return number;
        }

        private static Dictionary<char, int> RomanMap = new Dictionary<char, int>()
        {
            {'I', 1},
            {'V', 5},
            {'X', 10},
            {'L', 50},
            {'C', 100},
            {'D', 500},
            {'M', 1000}
        };
    }
}
