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
    /// Interaction logic for UserMenu.xaml
    /// </summary>
    public partial class UserMenu : Window
    {
        private List<Recipe> RecipeList = new List<Recipe>();

        Dictionary<double, Recipe> RescaleValue = new Dictionary<double, Recipe>();
        public UserMenu()
        {
            InitializeComponent();
        }
        public UserMenu(List<Recipe> rec)
        {
            this.RecipeList = rec;
            InitializeComponent();

        }

        private void CreateNewRecipe_Click(object sender, RoutedEventArgs e)
        {
            // Call the method to handle "Create New Recipe" option
           // RetrieveRecipeData();
            NewRecipe newRecipe = new NewRecipe();
            this.Hide();
            newRecipe.Show();
        }

        private void DisplayRecipes_Click(object sender, RoutedEventArgs e)
        {
            // Call the method to handle "Display Recipes" option
            DisplayRecipe display = new DisplayRecipe(RecipeList);
            this.Hide();
            display.Show();
        }

        private void RescaleRecipes_Click(object sender, RoutedEventArgs e)
        {
            // Call the method to handle "Rescale Recipes" option
            RescaleRecipe rescale = new RescaleRecipe(RecipeList);
            this.Hide();
            rescale.Show();
        }

        private void ResetRecipes_Click(object sender, RoutedEventArgs e)
        {
            // Call the method to handle "Reset Recipes" option
           
        }

        private void ClearRecipes_Click(object sender, RoutedEventArgs e)
        {
            // Call the method to handle "Clear Recipes" option
            
        }

        private void ExitProgram_Click(object sender, RoutedEventArgs e)
        {
            // Call the method to handle "Exit Program" option
            EndProg();
        }

      

        private void EndProg()
        {
            // Implementation for "Exit Program" option
            Close();
        }
    }
}

