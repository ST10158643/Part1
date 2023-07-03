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
        private List<Recipe> RecipeList = new List<Recipe>();
        Recipe selectedRecipe;


        public RescaleRecipe(List<Recipe> rec)
        {
            this.RecipeList = rec;
            InitializeComponent();
            PopulateRecipeComboBox();
        }
        private void PopulateRecipeComboBox()
        {
            // Populate the ComboBox with recipe names from the RecipeList
            recipeComboBox.ItemsSource = RecipeList.Select(recipe => recipe.Name).ToList();
        }
        private void rescaleBtn_Click(object sender, RoutedEventArgs e)
        {
            string selectedRecipeName = recipeComboBox.SelectedItem as string;
            selectedRecipe = RecipeList.FirstOrDefault(recipe => recipe.Name == selectedRecipeName);

            if (selectedRecipe != null)
            {
                double rescale = 1.0;
                if (halfRadioButton.IsChecked == true)
                    rescale = 0.5;
                else if (doubleRadioButton.IsChecked == true)
                    rescale = 2.0;
                else if (tripleRadioButton.IsChecked == true)
                    rescale = 3.0;

                selectedRecipe.RescaleRecipe(rescale);
                changeUI();
                // RescaleValue.Add(rescale, RecipeList[index]);

            }
            this.Close();
        }
        private void populateListViews()
        {

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
        private void returnMenu_Click(object sender, RoutedEventArgs e)
        {
            UserMenu userMenu = new UserMenu(RecipeList);
            this.Hide();
            userMenu.Show();
        }
        private void changeUI()
        {
            rescaleInput.Visibility = Visibility.Collapsed;
            showRescaled.Visibility = Visibility.Visible;
        }
    }
}