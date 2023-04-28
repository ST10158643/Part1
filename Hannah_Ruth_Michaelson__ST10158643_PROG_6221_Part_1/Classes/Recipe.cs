using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Hannah_Ruth_Michaelson__ST10158643_PROG_6221_Part_1.Classes
{
    public class Recipe
    {
        /// <summary>
        /// Ingredient CLass Array Object to hold Recipe Ingredients 
        /// </summary>
        private Ingredient[] ingArray;
        /// <summary>
        /// String Array Object to hold Recipe Steps 
        /// </summary>
        private string[] steps;
        //int to hold number of ingredients 
        private int numIngs = 0;
        //int to hold number of steps 
        private int numSteps = 0;
        //double to hold rescale factor 
        double rescale = 0.0;

        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Default Constructor
        /// </summary>
        public Recipe()
        {
            //setting console window width
            Console.WindowWidth = 67;
            //setting console foreground and background
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            //output welcome message 
            Console.WriteLine("_--_--_--_--_-_--_--_--_--_--_--_--_--_--_--_--_--_--_--_--_--_");
            Console.WriteLine(String.Format("{0,-10} {1,-10} {2,-19}", " ", "Welcome to Your Personal Digital", " "));
            Console.WriteLine("_--_--_--_--_-_--_--_--_--_--_--_--_--_--_--_--_--_--_--_--_--_");
            Console.BackgroundColor = ConsoleColor.Black;
            //method call to RetrieveRecipeData
            RetrieveRecipeData();

        }

        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Method to for user to choose recipe actions
        /// </summary>
        private void RecipeOptions()
        {
            //declaring variables to hold user input 
            int option;
            string input;
            //do while to ask user if they want to display recipe until guard condition is met, input must be between 1 and 2 
            do
            {
                Console.WriteLine(String.Format("{0,-10} {1,-10} {2,-40}", " ", "Display recipe ?", " "));
                Console.WriteLine(String.Format("{0,-15} {1,-10}", " ", "1. Yes", " "));
                Console.WriteLine(String.Format("{0,-15} {1,-10}", " ", "2. No", " "));
                Console.CursorLeft = 16;
                input = Console.ReadLine();
                option = ValidateInput.MenuInt(input);
            } while (option <= 0 || option >= 3);
            if (option == 1)
                DisplayRecipe();
            //do while to ask user if they want to rescale recipe until guard condition is met, input must be between 1 and 2 
            do
            {
                Console.WriteLine(String.Format("{0,-10} {1,-10} {2,-40}", " ", "Rescale recipe ?", " "));
                Console.WriteLine(String.Format("{0,-15} {1,-10}", " ", "1. Yes", " "));
                Console.WriteLine(String.Format("{0,-15} {1,-10}", " ", "2. No", " "));
                Console.CursorLeft = 16;
                input = Console.ReadLine();
                option = ValidateInput.MenuInt(input);
            } while (option <= 0 || option >= 3);
            if (option == 1)
                RescaleRecipe();
            //do while to ask user if they want to reset recipe until guard condition is met, input must be between 1 and 2 
            do
            {
                Console.WriteLine(String.Format("{0,-10} {1,-10} {2,-40}", " ", "Reset recipe ?", " "));
                Console.WriteLine(String.Format("{0,-15} {1,-10}", " ", "1. Yes", " "));
                Console.WriteLine(String.Format("{0,-15} {1,-10}", " ", "2. No", " "));
                Console.CursorLeft = 16;
                input = Console.ReadLine();
                option = ValidateInput.MenuInt(input);
            } while (option <= 0 || option >= 3);
            if (option == 1)
                ResetRecipe();
            //do while to ask user if they want to clear recipe until guard condition is met, input must be between 1 and 2 
            do
            {
                Console.WriteLine(String.Format("{0,-10} {1,-10} {2,-40}", " ", "Clear recipe ?", " "));
                Console.WriteLine(String.Format("{0,-15} {1,-10}", " ", "1. Yes", " "));
                Console.WriteLine(String.Format("{0,-15} {1,-10}", " ", "2. No", " "));
                Console.CursorLeft = 16;
                input = Console.ReadLine();
                option = ValidateInput.MenuInt(input);
            } while (option <= 0 || option >= 3);
            if (option == 1)
                ClearData();

            Console.ReadLine();

        }
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Method to retrieve user input
        /// </summary>

        private void RetrieveRecipeData()
        {
            //Heading output
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(String.Format("{0,-15} {1,-4} {2,-15}", "        _--_--_--_--_ ", "Capture Recipe", " _--_--_--_--_"));
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.Black;
            //declaring bool for do while guard conditions
            bool val;
            //do while to ask user to enter number of ingredients until input is greater than 0 
            do
            {
                Console.WriteLine(String.Format("\n{0,-10} {1,-10}", " ", "Please Enter Number of Ingredient's", " "));
                //setting console cursor position
                Console.CursorLeft = 16;
                string input = Console.ReadLine();
                //passing input to ValidateIput Class method to ensure is valid 
                this.numIngs = ValidateInput.ValidInt(input);
            } while (numIngs <= 0);

            //instancing ingredient array to user input
            ingArray = new Ingredient[numIngs];
            //for loop to populate  ingredient array according to array length  
            for (int i = 0; i < numIngs; i++)
            {
                //current array ingredient object is assigned to new instance on ingredient object
                ingArray[i] = new Ingredient();
                //do while to ask user to enter name of ingredients until input bool returns true
                do
                {
                    Console.WriteLine(String.Format("\n{0,-10} {1,-10}", " ", "Please the ingredient's name", " "));
                    Console.CursorLeft = 16;
                    string input = Console.ReadLine();
                    //passing input to ValidateIput Class method to ensure is valid 
                    val = ValidateInput.IsStringNull(input);
                    if (val)
                        ingArray[i].Name = input;

                } while (!val);
                //do while to ask user to enter unit of measure until input bool returns true
                do
                {
                    Console.WriteLine(String.Format("\n{0,-10} {1,-10}", " ", "Please enter the unit of measurement", " "));
                    Console.CursorLeft = 16;
                    string input = Console.ReadLine().ToLower();
                    //passing input to ValidateIput Class method to ensure is valid 
                    val = ValidateInput.IsStringNull(input);
                    if (val)
                        ingArray[i].UnitofM = input;

                } while (!val);
                //do while to ask user to enter number of quantity until input is greater than 0.0 or not 0 
                do
                {
                    Console.WriteLine(String.Format("\n{0,-10} {1,-10}", " ", "Please enter the quantity", " "));
                    Console.CursorLeft = 16;
                    string input = Console.ReadLine();
                    //passing input to ValidateIput Class method to ensure is valid 
                    ingArray[i].Quantity = ValidateInput.ValidDouble(input);
                    //if quantity is greater that 0.0 
                    if (ingArray[i].Quantity > 0.0)
                        // assign ingredient string quantity variable to ValidateInput Class method that returns string 
                        ingArray[i].strQuantity = ValidateInput.FindString(ingArray[i].Quantity);
                } while (ingArray[i].Quantity < 0.0 || ingArray[i].Quantity == 0);
            }//end for loop

            //Method call to alter the ingredient unit of measure according to number of quantity 
            PluralQuantity();
            //do while to ask user to enter number of steps until input is greater than 0 
            do
            {
                Console.WriteLine(String.Format("\n{0,-10} {1,-10}", " ", "Please enter Number of Recipe Steps", " "));
                Console.CursorLeft = 16;
                string input = Console.ReadLine();
                //passing input to ValidateIput Class method to ensure is valid 
                numSteps = ValidateInput.ValidInt(input);

            } while (numSteps <= 0);
            //completing instance of step array with inputted number 
            steps = new string[numSteps];
            //for loop to populate step  array according to array length
            for (int i = 0; i < numSteps; i++)
            {
                //do while to ask user to enter steps until bool returns true
                do
                {
                    Console.WriteLine(String.Format("\n{0,-10} {1,-10}", " ", "Please Enter Step " + (i + 1) + " Description", " "));
                    Console.CursorLeft = 16;
                    string input = Console.ReadLine();
                    //passing input to ValidateIput Class method to ensure is valid 
                    val = ValidateInput.IsStringNull(input);
                    //if bool is true, current step is assigned to user input
                    if (val)
                        steps[i] = input;
                } while (!val);
            }
            //Method call to display recipe options 
            RecipeOptions();
        }
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Method to display recipe
        /// </summary>
        private void DisplayRecipe()
        {
            //Heading output
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(String.Format("{0,-15} {1,-4} {2,-15}", "        _--_--_--_--_ ", "Full Recipe", " _--_--_--_--_"));
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.BackgroundColor = ConsoleColor.Black;
            //decaling a assigning int to hold count of steps 
            int stepCount = 0;
            //if number of ingredients stored is 0 display error message 
            if (numIngs == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(String.Format("{0,-15} {1,-10}", " ", "No Recipes Found!, Cannot Display a Recipe", " "));
                Console.ForegroundColor = ConsoleColor.Yellow;

            }
            //iOutput to display recipe 
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(String.Format("\n{0,-7} {1,-10}", " ", "Ingredients:", " "));
            //foreach loop to display each ingredient stored in ingredient array using Ingredient Class Method 
            foreach (Ingredient ingre in ingArray)
            {
                ingre.DisplayIngredients();
            }
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(String.Format("\n{0,-7} {1,-10}", " ", "Directions:", " "));
            //foreach loop to display each step stored in step array
            foreach (string step in steps)
            {
                Console.ForegroundColor = ConsoleColor.White;
                stepCount++;
                //// Console.WriteLine(String.Format("\n{0,-40} {1,-10}", " ", "Ingredients:\n", " "));
                Console.WriteLine(String.Format("\n{0,-7} {1,-7} {2,-10} {3,-10}", "", "-*- " + "Step" + stepCount, ": " + step, "\n "));
                Console.ForegroundColor = ConsoleColor.Yellow;
            }

        }

        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Method to rescale recipe quantities 
        /// </summary>
        private void RescaleRecipe()
        {//Heading output
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(String.Format("{0,-15} {1,-4} {2,-15}", "        _--_--_--_--_ ", "Rescale Recipe", " _--_--_--_--_"));
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.Black;
            //if number of ingredients stored is 0 display error message 
            if (numIngs == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(String.Format("{0,-15} {1,-10}", " ", "No Recipes Found!, Cannot Reset Recipe", " "));
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            //output to ask user to select rescale option
            Console.WriteLine(String.Format("{0,-10} {1,-10}", " ", "Please Select Rescale Option", " "));
            Console.WriteLine(String.Format("{0,-15} {1,-10}", " ", "1. Half Recipe", " "));
            Console.WriteLine(String.Format("{0,-15} {1,-10}", " ", "2. Double Recipe", " "));
            Console.WriteLine(String.Format("{0,-15} {1,-10}", " ", "3. Triple Recipe", " "));
            Console.CursorLeft = 16;
            string input = Console.ReadLine();
            //passing input to ValidateIput Class method to ensure is valid 
            int option = ValidateInput.ValidInt(input);
            //switch statement to set rescale number according to user input
            switch (option)
            {
                case 1:
                    rescale = 0.5;
                    break;
                case 2:
                    rescale = 2.0;
                    break;
                case 3:
                    rescale = 3.0;
                    break;
            }
            //foreach loop to iterate through each ingredient 
            foreach (Ingredient ingre in ingArray)
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
            foreach (Ingredient ingre in ingArray)
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
        /// Method to rest unit of measure after recipe rest
        /// </summary>
        private void RestUnitMeasure()
        {
            //String array to hold unit measures 
            string[] UM = { "teaspoon", "tablespoon", "cup", "teaspoons", "tablespoons", "cups" };
            //foreach loop to iterate through each ingredient 
            foreach (Ingredient ingre in ingArray)
            {
                //if unit of measure is tablespoon then change unit of measure to teaspoon
                if (ingre.UnitofM.Equals(UM[1]) || ingre.UnitofM.Equals(UM[4]))
                {
                    //sum to change quantity from tablespoon to teaspoon
                    double x = Math.Ceiling((ingre.Quantity / 5) * 15);
                    if(x<= 3)
                    {
                        ingre.UnitofM = UM[0];
                        ingre.Quantity = x;
                    }
                }
                //if unit of measure is cup then change unit of measure to tablespoon
                else if (ingre.UnitofM.Equals(UM[2]) || ingre.UnitofM.Equals(UM[5]))
                {
                    double x = Math.Ceiling((ingre.Quantity / 250) * 15);
                    if(x > 1)
                    {
                        ingre.UnitofM = UM[1];
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
            foreach (Ingredient ingre in ingArray)
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
        /// Method to rest recipe quantities 
        /// </summary>
        private void ResetRecipe()
        {
            //Heading output
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(String.Format("{0,-15} {1,-4} {2,-15}", "        _--_--_--_--_ ", "Reset Recipe", " _--_--_--_--_"));
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.Black;
            //if rescale variable is still 0.0 , display error message 
            if (rescale < 0.0)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(String.Format("{0,-15} {1,-10}", " ", "Recipe Has Not Been Rescaled!, Cannot Reset Recipe", " "));
                Console.ForegroundColor = ConsoleColor.Yellow;

            }
            //if number of ingredients stored is 0 display error message 
            else if (numIngs == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(String.Format("{0,-15} {1,-10}", " ", "No Recipes Found!, Cannot Reset Recipe", " "));
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            //foreach loop to iterate through each ingredient 
            foreach (Ingredient ingre in ingArray)
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
        /// Method to clear recipe data 
        /// </summary>
        private void ClearData()
        {
            //Heading output
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(String.Format("{0,-15} {1,-4} {2,-15}", "        _--_--_--_--_ ", "Clear Recipe", " _--_--_--_--_"));
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.Black;
            //if rescale variable is still 0.0 , display error message 
            if (numIngs == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(String.Format("{0,-15} {1,-10}", " ", "No Recipes Found!, Cannot Clear Data", " "));
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            //output to ensure user wants to clear data 
            Console.WriteLine(String.Format("{0,-10} {1,-10}", " ", "Are your sure you would like to clear all recipe data?", " "));
            Console.WriteLine(String.Format("{0,-15} {1,-10}", " ", "1. Yes", " "));
            Console.WriteLine(String.Format("{0,-15} {1,-10}", " ", "2. No", " "));
            Console.CursorLeft = 16;
            string input = Console.ReadLine();
            //passing input to ValidateIput Class method to ensure is valid 
            int option = ValidateInput.ValidInt(input);

            //if user chooses option 1 
            if (option == 1)
            {   //Array method to clear ingArray 
                Array.Clear(ingArray, 0, ingArray.Length);
                //Array method to clear step array 
                Array.Clear(steps, 0, steps.Length);
                //output to ask user to create new recipe or exit program 
                Console.WriteLine(String.Format("{0,-10} {1,-10}", " ", "Recipe Cleared! Would you like to create a new recipe?", " "));
                Console.WriteLine(String.Format("{0,-15} {1,-10}", " ", "1. Create New Recipe", " "));
                Console.WriteLine(String.Format("{0,-15} {1,-10}", " ", "2. Exit", " "));
                Console.CursorLeft = 16;
                input = Console.ReadLine();
                //passing input to ValidateIput Class method to ensure is valid 
                option = ValidateInput.ValidInt(input);

                //switch statement for user selection
                switch (option)
                {
                    case 1:
                        //method call to recipeOption to create new recipe 
                        RetrieveRecipeData();
                        break;
                    case 2:
                        //method call to end program 
                        EndProg();
                        break;
                }
            }
        }
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Method to close program
        /// </summary>
        private void EndProg()
        {
            //output goodbye message 
            Console.WriteLine(String.Format("{0,-15} {1,-10}", " ", "Enjoy Your Meal!", " "));
            //system method to end program 
            System.Environment.Exit(0);
            
        }
    }
}//__---____---____---____---____---____---____---__.ooo END OF FILE ooo.__---____---____---____---____---____---____---__\\