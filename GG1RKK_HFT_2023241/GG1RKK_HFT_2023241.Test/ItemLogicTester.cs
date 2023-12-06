using GG1RKK_HFT_202324.Models;
using GG1RKK_HFT_2023241.Logic.Classes;
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
    public class ItemLogicTester
    {
        ItemLogic logic;
        Mock<IRepository<Item>> mockItemRepo;
        [SetUp]
        public void Init()
        {
            mockItemRepo = new Mock<IRepository<Item>>();
            mockItemRepo.Setup(m => m.ReadAll()).Returns(new List<Item>()
            {
                new Item {ItemId = 1, ItemName = "Claymore", CategoryId = 1, Price = 100 }
            }.AsQueryable());
            logic = new ItemLogic(mockItemRepo.Object);
        }
        [Test]
        public void ItemCreateTestNameIncorrect()
        {
            var item = new Item() { ItemName = "a" };
            try
            {
                logic.Create(item);
            }
            catch
            {

            }
            mockItemRepo.Verify(r => r.Create(item), Times.Never);
        }

        [Test]
        public void ItemCreateTestNameCorrect()
        {
            var item = new Item() { ItemName = "Sword of training" };
            try
            {
                logic.Create(item);
            }
            catch
            {

            }
            mockItemRepo.Verify(r => r.Create(item), Times.Once);
        }
    }
}
