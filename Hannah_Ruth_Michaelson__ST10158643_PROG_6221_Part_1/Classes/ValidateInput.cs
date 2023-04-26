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

           
                if (string.IsNullOrEmpty(input))
                {
                    throw new UserException("No value has been entered");
                }
                else
                    valid = true;
           
           
            return valid;
        }
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Method to take in menu string Input and ensure is a valid number 
        /// </summary>
        public int MenuInt(string input)
        {

          
                if (!int.TryParse(input, out int num))
                {
                    Console.WriteLine(String.Format("{0,-15} {1,-10} {2,-40}", " ", "Please enter a digit", " "));
                }

                if (num <= 0 || num >= 7)
                {
                    Console.WriteLine("Please enter a num that is an option");
                }
                return this.number = num;
            
           
        }
        /// <summary>
        /// Method to take in array size string Input and ensure is a valid number 
        /// </summary>
        public int ArrayNum(string input)
        {
            
                if (int.TryParse(input, out int num))
                {
                    if ((Convert.ToInt32(input) > 1))
                    {
                        this.number = num;
                        return this.number;
                    }
                    else
                        Console.WriteLine($"Input '{input}' is not a valid number.");
                }
                else
                    this.number = FindNumber(input);
            
            
            return number;
        }
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Method to find inputted strings int value 
        /// </summary>
        private int FindNumber(string str)
        {
            string input = str.ToLower();

            Dictionary<string, int> numberWords = new Dictionary<string, int>()
            {
                    {"zero", 0},
                    {"one", 1},
                    {"two", 2},
                    {"three", 3},
                    {"four", 4},
                    {"five", 5},
                    {"six", 6},
                    {"seven", 7},
                    {"eight", 8},
                    {"nine", 9},
                    {"ten", 10},
            };

                if (!numberWords.TryGetValue(input, out int num))
                {
                    Console.WriteLine($"Input '{str}' is not a valid number word.");
                }
                else
                    this.number = numberWords[input];
            
            return this.number;
        }
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Method to Retrieve String Input and Validate that is Double 
        /// </summary>
        public double ReceiveDouble(string input)
        {
            
                if (!double.TryParse(input, NumberStyles.Number, CultureInfo.InvariantCulture, out double num))
                {
                    Console.WriteLine("Please enter a number");
                }

                if (num <= 0.0)
                {
                    Console.WriteLine(String.Format("{0,-15} {1,-10} {2,-40}", " ", "Please enter a number greater that 0.0!!", " "));
                }
                return this.doubleNum = num;
            
           
        }
    
    public class UserException : Exception
        {
            public UserException(string message) : base(message)
            {

            }

        }
    }
}

        