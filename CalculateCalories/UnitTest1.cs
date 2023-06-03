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
          
            List<double> doubleList = new List<double> {100,100,200,100};
          
            Recipe obj = new Recipe();
            //may have to add a para that is for the total Cal 
            double totalCal = obj.CalculateCalories(doubleList);
            double resultTotalCal = 500;
            Assert.AreEqual(resultTotalCal, totalCal);
            
            
        }
    }
}
