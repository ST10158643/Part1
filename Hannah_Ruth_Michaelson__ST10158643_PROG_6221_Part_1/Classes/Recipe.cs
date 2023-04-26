using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Hannah_Ruth_Michaelson__ST10158643_PROG_6221_Part_1.Classes
{
    internal class Recipe
    {
        /// <summary>
        /// Ingredient CLass Array Object to hold Recipe Ingredients 
        /// </summary>
        private Ingredient[] ingArray;
        private Ingredient[] RestArray;
        /// <summary>
        /// String Array Object to hold Recipe Steps 
        /// </summary>
        private string[] steps;
        private int numIngs { get; set; } = 0;
        private int numSteps { get; set; } = 0;

        double rescale = 0.0;

        //private string strInput;

        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Default Constructor
        /// </summary>
        public Recipe()
        {

            Console.WindowWidth = 67;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("_--_--_--_--_------------------------------------_--_--_--_--_--");
            Console.WriteLine(String.Format("{0,-15} {1,-10} {2,-15}", " ", "Welcome to Your Personal Digital", " "));
            Console.WriteLine("_--_--_--_--_------------------------------------_--_--_--_--_--");
            Console.BackgroundColor = ConsoleColor.Black;
            DisplayMenu();

        }
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Method to Display Menu
        /// </summary>
        public void DisplayMenu() 
        {
            Console.WriteLine(String.Format("\n{0,-15} {1,-10}", " ", "Please Select Option", " "));
            Console.WriteLine(String.Format("\n{0,-20} {1,-10}", " ", "1. Create New Recipe", " "));
            Console.WriteLine(String.Format("{0,-20} {1,-10}", " ", "2. Display Recipe", " "));
            Console.WriteLine(String.Format("{0,-20} {1,-10}", " ", "3. Rescale Recipe", " "));
            Console.WriteLine(String.Format("{0,-20} {1,-10}", " ", "4. Reset Recipe", " "));
            Console.WriteLine(String.Format("{0,-20} {1,-10}", " ", "5. Clear Recipe", " "));
            Console.WriteLine(String.Format("{0,-20} {1,-10}", " ", "6. Exit", " "));
            Console.CursorLeft = 15;
            bool validOption = true;
            do
            {
                try
                {
                    // int option = Convert.ToInt32(Console.ReadLine());
                    var option = int.Parse(Console.ReadLine());
                    if (option >= 7) { throw new FormatException();}

                    switch (option)
                    {
                        case 1:
                            RetrieveRecipeData();
                            break;
                        case 2:
                            DisplayRecipe();
                            // DisplayRecipe(ingArray,num);
                            break;
                        case 3:
                            RescaleRecipe();
                            break;
                        case 4:
                            ResetRecipe();
                            break;
                        case 5:
                            ClearData();
                            break;
                        case 6:
                            EndProg();
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine($"The num entered is not valid.");
                    Console.WriteLine($"Please enter a num from 1 to 6.");
                    validOption = false;
                    Console.ForegroundColor = ConsoleColor.Yellow;

                }
                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine($"Unexpected error: {e.Message}");
                    validOption = false;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }

            } while (!validOption);
            Console.ReadKey();


        }
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Method to Retrieve User Input
        /// </summary>
        private void RetrieveRecipeData()
        {
            bool val;
            do
            {
                Console.CursorLeft = 15;
                Console.WriteLine(String.Format("\n{0,-15} {1,-10}", " ", "Please Enter Number of Ingredient's", " "));
                string input = Console.ReadLine();
                this.numIngs = new ValidateInput().ArrayNum(input);
            } while (numIngs <= 0);

            ingArray = new Ingredient[numIngs];
            RestArray = new Ingredient[numIngs];
            var ing = new Ingredient();

            for (int i = 0; i < numIngs; i++)
            {
                do
                {
                    Console.WriteLine(String.Format("\n{0,-15} {1,-10}", " ", "Please the ingredient's name", " "));
                    string input = Console.ReadLine();
                    val = new ValidateInput().IsStringNull(input);
                    if (val)
                        ing.Name = input;

                } while (!val);

                do
                {
                    Console.WriteLine(String.Format("\n{0,-15} {1,-10}", " ", "Please enter the unit of measurement", " "));
                    string input = Console.ReadLine().ToLower();
                    val = new ValidateInput().IsStringNull(input);
                    if (val)
                        ing.UnitofM = input;

                } while (!val);
                do
                {

                    Console.WriteLine(String.Format("\n{0,-15} {1,-10}", " ", "Please enter the quantity", " "));
                    string input = Console.ReadLine();
                    ing.Quantity = new ValidateInput().ReceiveDouble(input);

                } while (ing.Quantity <= 0.0);

                ingArray[i] = ing;
            }
            Array.Copy(ingArray, RestArray, ingArray.Length);

            /* for (int i = 0; i < ingArray.Length; i++)
            { 
                RestArray[i] = ingArray[i];
            }*/

            do
            {
                Console.WriteLine(String.Format("\n{0,-15} {1,-10}", " ", "Please enter Number of Recipe Steps", " "));
                string input = Console.ReadLine();
                numSteps = new ValidateInput().ArrayNum(input);

            } while (numSteps <= 0);

            steps = new string[numSteps];
            for (int i = 0; i < numSteps; i++)
            {
                do
                {
                    Console.WriteLine(String.Format("\n{0,-15} {1,-10}", " ", "Please Enter Step " + (i + 1) + " Description", " "));
                    string input = Console.ReadLine();
                    val = new ValidateInput().IsStringNull(input);
                    if (val)
                        steps[i] = input;
                } while (!val);
            }
            DisplayMenu();
        }
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Method to Display Recipe
        /// </summary>
        private void DisplayRecipe()
        {
            int stepCount = 0;

            if (numIngs == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(String.Format("{0,-15} {1,-10}", " ", "No Recipes Found!, Cannot Display a Recipe", " "));
                Console.ForegroundColor = ConsoleColor.Yellow;
                DisplayMenu();
            }
            Console.WriteLine(String.Format("\n{0,-15} {1,-10}", " ", "Ingredients:\n", " "));
            foreach (Ingredient ingre in ingArray)
            {
                ingre.DisplayIngredients();
            }
            Console.WriteLine(String.Format("\n{0,-15} {1,-10}", " ", "Directions:\n", " "));
            foreach (string step in steps)
            {
                stepCount++;
                //// Console.WriteLine(String.Format("\n{0,-40} {1,-10}", " ", "Ingredients:\n", " "));
                Console.WriteLine(String.Format("\n{0,-15} {1,-10}", " ", "Step \n* " + stepCount + " " + step));
            }

            DisplayMenu();
        }

        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Method to Rescale Recipe Quantities 
        /// </summary>
        private void RescaleRecipe()
        {
            if (numIngs == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(String.Format("{0,-15} {1,-10}", " ", "No Recipes Found!, Cannot Reset Recipe", " "));
                Console.ForegroundColor = ConsoleColor.Yellow;
                DisplayMenu();
            }
            Console.WriteLine(String.Format("{0,-15} {1,-10}", " ", "\nPlease Select Rescale Option", " "));
            Console.WriteLine(String.Format("{0,-15} {1,-10}", " ", "1.Half Recipe", " "));
            Console.WriteLine(String.Format("{0,-15} {1,-10}", " ", "2. Double Recipe", " "));
            Console.WriteLine(String.Format("{0,-15} {1,-10}", " ", "3. Triple Recipe", " "));
            string input = Console.ReadLine();
            int option = new ValidateInput().ArrayNum(input);
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
            foreach (Ingredient ingre in ingArray)
            {
                ingre.Quantity *= rescale;
            }
            ChangeUM();
            Console.WriteLine(String.Format("{0,-15} {1,-10}", " ", "Rescaled Recipe :\n", " "));
            DisplayRecipe();
        }
        public void ChangeUM()
        {
            string[] UM = { "teaspoon", "tablespoon", "cup" };
            foreach (Ingredient ingre in ingArray)
            {
                if (ingre.UnitofM.Equals(UM[0]) && ingre.Quantity >= 3)
                {
                    ingre.UnitofM = UM[1];
                    ingre.Quantity = (ingre.Quantity * 5) / 15;
                    ingre.Quantity = ((int)ingre.Quantity);
                    Console.WriteLine("\nTeaspoon Change=" + ingre.Quantity);
                }
                else if (ingre.UnitofM.Equals(UM[1]) && ingre.Quantity >= 16)
                {
                    ingre.UnitofM = UM[2];
                    ingre.Quantity = (ingre.Quantity * 15) / 250;
                    ingre.Quantity = ((int)ingre.Quantity);
                    Console.WriteLine("\nTablespoon Change=" + ingre.Quantity);
                }
            }
        }
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Method to Rest Recipe Quantities 
        /// </summary>
        public void ResetRecipe()
        {
            if (rescale < 0.0)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(String.Format("{0,-15} {1,-10}", " ", "Recipe Has Not Been Rescaled!, Cannot Reset Recipe", " "));
                Console.ForegroundColor = ConsoleColor.Yellow;
                DisplayMenu();

            }
            else if (numIngs == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(String.Format("{0,-15} {1,-10}", " ", "No Recipes Found!, Cannot Reset Recipe", " "));
                Console.ForegroundColor = ConsoleColor.Yellow;
                DisplayMenu();
            }
            Array.Copy(ingArray, RestArray, ingArray.Length);

            /*foreach (Ingredient ingre in ingArray)
            {
                ingre.Quantity /= rescale;

            }*/

            Console.WriteLine(String.Format("{0,-15} {1,-10}", " ", "Original Recipe :\n", " "));
            DisplayRecipe();
        }
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Method to Clear Recipe Data
        /// </summary>
        private void ClearData()
        {
            if (numIngs == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(String.Format("{0,-15} {1,-10}", " ", "No Recipes Found!, Cannot Clear Data", " "));
                Console.ForegroundColor = ConsoleColor.Yellow;
                DisplayMenu();
            }
            Console.WriteLine(String.Format("{0,-15} {1,-10}", " ", "Are your sure you would like to clear all recipe data?", " "));
            Console.WriteLine(String.Format("{0,-15} {1,-10}", " ", "1. Yes", " "));
            Console.WriteLine(String.Format("{0,-15} {1,-10}", " ", "2. No", " "));
            /* Console.WriteLine("Are your sure you would like to clear all recipe data?" +
                 "\n1. Yes" +
                 "\n2.Cancel and Return to Menu");*/
            int option = Convert.ToInt32(Console.ReadLine());
            if (option != 1)
            {
                DisplayMenu();
            }
            else
            {
                Array.Clear(ingArray, 0, ingArray.Length);
                Array.Clear(RestArray, 0, RestArray.Length);
                Array.Clear(steps, 0, steps.Length);
                Console.WriteLine(String.Format("{0,-15} {1,-10}", " ", "Recipe Cleared!\n Would you like to create a new recipe?", " "));
                Console.WriteLine(String.Format("{0,-15} {1,-10}", " ", "1. Create New Recipe", " "));
                Console.WriteLine(String.Format("{0,-15} {1,-10}", " ", "2. Return to Menu", " "));
                Console.WriteLine(String.Format("{0,-15} {1,-10}", " ", "3. Exit", " "));

                option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        RetrieveRecipeData();
                        break;
                    case 2:
                        DisplayMenu();
                        break;
                    case 3:
                        EndProg();
                        break;
                }
            }
        }
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Method to Close Program 
        /// </summary>
        private void EndProg()
        {
            Console.WriteLine(String.Format("{0,-15} {1,-10}", " ", "Enjoy Your Meal!", " "));
            System.Environment.Exit(0);
        }
    }
}//------------------------------------------...ooo000 END OF FILE 000ooo...--------------------------------//