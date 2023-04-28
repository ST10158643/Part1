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
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Declaring and assinging value to variables for default return  
        /// </summary>

        static double doubleNum = 0.0;
        static int number = -1;

        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Method to Ensure String is not null 
        /// </summary>
        public static bool IsStringNull(string input)
        {
            // Declaring and assigning value to bool for default return  
            bool valid = false;

            try
            {
                //if input is has value bool returns true
                if (!string.IsNullOrEmpty(input))
                {
                    valid = true;

                }
                else
                    //if input is has no value throws exception
                    throw new UserException(String.Format("{0,-20} {1,-10} {2,-40}", " ", "No value has been entered", " "));
            }//UserException Try-Catch
            catch (UserException e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ForegroundColor = ConsoleColor.Yellow;
            }//OutOfMemoryException Try-Catch
            catch (OutOfMemoryException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(String.Format("{0,-15} {1,-10} {2,-40}", " ", "Error: Out of memory. Please reduce the number of ingredients or increase available memory.", " "));
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            //return bool
            return valid;
        }
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Method to take in menu string Input and ensure is a valid number 
        /// </summary>
        public static int MenuInt(string input)
        {

            try
            {  //if input is not an int then throw exception
                if (!int.TryParse(input, out int num))
                {
                    throw new UserException(String.Format("{0,-15} {1,-10} {2,-40}", " ", "Please enter a number that is an option", " "));
                }
                //if input is not between 1 and 2 throw exception
                if (num <= 0 || num >= 3)
                {
                    throw new UserException(String.Format("{0,-15} {1,-10} {2,-40}", " ", "Please enter a number that is an option", " "));
                }
                //return int
                return num;
            }//UserException Try-Catch
            catch (UserException e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ForegroundColor = ConsoleColor.Yellow;
            }//OutOfMemoryException Try-Catch
            catch (OutOfMemoryException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(String.Format("{0,-15} {1,-10} {2,-40}", " ", "Error: Out of memory. Please reduce the number of ingredients or increase available memory.", " "));
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            return number;
        }
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Method to take in array size string Input and ensure is a valid number 
        /// </summary>
        public static int ValidInt(string input)
        {
            //if input has not value then return default number 
            if (!IsStringNull(input))
                //return int
                return number;
            try
            {
                //if input value is int 
                if (int.TryParse(input, out int num))
                {
                    //if input int is not greater that 0, then throw exception
                    if (!(Convert.ToInt32(input) > 0))
                    {
                        throw new UserException(String.Format("{0,-15} {1,-10} {2,-40}", " ", $"Input '{input}' is not a valid number.", " "));
                    }
                    //else if int is not less that 0 return input number 
                    else
                    {

                        return num;
                    }
                }
                //else if input is a string pass to FindNumber Method 
                else
                {//passing input number to FindNumber Method 
                    number = FindNumber(input);
                    //if the number returned from FindNumber method is 0, then throw exception
                    if (number == 0)
                    {
                        throw new UserException(String.Format("{0,-15} {1,-10} {2,-40}", " ", $"Input '{input}' is not a valid number.", " "));
                    }
                    else
                        //else return the number returned from findNumber 
                        return number;
                }
            }//UserException Try-Catch
            catch (UserException e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ForegroundColor = ConsoleColor.Yellow;
            }//OutOfMemoryException Try-Catch
            catch (OutOfMemoryException)
            {
                Console.WriteLine(String.Format("{0,-15} {1,-10} {2,-40}", " ", "Please reduce the number of ingredients", " "));

            }
            //return int
            return number;
        }
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Method to validate string input is a double
        /// </summary>
        public static double ValidDouble(string input)
        {
            //Declaring default return double
            double reNum;
            //if input string has no value return default double
            if (!IsStringNull(input))
                //return double
                return doubleNum;
            try
            {//if input is double 
                if (double.TryParse(input, NumberStyles.Number, CultureInfo.InvariantCulture, out double num))
                {//if input double is not greater that 0.0, then throw exception
                    if (!(Convert.ToDouble(input) > 0.0))
                    {
                        throw new UserException(String.Format("{0,-15} {1,-10} {2,-40}", " ", $"Input '{input}' is not a valid number.", " "));
                    }
                    //else if double is not less that 0.0 return input double 
                    else
                    {
                        return num;
                    }
                }
                //else if input is a string, return double is assigned to value of  the double inpue passed to FindNumber Method 
                else
                {
                    reNum = Convert.ToDouble(FindNumber(input));
                    //if the number returned from FindNumber method is 0, then throw exception
                    if (reNum == 0)
                    {
                        throw new UserException(String.Format("{0,-15} {1,-10} {2,-40}", " ", $"Input '{input}' is not a valid number.", " "));
                    }
                    else
                        //else return the converted number returned from findNumber 
                        return reNum;

                }
            }//UserException Try-Catch
            catch (UserException e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ForegroundColor = ConsoleColor.Yellow;
            }//OutOfMemoryException Try-Catch
            catch (OutOfMemoryException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(String.Format("{0,-15} {1,-10} {2,-40}", " ", "Error: Out of memory. Please reduce the number of ingredients or increase available memory.", " "));
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            return doubleNum;
        }
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Method to find inputted strings int value 
        /// </summary>
        public static int FindNumber(string str)
        {

            long longNum = 0;
            long total = 0L;
            string[] words = str.Split(' ');
            int multiplier = 1;
            bool hasAnd = false;

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
                words = str.ToLowerInvariant().Split(' ');
                var numbers = new List<long>();
                foreach (var word in words)
                {
                    if (numberConvert.TryGetValue(word, out var number))
                    {
                        if (number == 0)
                        {
                            hasAnd = true;
                            continue;
                        }
                        if (hasAnd)
                        {
                            longNum += number;
                        }
                        else
                        {
                            numbers.Add(number);
                        }
                    }
                }
                foreach (long numl in numbers)
                {
                    if (numl >= 1000)
                    {
                        total += longNum * numl;
                        longNum = 0;
                    }
                    else if (numl >= 100)
                    {
                        longNum *= numl;
                    }
                    else longNum += numl;
                }
                if (str.StartsWith("minus", StringComparison.InvariantCultureIgnoreCase))
                {
                    multiplier = -1;
                }
            }//UserException Try-Catch
            catch (UserException e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ForegroundColor = ConsoleColor.Yellow;
            }//OutOfMemoryException Try-Catch
            catch (OutOfMemoryException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(String.Format("{0,-15} {1,-10} {2,-40}", " ", "Error: Out of memory. Please reduce the number of ingredients or increase available memory.", " "));
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            return Convert.ToInt32((total + longNum) * multiplier);
        }
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Method to find inputted strings int value 
        /// </summary>
        public static string FindString(double quantity)
        {
            string result = "";
            double quotient = 0;
            double remainder = 0;


            try
            {
                Dictionary<double, string> numberConvert = new Dictionary<double, string>
                {
                    {0.25,"a quater" },{0.5,"half a" }, {0, "zero"},{1, "one"}, {2, "two"},{3, "three"},{4, "four"},{5, "five"},{6, "six"},
                    {7, "seven"},{8, "eight"},{9, "nine"},{10, "ten"},{11, "eleven"},{12, "twelve"},{13, "thirteen"}, {14, "fourteen"},
                    {15, "fifteen"},{16, "sixteen"},{17, "seventeen"},{18, "eighteen"},{19, "nineteen"}, {20, "twenty"}, {30, "thirty"},
                    {40, "forty"},{50, "fifty"},{60, "sixty"},{70, "seventy"},{80, "eighty"},{90, "ninety"},{100, "hundred"},{1000, "thousand"},
                    {100000, "lakh"},{1000000, "million"},{1000000000, "billion"},{1000000000000, "trillion"},{1000000000000000, "quadrillion"},
                    {1000000000000000000, "quintillion"}
                };

                if (quantity < 0)
                {
                    result += "minus ";
                    quantity = -quantity;
                }

                if (quantity < 20)
                {
                    numberConvert.TryGetValue(quantity, out result);
                }
                else if (quantity < 100)
                {
                    quotient = Math.Floor(quantity / 10) * 10;
                    remainder = quantity % 10;
                    numberConvert.TryGetValue(quotient, out result);
                    if (remainder > 0)
                    {
                        result += " " + FindString(remainder);
                    }
                }
                else if (quantity < 1000)
                {
                    quotient = Math.Floor(quantity / 100);
                    remainder = quantity % 100;
                    result = FindString(quotient) + " hundred";
                    if (remainder > 0)
                    {
                        result += " and " + FindString(remainder);
                    }
                }
                else
                {
                    for (int i = numberConvert.Count - 1; i >= 0; i--)
                    {
                        double divisor = numberConvert.ElementAt(i).Key;
                        if (quantity >= divisor)
                        {
                            quotient = Math.Floor(quantity / divisor);
                            remainder = quantity % divisor;
                            result = FindString(quotient) + " " + numberConvert[divisor];
                            if (remainder > 0)
                            {
                                result += ", " + FindString(remainder);
                            }
                            break;
                        }
                    }
                }
            }//UserException Try-Catch
            catch (UserException e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ForegroundColor = ConsoleColor.Yellow;
            }//OutOfMemoryException Try-Catch
            catch (OutOfMemoryException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(String.Format("{0,-15} {1,-10} {2,-40}", " ", "Error: Out of memory. Please reduce the number of ingredients or increase available memory.", " "));
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            return result;
        }
        //Subclass UserException that extends the Exception class to handle exceptions
        public class UserException : Exception
        {
            public UserException(string message) : base(message)
            {

            }

        }
    }
}
//__---____---____---____---____---____---____---__.ooo END OF FILE ooo.__---____---____---____---____---____---____---__\\






