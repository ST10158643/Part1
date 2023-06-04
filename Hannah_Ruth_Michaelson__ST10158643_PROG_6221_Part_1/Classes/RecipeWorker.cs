using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Hannah_Ruth_Michaelson__ST10158643_PROG_6221_Part_1.Classes
{
    public class RecipeWorker
    {
       public static Recipe delObj = new Recipe();
       public static CalorieAlert delCal = new CalorieAlert(delObj.CheckCalories);
        //NEW VARIABES 
        List<string> foodGroups = new List<string> { "Starch", "Vegetables and Fruits", "Legumes",
                              "Meat, Chiken, Fish and Eggs", "Milk and Dairy", "Fats and Oils"
                               ,"Water"};
        private Ingredient ing = new Ingredient();
        bool val;
        int i = 0;
       
        /// <summary>
        /// Recipe Class Object List to hold Recipes
        /// </summary>
        private List<Recipe> RecipeList = new List<Recipe>();
        /// <summary>
        /// Ingredient Class Object List to hold Recipe Ingredients 
        /// </summary>
        private List<Ingredient> IngredientList = new List<Ingredient>();
        /// <summary>
        /// String List to hold Recipe Steps 
        /// </summary>
        private List<string> Steps = new List<string>();
        /// <summary>
        /// Dictionary to hold rescale values that corresponde to RecipeList Index
        /// </summary>
        Dictionary<double, Recipe> RescaleValue = new Dictionary<double, Recipe>();

        //TAKE AWAY?
        //double to hold rescale factor 
        double rescale = 0.0;
        int inputOption;
        string rName;

        public object Ing { get => ing; set => ing = (Ingredient)value; }

        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Default Constructor
        /// </summary>
        public RecipeWorker()
        {
            //setting console window width
            Console.WindowWidth = 100;
            Display("Welcome to Your Digital Cookbook", ConsoleColor.DarkYellow);
            //method call to RetrieveRecipeData
            RecipeOptions();


        }
        public void Display(string text, ConsoleColor colour)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = colour;
            string separator = "_--_--_--_--_-_--_--_--_--_--_--_--_--_--_--_--_--_--_--_--_--__--_--_--_--_-_--_--_--_--_--_--_--_--_--_--_--";
            string centeredHeading = string.Format("{0," + ((Console.WindowWidth + text.Length) / 2).ToString() + "}{1,45}", text, "");
            string heading = $"{separator}\n{centeredHeading}\n{separator}";
            Console.WriteLine(heading);
            Console.BackgroundColor = ConsoleColor.Black;

        }

        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Method to for user to choose recipe actions
        /// </summary>
        /// 
        private void RecipeOptions()
        {
            //declaring variables to hold user input 
            int option;
            string input;

            if (!string.IsNullOrEmpty(rName))
                Display("App Menu", ConsoleColor.DarkBlue);
          //  Display("Cookbook Menu", ConsoleColor.Black);


            // Menu options
            List<string> menuOptions = new List<string>{ "Create New Recipe", "Display Recipes", "Rescale Recipes", "Reset Recipes", "Clear Recipes", "Exit Program" };
            
            for (int i = 0; i < menuOptions.Count; i++)
            {
                Console.WriteLine($"\n{(i + 1).ToString().PadLeft(10)}. {menuOptions[i]} ?");

            }
            do
                {   
                    Console.CursorLeft = 12;
                    input = Console.ReadLine();
                    option = ValidateInput.MenuInt(input, menuOptions.Count + 1);
                } while (option <= 0 || option > menuOptions.Count);

                switch (option)
                {
                    case 1:
                        RetrieveRecipeData();
                        break;
                    case 2:
                        DisplayRecipe();
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

                Console.WriteLine();
            

            Console.ReadLine();
        }

        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Method to retrieve user input
        /// </summary>
        private void RetrieveRecipeData()
        {
            Console.Clear();
            Display( "Add New Recipe", ConsoleColor.DarkBlue);
            
            do
            {
                Console.WriteLine(String.Format("\n{0,-10} {1,-10}", " ", "Please Enter The Reicpe's Name", " "));
                Console.CursorLeft = 12;
                string input = Console.ReadLine();
                //passing input to ValidateIput Class method to ensure is valid 
                val = ValidateInput.IsStringNull(input);
                if (val)
                    rName = input;

            } while (!val);

            GetIngredients();
            //Method call to alter the ingredient unit of measure according to number of quantity 
            PluralQuantity();

            GetRecipeSteps();
            Console.Clear();            
            //output 
            Display("Recipe Saved !", ConsoleColor.Black);
            Task.Delay(1000).Wait();
            Console.Clear();
            Recipe recipe = new Recipe(rName, IngredientList, Steps);
            RecipeList.Add(recipe);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(delCal());
            //Method call to display recipe options 
            Console.ForegroundColor = ConsoleColor.Yellow;
            RecipeOptions();
        }
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Method to Retreive Ingreidient Data
        /// </summary>
        private void GetIngredients()
        {
            do
            {
                Console.WriteLine(String.Format("\n{0,-10} {1,-10}", " ", "Please the ingredient's name", " "));
                Console.CursorLeft = 12;
                string input = Console.ReadLine();
                //passing input to ValidateIput Class method to ensure is valid 
                val = ValidateInput.IsStringNull(input);
                if (val)
                    ing.Name = input;

            } while (!val);
            //do while to ask user to enter unit of measure until input bool returns true
            do
            {
                Console.WriteLine(String.Format("\n{0,-10} {1,-10}", " ", "Please enter the unit of measurement", " "));
                Console.CursorLeft = 12;
                string input = Console.ReadLine().ToLower();
                //passing input to ValidateIput Class method to ensure is valid 
                val = ValidateInput.IsStringNull(input);
                if (val)
                    ing.UnitofM = input;

            } while (!val);
            //do while to ask user to enter number of quantity until input is greater than 0.0 or not 0 
            do
            {
                Console.WriteLine(String.Format("\n{0,-10} {1,-10}", " ", "Please enter the quantity", " "));
                Console.CursorLeft = 12;
                string input = Console.ReadLine();
                //passing input to ValidateIput Class method to ensure is valid 
                ing.Quantity = ValidateInput.ValidDouble(input);
                //if quantity is greater that 0.0 
                if (ing.Quantity > 0.0)
                    // assign ingredient string quantity variable to ValidateInput Class method that returns string 
                    ing.strQuantity = ValidateInput.FindString(ing.Quantity);
            } while (ing.Quantity < 0.0 || ing.Quantity == 0);
            do
            {
                Console.WriteLine(String.Format("\n{0,-10} {1,-10}", " ", "Please enter ingredient calories", " "));
                Console.CursorLeft = 12;
                string input = Console.ReadLine();
                //passing input to ValidateIput Class method to ensure is valid 
                ing.Calories = ValidateInput.ValidDouble(input);
                //if quantity is greater that 0.0 
                if (ing.Calories > 0.0)
                    // assign ingredient string calorie variable to ValidateInput Class method that returns string 
                    ing.strCalories = ValidateInput.FindString(ing.Calories);
            } while (ing.Calories < 0.0 || ing.Calories == 0);
            do
            {
                Console.WriteLine(String.Format("\n{0,-10} {1,-10}", " ", "Please select ingredient food grouping", " "));
                Console.WriteLine(String.Format("\n{0,-10} {1,-10}", " ", "1. Starch", " "));
                Console.WriteLine(String.Format("{0,-10} {1,-10}", " ", "2. Vegetables and Fruits ", " "));
                Console.WriteLine(String.Format("{0,-10} {1,-10}", " ", "3. Legumes ", " "));
                Console.WriteLine(String.Format("{0,-10} {1,-10}", " ", "4. Meat, Chiken, Fish and Eggss ", " "));
                Console.WriteLine(String.Format("{0,-10} {1,-10}", " ", "5. Milk and Dairy ", " "));
                Console.WriteLine(String.Format("{0,-10} {1,-10}", " ", "6. Fats and Oils ", " "));
                Console.WriteLine(String.Format("{0,-10} {1,-10}", " ", "7. Water ", " "));
                Console.CursorLeft = 12;
                string input = Console.ReadLine();
                int inputNum = ValidateInput.MenuInt(input, foodGroups.Count + 1);
                switch (inputNum)
                {

                    case 1:
                        ing.FoodGroup = foodGroups[0];
                        break;
                    case 2:
                        ing.FoodGroup = foodGroups[1];
                        break;
                    case 3:
                        ing.FoodGroup = foodGroups[2];
                        break;
                    case 4:
                        ing.FoodGroup = foodGroups[3];
                        break;
                    case 5:
                        ing.FoodGroup = foodGroups[4];
                        break;
                    case 6:
                        ing.FoodGroup = foodGroups[5];
                        break;
                    case 7:
                        ing.FoodGroup = foodGroups[6];
                        break;
                }
            } while (string.IsNullOrEmpty(ing.FoodGroup));
            //D
            IngredientList.Add(ing);
            //D
            Console.Clear();
            Display("Add New Recipe", ConsoleColor.DarkBlue);
            do
            {
                Console.WriteLine(String.Format("{0,-10} {1,-10}", " ", "Would you like to add another ingredient?", " "));
                Console.WriteLine(String.Format("{0,-10} {1,-10}", " ", "1. Yes", " "));
                Console.WriteLine(String.Format("{0,-10} {1,-10}", " ", "2. No", " "));
                Console.CursorLeft = 12;
                string userInput = Console.ReadLine();
                inputOption = ValidateInput.MenuInt(userInput, 3);
            } while (inputOption <= 0 || inputOption > 2);
           
            Console.Clear();
            Display("Add New Recipe", ConsoleColor.DarkBlue);
            if (inputOption == 1)
            {
                GetIngredients();
            }
        }
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Method to Retreive Recipe Steps Data
        /// </summary>
        private void GetRecipeSteps()
        {
            inputOption = 0;
            
                i++;
                //do while to ask user to enter steps until bool returns true
                do
                {

                    Console.WriteLine(String.Format("\n{0,-10} {1,-10}", " ", "Please Enter Recipe Step " +i+ " Description", " "));
                    Console.CursorLeft = 12;
                    string input = Console.ReadLine();
                    //passing input to ValidateIput Class method to ensure is valid 
                    val = ValidateInput.IsStringNull(input);
                    //if bool is true, current step is assigned to user input
                    if (val)
                        Steps.Add(input);
                } while (!val);               
            do
            { 
                Console.WriteLine(String.Format("{0,-10} {1,-10}", " ", "Would you like to add another step?", " "));
                Console.WriteLine(String.Format("{0,-10} {1,-10}", " ", "1. Yes", " "));
                Console.WriteLine(String.Format("{0,-10} {1,-10}", " ", "2. No", " "));
                Console.CursorLeft = 12;
                string userInput = Console.ReadLine();
                inputOption = ValidateInput.MenuInt(userInput, 3);
            } while (inputOption <= 0 || inputOption > 2);
           
            if (inputOption == 1)
            {
                GetRecipeSteps();
            }

        }
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Method to clear recipe data 
        /// </summary>
        private void ClearData()
        {
            int index;
            string input;
            int option;
            //Heading output
            Console.Clear();
            Display("Clear Recipe", ConsoleColor.DarkBlue);
            //if rescale variable is still 0.0 , display error message 
            if (RecipeList.Count == 0)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(String.Format("{0,-10} {1,-10}", " ", "No Recipes Found!, Cannot Clear Data", " "));
            Console.ForegroundColor = ConsoleColor.Yellow;
            RecipeOptions();
        }
        RecipeList.Sort((recipe1, recipe2) => string.Compare(recipe1.Name, recipe2.Name));
        do
        {

            
            Console.WriteLine(String.Format("{0,-10} {1,-10}", " ", "Please select the recipe you would like to clear", " "));
            for (int i = 0; i < RecipeList.Count; i++)
            {

                Console.WriteLine(String.Format("{0,-10} {1,-10}", " ", (i + 1) + "." + RecipeList[i].Name));
            }
           
             Console.CursorLeft = 12;
            input = Console.ReadLine();
            index = int.Parse(input) - 1;
        } while (index<= 0 || index > RecipeList.Count-1);

            //output to ensure user wants to clear data 

            do
            {
                Console.WriteLine(String.Format("{0,-10} {1,-10}", " ", "Are your sure you would like to clear all recipe data?", " "));
                Console.WriteLine(String.Format("{0,-10} {1,-10}", " ", "1. Yes", " "));
                Console.WriteLine(String.Format("{0,-10} {1,-10}", " ", "2. No", " "));
                Console.CursorLeft = 12;
                input = Console.ReadLine();
                //passing input to ValidateIput Class method to ensure is valid 
                option = ValidateInput.MenuInt(input, 3);
            } while (option <= 0 || option > 2);
            //if user chooses option 1 
            if (option == 1)
            {
                if (index >= 0 && index < RecipeList.Count)
                {
                    RecipeList.RemoveAt(index);

                }
                Console.WriteLine(String.Format("{0,-10} {1,-10}", " ", "Recipe Cleared! Would you like to create a new recipe?", " "));
            }
            else
                Console.WriteLine(String.Format("{0,-10} {1,-10}", " ", "Please Select an Option Below,", " "));
            //output to ask user to create new recipe or exit program 
            do
            {
                Console.WriteLine(String.Format("{0,-10} {1,-10}", " ", "1. Create New Recipe", " "));
                Console.WriteLine(String.Format("{0,-10} {1,-10}", " ", "2. Return To Menu", " "));
                Console.WriteLine(String.Format("{0,-10} {1,-10}", " ", "3. Exit", " "));
                Console.CursorLeft = 12;
                input = Console.ReadLine();
                //passing input to ValidateIput Class method to ensure is valid 
                option = ValidateInput.MenuInt(input, 4);
            } while (option <= 0 || option > 3);
            //switch statement for user selection
            switch (option)
            {
                case 1:
                    //method call to RetrieveRecipeData create new recipe 
                    RetrieveRecipeData();
                    break;
                case 2:
                    //method call to recipeOptione 
                    RecipeOptions();
                    break;
                case 3:
                    //method call to end program 
                    EndProg();
                    break;
            }
        }
    
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Method to close program
        /// </summary>
        private void EndProg()
        {
            Console.Clear();
            //output goodbye message 
            Display("Enjoy Your Meal!", ConsoleColor.Black);              
           

        }
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Method to display recipe
        /// </summary>
        private void DisplayRecipe()
        {

            //if number of ingredients stored is 0 display error message 
            if (RecipeList.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(String.Format("{0,-10} {1,-10}", " ", "No Recipes Found!, Cannot Display a Recipe", " "));
                Console.ForegroundColor = ConsoleColor.Yellow;
                RecipeOptions();
            }
        https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.sort?view=net-7.0
            RecipeList.Sort((recipe1, recipe2) => string.Compare(recipe1.Name, recipe2.Name));
            Console.WriteLine(String.Format("{0,-10} {1,-10}", " ", "Please select the recipe you would like to view", " "));
            for (int i = 0; i < RecipeList.Count; i++)
            {

                Console.WriteLine(String.Format("{0,-10} {1,-10}", " ", (i + 1) + "." + RecipeList[i].Name));
            }
            Console.CursorLeft = 12;
            string input = Console.ReadLine();
            int index = int.Parse(input) - 1;

            if (index >= 0 && index < RecipeList.Count)
            {
                RecipeList[index].DisplayRecipe();
                /*//foreach loop to display each ingredient stored in ingredient array using Ingredient Class Method 
                foreach (Recipe ing in RecipeList)
                {
                    ing.DisplayRecipe();
                }*/
            }
            RecipeOptions();
        }
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Method to rescale recipe quantities 
        /// </summary>
        private void RescaleRecipe()
        {//Heading output
            Console.Clear();
            Display("Rescale Recipe", ConsoleColor.DarkBlue);
            
            //if number of ingredients stored is 0 display error message 
            if (RecipeList.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(String.Format("{0,-10} {1,-10}", " ", "No Recipes Found!, Cannot Reset Recipe", " "));
                Console.ForegroundColor = ConsoleColor.Yellow;
                RecipeOptions();
            }
            RecipeList.Sort((recipe1, recipe2) => string.Compare(recipe1.Name, recipe2.Name));
            Console.WriteLine(String.Format("{0,-10} {1,-10}", " ", "Please select the recipe you would like to rescale", " "));
            for (int i = 0; i < RecipeList.Count; i++)
            {

                Console.WriteLine(String.Format("{0,-10} {1,-10}", " ", (i + 1) + "." + RecipeList[i].Name));
            }
            Console.CursorLeft = 12;
            string input = Console.ReadLine();
            int index = int.Parse(input) - 1;

            
            //output to ask user to select rescale option
            Console.WriteLine(String.Format("{0,-10} {1,-10}", " ", "Please Select Rescale Option", " "));
            Console.WriteLine(String.Format("{0,-10} {1,-10}", " ", "1. Half Recipe", " "));
            Console.WriteLine(String.Format("{0,-10} {1,-10}", " ", "2. Double Recipe", " "));
            Console.WriteLine(String.Format("{0,-10} {1,-10}", " ", "3. Triple Recipe", " "));
            Console.CursorLeft = 12;    
            input = Console.ReadLine();
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
            
            if (index >= 0 && index < RecipeList.Count)
            {
                RecipeList[index].RescaleRecipe( rescale);
                RescaleValue.Add(rescale, RecipeList[index]);
               
            }
            RecipeOptions();
        } 
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Method to rest recipe quantities 
        /// </summary>
        private void ResetRecipe()
        {
            //Heading output
            Console.Clear();
            Display("Reset Recipe", ConsoleColor.DarkBlue);
                       
            //if number of ingredients stored is 0 display error message 
            if (RecipeList.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(String.Format("{0,-10} {1,-10}", " ", "No Recipes Found!, Cannot Reset Recipe", " "));
                Console.ForegroundColor = ConsoleColor.Yellow;
                RecipeOptions();
            }

            RecipeList.Sort((recipe1, recipe2) => string.Compare(recipe1.Name, recipe2.Name));
            Console.WriteLine(String.Format("{0,-10} {1,-10}", " ", "Please select the recipe you would like to rescale", " "));
            for (int i = 0; i < RecipeList.Count; i++)
            {

                Console.WriteLine(String.Format("{0,-10} {1,-10}", " ", (i + 1) + "." + RecipeList[i].Name));
            }
            Console.CursorLeft = 12;
            string input = Console.ReadLine();
            int index = int.Parse(input) - 1;

            if (index >= 0 && index < RecipeList.Count)
            {
            https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.keyvaluepair-2?view=net-7.0
                foreach (KeyValuePair<double, Recipe> pair in RescaleValue)
                {
                    if (pair.Value.Name == RecipeList[index].Name)
                    {
                        rescale = pair.Key;
                        break;
                    }
                    else
                    {
                         Console.ForegroundColor = ConsoleColor.DarkRed;
                         Console.WriteLine(String.Format("{0,-10} {1,-10}", " ", "Recipe Has Not Been Rescaled!, Cannot Reset Recipe", " "));
                         Console.ForegroundColor = ConsoleColor.Yellow;
                         RecipeOptions();
                    }
                }
                RecipeList[index].ResetRecipe(rescale);   
            }
            RecipeOptions();
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

    }
}//__---____---____---____---____---____---____---__.ooo END OF FILE ooo.__---____---____---____---____---____---____---__\\