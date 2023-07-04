using Hannah_Ruth_Michaelson__ST10158643_PROG_6221_Part_1.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
        public partial class Rescale : Window
        {
            private List<Recipe> RecipeList;
            private UserMenu userMenu;
            private double rescale = 1.0;



        public Rescale(List<Recipe> rec, UserMenu userMenu)
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
                
                if (halfRadioButton.IsChecked == true)
                {
                    rescale = 0.5;
                }
                else if (doubleRadioButton.IsChecked == true)
                {
                    rescale = 2.0;
                }
                else if (tripleRadioButton.IsChecked == true)
                {
                    rescale = 3.0;
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

            private void rescaleBtn_Click(object sender, RoutedEventArgs e)
            {
                int selectedIndex = recipeComboBox.SelectedIndex;

                if (selectedIndex >= 0)
                {
                    double rescale = GetRescaleValue();
                    RecipeList[selectedIndex].RescaleRecipe(rescale);
                    RecipeList[selectedIndex].totalCalories *= rescale;
                    UpdateRecipeDetails(selectedIndex);
                }

                // Disable the radio buttons and rescale button
                halfRadioButton.IsEnabled = false;
                doubleRadioButton.IsEnabled = false;
                tripleRadioButton.IsEnabled = false;
                rescaleBT.IsEnabled = false;
            }

            private void returnMenu_Click(object sender, RoutedEventArgs e)
            {
                int selectedIndex = recipeComboBox.SelectedIndex;

                userMenu.recipeList = RecipeList;
                userMenu.RescaleValue.Add(rescale, RecipeList[selectedIndex]);
                // Update the recipe list in UserMenu
                userMenu.Show(); // Show the UserMenu window
                this.Close(); // Close the Rescale window
            }
        }
    }

   



