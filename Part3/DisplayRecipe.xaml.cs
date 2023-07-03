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
    /// <summary>
    /// Interaction logic for DisplayRecipe.xaml
    /// </summary>
    public partial class DisplayRecipe : Window
    {
        //  private List<Recipe> RecipeList; // Add this line to declare the RecipeList variable
        private List<Recipe> RecipeList = new List<Recipe>();
        public DisplayRecipe(List<Recipe> rec)
        {
            this.RecipeList = rec;
            InitializeComponent();
            PopulateRecipeList();
        }

        private void PopulateRecipeList()
        {
            // Sort RecipeList based on the Name property of each Recipe object in ascending order
            RecipeList.Sort((recipe1, recipe2) => string.Compare(recipe1.Name, recipe2.Name));

            // Add recipe names to the ListBox in alphabetical order
            foreach (Recipe recipe in RecipeList)
            {
                recipeComboBox.Items.Add(recipe.Name);
            }
        }

        private void RecipeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;

            if (comboBox.SelectedIndex == 0)
            {
                // Display all recipes in the ListView and ListBox
                // You'll need to populate the ListView (ingredientsListView) and ListBox (instructionsListBox) here
            }
            else
            {
                int selectedIndex = comboBox.SelectedIndex - 1; // Subtract 1 to account for the "All Recipes" option

                if (selectedIndex >= 0 && selectedIndex < RecipeList.Count)
                {
                    // Display the selected recipe in the ListView and ListBox
                    // You'll need to populate the ListView (ingredientsListView) and ListBox (instructionsListBox) with the selected recipe's details

                    Recipe selectedRecipe = RecipeList[selectedIndex];

                    // Populate the ListView with the transformed ingredient list
                    var ingredientList = selectedRecipe.IngredientList.Select((ingre, index) => new
                    {
                        Number = $"{index + 1} ",
                        IngredientInfo = $"{ingre.Quantity.ToString()} {ingre.UnitofM} of {ingre.Name}",
                        Calories = ingre.Calories,
                        FoodGroup = ingre.FoodGroup
                    }).ToList();

                    var stepList = selectedRecipe.Steps.Select((step, index) => new
                    {
                        Number = $"Step {index + 1}",
                        StepDescription = step
                    }).ToList();

                    ingredientsListView.ItemsSource = ingredientList;

                    // Populate the ListBox with the recipe's steps
                    stepsListView.ItemsSource = stepList;

                    // Update the total calories text
                    recipeNameTextBlock.Text = $"Recipe Name: {selectedRecipe.Name}";
                    totalCaloriesTextBlock.Text = $"Total Calories: {selectedRecipe.totalCalories} Kcal";
                  
                }
            }
        }
        //??????
        private void IngredientsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Handle the selection change event of the ingredientsListView
            // You can implement your logic here to handle the selected ingredient
            if (ingredientsListView.SelectedItem is Ingredient selectedIngredient)
            {
                // Use the selectedIngredient object to access its properties and display them as needed
                // For example, you can update the text blocks or labels with the selected ingredient's details
                recipeNameTextBlock.Text = $"Recipe Name: {selectedIngredient.Name}";

            }
           
        }

        private void DisplayAllRecipes()
        {
            // Clear existing items in the ingredientsListView and instructionsListBox
            ingredientsListView.Items.Clear();
            stepsListView.Items.Clear();

            foreach (Recipe recipe in RecipeList)
            {
                DisplayRecipeDetails(recipe);
            }
        }

        private void DisplayRecipeByName(string recipeName)
        {
            // Clear existing items in the ingredientsListView and instructionsListBox
            ingredientsListView.Items.Clear();
            stepsListView.Items.Clear();

            foreach (Recipe recipe in RecipeList)
            {
                if (recipe.Name == recipeName)
                {
                    DisplayRecipeDetails(recipe);
                    break;
                }
            }
        }

        private void DisplayRecipeDetails(Recipe recipe)
        {
            // Display recipe details in the ingredientsListView and instructionsListBox
            // Implement your logic here to populate the ingredientsListView and instructionsListBox based on the selected recipe
            // You can access the recipe's properties like recipe.Ingredients and recipe.Instructions
        }

        private void returnMenu_Click(object sender, RoutedEventArgs e)
        {
            UserMenu userMenu = new UserMenu();
            this.Hide();
            userMenu.Show();
        }
    }
}
  