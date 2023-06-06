using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hannah_Ruth_Michaelson__ST10158643_PROG_6221_Part_1.Classes
{
    // <summary>
    /// Declaring Delegate to Display Calorie Alert
    /// </summary>
    public delegate string CalorieAlert(double cal);
    public class Recipe
    {
        // <summary>
        /// Holds the double value of Recipe calories 
        /// </summary>
        public double totalCalories { get; set; } = 0.0;
   
        // <summary>
        /// Holds the string name of recipe
        /// </summary>
        public string Name { get; set; }

        // <summary>
        /// Holds the string value of Recipe calories 
        /// </summary>
        public string strCalories { get; set; } = string.Empty;
       
        /// <summary>
        /// Ingredient Class Object List to hold Recipes Ingredients
        /// </summary>
        public List<Ingredient> IngredientList = new List<Ingredient>();
        // public List<Ingredient> IngredientList  { get; set; }

        /// <summary>
        /// String List to hold Recipes Steps
        /// </summary>
        public List<string> Steps = new List<string>();
       

        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Default Constructor
        /// </summary>
        public Recipe()
        {
            
        }
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Parameterized constructor
        /// </summary>
        public Recipe(string name, List<Ingredient> Ings, List<string> step, double calories)
        {
            Name = name;
            IngredientList = Ings;
            Steps = step;
            totalCalories = calories;
        }
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Method to Print Array Objects
        /// </summary>
        public void DisplayRecipe()
        {
            //Declaring Int varibale for iteration 
            int x = 1;
            //Method to clear console 
            Console.Clear();

            //Heading output, change foreground and background 
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(String.Format("{0,-15} {1,-4} {2,-15}", " _--_--_--_--_ _--_--_--_--__--_--_--_--_", "Full Recipe", " _--_--_--_--_ _--_--_--_--__--_--_--_--_"));
            Console.BackgroundColor = ConsoleColor.Black;

            //Recipe output, change foreground and background 
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("{0,-15} {1,-20}", "Recipe Name:", Name);
            Console.WriteLine("{0,-15} {1,-20}", "\nTotal Calories:",  totalCalories+" Kcal");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n _--_--_--_--_-_--_--_--_--_--_--_--_--_--_--_--_--_--_--_--_--__--_--_--_--_-_--_--_--_--_--_--_--_--_--_--_--");
            Console.WriteLine("{0,-15} {1,-20}", "Ingredients:", "\n");
            Console.ForegroundColor = ConsoleColor.White;
            
            //foreach loop to call the display method of each ingredient object in ingredient list 
            foreach (Ingredient ingre in this.IngredientList)
            {                
                ingre.DisplayIngredients(x);
                //incrementing int 
                x++;
            }
            //Recipe output, change foreground and background 
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n _--_--_--_--_-_--_--_--_--_--_--_--_--_--_--_--_--_--_--_--_--__--_--_--_--_-_--_--_--_--_--_--_--_--_--_--_--");
            Console.WriteLine("{0,-15} {1,-20}", "Instructions:", "\n");
            //for loop to display each step within the Steps list 
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < Steps.Count; i++)
            {
                Console.WriteLine($"\n{"Step".PadLeft(15)} {(i+1).ToString()}, {Steps[i]}");

            }
            //Recipe output, change foreground and background 
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(" \n_--_--_--_--_-_--_--_--_--_--_--_--_--_--_--_--_--_--_--_--_--__--_--_--_--_-_--_--_--_--_--_--_--_--_--_--_--");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
        }
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Method to Rescale Recipe Quantities 
        /// </summary>
        public void RescaleRecipe(double rescale)
        {
            //foreach loop to iterate through each ingredient in ingredientList 
            foreach (Ingredient ingre in IngredientList)
            {
                // each ingredient's quantity is multiplied by rescale double to change value 
                ingre.Quantity *= rescale;
                // each ingredient's quantity assigned to new double string value using ValidateInput Class Method 
                ingre.strQuantity = ValidateInput.FindString(ingre.Quantity);
            }
            //Call to method to update unit of measure 
            ChangeUnitMeasure();
            Console.WriteLine(String.Format("{0,-10} {1,-10}", " ", "Rescaled Recipe :\n", " "));
            //call to display rescaled recipe
            DisplayRecipe();
        }
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Method to Change Unit of Measure according to rescale
        /// </summary>
        private void ChangeUnitMeasure()
        {
            //String array to hold unit measures 
           List<string>  UM = new List<string> { "teaspoon", "tablespoon", "cup", "teaspoons", "tablespoons", "cups" };
            //foreach loop to iterate through each ingredient 
            foreach (Ingredient ingre in IngredientList)
            {
                //if unit of measure is teaspoon and greater or equal to 3 then change unit of measure to tablespoon
                if (ingre.UnitofM.Equals(UM[0]) || ingre.UnitofM.Equals(UM[3]))
                {
                    if (ingre.Quantity >= 3)
                    {
                        ingre.UnitofM = UM[1];
                        //sum to change quantity from teaspoon to tablespoon
                        ingre.Quantity = Math.Floor((ingre.Quantity * 5) / 15);
                        ingre.Quantity = ((int)ingre.Quantity);
                    }
                }
                //if unit of measure is tablespoon and greater or equal to 16 then change unit of measure to cup
                else if (ingre.UnitofM.Equals(UM[1]) || ingre.UnitofM.Equals(UM[4]))
                {
                    if (ingre.Quantity >= 16)
                    {
                        ingre.UnitofM = UM[2];
                        //sum to change quantity from tablespoon to cup
                        ingre.Quantity = Math.Ceiling((ingre.Quantity * 15) / 250);
                        ingre.Quantity = ((int)ingre.Quantity);
                    }

                }
                // each ingredient's quantity assigned to new double string value using ValidateInput Class Method 
                ingre.strQuantity = ValidateInput.FindString(ingre.Quantity);
            }
            //Method call to alter the ingredient unit of measure according to number of quantity 
            CheckQuantity();
        }
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Method to rest recipe quantities 
        /// </summary>
        public void ResetRecipe(double rescale)
        {            
            //foreach loop to iterate through each ingredient 
            foreach (Ingredient ingre in IngredientList)
            {//divide quantity by rescale double to restore to value 
                ingre.Quantity /= rescale;
            }
            //method call to rest unit of measure according to rest quantities 
            RestUnitMeasure();
            //method call to output recipe
            DisplayRecipe();
        }
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Method to rest unit of measure after recipe rest
        /// </summary>
        private void RestUnitMeasure()
        { 
            //String array to hold unit measures 
           List<string> UM = new List<string>{ "teaspoon", "tablespoon", "cup", "teaspoons", "tablespoons", "cups" };
            //foreach loop to iterate through each ingredient 
            foreach (Ingredient ingre in IngredientList)
            {
                //if unit of measure is tablespoon then change unit of measure to teaspoon
                if (ingre.UnitofM.Equals(UM[1]) || ingre.UnitofM.Equals(UM[4]))
                {
                    //sum to change quantity from tablespoon to teaspoon
                    double x = Math.Ceiling((ingre.Quantity / 5) * 15);
                    //if x is less than 3 
                    if (x < 3)
                    {//unit of measure is teaspoon
                        ingre.UnitofM = UM[0];
                        //quantity is equal is a 
                        ingre.Quantity = x;
                    }
                }
                //if unit of measure is cup then change unit of measure to tablespoon
                else if (ingre.UnitofM.Equals(UM[2]) || ingre.UnitofM.Equals(UM[5]))
                {
                    double x = Math.Ceiling((ingre.Quantity / 250) * 15);
                    if (x > 1)
                    {//unit of measure is teaspoon
                        ingre.UnitofM = UM[1];
                        //quantity is equal is a 
                        ingre.Quantity = x;
                    }

                }
                // each ingredient's quantity assigned to new double string value using ValidateInput Class Method 
                ingre.strQuantity = ValidateInput.FindString(ingre.Quantity);
            }
            //Method call to alter the ingredient unit of measure according to number of quantity 
            CheckQuantity();
        }

        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Method to add "S" to unit of measure of quantity is greater than one 
        /// </summary>
        private void CheckQuantity()
        {
            //foreach loop to iterate through each ingredient 
            foreach (Ingredient ingre in IngredientList)
            {
                //if quantity is greater than one add s to end unit of measure 
                if (ingre.Quantity > 1 && !ingre.UnitofM.EndsWith("s"))
                {
                    ingre.UnitofM = ingre.UnitofM.Trim() + "s";
                }
                //if quantity is one add remove s unit of measure 
                else if (ingre.Quantity == 1 && ingre.UnitofM.EndsWith("s"))
                {
                    ingre.UnitofM = ingre.UnitofM.TrimEnd('s');
                }

            }
        }
      
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Method to CheckCalories of Recipe, returns string to display calorie alert
        /// </summary>
        public string CheckCalories(double calories)
        {
            // declaring return string
            string alert = null;

            if (calories > 300)
            {
                // return string is assigned to string message with alert explanation information
                alert = String.Format("{0,-5} {1,-10} {2,-40}", " ", "Alert: The total recipe calories is " + calories + " , The recipe is over 300 Kcal !!", " ");
            }
           
            // return string
            return alert;
        }

    }
}//__---____---____---____---____---____---____---__.ooo END OF FILE ooo.__---____---____---____---____---____---____---__\\
