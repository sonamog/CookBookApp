using System;
using CookBook.Controllers;
using CookBook.Models;
using DataAccess.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CookBookUT
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {         
            TestData testData = new TestData();
            var expected = new TestData
            {
                Recipe_name = "Test name",
                Recipe_Category = "Test category",
                Recipe_Date = null,
                Recipe_Description = "Test description",
                Recipe_Id = 1
            };
            testData = testData.GetSingleRecipeTestData();
            var actual = testData.GetSingleRecipeTestData();
            actual = testData; //Both 
            Assert.AreSame(testData, actual);
        }

        [TestMethod]
        public void DeleteRecipeById()
        {

        }

    }
}
