using GG1RKK_HFT_202324.Models;
using GG1RKK_HFT_2023241.Logic.Classes;
using GG1RKK_HFT_2023241.Repository.Database;
using GG1RKK_HFT_2023241.Repository.Interface;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace GG1RKK_HFT_2023241.Test
{
    [TestFixture]
    public class AdventurerLogicTester
    {
        AdventurerLogic logic;
        Mock<IRepository<Adventurer>> mockAdventurerRepo;

        [SetUp]
        public void Init()
        {
            mockAdventurerRepo = new Mock<IRepository<Adventurer>>();
            mockAdventurerRepo.Setup(m => m.ReadAll()).Returns(new List<Adventurer>()
            {
                new Adventurer { AdventurerId = 2, AdventurerName = "Finn the Human", Class = "Bro", Level = 5 }
            }.AsQueryable());
            logic = new AdventurerLogic(mockAdventurerRepo.Object); 
        }

        [Test]
        public void AdventurerCreateTestNameIncorrect()
        {
            var adventurer = new Adventurer() { AdventurerName = "a", Level = 1};
            try
            {
                logic.Create(adventurer);
            }
            catch
            {

            }
            mockAdventurerRepo.Verify(r => r.Create(adventurer), Times.Never);
        }

        [Test]
        public void AdventurerCreateTestNameCorrect()
        {
            var adventurer = new Adventurer() { AdventurerName = "John", Level = 1 };
            try
            {
                logic.Create(adventurer);
            }
            catch
            {

            }
            mockAdventurerRepo.Verify(r => r.Create(adventurer), Times.Once);
        }
        [Test]
        public void AdventurerCreateTestLevelIncorrect()
        {
            var adventurer = new Adventurer() { AdventurerName = "John", Level = -1 };
            try
            {
                logic.Create(adventurer);
            }
            catch
            {

            }
            mockAdventurerRepo.Verify(r => r.Create(adventurer), Times.Never);
        }
    }
}
