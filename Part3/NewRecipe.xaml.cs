using Hannah_Ruth_Michaelson__ST10158643_PROG_6221_Part_1.Classes;
using System.Collections.Generic;
using System.Threading;
using System.Windows;
using System.Windows.Controls;

namespace Part3
{
    /// <summary>
    /// Interaction logic for NewRecipe.xaml
    /// </summary>
    public partial class NewRecipe : Window
    {
        private string rName;
        private List<Ingredient> ingredientList = new List<Ingredient>();
        private List<string> steps = new List<string>();
        private List<Recipe> RecipeList = new List<Recipe>();

        public static Recipe delObj = new Recipe();
        public static CalorieAlert delCal = new CalorieAlert(delObj.CheckCalories);
        private double recipeCal;

        public bool val;
        public bool add;
        public bool addAnotherStep;

        public NewRecipe()
        {
            InitializeComponent();
        }

        private void readyIng(object sender, RoutedEventArgs e)
        {
            // Retrieve recipe name from the text box
            rName = recipeNameTX.Text;
            changeUI(1);
            
        }

        // Continue Adding Ingredients or Move to Adding Steps
        private void anotherBtn_Click(object sender, RoutedEventArgs e)
        {
            // Call the method to get ingredient data
            // ingredientList = GetIngredients();

            ingredientList.Add(addIng());
                // Reset ingredient input fields
                ingNameTX.Text = "";
                ingQuantityTX.Text = "";
                ingCalTX.Text = "";
                unitMeasCB.SelectedIndex = -1;
                unitMeasTX.Visibility = Visibility.Collapsed;
                foodGrpCB.SelectedIndex = -1;
                 

            
        }
        public Ingredient addIng()
        {
            // Declaring variables 
            string input;
            // Declaring instance of Ingredient for each ingredient
            Ingredient ing;
            add = true;
            // Instantiate a new Ingredient object
            ing = new Ingredient();

            // Retrieve ingredient name from the text box

            val = ValidateInput.IsStringNull(ingNameTX.Text);
            if (val)
            {
                // Assigning ingredient name to input 
                ing.Name = ingNameTX.Text;
            }

            // Retrieve unit of measure from the combo box
            ComboBoxItem unitItem = unitMeasCB.SelectedItem as ComboBoxItem;
            if (unitItem != null)
            {
                input = unitItem.Content.ToString();
                if (input == "Other")
                {
                    unitMeasTX.Visibility = Visibility.Visible;
                    bool val = ValidateInput.IsStringNull(unitMeasTX.Text);
                    if (val)
                    {
                        // Assigning ingredient UM to input
                        ing.UnitofM = unitMeasTX.Text;
                    }
                }
                else
                {
                    bool val = ValidateInput.IsStringNull(input);
                    if (val)
                    {
                        // Assigning ingredient UM to input
                        ing.UnitofM = input;
                    }
                }
            }

            // Retrieve food group from the combo box
            ComboBoxItem foodGroupItem = (ComboBoxItem)foodGrpCB.SelectedItem;
            if (foodGroupItem != null)
            {
                input = foodGroupItem.Content.ToString();
                bool val = ValidateInput.IsStringNull(input);
                if (val)
                {
                    // Assigning ingredient foodgroup to input
                    ing.FoodGroup = input;
                }
            }

            // Retrieve ingredient quantity from the text box
            input = ingQuantityTX.Text;
            ing.Quantity = ValidateInput.ValidDouble(input);

            // Retrieve ingredient Calories from the text box
            input = ingCalTX.Text;
            ing.Calories = ValidateInput.ValidDouble(input);

            // Add the ingredient to the list
              return(ing);
        }

        // Continue Adding Ingredients
        private void readySteps_Click(object sender, RoutedEventArgs e)
        {
            ingredientList.Add(addIng());
            changeUI(2);
           
        }

        // Move to Save Recipe
        private void SaveRecipe_Click(object sender, RoutedEventArgs e)
        {
           
            stepTX.Visibility = Visibility.Collapsed;
            stepsLB.Visibility = Visibility.Collapsed;
            anotherStepBtn.Visibility = Visibility.Collapsed;
            saveRecipeBtn.Visibility = Visibility.Collapsed;

            // Calculate recipe calories
            recipeCal = CalculateCalories(ingredientList);

            // Method call to alter the ingredient unit of measure according to the quantity
            PluralQuantity(ingredientList);

            // Declaration and instantiation Recipe object using the para constructor
            Recipe recipe = new Recipe(rName, ingredientList, steps, recipeCal);

            // Add recipe object to RecipeList
            RecipeList.Add(recipe);

            if (recipeCal >= 300)
            {
                // Call the delCal delegate to display a calorie alert message
                MessageBox.Show("\n" + delCal(recipeCal));
            }

            MessageBox.Show("Recipe saved successfully!");

            UserMenu userMenu = new UserMenu(RecipeList);
            this.Hide();
            userMenu.Show();
        }

        // Method to retrieve ingredient data
        private List<Ingredient> GetIngredients()
        {
            // Declaring variables 
            string input;
            // Declaring instance of Ingredient for each ingredient
            Ingredient ing;
            // Declaring and initializing Ingredient List 
            List<Ingredient> ingList = new List<Ingredient>();

           bool add = true;

            do
            {
                // Instantiate a new Ingredient object
                ing = new Ingredient();

                // Retrieve ingredient name from the text box
                input = ingNameTX.Text;
                val = ValidateInput.IsStringNull(input);
                if (val)
                {
                    // Assigning ingredient name to input 
                    ing.Name = input;
                }

                // Retrieve unit of measure from the combo box
                ComboBoxItem unitItem = unitMeasCB.SelectedItem as ComboBoxItem;
                if (unitItem != null)
                {
                    input = unitItem.Content.ToString();
                    if (input == "Other")
                    {
                        unitMeasTX.Visibility = Visibility.Visible;
                        bool val = ValidateInput.IsStringNull(unitMeasTX.Text);
                        if (val)
                        {
                            // Assigning ingredient UM to input
                            ing.UnitofM = unitMeasTX.Text;
                        }
                    }
                    else
                    {
                        bool val = ValidateInput.IsStringNull(input);
                        if (val)
                        {
                            // Assigning ingredient UM to input
                            ing.UnitofM = input;
                        }
                    }
                }

                // Retrieve food group from the combo box
                ComboBoxItem foodGroupItem = (ComboBoxItem)foodGrpCB.SelectedItem;
                if (foodGroupItem != null)
                {
                    input = foodGroupItem.Content.ToString();
                    bool val = ValidateInput.IsStringNull(input);
                    if (val)
                    {
                        // Assigning ingredient foodgroup to input
                        ing.FoodGroup = input;
                    }
                }

                // Retrieve ingredient quantity from the text box
                input = ingQuantityTX.Text;
                ing.Quantity = ValidateInput.ValidDouble(input);

                // Retrieve ingredient Calories from the text box
                input = ingCalTX.Text;
                ing.Calories = ValidateInput.ValidDouble(input);

                // Add the ingredient to the list
                ingList.Add(ing);

                // Reset ingredient input fields
                ingNameTX.Text = "";
                ingQuantityTX.Text = "";
                ingCalTX.Text = "";
                unitMeasCB.SelectedIndex = -1;
                unitMeasTX.Visibility = Visibility.Collapsed;
                foodGrpCB.SelectedIndex = -1;

                if (anotherBtn.IsPressed)
                    add = true;
                else
                    add = false;
               } while (add);

            return ingList;
        }

        // Method to calculate recipe calories
        public double CalculateCalories(List<Ingredient> ingredients)
        {
            // Declare and initialize a variable for storing the total calories
            double totalCalories = 0;

            // Loop through each ingredient and add its calories to the total
            foreach (Ingredient ingredient in ingredients)
            {
                totalCalories += ingredient.Calories;
            }

            // Return the total calories
            return totalCalories;
        }

        // Method to pluralize ingredient quantity
        private void PluralQuantity(List<Ingredient> ingredientList)
        {
            // Loop through each ingredient
            foreach (Ingredient ingredient in ingredientList)
            {
                // Check if the quantity is greater than one and the unit of measure doesn't already end with 's'
                if (ingredient.Quantity > 1 && !ingredient.UnitofM.EndsWith("s"))
                {
                    // Add 's' to the end of the unit of measure
                    ingredient.UnitofM += "s";
                }
                // Check if the quantity is exactly one and the unit of measure ends with 's'
                else if (ingredient.Quantity == 1 && ingredient.UnitofM.EndsWith("s"))
                {
                    // Remove the 's' from the end of the unit of measure
                    ingredient.UnitofM = ingredient.UnitofM.TrimEnd('s');
                }
            }
        }

        // Method to retrieve recipe steps
        private List<string> GetRecipeSteps()
        {
            string input;
            List<string> steps = new List<string>();

            do
            {
                input = stepTX.Text;
                val = ValidateInput.IsStringNull(input);
                steps.Add(input);
            } while (!val);

            stepTX.Text = "";

            // If the "Add step" button is clicked, continue adding steps
            if (addAnotherStep)
            {
                // Clear the UI for adding a new step
                stepTX.Visibility = Visibility.Visible;
                stepsLB.Visibility = Visibility.Visible;
                anotherStepBtn.Visibility = Visibility.Visible;
                saveRecipeBtn.Visibility = Visibility.Visible;

                // Clear the UI and display a success message
                

                // Return an empty list to indicate that the steps are not finalized yet
                return new List<string>();
            }
            else
            {
                // If the "Done" button is clicked, return the step list
                return steps;
            }
        }
        private void addStep_Click(object sender, RoutedEventArgs e)
        {
            // Retrieve the value entered in the step input TextBox
            string stepText = stepTX.Text;

            // Perform any necessary operations with the step input, such as saving it to a list or database

            // Example: Saving the step to a list
            List<string> stepsList = new List<string>();
            stepsList.Add(stepText);

            // Optionally, you can perform validation or error checking before proceeding to the next step

            // Show or hide relevant UI elements based on the application logic

            // Example: Showing the "Add step" button and "Done" button
            stepsLB.Visibility = Visibility.Visible;
            stepTX.Visibility = Visibility.Visible;
            anotherStepBtn.Visibility = Visibility.Visible;
            saveRecipeBtn.Visibility = Visibility.Visible;

            // Clear the step input TextBox for the next step
            stepTX.Text = string.Empty;
        }

        // Method to clear the UI after saving a recipe
        private void changeUI(int i)
        {
            if (i == 1)
            {
                // Hide the recipe name label and text box
                recipeNameLB.Visibility = Visibility.Collapsed;
                recipeNameTX.Visibility = Visibility.Collapsed;
                ingBtn.Visibility = Visibility.Collapsed;


               

                ingNameLB.Visibility = Visibility.Visible;
                ingNameTX.Visibility = Visibility.Visible;
                unitMeasLB.Visibility = Visibility.Visible;
                unitMeasCB.Visibility = Visibility.Visible;
                ingQuantityLB.Visibility = Visibility.Visible;
                ingQuantityTX.Visibility = Visibility.Visible;
                ingCalLB.Visibility = Visibility.Visible;
                ingCalTX.Visibility = Visibility.Visible;
                foodGrpLB.Visibility = Visibility.Visible;
                foodGrpCB.Visibility = Visibility.Visible;
                anotherBtn.Visibility = Visibility.Visible;
                stepBtn.Visibility = Visibility.Visible;
            }
            else if (i == 2)
            {
                // Hide the ingredient-related elements
                ingNameLB.Visibility = Visibility.Collapsed;
                ingNameTX.Visibility = Visibility.Collapsed;
                unitMeasLB.Visibility = Visibility.Collapsed;
                unitMeasCB.Visibility = Visibility.Collapsed;
                ingQuantityLB.Visibility = Visibility.Collapsed;
                ingQuantityTX.Visibility = Visibility.Collapsed;
                ingCalLB.Visibility = Visibility.Collapsed;
                ingCalTX.Visibility = Visibility.Collapsed;
                foodGrpLB.Visibility = Visibility.Collapsed;
                foodGrpCB.Visibility = Visibility.Collapsed;
                anotherBtn.Visibility = Visibility.Collapsed;
                stepBtn.Visibility = Visibility.Collapsed;
                // Show the step-related elements
                stepTX.Visibility = Visibility.Visible;
                stepsLB.Visibility = Visibility.Visible;
                anotherStepBtn.Visibility = Visibility.Visible;
                saveRecipeBtn.Visibility = Visibility.Visible;
            }
            else if (i == 3)
            {
                stepTX.Visibility = Visibility.Collapsed;
                stepsLB.Visibility = Visibility.Collapsed;
                anotherStepBtn.Visibility = Visibility.Collapsed;
                saveRecipeBtn.Visibility = Visibility.Collapsed;
            }
            else if (i == 4)
            {
                // Clear the text box and other UI elements
                recipeNameTX.Text = string.Empty;

                // Clear other UI elements related to ingredients
                ingNameTX.Text = string.Empty;
                ingQuantityTX.Text = string.Empty;
                ingCalTX.Text = string.Empty;
                unitMeasCB.SelectedIndex = -1;
                unitMeasTX.Text = string.Empty;
                foodGrpCB.SelectedIndex = -1;

                // Clear other UI elements related to steps
                stepTX.Text = string.Empty;


                // Hide ingredient-related elements
                ingNameLB.Visibility = Visibility.Collapsed;
                ingNameTX.Visibility = Visibility.Collapsed;
                unitMeasLB.Visibility = Visibility.Collapsed;
                unitMeasCB.Visibility = Visibility.Collapsed;
                ingQuantityLB.Visibility = Visibility.Collapsed;
                ingQuantityTX.Visibility = Visibility.Collapsed;
                ingCalLB.Visibility = Visibility.Collapsed;
                ingCalTX.Visibility = Visibility.Collapsed;
                foodGrpLB.Visibility = Visibility.Collapsed;
                foodGrpCB.Visibility = Visibility.Collapsed;
                anotherBtn.Visibility = Visibility.Collapsed;

                // Hide step-related elements
                stepTX.Visibility = Visibility.Collapsed;
                stepsLB.Visibility = Visibility.Collapsed;
                anotherStepBtn.Visibility = Visibility.Collapsed;
                saveRecipeBtn.Visibility = Visibility.Collapsed;

                // Show recipe name-related elements
                recipeNameLB.Visibility = Visibility.Visible;
                recipeNameTX.Visibility = Visibility.Visible;
                ingBtn.Visibility = Visibility.Visible;

                // Clear the ingredient list
                

                // Reset flags
                add = false;
                addAnotherStep = false;
            }
        }

    }
}

