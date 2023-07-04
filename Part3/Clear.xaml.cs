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
    public partial class Clear : Window
    {
        private List<Recipe> RecipeList;
        private UserMenu userMenu;
    
        public Clear(List<Recipe> rec, UserMenu userMenu)
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

        private void clearBtn_Click(object sender, RoutedEventArgs e)
        {
            int selectedIndex = recipeComboBox.SelectedIndex;
            string recName = RecipeList[selectedIndex].Name;

            if (selectedIndex >= 0 && selectedIndex < RecipeList.Count)
            {
               
                RecipeList.RemoveAt(selectedIndex);              
               
                clearTX.Text = $"Recipe '{recName}' cleared successfully.";


                MessageBox.Show($"Recipe '{recName}' cleared successfully.");
            }

            // Disable the radio buttons and rescale button
            clearBT.IsEnabled = false;
        }
      
        private void returnBtn_Click(object sender, RoutedEventArgs e)
        {
            
            userMenu.recipeList = RecipeList;

            // Update the recipe list in UserMenu
            userMenu.Show(); // Show the UserMenu window
            this.Close(); // Close the Rescale window
        }

    }
}

