using System;

namespace Percentages
{
    class Percentages
    {
        public static double Calculate(string userInput)
        {
            var substrings = userInput.Split();
            var amount = Double.Parse(substrings[0]);
            var percentage = Double.Parse(substrings[1]);
            var monthsPassed = Double.Parse(substrings[2]);

            double sum = amount * (Math.Pow((1 + (percentage / 100) / 12), monthsPassed));
            return sum;
        }
    }
}
