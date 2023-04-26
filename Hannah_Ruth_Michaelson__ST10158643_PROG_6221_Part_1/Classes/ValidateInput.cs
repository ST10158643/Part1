using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hannah_Ruth_Michaelson__ST10158643_PROG_6221_Part_1.Classes
{
    public class ValidateInput
    {
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
            return input == null;
        }
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Method to take in menu string Input and ensure is a valid number 
        /// </summary>
        public int MenuInt(string input)
        {
            return 0;
        }
        /// <summary>
        /// Method to take in array size string Input and ensure is a valid number 
        /// </summary>
        public int ArrayNum(string input)
        {
            return 0;
        }
        public double ReceiveDouble(string input)
        {
            return 0.0;
        }
        public class UserException : Exception
        {
            public UserException(string message) : base(message)
            {

            }

        }
    }
}


        