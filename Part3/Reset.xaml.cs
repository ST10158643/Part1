using Hannah_Ruth_Michaelson__ST10158643_PROG_6221_Part_1.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Part3
{
    public partial class Reset : Window
    {
        private List<Recipe> RecipeList;
        private UserMenu userMenu;
        private double rescale = 1.0;


        public Reset(List<Recipe> rec, UserMenu userMenu)
        {
            this.RecipeList = rec;
            this.userMenu = userMenu;
            InitializeComponent();
            PopulateRecipeList();
        }

        // Populates the recipeComboBox with recipe names
        private void PopulateRecipeList()
        {
            // Sort RecipeList based on the Name property of each Recipe object in ascending order
            RecipeList.Sort((recipe1, recipe2) => string.Compare(recipe1.Name, recipe2.Name));

            // Add recipe names to the ComboBox in alphabetical order
            foreach (Recipe recipe in RecipeList)
            {
                recipeComboBox.Items.Add(recipe.Name);
            }
        }

        // Returns the rescale value based on the selected radio button
        private double GetRescaleValue()
        {
            // If index is greater than or equal to 0 and less than the number of recipes in the list
            if (recipeComboBox.SelectedIndex >= 0 && recipeComboBox.SelectedIndex < RecipeList.Count)
            {
                // foreach loop to iterate through each element of the dictionary
                foreach (KeyValuePair<double, Recipe> pair in userMenu.RescaleValue)
                {
                    // If name of the current Recipe object matches the name of the Recipe at the selected index in RecipeList
                    if (pair.Value.Name == RecipeList[recipeComboBox.SelectedIndex].Name)
                    {
                        // Assign the rescale value from the dictionary to the 'rescale' variable
                        return pair.Key;
                    }
                    else
                    {
                        // Display error message
                        MessageBox.Show("Recipe has not been rescaled! Cannot reset the recipe.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        // Method call to menu
                       
                    }
                }
            }

            return rescale;
        }

        // Updates the UI with the rescaled recipe details
        private void UpdateRecipeDetails(int selectedIndex)
        {
            // Clear the existing content in the StackPanel
            ingredientsStackPanel.Children.Clear();
            stepsStackPanel.Children.Clear();

            // Populate the StackPanel with the transformed ingredient list
            var recipeIngs = RecipeList[selectedIndex].IngredientList.Select((ingre, index) => new
            {
                Number = $"{index + 1} ",
                IngredientInfo = $"{ingre.Quantity.ToString()} {ingre.UnitofM} of {ingre.Name}",
                Calories = ingre.Calories,
                FoodGroup = ingre.FoodGroup
            }).ToList();

            // Populate the StackPanel with the transformed step list
            var stepList = RecipeList[selectedIndex].Steps.Select((step, index) => new
            {
                Number = $"Step {index + 1}: ",
                StepDescription = step
            }).ToList();

            // Create CheckBox and TextBox for each ingredient and add them to the StackPanel
            foreach (var ingredient in recipeIngs)
            {
                StackPanel ingredientPanel = new StackPanel();
                ingredientPanel.Orientation = Orientation.Horizontal;

                CheckBox ingredientCheckBox = new CheckBox();
                ingredientCheckBox.VerticalAlignment = VerticalAlignment.Center;
                ingredientPanel.Children.Add(ingredientCheckBox);

                TextBox ingredientTextBox = new TextBox();
                ingredientTextBox.Text = ingredient.IngredientInfo;
                ingredientTextBox.Margin = new Thickness(5, 0, 0, 0);
                ingredientPanel.Children.Add(ingredientTextBox);

                ingredientsStackPanel.Children.Add(ingredientPanel);
            }

            // Create CheckBox and TextBox for each step and add them to the StackPanel
            foreach (var step in stepList)
            {
                StackPanel stepPanel = new StackPanel();
                stepPanel.Orientation = Orientation.Horizontal;

                CheckBox stepCheckBox = new CheckBox();
                stepCheckBox.VerticalAlignment = VerticalAlignment.Center;
                stepPanel.Children.Add(stepCheckBox);

                TextBox stepTextBox = new TextBox();
                stepTextBox.Text = step.StepDescription;
                stepTextBox.Margin = new Thickness(5, 0, 0, 0);
                stepPanel.Children.Add(stepTextBox);

                stepsStackPanel.Children.Add(stepPanel);
            }

            // Update the recipe name and total calories
            recipeNameTextBlock.Text = $"Recipe Name: {RecipeList[selectedIndex].Name}";
            totalCaloriesTextBlock.Text = $"Total Calories: {RecipeList[selectedIndex].totalCalories} Kcal";
        }

        private void resetBtn_Click(object sender, RoutedEventArgs e)
        {
            int selectedIndex = recipeComboBox.SelectedIndex;

            if (selectedIndex >= 0)
            {
                double rescale = GetRescaleValue();
                // Update recipe calories
                RecipeList[selectedIndex].totalCalories /= rescale;
                // Call to recipe ResetRecipe() method with the rescale value as a parameter
                RecipeList[selectedIndex].ResetRecipe(rescale);
                // Call to RecipeWorker's CalculateCalories() method to update calories
                RecipeList[selectedIndex].totalCalories = RecipeList[selectedIndex].CalculateCalories();
                UpdateRecipeDetails(selectedIndex);
            }

            // Disable the radio buttons and rescale button
            resetBT.IsEnabled = false;
        }

        private void returnMenu_Click(object sender, RoutedEventArgs e)
        {
            int selectedIndex = recipeComboBox.SelectedIndex;

            userMenu.recipeList = RecipeList;

            // Find the matching recipe in the dictionary and remove it
            foreach (var pair in userMenu.RescaleValue.ToList())
            {
                if (pair.Value == RecipeList[selectedIndex])
                {
                    userMenu.RescaleValue.Remove(pair.Key);
                    break;
                }
            }

            // Update the recipe list in UserMenu
            userMenu.Show(); // Show the UserMenu window
            this.Close(); // Close the Rescale window
        }

    }
}

