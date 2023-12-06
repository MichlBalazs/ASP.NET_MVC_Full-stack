using GG1RKK_HFT_202324.Models;
using GG1RKK_HFT_2023241.Logic.Classes;
using GG1RKK_HFT_2023241.Logic.Interfaces;
using GG1RKK_HFT_2023241.Repository.Database;
using GG1RKK_HFT_2023241.Repository.Interface;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GG1RKK_HFT_2023241.Test
{
    [TestFixture]
    public class CategoryLogicTester
    {
        ICategoryLogic logic;
        Mock<IRepository<Category>> mockCategoryRepo;


        [SetUp]
        public void Init()
        {
            mockCategoryRepo = new Mock<IRepository<Category>>();
            mockCategoryRepo.Setup(m => m.ReadAll()).Returns(new List<Category>()
            {
                new Category { CategoryName = "test1" , Items = GeneratedItems()}
            }.AsQueryable());
            logic = new CategoryLogic(mockCategoryRepo.Object);
        }

        private ICollection<Item> GeneratedItems()
        {
            List<Item> list = new List<Item>
            {
                new Item {ItemId = 1, ItemName = "SWORD", CategoryId = 1, Price = 100 },
                new Item {ItemId = 2, ItemName = "SHIELD", CategoryId = 1, Price = 150 },
                new Item {ItemId = 3, ItemName = "HAMMER", CategoryId = 1, Price = 60 }
            };
            return list;


        }

        [TestCase("test1",3)]
        public void Test(string cname, int expected)
        {
            //arrange
            //string category_name = "test1";
            //int expected = 3;
            //act
            int result = logic.GetItemsNumberInCategory(cname);
            //assert
            Assert.That(expected, Is.EqualTo(result));
        }
    }
}
