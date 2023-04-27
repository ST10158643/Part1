using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hannah_Ruth_Michaelson__ST10158643_PROG_6221_Part_1.Classes
{
    public class ValidateInput
    {
        bool valid;
        int number;
        double doubleNum;
        // int Number { get; set; } = -1;
        //public double DoubleNum { get => doubleNum; set => doubleNum = value
        public ValidateInput()
        {
            //remove?
        }
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Method to Ensure String is not null 
        /// </summary>
        public bool IsStringNull(string input)
        {

            try
            {
                if (string.IsNullOrEmpty(input))
                {
                    throw new UserException("No value has been entered");
                }
                else
                    valid = true;
            }
            catch (UserException e)
            {
                Console.WriteLine($"Message: {e.Message}");
            }
            catch (OutOfMemoryException)
            {
                Console.WriteLine("Error: Out of memory. Please reduce the number of ingredients or increase available memory.");

            }
            return valid;
        }

        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Method to take in menu string Input and ensure is a valid number 
        /// </summary>
        public int MenuInt(string input)
        {

            try
            {
                if (!int.TryParse(input, out int num))
                {
                    throw new UserException(String.Format("{0,-15} {1,-10} {2,-40}", " ", "Please enter a digit", " "));
                }

                if (num <= 0 || num >= 7)
                {
                    throw new UserException("Please enter a num that is an option");
                }
                return this.number = num;
            }
            catch (UserException e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ResetColor();
            }
            catch (OutOfMemoryException)
            {
                Console.WriteLine(String.Format("{0,-15} {1,-10} {2,-40}", " ", "Sir please input a smaller number", " "));

            }
            return this.number;
        }
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Method to take in array size string Input and ensure is a valid number 
        /// </summary>
        public int ArrayNum(string input)
        {
            try
            {
                if (int.TryParse(input, out int num))
                {
                    if ((Convert.ToInt32(input) > 1))
                    {
                        this.number = num;
                        return this.number;
                    }
                    else
                        throw new UserException($"Input '{input}' is not a valid number.");
                }
                else
                    this.number = FindNumber(input);
            }
            catch (UserException e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ResetColor();
            }
            catch (OutOfMemoryException)
            {
                Console.WriteLine(String.Format("{0,-15} {1,-10} {2,-40}", " ", "Please reduce the number of ingredients", " "));

            }
            return number;
        }
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Method to find inputted strings int value 
        /// </summary>

        private static int FindNumber(string str)
        {
            string input = str.ToLower();
            long longNum = 0;
            long total = 0L;
            List<int> numbers = new List<int>();
            string[] words = str.Split(' ');
            int multiplier = 1;

            Dictionary<string, long> numberConvert = new Dictionary<string, long>
            {
            {"zero",0},{"one",1},{"two",2},{"three",3},{"four",4},{"five",5},{"six",6},
            {"seven",7},{"eight",8},{"nine",9},{"ten",10},{"eleven",11},{"twelve",12},
            {"thirteen",13},{"fourteen",14},{"fifteen",15},{"sixteen",16},{"seventeen",17},
            {"eighteen",18},{"nineteen",19},{"twenty",20},{"thirty",30},{"forty",40},
            {"fifty",50},{"sixty",60},{"seventy",70},{"eighty",80},{"ninety",90},
            {"hundred",100},{"thousand",1000},{"lakh",100000},{"million",1000000},
            {"billion",1000000000},{"trillion",1000000000000},{"quadrillion",1000000000000000},
            {"quintillion",1000000000000000000}
             };
            try
            {
                foreach (string word in words)
                {
                    string wordLower = word.ToLowerInvariant();
                    if (numberConvert.ContainsKey(wordLower))
                    {
                        numbers.Add((int)numberConvert[wordLower]);
                    }
                }
                foreach (long numl in numbers)
                {
                    if (numl >= 1000)
                    {
                        total += longNum * numl;
                        Console.WriteLine("numl >= 1000" + total.ToString() + "  +  " + total);
                        longNum = 0;
                    }
                    else if (numl >= 100)
                    {
                        longNum *= numl;
                        Console.WriteLine("numl >= 100" + longNum.ToString() + "  +  " + longNum); ;
                    }
                    else longNum += numl;
                }
                if (str.StartsWith("minus", StringComparison.InvariantCultureIgnoreCase))
                {
                    multiplier = -1;
                }
            }
            catch (UserException e)
            {

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ResetColor();

            }
            return Convert.ToInt32((total + longNum) * multiplier);
        }

        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Method to Retrieve String Input and Validate that is Double 
        /// </summary>
        public double ReceiveDouble(string input)
        {
            try
            {
                if (!double.TryParse(input, NumberStyles.Number, CultureInfo.InvariantCulture, out double num))
                {
                    throw new UserException("Please enter a number");
                }

                if (num <= 0.0)
                {
                    throw new UserException(String.Format("{0,-15} {1,-10} {2,-40}", " ", "Please enter a number greater that 0.0!!", " "));
                }
                return this.doubleNum = num;
            }
            catch (UserException e)
            {

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ResetColor();

            }
            catch (OutOfMemoryException)
            {
                Console.WriteLine(String.Format("{0,-15} {1,-10} {2,-40}", " ", "Please input a smaller number", " "));

            }
            return this.doubleNum;
        }
    }
    public class UserException : Exception
    {
        public UserException(string message) : base(message)
        {

        }

    }
}
//__---____---____---____---____---____---____---__.ooo END OF FILE ooo.__---____---____---____---____---____---____---__\\

