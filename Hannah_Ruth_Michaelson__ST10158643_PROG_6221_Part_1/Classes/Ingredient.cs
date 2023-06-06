using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hannah_Ruth_Michaelson__ST10158643_PROG_6221_Part_1.Classes
{
    public class Ingredient
    {
        
        /// <summary>
        /// Holds the calories for the ingredient
        /// </summary>
        public double Calories { get; set; } = 0.0;
      
        // <summary>
        /// Holds the string word quantity of the ingredients
        /// </summary>
        public string strCalories { get; set; } = string.Empty;

        /// <summary>
        /// Holds the Food Group for the ingredient
        /// </summary>
        public string FoodGroup { get; set; } = string.Empty;

        /// <summary>
        /// Holds the name of the ingredient
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

        // <summary>
        /// Holds the string word quantity of the ingredients
        /// </summary>
        public string strQuantity { get; set; } = string.Empty;

        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Default Constructorr
        /// </summary>
        public Ingredient()
        {


        }
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Unit Test Overload Constructor
        /// </summary>
        public Ingredient(double cal)
        {
            this.Calories = cal;
        }
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Method to Print Array Objects
        /// </summary>
        public void DisplayIngredients(int i)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"\n{i.ToString().PadLeft(12)}.  {this.strQuantity} {this.UnitofM} of {this.Name}");
            Console.WriteLine($"\n{"".PadLeft(20)}[Calories: {this.Calories}] [Food Group: {this.FoodGroup}]");

        }
    }
}//__---____---____---____---____---____---____---__.ooo END OF FILE ooo.__---____---____---____---____---____---____---__\\
