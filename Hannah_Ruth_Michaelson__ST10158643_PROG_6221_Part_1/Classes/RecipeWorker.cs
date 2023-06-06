using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Schema;

namespace Hannah_Ruth_Michaelson__ST10158643_PROG_6221_Part_1.Classes
{
    public class RecipeWorker
    {
        /// <summary>
        /// Recipe Class Object for use of delegate 
        /// </summary>
        public static Recipe delObj = new Recipe();

        /// <summary>
        /// Declaration and instantiation of a static variable "delCal" of type "CalorieAlert", the constructor of "CalorieAlert" is called with the argument "delObj.CheckCalories"
        /// </summary>
        public static CalorieAlert delCal = new CalorieAlert(delObj.CheckCalories);


        /// <summary>
        ///Declaration and initialization of string List to hold food group names 
        /// </summary>
        private List<string> foodGroups = new List<string> { "Starch", "Vegetables and Fruits", "Legumes",
                              "Meat, Chiken, Fish and Eggs", "Milk and Dairy", "Fats and Oils"
                               ,"Water"};
       
        /// <summary>
        /// Declaration of Global boolean variable for validation
        /// </summary>
        public bool val;
              
        /// <summary>
        /// Recipe Class Object List to hold Recipes
        /// </summary>
        private List<Recipe> RecipeList = new List<Recipe>();
     
        /// <summary>
        /// Dictionary to hold rescale values that corresponde to RecipeList Index
        /// </summary>
        Dictionary<double, Recipe> RescaleValue = new Dictionary<double, Recipe>();

        /// <summary>
        /// Declaration of variable store the rescale factor
        /// </summary>
        double rescale = 0.0;
            
        /// <summary>
        /// Declaration of variable to store the recipe name
        /// </summary>
        string rName;

         //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Default Constructor
        /// </summary>
        public RecipeWorker()
        {
            

        }

        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Method to set console window and start program run 
        /// </summary>
        public void StartProg()
        {
            //setting console window width
            Console.WindowWidth = 100;
            Display("Welcome to Your Digital Cookbook", ConsoleColor.DarkYellow);
            //method call to RetrieveRecipeData
            RecipeOptions();

        }
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Method to display the given text with the specified color as a heading.
        /// </summary>
        /// <param name="text">text to be displayed as a heading.</param>
        /// <param name="colour"> ConsoleColor to be used as the background color.</param>
        public void Display(string text, ConsoleColor colour)
        {
            ///Decalring Varibales 
            string separator;
            string cenHead;
            string head;

            // Set foreground color to yellow
            Console.ForegroundColor = ConsoleColor.Yellow;
            // Set  background color to the specified color
            Console.BackgroundColor = colour;

            // Initialization of separator string
            separator = "_--_--_--_--_-_--_--_--_--_--_--_--_--_--_--_--_--_--_--_--_--__--_--_--_--_-_--_--_--_--_--_--_--_--_--_--_--";
            //Initialization of string using to format and calculate the padding dynamically
            cenHead = string.Format("{0," + ((Console.WindowWidth + text.Length) / 2).ToString() + "}{1,45}", text, "");

            //Initialization of string to display heading 
            head = $"{separator}\n{cenHead}\n{separator}";

            // Display the heading
            Console.WriteLine(head);

            // Reset the background color to black
            Console.BackgroundColor = ConsoleColor.Black;
        }
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Method to for user to choose recipe actions
        /// </summary>
        /// 
        private void RecipeOptions()
        {
            // Declaring variables to hold user input
            int option; 
            string input;

            //if the Recipe name is not empty 
            if (!string.IsNullOrEmpty(rName))
            {
                Console.WriteLine("Press any key to return to menu");
                Console.ReadKey();
                Console.Clear();
                Display("App Menu", ConsoleColor.DarkBlue);
            }
            // Declaring and initialising List to hold Menu options
            List<string> menuOptions = new List<string> { "Create New Recipe", "Display Recipes", "Rescale Recipes", "Reset Recipes", "Clear Recipes", "Exit Program" };
       
            //forloop to iterate through each menu option 
            for (int i = 0; i < menuOptions.Count; i++)
            {
                //Displaying each menu option with a corresponding number
                Console.WriteLine($"\n{(i + 1).ToString().PadLeft(10)}. {menuOptions[i]} ?");
            }
            //do while loop, while input is out greater than menu options or less and or equal to 0 
            do
            {
                Console.CursorLeft = 12;
                input = Console.ReadLine();
                // Validating the user input to ensure it is a valid menu option
                option = ValidateInput.MenuInt(input, menuOptions.Count + 1);
            } while (option <= 0 || option > menuOptions.Count);

            //Switch statement to call method relevent to user input 
            switch (option)
            {
                case 1:
                    RetrieveRecipeData(); //method call to retrieve recipe data
                    break;
                case 2:
                    DisplayRecipe(); //method call  to display recipes
                    break;
                case 3:
                    RescaleRecipe(); //method call to rescale recipes
                    break;
                case 4:
                    ResetRecipe(); //method call to reset recipes
                    break;
                case 5:
                    ClearData(); // method call to clear recipe data
                    break;
                case 6:
                    EndProg(); // method call to end the program
                    break;
            }
            
            Console.ReadLine();
        }

        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        ///  Method to Retreive User Recipe Input 
        /// </summary>
        private void RetrieveRecipeData()
        {
            //Declaring double to hold recipe calories
            double recipeCal;
            //Declaring and initialising Ingredient List 
            List<Ingredient> IngredientList = new List<Ingredient>();
            //Declaring and initialising string Step List 
            List<string> Steps = new List<string>();
            //Clear console 
            Console.Clear();
            //method call to display heading 
            Display("Add New Recipe", ConsoleColor.DarkBlue);

            //do-while loop, prompt user to enter the recipe's name until a valid input is provided
            do
            {
                Console.WriteLine(String.Format("\n{0,-10} {1,-10}", " ", "Please Enter The Recipe's Name", " "));
                Console.CursorLeft = 12;
                string input = Console.ReadLine();
                // Passing input to the ValidateInput class method to ensure it is valid
                val = ValidateInput.IsStringNull(input);
                if (val)
                    rName = input;

            } while (!val);
            //Populating List through method call to get ingredient data 
             IngredientList = GetIngredients();
            //assigning value of recipe Calories double to Calculate Calries return method 
             recipeCal = CalculateCalories(IngredientList);
            //Method call to alter the ingredient unit of measure according to the quantity
            PluralQuantity(IngredientList);
            
            //Populating Step list through method call to get steps data 
            Steps = GetRecipeSteps();

            // Declaration and instantiation Recipe object using the para constructor
            Recipe recipe = new Recipe(rName, IngredientList, Steps, recipeCal);
            // add recipe object to RecipeList 
            RecipeList.Add(recipe);
            //clear console window 
            Console.Clear();
            // Output indicating that the recipe is saved
            Display("Recipe Saved !", ConsoleColor.Black);
            //change foreground to red 
            Console.ForegroundColor = ConsoleColor.DarkRed;
            //Call the delCal delegate to display a calorie alert message
            Console.WriteLine("\n"+delCal(recipeCal));
            // Delay for 2 second
            Task.Delay(2000).Wait();
            Console.Clear();
            //change foreground to yellow 
            Console.ForegroundColor = ConsoleColor.Yellow;
            // Method call to display recipe options
            RecipeOptions();
        }
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Method to Retreive Ingreidient Data
        /// </summary>
        private List< Ingredient> GetIngredients()
        {
            //Declaring variables 
            string input;
            int inputOption;
            //Declaring instance of Ingredient for each ingredient
            Ingredient ing;
            //Declaring and initialising Ingredient List 
            List<Ingredient> ingList = new List<Ingredient>();

            //do while to ask user to enter ingredient data till option selected is not 1/ yes 
            do
            {  //do while to ask user to enter ingredient until input bool returns true
                do
                {
                    // Instantiate a new Ingredient object
                    ing = new Ingredient();
                    //Input prompt 
                    Console.WriteLine(String.Format("\n{0,-10} {1,-10}", " ", "Please the ingredient's name", " "));
                    Console.CursorLeft = 12;
                    input = Console.ReadLine();
                    //passing input to ValidateIput Class method to ensure is valid 
                    val = ValidateInput.IsStringNull(input);
                    if (val)
                        //assiging ingredient name to input 
                        ing.Name = input;

                } while (!val);
                //do while to ask user to enter unit of measure until input bool returns true
                do
                {
                    Console.WriteLine(String.Format("\n{0,-10} {1,-10}", " ", "Please enter the unit of measurement", " "));
                    Console.CursorLeft = 12;
                    input = Console.ReadLine().ToLower();
                    //passing input to ValidateIput Class method to ensure is valid 
                    val = ValidateInput.IsStringNull(input);
                    if (val)
                        //assiging ingredient UM to input 
                        ing.UnitofM = input;

                } while (!val);
                //do while to ask user to enter number of quantity until input is greater than 0.0 or not 0 
                do
                {
                    Console.WriteLine(String.Format("\n{0,-10} {1,-10}", " ", "Please enter the quantity", " "));
                    Console.CursorLeft = 12;
                    input = Console.ReadLine();
                    //passing input to ValidateIput Class method to ensure is valid 
                    ing.Quantity = ValidateInput.ValidDouble(input);
                    //if quantity is greater that 0.0 
                    if (ing.Quantity > 0.0)
                        // assign ingredient string quantity variable to ValidateInput Class method that returns string 
                        ing.strQuantity = ValidateInput.FindString(ing.Quantity);
                } while (ing.Quantity < 0.0 || ing.Quantity == 0);
                //do while to ask user to enter number of calories until input is greater than 0.0 or not 0
                do
                {
                    Console.WriteLine(String.Format("\n{0,-10} {1,-10}", " ", "Please enter ingredient calories", " "));
                    Console.CursorLeft = 12;
                    input = Console.ReadLine();
                    //passing input to ValidateIput Class method to ensure is valid 
                    ing.Calories = ValidateInput.ValidDouble(input);
                    //if quantity is greater that 0.0 
                    if (ing.Calories > 0.0)
                        // assign ingredient string calorie variable to ValidateInput Class method that returns string 
                        ing.strCalories = ValidateInput.FindString(ing.Calories);
                } while (ing.Calories < 0.0 || ing.Calories == 0);
                //do while to ask user to enter number of food group until ingredient food group is assigned 
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
                    input = Console.ReadLine();
                    int inputNum = ValidateInput.MenuInt(input, foodGroups.Count + 1);
                    //switch statement to assign ingredient foodgroup to user according to user selection 
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

                //adding ingredient object to ingredientList
                ingList.Add(ing);

                //clear console window
                Console.Clear();

                //method call to display heading
                Display("Add New Recipe", ConsoleColor.DarkBlue);
               
                ingList.Add(ing);

                Console.Clear();
                Display("Add New Recipe", ConsoleColor.DarkBlue);
                //do while to ask user if they would like to save another ingredient, until the input not 1 or 2 
                do
                {
                    Console.WriteLine(String.Format("{0,-10} {1,-10}", " ", "Would you like to add another ingredient?", " "));
                    Console.WriteLine(String.Format("{0,-10} {1,-10}", " ", "1. Yes", " "));
                    Console.WriteLine(String.Format("{0,-10} {1,-10}", " ", "2. No", " "));
                    Console.CursorLeft = 12;
                    input = Console.ReadLine();
                    inputOption = ValidateInput.MenuInt(input, 3);

                } while (inputOption != 1 && inputOption != 2);

            } while (inputOption == 1);
            //return Ingredient List 
            return ingList;
        }
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Method to Retreive Recipe Steps Data
        /// </summary>
        private List<string> GetRecipeSteps()
        {
            //Declaring and initialzing variables 
            string userInput;
            int inputOption;
            int iteration = 0;
            // Declaring and initialising string Step List
            List<string> Steps = new List<string>();

            //incrementing int 
            iteration++;
            //clear console
            Console.Clear();
            //method call to display heading 
            Display("Add New Recipe", ConsoleColor.DarkBlue);
            //do while to ask user to enter steps until input is not equal to 1/yes
            do
            {
                //do while to ask user to enter steps until bool returns true
                do
                {
                    Console.WriteLine(String.Format("\n{0,-10} {1,-10}", " ", "Please Enter Recipe Step " + iteration + " Description", " "));
                    Console.CursorLeft = 12;
                    string input = Console.ReadLine();
                    //passing input to ValidateIput Class method to ensure is valid 
                    val = ValidateInput.IsStringNull(input);
                    //if bool is true, current step is assigned to user input
                    if (val)
                        Steps.Add(input);
                } while (!val);
                //do while to ask user if they would like to save another ingredient, until the input not 1 or 2 
                do
                {
                    Console.WriteLine(String.Format("{0,-10} {1,-10}", " ", "Would you like to add another step?", " "));
                    Console.WriteLine(String.Format("{0,-10} {1,-10}", " ", "1. Yes", " "));
                    Console.WriteLine(String.Format("{0,-10} {1,-10}", " ", "2. No", " "));
                    Console.CursorLeft = 12;
                    userInput = Console.ReadLine();
                    //intialing inputOption by passing userInput to ValidateInput Class method to ensure is valid 
                    inputOption = ValidateInput.MenuInt(userInput, 3);
                    
                } while (inputOption != 1 && inputOption != 2);

            } while (inputOption == 1);
           //return Step List 
            return Steps;
        }
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Method to Calculte the Total Recipe Calories, passing Ingredient List 
        /// </summary>
        public double CalculateCalories(List<Ingredient> ingredients)
        {
            //Declare and instiating Int variable
            double kCal = 0;
            // foreach loop to iterate through each ingredient's calories within the ingredients list
            foreach (Ingredient ing in ingredients)
            {
                // calorie variable is assigned to, calories plus the current ingredient's calorie value
                kCal += ing.Calories;
            }
            // return the total calories
            return kCal;
        }
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Method to Clear Recipe Data
        /// </summary>
        private void ClearData()
        {
            //Declaring variables
            string input;
            int index;
            int option;

            //clear console window 
            Console.Clear();
            //method call to display heading
            Display("Clear Recipe", ConsoleColor.DarkBlue);

            //if rescale variable is still 0.0 , display error message 
            if (RecipeList.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(String.Format("{0,-10} {1,-10}", " ", "No Recipes Found!, Cannot Clear Data", " "));
                Console.ForegroundColor = ConsoleColor.Yellow;
                RecipeOptions();
            }
            //Sort RecipeList based on the Name property of each Recipe object in ascending order
            RecipeList.Sort((recipe1, recipe2) => string.Compare(recipe1.Name, recipe2.Name));

            Console.WriteLine(String.Format("{0,-10} {1,-10}", " ", "Please select the recipe you would like to clear", " "));
            //do while to prompt the user to select a recipe to clear
            do
            {
                //for loop to iterate through each recipe name within recipelist 
                for (int i = 0; i < RecipeList.Count; i++)
                {

                    Console.WriteLine(String.Format("{0,-10} {1,-10}", " ", (i + 1) + "." + RecipeList[i].Name));
                }
                Console.CursorLeft = 12;
                //initialization of varibales 
                input = Console.ReadLine();
                index = int.Parse(input) - 1;
            } while (index < 0 || index >= RecipeList.Count);

            //do while to ensure user wants to clear data 
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
            {//if index is greater than or equal to 0 and less than the number of recipes in list 
                if (index >= 0 && index < RecipeList.Count)
                {
                    RecipeList.RemoveAt(index);

                }
               //output to inform recipe has been cleared
                Console.WriteLine(String.Format("{0,-10} {1,-10}", " ", "Recipe Cleared! Would you like to create a new recipe?", " "));
            }
            else
                //output if no recipe is cleared
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
        /// Method to Close Program 
        /// </summary>
        private void EndProg()
        {//method to clear console window 
            Console.Clear();
            //output goodbye message 
            Display("Enjoy Your Meal!", ConsoleColor.Black);     
        }
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Method to Dislay Recipe
        /// </summary>
        private void DisplayRecipe()
        {
            //Declaring variables
            string input;
            int index;
           
            //if number of ingredients stored is 0 display error message 
            if (RecipeList.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(String.Format("{0,-10} {1,-10}", " ", "No Recipes Found!, Cannot Display a Recipe", " "));
                Console.ForegroundColor = ConsoleColor.Yellow;
                //method call to menu 
                 RecipeOptions();
            }            
            //Sort RecipeList based on the Name property of each Recipe object in ascending order
            RecipeList.Sort((recipe1, recipe2) => string.Compare(recipe1.Name, recipe2.Name));
            Console.WriteLine(String.Format("{0,-10} {1,-10}", " ", "Please select the recipe you would like to view", " "));
            //do while to prompt the user to select a recipe to view
            do 
            {
                //for loop to iterate through each recipe name within recipelist 
                for (int i = 0; i < RecipeList.Count; i++)
                {

                    Console.WriteLine(String.Format("{0,-10} {1,-10}", " ", (i + 1) + "." + RecipeList[i].Name));
                }
                Console.CursorLeft = 12;
                //initialization of varibales 
                input = Console.ReadLine();
                index = int.Parse(input) -1;
            } while (index < 0 || index >= RecipeList.Count);

            RecipeList[index].DisplayRecipe();
            //if index is greater than or equal to 0 and less than the number of recipes in list 
           /* if (index >= 0 && index < RecipeList.Count)
            {
                //call to recipe DisplayRecipe() method using recipe object in recipe list 
                RecipeList[index].DisplayRecipe();
                
            }
            //method call to menu 
             RecipeOptions();
        }
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Method to Rescale Recipe Quantities 
        /// </summary>
        private void RescaleRecipe()
        {
            //Declaring variables
            string input;
            int index;

            //clear console window
            Console.Clear();
            //method call to display heading
            Display("Rescale Recipe", ConsoleColor.DarkBlue);
            
            //if number of ingredients stored is 0 display error message 
            if (RecipeList.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(String.Format("{0,-10} {1,-10}", " ", "No Recipes Found!, Cannot Reset Recipe", " "));
                Console.ForegroundColor = ConsoleColor.Yellow;
                //method call to menu 
                RecipeOptions();
            }
            //Sort RecipeList based on the Name property of each Recipe object in ascending order
            RecipeList.Sort((recipe1, recipe2) => string.Compare(recipe1.Name, recipe2.Name));
            Console.WriteLine(String.Format("{0,-10} {1,-10}", " ", "Please select the recipe you would like to rescale", " "));
            //do while to prompt the user to select a recipe to Rescale
            do
            {
                //for loop to iterate through each recipe name within recipelist 
                for (int i = 0; i < RecipeList.Count; i++)
                {

                    Console.WriteLine(String.Format("{0,-10} {1,-10}", " ", (i + 1) + "." + RecipeList[i].Name));
                }
                Console.CursorLeft = 12;
                //initialization of varibales 
                input = Console.ReadLine();
                index = int.Parse(input) - 1;
            } while (index < 0 || index >= RecipeList.Count);

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
            //if index is greater than or equal to 0 and less than the number of recipes in list 
            if (index >= 0 && index < RecipeList.Count)
            {
                //call to recipe RescaleRecipe() method with rescale double as parametre  
                RecipeList[index].RescaleRecipe( rescale);
                //add rescale value and RecipeList index value to RescaleValue Dictionary 
                RescaleValue.Add(rescale, RecipeList[index]);
            }
            //method call to menu 
            RecipeOptions();
        } 
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Method to Rest Recipe Quantities 
        /// </summary>
        private void ResetRecipe()
        {
            //Declaring variables
            string input;
            int index;

            //clear console window 
            Console.Clear();
            //method call to display heading
             Display("Reset Recipe", ConsoleColor.DarkBlue);
                       
            //if number of ingredients stored is 0 display error message 
            if (RecipeList.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(String.Format("{0,-10} {1,-10}", " ", "No Recipes Found!, Cannot Reset Recipe", " "));
                Console.ForegroundColor = ConsoleColor.Yellow;
                //method call to menu 
                RecipeOptions();
            }
            //Sort RecipeList based on the Name property of each Recipe object in ascending order
            RecipeList.Sort((recipe1, recipe2) => string.Compare(recipe1.Name, recipe2.Name));
            Console.WriteLine(String.Format("{0,-10} {1,-10}", " ", "Please select the recipe you would like to rescale", " "));
            //do while to prompt the user to select a recipe to reset
            do
            {
                //for loop to iterate through each recipe name within recipelist 
                for (int i = 0; i < RecipeList.Count; i++)
                {

                    Console.WriteLine(String.Format("{0,-10} {1,-10}", " ", (i + 1) + "." + RecipeList[i].Name));
                }
                Console.CursorLeft = 12;
                //initialization of varibales 
                input = Console.ReadLine();
                index = int.Parse(input) - 1;
            } while (index < 0 || index >= RecipeList.Count);

            //if index is greater than or equal to 0 and less than the number of recipes in list 
            if (index >= 0 && index < RecipeList.Count)
            {
                
                //foreach loop to iterate through each element of dictionary 
                foreach (KeyValuePair<double, Recipe> pair in RescaleValue)
                {
                   //if name of the current Recipe object matches the name of the Recipe at index in RecipeList
                    if (pair.Value.Name == RecipeList[index].Name)
                    {
                        // assign rescale value from the dictionary to the 'rescale' variable
                        rescale = pair.Key;
                        break;
                    }
                    else
                    {    //display error message 
                         Console.ForegroundColor = ConsoleColor.DarkRed;
                         Console.WriteLine(String.Format("{0,-10} {1,-10}", " ", "Recipe Has Not Been Rescaled!, Cannot Reset Recipe", " "));
                         Console.ForegroundColor = ConsoleColor.Yellow;
                        //method call to menu
                        RecipeOptions();
                    }
                }
                //call to recipe ReseteRecipe() method with rescale double as parametre  
                RecipeList[index].ResetRecipe(rescale);   
            }
            //method call to menu 
            RecipeOptions();
        }
        //---------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Method to add "S" to unit of measure of quantity is greater than one 
        /// </summary>
        private void PluralQuantity(List<Ingredient> IngredientList)
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