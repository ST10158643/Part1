using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Hannah_Ruth_Michaelson__ST10158643_PROG_6221_Part_1.Classes;
using System.Collections.Generic;

namespace CalculateCalories
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CalcuCalories_Test()
        {
            // Defa list of Ingredients with calorie amounts
            List<Ingredient> IngCal = new List<Ingredient>
            {//instancing ingredient objects with test construtor 
                new Ingredient(250),
                new Ingredient(250)
            };

            // Instance of the Recipe class
            RecipeWorker obj = new RecipeWorker();

            //Declaring double to hold Total Calories 
            double totalCal;

            // Decalring and assiging the expected result of the total calories
            double resultTotalCal = 500;

            // Calculate the total calories with RecipeWorker Class Method, by passing doubleList as a parameter
            totalCal = obj.CalculateCalories(IngCal);


            // Assert that the actual total calories matches the expected result
            Assert.AreEqual(resultTotalCal, totalCal);
            
        }
    }
}


