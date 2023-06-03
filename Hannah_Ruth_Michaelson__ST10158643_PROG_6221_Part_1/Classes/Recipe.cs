using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hannah_Ruth_Michaelson__ST10158643_PROG_6221_Part_1.Classes
{
    public delegate string CalorieAlert();
    public class Recipe
    {
        public string Name { get; set; }

        public List<Ingredient> IngredientList = new List<Ingredient>();
       // public List<Ingredient> IngredientList  { get; set; }
        public List<string> Steps = new List<string>();
        //public List<string> Steps { get; set; }
        public List<double> trackCal = new List<double>();
        public string strCalories { get; set; } = string.Empty;
        public static double TotalCalories { get; set; } 

        //FROM WORKER CLASS
        //double to hold rescale factor 
        double rescale = 0.0;
  

        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Default Constructor
        /// </summary>
        public Recipe()
        {
            
        }
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Overload Constructor
        /// </summary>
        public Recipe(string name, List<Ingredient> Ings, List<string> step)
        {
            Name = name;
            IngredientList = Ings;
            Steps = step;
            foreach (Ingredient ingre in IngredientList)
            {
                trackCal.Add( ingre.Calories);
            }
            
        }
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Method to Print Array Objects
        /// </summary>
        public void DisplayRecipe()
        {   
            Console.Clear();

            //Heading output
            Console.ForegroundColor = ConsoleColor.Blue;

            Console.WriteLine(String.Format("{0,-15} {1,-4} {2,-15}", "        _--_--_--_--_ ", "Full Recipe", " _--_--_--_--_"));
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.BackgroundColor = ConsoleColor.Black;
            //decaling a assigning int to hold count of steps 
           
          
            Console.WriteLine("{0,-15} {1,-20}", "Recipe Name:", Name);
            Console.WriteLine("{0,-15} {1,-20}", "\nTotal Calories:", TotalCalories+" Kcal");
            Console.WriteLine("\n _--_--_--_--_-_--_--_--_--_--_--_--_--_--_--_--_--_--_--_--_--__--_--_--_--_-_--_--_--_--_--_--_--_--_--_--_--");
            Console.WriteLine("{0,-15} {1,-20}", "Ingredients:", "\n");
            for(int x = 1;  x < IngredientList.Count; x++)
            {
                IngredientList[x].DisplayIngredients(x);
            }            
            Console.WriteLine("\n _--_--_--_--_-_--_--_--_--_--_--_--_--_--_--_--_--_--_--_--_--__--_--_--_--_-_--_--_--_--_--_--_--_--_--_--_--");
            Console.WriteLine("{0,-15} {1,-20}", "Instructions:", "\n");
            for (int i = 0; i < Steps.Count; i++)
            {
                Console.WriteLine($"\n{"Step".PadLeft(15)} {i.ToString()}, {Steps[i]}?");

            }

            // Table footer
            Console.WriteLine(" \n_--_--_--_--_-_--_--_--_--_--_--_--_--_--_--_--_--_--_--_--_--__--_--_--_--_-_--_--_--_--_--_--_--_--_--_--_--");
        

    }
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Method to rescale recipe quantities 
        /// </summary>
        public void RescaleRecipe(double rescale)
        {   foreach (Ingredient ingre in IngredientList)
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
        /// Method to change unit of measure according to rescale
        /// </summary>
        private void ChangeUnitMeasure()
        {
            //String array to hold unit measures 
            string[] UM = { "teaspoon", "tablespoon", "cup", "teaspoons", "tablespoons", "cups" };
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
            PluralQuantity();
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
            string[] UM = { "teaspoon", "tablespoon", "cup", "teaspoons", "tablespoons", "cups" };
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
            PluralQuantity();
        }

        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Method to add "S" to unit of measure of quantity is greater than one 
        /// </summary>
        private void PluralQuantity()
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
        public double CalculateCalories(List<double> calories)
        {
            foreach (double num in calories)
            {
                TotalCalories += num;
            }
            return TotalCalories;
        }
        public string CheckCalories()
        {
            string alert = null;
            CalculateCalories(trackCal);            
            if (TotalCalories >= 300)
            {
                alert = String.Format("{0,-5} {1,-10} {2,-40}", " ", "Alert: The total recipe calories is " + TotalCalories + " , The recipe is over 300 Kcal !!", " ");
            }
            return alert;
        }
    }
}//__---____---____---____---____---____---____---__.ooo END OF FILE ooo.__---____---____---____---____---____---____---__\\
