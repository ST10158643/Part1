using System;
using System.Collections.Generic;
using System.Linq;
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
        /// <summary>
        /// String Array Object to hold Recipe Steps 
        /// </summary>
        private string[] steps;
        private int numIngs { get; set; } = 0;
        double rescale = 0.0;

        //private string strInput;

        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Default Constructor
        /// </summary>
        public Recipe()
        {


            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("******************************************************************************************************************");
            Console.WriteLine(String.Format("{0,-40} {1,-10} {2,-40}", " ","Welcome to Your Personal Digital"," "));
            Console.WriteLine("******************************************************************************************************************");
            Console.BackgroundColor = ConsoleColor.Black;
            DisplayMenu();

        }

        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Method to Dispay Menu
        /// </summary>
        public void DisplayMenu() 
        {
            Console.WriteLine(String.Format("\n{0,-40} {1,-10}"," ","Please Select Option"));
            Console.WriteLine(String.Format("\n{0,-40} {1,-10}", " ", "1. Create New Recipe"));
            Console.WriteLine(String.Format("{0,-40} {1,-10}"," ", "2. Display Recipe"));
            Console.WriteLine(String.Format("{0,-40} {1,-10}", " ", "3. Rescale Recipe "));
            Console.WriteLine(String.Format("{0,-40} {1,-10}", " ", "4. Rest Recipe"));
            Console.WriteLine(String.Format("{0,-40} {1,-10}", " ", "5. Clear Recipe "));
            Console.WriteLine(String.Format("{0,-40} {1,-10}", " ", "6. Exit"));
            bool validOption = true;
            do
            {
                try
                {
                    // int option = Convert.ToInt32(Console.ReadLine());
                    var option = int.Parse(Console.ReadLine());
                    if (option > 7) { throw new FormatException();}

                    switch (option)
                    {
                        case 1:
                            RetrieveRecipeData();
                            break;
                        case 2:
                            DisplayRecipe();
                            // DisplayRecipe(ingArray,numIngs);
                            break;
                        case 3:
                            RescaleRecipe();
                            break;
                        case 4:
                            RestRecipe();
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
                    Console.WriteLine($"The number entered is not valid.");
                    Console.WriteLine($"Please enter a number from 1 to 6.");
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

            int numSteps = 0;
            do
            {
                try
                {
                    Console.WriteLine("\nPlease Enter Number of Ingredient's ");

                    numIngs = Convert.ToInt32(Console.ReadLine());
                    if (numIngs < 1)
                    {
                        throw new FormatException();
                    }
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Please Enter Valid Number");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
            } while (numIngs < 1);
            ingArray = new Ingredient[numIngs];

            for (int i = 0; i < numIngs; i++)
            {
                var ing = new Ingredient();
                Console.WriteLine("Please enter name of ingredient");
                ing.Name = Console.ReadLine();
                Console.WriteLine("Please enter the unit of measurement");
                ing.UnitofM = Console.ReadLine();
                do
                {
                    try
                    {
                        Console.WriteLine("Please enter the quantity");
                        ing.Quantity = Convert.ToDouble(Console.ReadLine());
                        if (ing.Quantity < 1)
                        {
                            throw new FormatException("");
                        }
                        else
                            ingArray[i] = ing;
                    }
                    catch (FormatException)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Please Enter Valid Number");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                } while (ing.Quantity < 1);
            }
            do
            {
                try
                {
                    Console.WriteLine("Please enter Number of Recipe Steps ");
                    numSteps = Convert.ToInt32(Console.ReadLine());
                    if (numSteps <= 0)
                    {
                        throw new FormatException("Invalid input.");
                    }
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed; 
                    Console.WriteLine("Please enter a valid number.");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
            } while (numSteps <= 0);

            steps = new string[numSteps];
            for (int i = 0; i < numSteps; i++)
            {
                Console.WriteLine("Please Enter Step " + (i + 1) + " Desciption");
                steps[i] = Console.ReadLine();
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

            Console.Write("Ingredients:\n");
            foreach (Ingredient ingre in ingArray)
            {
                ingre.DisplayIngredients();
            }
            Console.Write("Directions:\n");
            foreach (string step in steps)
            {
                stepCount++;
                Console.WriteLine("Step \n* " + stepCount + " " + step);
            }

            DisplayMenu();
        }
        /*  public void DisplayRecipe(Ingredient[] a, int loop)
          {
              int stepCount = 0;
              Console.Write("Ingredients:\n");
              for (int i = 0; i < loop; i++)
              {
                  ingArray[i].DisplayIngredients();
              }
              Console.Write("Directions For loop :\n");
              for (int i = 0; i < steps.Length; i++)
              {
                  Console.WriteLine("Step " + (i + 1) + "\n" + steps[i]);
              }
              Console.Write("Ingredients:\n");
              foreach (Ingredient ingre in ingArray)
              {
                  ingre.DisplayIngredients();
              }
              Console.Write("Directions ForEach:\n");
              foreach ( string step in steps)
              {  
                 stepCount++;
                  Console.WriteLine("Step "+stepCount+"\n"+step);  
              }

              DisplayMenu();
          }*/
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Method to Rescale Recipe Quantites 
        /// </summary>
        private void RescaleRecipe()
        {
            Console.WriteLine("\nPlease Select Rescale Option");
            Console.WriteLine("1. Half Recipe");
            Console.WriteLine("2. Double Recipe");
            Console.WriteLine("3. Triple Recipe");

            int option = Convert.ToInt32(Console.ReadLine());

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
            Console.WriteLine("Rescaled Recipe :\n");
            DisplayRecipe();

        }
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Method to Rest Recipe Quantites 
        /// </summary>
        public void RestRecipe()
        {
            foreach (Ingredient ingre in ingArray)
            {
                ingre.Quantity /= rescale;
            }
            Console.WriteLine("Original Recipe :\n");
            DisplayRecipe();
        }
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Method to Clear Recipe Data
        /// </summary>
        private void ClearData()
        {
            Console.WriteLine("Are your sure you would like to clear all recipe data?/n" +
                "1. Yes" +
                "\n2.Cancel and Return to Menu");
            int option = Convert.ToInt32(Console.ReadLine());
            if (option != 1)
            {
                DisplayMenu();
            }
            else
            {
                Array.Clear(ingArray, 0, ingArray.Length);
                Array.Clear(steps, 0, steps.Length);

                Console.WriteLine("Recipe Cleared!\n Would you like to create a new recipe?");
                Console.WriteLine("1. Create New Recipe");
                Console.WriteLine("2. Return to Menu");
                Console.WriteLine("3. Exit");

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
            Console.WriteLine("Enjoy Your Meal!");
            System.Environment.Exit(0);
        }
    }
}//------------------------------------------...ooo000 END OF FILE 000ooo...--------------------------------//