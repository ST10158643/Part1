using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hannah_Ruth_Michaelson__ST10158643_PROG_6221_Part_1.Classes
{
    internal class Ingredient
    {
        
        /// <summary>
        /// Holds the ingredients number 
        /// </summary>
        public int Number { get; set; } = 0;

        /// <summary>
        /// Holds the Name of ingredients
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Holds the unit of measure of the ingredient
        /// </summary>
        public string UnitofM { get; set; } = string.Empty;

        /// <summary>
        /// Holds the quantity for the ingredient
        /// </summary>
        public double Quantity { get; set; } = 0.0;

        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Default Constructor
        /// </summary>

        public Ingredient()
        {


        }
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Method to Output Ingredients
        /// </summary>
        public void DisplayIngredients()
        {
            Console.WriteLine("* " + Convert.ToString(this.Quantity) + " " + this.UnitofM + " of " + this.Name);

        }
    }
}
