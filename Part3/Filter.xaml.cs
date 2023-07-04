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
    /// Interaction logic for Filter.xaml
    /// </summary>
    public partial class Filter : Window
    {
        private List<Recipe> recipeList;
        private UserMenu userMenu;

        public Filter(List<Recipe> recipeList, UserMenu userMenu)
        {
            this.recipeList = recipeList;
            this.userMenu = userMenu;
            InitializeComponent();
        }

        private void ReturnToMenuButton_Click(object sender, RoutedEventArgs e)
        {
            userMenu.recipeList = recipeList;
            userMenu.Show();
            this.Close();
        }

        private List<Recipe> FilterRecipes(string ingredientName, string foodGroup, double maxCalories)
        {
            List<Recipe> filteredRecipes = new List<Recipe>();

            foreach (Recipe recipe in recipeList)
            {
                bool ingredientNameMatch = false;
                bool foodGroupMatch = false;

                foreach (Ingredient ingredient in recipe.IngredientList)
                {
                    if (ingredient.Name.ToLower().Contains(ingredientName.ToLower()))
                    {
                        ingredientNameMatch = true;
                    }

                    if (ingredient.FoodGroup.ToLower() == foodGroup.ToLower())
                    {
                        foodGroupMatch = true;
                    }
                }

                if (ingredientNameMatch && foodGroupMatch && recipe.totalCalories <= maxCalories)
                {
                    filteredRecipes.Add(recipe);
                }
            }

            return filteredRecipes;
        }

        private void FilterButton_Click(object sender, RoutedEventArgs e)
        {
            string ingredientName = ingredientTextBox.Text;
            string foodGroup = (foodGroupComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
            double maxCalories = double.Parse(maxCaloriesTextBox.Text);

            List<Recipe> filteredRecipes = FilterRecipes(ingredientName, foodGroup, maxCalories);

        }
    }
}
