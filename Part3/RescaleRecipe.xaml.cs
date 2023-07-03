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
    /// Interaction logic for RescaleRecipe.xaml
    /// </summary>
    public partial class RescaleRecipe : Window
    {

        //  private List<Recipe> RecipeList; // Add this line to declare the RecipeList variable
        private List<Recipe> RecipeList = new List<Recipe>();

        public RescaleRecipe(List<Recipe> rec)
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
            }
            else
            {
                // Subtract 1 to account for the "All Recipes" option
                int selectedIndex = comboBox.SelectedIndex;
               

              // RecipeList[selectedIndex].IngredientList = RecipeList[selectedIndex].RescaleRecipeR(rescaleValue());
                

                // Populate the ListView with the transformed ingredient list
                var recipeIngs = RecipeList[selectedIndex].IngredientList.Select((ingre, index) => new
                {
                        Number = $"{index + 1} ",
                        IngredientInfo = $"{ingre.Quantity.ToString()} {ingre.UnitofM} of {ingre.Name}",
                        Calories = ingre.Calories,
                        FoodGroup = ingre.FoodGroup
                    }).ToList();

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

                    recipeNameTextBlock.Text = $"Recipe Name: {RecipeList[selectedIndex].Name}";
                    totalCaloriesTextBlock.Text = $"Total Calories: {RecipeList[selectedIndex].totalCalories} Kcal";
                
            }
        }
        private void rescaleBtn_Click(object sender, RoutedEventArgs e)
        {            
            rescaleInput.Visibility = Visibility.Collapsed;
            ShowDetails();
            recipeNameTextBlock.Visibility = Visibility.Visible;
            totalCaloriesTextBlock.Visibility = Visibility.Visible;
            ingTB.Visibility = Visibility.Visible;
            ingredientsStackPanel.Visibility = Visibility.Visible;
            stepBlock.Visibility = Visibility.Visible;
            stepsStackPanel.Visibility = Visibility.Visible;
                     
        }
        private double rescaleValue()
        {
            double rescale = 1.0;
            if (halfRadioButton.IsChecked == true)
                rescale = 0.5;
            else if (doubleRadioButton.IsChecked == true)
                rescale = 2.0;
            else if (tripleRadioButton.IsChecked == true)
                rescale = 3.0;

            return rescale;

        }
        private void returnMenu_Click(object sender, RoutedEventArgs e)
        {
            UserMenu userMenu = new UserMenu();
            this.Hide();
            userMenu.Show();
        }
        private void ShowDetails()
        {
            recipeNameTextBlock.Visibility = Visibility.Visible;
            totalCaloriesTextBlock.Visibility = Visibility.Visible;
            ingTB.Visibility = Visibility.Visible;
            ingredientsStackPanel.Visibility = Visibility.Visible;
            stepBlock.Visibility = Visibility.Visible;
            stepsStackPanel.Visibility = Visibility.Visible;
        }


    }

}