using Hannah_Ruth_Michaelson__ST10158643_PROG_6221_Part_1.Classes;
using System;
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
        private UserMenu userMenu;

        public NewRecipe()
        {
            InitializeComponent();
        }

        public NewRecipe(List<Recipe> recipeList, UserMenu userMenu)
        {
            InitializeComponent();
            this.RecipeList = recipeList;
            this.userMenu = userMenu;
        }

        // Event handler for "Ready" button click
        private void readyIng(object sender, RoutedEventArgs e)
        {
            // Retrieve recipe name from the text box
            bool val = ValidateInput.IsStringNullW(recipeNameTX.Text);
            if (val)
            {
                rName = recipeNameTX.Text;
                changeUI(2); // Move to ingredient input UI
            }
        }// Event handler for "Add Another Ingredient" button click
        private void anotherBtn_Click(object sender, RoutedEventArgs e)
        {
            // Hide the error labels
            eQuan.Visibility = Visibility.Collapsed;
            eName.Visibility = Visibility.Collapsed;
            eUM.Visibility = Visibility.Collapsed;
            eFoodGroup.Visibility = Visibility.Collapsed;
            eCal.Visibility = Visibility.Collapsed;

            // Add the ingredient to the ingredient list
            ingredientList.Add(addIng());

            // Reset ingredient input fields
            ingNameTX.Text = "";
            ingQuantityTX.Text = "";
            ingCalTX.Text = "";
            unitMeasTX.Text = "";
            foodGrpCB.SelectedIndex = -1;
        }
        // Done adding ing, add steps 
        private void readySteps_Click(object sender, RoutedEventArgs e)
        {
            eQuan.Visibility = Visibility.Collapsed;
            eName.Visibility = Visibility.Collapsed;
            eUM.Visibility = Visibility.Collapsed;
            eFoodGroup.Visibility = Visibility.Collapsed;
            eCal.Visibility = Visibility.Collapsed;
            changeUI(3); // Move to step input UI
        }

        // Event handler for "Add Step" button click
        private void addStep_Click(object sender, RoutedEventArgs e)
        {
            // Add the step to the step list
            steps.Add(addStep());

            // Reset the step input field
            stepTX.Text = "";
        }
       
        public string addStep()
        {
            // Retrieve the value entered in the step input TextBox
            string stepText = stepTX.Text;
            return stepText;
         
        }

        // Method to clear the UI after saving a recipe

    
    // Move to Save Recipe
    private void SaveRecipe_Click(object sender, RoutedEventArgs e)
    {
            steps.Add(addStep());
            changeUI(3);
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

        //Method to save ingredient 
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

            // Retrieve unit of measure
            val = ValidateInput.IsStringNull(unitMeasTX.Text);
            if (val)
            {
                ing.UnitofM = unitMeasTX.Text;
                eUM.Visibility = Visibility.Collapsed; // Hide the error label
            }
            else
            {
                eUM.Visibility = Visibility.Visible; // Show the error label
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
            return (ing);
        }
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


        // Method to change the UI based on the given mode
        private void changeUI(int mode)
        {
            // Hide all UI elements
            recipeNameLB.Visibility = Visibility.Collapsed;
            recipeNameTX.Visibility = Visibility.Collapsed;
            ingBtn.Visibility = Visibility.Collapsed;
            ingNameLB.Visibility = Visibility.Collapsed;
            ingNameTX.Visibility = Visibility.Collapsed;
            unitMeasLB.Visibility = Visibility.Collapsed;
            unitMeasTX.Visibility = Visibility.Collapsed;
            ingQuantityLB.Visibility = Visibility.Collapsed;
            ingQuantityTX.Visibility = Visibility.Collapsed;
            ingCalLB.Visibility = Visibility.Collapsed;
            ingCalTX.Visibility = Visibility.Collapsed;
            foodGrpLB.Visibility = Visibility.Collapsed;
            foodGrpCB.Visibility = Visibility.Collapsed;
            anotherBtn.Visibility = Visibility.Collapsed;
            stepBtn.Visibility = Visibility.Collapsed;
            stepTX.Visibility = Visibility.Collapsed;
            stepsLB.Visibility = Visibility.Collapsed;
            anotherStepBtn.Visibility = Visibility.Collapsed;
            saveRecipeBtn.Visibility = Visibility.Collapsed;

            // Show UI elements based on the mode
            if (mode == 1)
            {
                // Show recipe name input
                recipeNameLB.Visibility = Visibility.Visible;
                recipeNameTX.Visibility = Visibility.Visible;
                ingBtn.Visibility = Visibility.Visible;
            }
            else if (mode == 2)
            {
                // Show ingredient input
                ingNameLB.Visibility = Visibility.Visible;
                ingNameTX.Visibility = Visibility.Visible;
                unitMeasLB.Visibility = Visibility.Visible;
                unitMeasTX.Visibility = Visibility.Visible;
                ingQuantityLB.Visibility = Visibility.Visible;
                ingQuantityTX.Visibility = Visibility.Visible;
                ingCalLB.Visibility = Visibility.Visible;
                ingCalTX.Visibility = Visibility.Visible;
                foodGrpLB.Visibility = Visibility.Visible;
                foodGrpCB.Visibility = Visibility.Visible;
                anotherBtn.Visibility = Visibility.Visible;
                stepBtn.Visibility = Visibility.Visible;

                recipeNameLB.Visibility = Visibility.Collapsed;
                recipeNameTX.Visibility = Visibility.Collapsed;
                ingBtn.Visibility = Visibility.Collapsed;
            }
            else if (mode == 3)
            {
                // Show step input
                stepTX.Visibility = Visibility.Visible;
                stepsLB.Visibility = Visibility.Visible;
                anotherStepBtn.Visibility = Visibility.Visible;
                saveRecipeBtn.Visibility = Visibility.Visible;
            }
            else if (mode == 4)
            {
                // Clear all input fields
                recipeNameTX.Text = string.Empty;
                ingNameTX.Text = string.Empty;
                unitMeasTX.Text = string.Empty;
                ingQuantityTX.Text = string.Empty;
                ingCalTX.Text = string.Empty;
                foodGrpCB.SelectedIndex = -1;
                stepTX.Text = string.Empty;

                // Reset the ingredient list and step list
                ingredientList.Clear();
                steps.Clear();

                // Reset the recipe name
                rName = string.Empty;

                // Move back to the first UI
                changeUI(1);
            }
        }
    }
} 


   

