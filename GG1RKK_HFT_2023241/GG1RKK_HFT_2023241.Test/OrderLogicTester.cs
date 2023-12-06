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
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GG1RKK_HFT_2023241.Test
{
    [TestFixture]
    public class OrderLogicTester
    {
        IOrderLogic logic;
        Mock<IRepository<Order>> mockOrderRepo;
        [SetUp]
        public void Init()
        {
            mockOrderRepo = new Mock<IRepository<Order>>();
            mockOrderRepo.Setup(m => m.ReadAll()).Returns(new List<Order>()
            {
                new Order { OrderId = 1, AdventurerId = 1, ItemId = 1, Item = item1, Adventurer = a1 },
                new Order { OrderId = 2, AdventurerId = 1, ItemId = 2, Item = item2, Adventurer = a1 }
            }.AsQueryable);
            logic = new OrderLogic(mockOrderRepo.Object);
        }

        Item item1 = new Item { ItemId = 1, ItemName = "SWORD", CategoryId = 1, Price = 100 };
        Item item2 = new Item { ItemId = 2, ItemName = "SHIELD", CategoryId = 1, Price = 50 };
        Adventurer a1 = new Adventurer { AdventurerId = 1, AdventurerName = "Little Lisa", Class = "Fighter", Level = 3 };

        [Test]
        public void OrderCountTest1()
        {
            //arrange
            int id = 1;
            int expected = 2;
            //act
            var result = logic.OrderCount(id);
            //assert
            Assert.That(result == expected);
        }
        [Test]
        public void OrderCountTest2()
        {
            //arrange
            int id = 3;
            int expected = 0;
            //act
            var result = logic.OrderCount(id);
            //assert
            Assert.That(result == expected);
        }

        [Test]
        public void OrderedItemsCategoryTest()
        {
            //arrange
            int expected = 1;
            int id = 1;
            //act
            int result = logic.OrderedItemsCategory(id);
            //assert
            Assert.That(result == expected);
        }

        [Test]
        public void OrderedItemsAvgPriceTest()
        {
            double expected = 75;
            double result = logic.OrderedItemsAvgPrice();
            Assert.That(expected == result);
        }

        [Test]
        public void WhoBoughtThisItemTest()
        {
            int id = 1;
            string expected = "Little Lisa";
            string result = logic.WhoBoughtThisItem(id);
            Assert.That(expected == result);
        }
    }
}
