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
        public List<Recipe> recipeList;
        public Dictionary<double, Recipe> RescaleValue = new Dictionary<double, Recipe>();

        public UserMenu()
        {
            InitializeComponent();
            recipeList = GetInitialRecipeList();
        }

        public UserMenu(List<Recipe> rec)
        {
            InitializeComponent();
            recipeList = rec;
        }

        private void CreateNewRecipe_Click(object sender, RoutedEventArgs e)
        {
            if (recipeList.Count > 0)
            {
                NewRecipe newMore = new NewRecipe(recipeList, this); // Pass the recipeList and UserMenu instance
                this.Hide();
                newMore.Show();
            }
            else
            {
                NewRecipe newRecipe = new NewRecipe(); // Pass the recipeList and UserMenu instance
                this.Hide();
                newRecipe.Show();
            }
        }

        private void DisplayRecipes_Click(object sender, RoutedEventArgs e)
        {
            // Call the method to handle "Display Recipes" option
            DisplayRecipe display = new DisplayRecipe(recipeList);
            this.Hide();
            display.Show();
        }

        private void RescaleRecipes_Click(object sender, RoutedEventArgs e)
        {
            // Call the method to handle "Rescale Recipes" option
            Rescale rescale = new Rescale(recipeList, this); // Pass the UserMenu instance as the second argument
            this.Hide();
            rescale.Show();
        }

        private void ResetRecipes_Click(object sender, RoutedEventArgs e)
        {
            Reset reset = new Reset(recipeList, this); // Pass the UserMenu instance as the second argument
            this.Hide();
            reset.Show();

        }

        private void ClearRecipes_Click(object sender, RoutedEventArgs e)
        {
            Clear clear = new Clear(recipeList, this); // Pass the UserMenu instance as the second argument
            this.Hide();
            clear.Show();

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

        private List<Recipe> GetInitialRecipeList()
        {
            // TODO: Implement the logic to retrieve the initial recipe list
            // For now, return a new empty list as an example
            return new List<Recipe>();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            Filter fil = new Filter(recipeList, this); // Pass the UserMenu instance as the second argument
            this.Hide();
            fil.Show();
        }
    }
}

