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
        public List<Recipe> RecipeList { get; set; }


        public DisplayRecipe(List<Recipe> rec)
        {
            RecipeList = rec;
            InitializeComponent();
            PopulateRecipeList();
        }
        // Populates the recipeComboBox with recipe names
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
        private void displayBtn_Click(object sender, RoutedEventArgs e)
        {
            int selectedIndex = recipeComboBox.SelectedIndex -1;
           
            if (recipeComboBox.SelectedIndex == 0)
            {
                DisplayAll();               
            }
            else
            {
                UpdateRecipeDetails(selectedIndex);
            }
        }
        // Updates the UI with the recipe details
        private void UpdateRecipeDetails(int selectedIndex)
        {
            // Clear the existing content in the StackPanel
            recPanel.Children.Clear();

            // Add heading for Recipe Name
            TextBlock recipeNameHeadingTextBlock = new TextBlock();
            recipeNameHeadingTextBlock.Text = $"Recipe Name: {RecipeList[selectedIndex].Name}";
            recipeNameHeadingTextBlock.FontSize = 18;
            recipeNameHeadingTextBlock.FontWeight = FontWeights.SemiBold;
            recipeNameHeadingTextBlock.HorizontalAlignment = HorizontalAlignment.Center; // Align center
            recPanel.Children.Add(recipeNameHeadingTextBlock);

            // Add heading for Total Calories
            TextBlock totalCaloriesHeadingTextBlock = new TextBlock();
            totalCaloriesHeadingTextBlock.Text = $"Total Calories: {RecipeList[selectedIndex].totalCalories} Kcal";
            totalCaloriesHeadingTextBlock.FontSize = 15;
            totalCaloriesHeadingTextBlock.FontWeight = FontWeights.SemiBold;
            totalCaloriesHeadingTextBlock.HorizontalAlignment = HorizontalAlignment.Left; // Align left
            recPanel.Children.Add(totalCaloriesHeadingTextBlock);


            // Add heading for Ingredients
            TextBlock ingredientsHeadingTextBlock = new TextBlock();
            ingredientsHeadingTextBlock.Text = "Ingredients";
            ingredientsHeadingTextBlock.FontSize = 15;
            ingredientsHeadingTextBlock.FontWeight = FontWeights.SemiBold;
            recPanel.Children.Add(ingredientsHeadingTextBlock);

            // Populate the StackPanel with the transformed ingredient list
            var recipeIngs = RecipeList[selectedIndex].IngredientList.Select((ingre, index) => new
            {
                Number = $"{index + 1} ",
                IngredientInfo = $"{ingre.Quantity.ToString()} {ingre.UnitofM} of {ingre.Name}",
                Calories = ingre.Calories,
                FoodGroup = ingre.FoodGroup
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

                recPanel.Children.Add(ingredientPanel);
            }

            // Add heading for Instructions
            TextBlock instructionsHeadingTextBlock = new TextBlock();
            instructionsHeadingTextBlock.Text = "Instructions";
            instructionsHeadingTextBlock.FontSize = 15;
            instructionsHeadingTextBlock.FontWeight = FontWeights.SemiBold;
            recPanel.Children.Add(instructionsHeadingTextBlock);


            // Populate the StackPanel with the transformed step list
            var stepList = RecipeList[selectedIndex].Steps.Select((step, index) => new
            {
                Number = $"Step {index + 1}: ",
                StepDescription = step
            }).ToList();

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

                recPanel.Children.Add(stepPanel);
            }

            
        }

        private void DisplayAll()
        {

            // Clear the existing content in the StackPanel
            recPanel.Children.Clear();
            for (int curRec = 0; curRec < RecipeList.Count; curRec++)
            {

                // Add heading for Recipe Name
                TextBlock recipeNameHeadingTextBlock = new TextBlock();
                recipeNameHeadingTextBlock.Text = $"Recipe Name: {RecipeList[curRec].Name}";
                recipeNameHeadingTextBlock.FontSize = 18;
                recipeNameHeadingTextBlock.FontWeight = FontWeights.SemiBold;
                recipeNameHeadingTextBlock.HorizontalAlignment = HorizontalAlignment.Center; // Align center
                recPanel.Children.Add(recipeNameHeadingTextBlock);

                // Add heading for Total Calories
                TextBlock totalCaloriesHeadingTextBlock = new TextBlock();
                totalCaloriesHeadingTextBlock.Text = $"Total Calories: {RecipeList[curRec].totalCalories} Kcal";
                totalCaloriesHeadingTextBlock.FontSize = 15;
                totalCaloriesHeadingTextBlock.FontWeight = FontWeights.SemiBold;
                totalCaloriesHeadingTextBlock.HorizontalAlignment = HorizontalAlignment.Left; // Align left
                recPanel.Children.Add(totalCaloriesHeadingTextBlock);


                // Add heading for Ingredients
                TextBlock ingredientsHeadingTextBlock = new TextBlock();
                ingredientsHeadingTextBlock.Text = "Ingredients";
                ingredientsHeadingTextBlock.FontSize = 15;
                ingredientsHeadingTextBlock.FontWeight = FontWeights.SemiBold;
                recPanel.Children.Add(ingredientsHeadingTextBlock);

                // Populate the StackPanel with the transformed ingredient list
                var recipeIngs = RecipeList[curRec].IngredientList.Select((ingre, index) => new
                {
                    Number = $"{index + 1} ",
                    IngredientInfo = $"{ingre.Quantity.ToString()} {ingre.UnitofM} of {ingre.Name}",
                    Calories = ingre.Calories,
                    FoodGroup = ingre.FoodGroup
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

                    recPanel.Children.Add(ingredientPanel);
                }

                // Add heading for Instructions
                TextBlock instructionsHeadingTextBlock = new TextBlock();
                instructionsHeadingTextBlock.Text = "Instructions";
                instructionsHeadingTextBlock.FontSize = 15;
                instructionsHeadingTextBlock.FontWeight = FontWeights.SemiBold;
                recPanel.Children.Add(instructionsHeadingTextBlock);

                // Populate the StackPanel with the transformed step list
                var stepList = RecipeList[curRec].Steps.Select((step, index) => new
                {
                    Number = $"Step {index + 1}: ",
                    StepDescription = step
                }).ToList();

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

                    recPanel.Children.Add(stepPanel);
                }
            }
        }



       
        private void returnMenu_Click(object sender, RoutedEventArgs e)
        {
            UserMenu userMenu = new UserMenu(RecipeList);
            this.Hide();
            userMenu.Show();
        }

       
    }
}
  