using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CookBook.Models
{
    public class TestData
    {
        //[Key]
        public int Recipe_Id { get; set; }
        public string Recipe_Category { get; set; }
        public string Recipe_name { get; set; }
        public string Recipe_Description { get; set; }
        public DateTime? Recipe_Date { get; set; }

        //sample test -- see CookBookUT for its usuage
        public virtual TestData GetSingleRecipeTestData()
        {
            return new TestData
            {
                Recipe_name = "Test name",
                Recipe_Category = "Test category",
                Recipe_Date = null,
                Recipe_Description = "Test description",
                Recipe_Id = 1
            };
        }


        public virtual List<TestData> GetManyRecipesTestData()
        {
            return new List<TestData>
            {
                new TestData
                {
                    Recipe_name = "Test name 1",
                    Recipe_Category = "Test category 1",
                    Recipe_Date = DateTime.Now,
                    Recipe_Description = "Test description 1",
                    Recipe_Id = 1
                },
                new TestData
                {
                    Recipe_name = "Test name 2",
                    Recipe_Category = "Test category 2",
                    Recipe_Date = DateTime.Now,
                    Recipe_Description = "Test description 2",
                    Recipe_Id = 2
                }
            };
        }
    }
}