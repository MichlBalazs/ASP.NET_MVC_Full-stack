using GG1RKK_HFT_202324.Models;
using GG1RKK_HFT_2023241.Logic.Interfaces;
using GG1RKK_HFT_2023241.Repository.Database;
using GG1RKK_HFT_2023241.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace GG1RKK_HFT_2023241.Logic.Classes
{
    public class AdventurerLogic : IAdventurerLogic
    {
        IRepository<Adventurer> repo;
        public AdventurerLogic(IRepository<Adventurer> repo)
        {
            this.repo = repo;
        }

        public void Create(Adventurer adventurer)
        {
            repo.Create(adventurer);
        }

        public void Delete(int id)
        {
            repo.Delete(id);
        }

        public Adventurer Read(int id)
        {
            var adventurer = this.repo.Read(id);
            if (adventurer == null)
            {
                throw new ArgumentException("Order does not exist");
            }
            return adventurer;
        }

        public IQueryable<Adventurer> ReadAll()
        {
            return repo.ReadAll();
        }

        public void Update(Adventurer adventurer)
        {
            repo.Update(adventurer);
        }
        public IEnumerable<object> GetAdventurerCountWithOrders()
        {
            return repo.ReadAll()
                .Select(adventurer => new
                {
                    AdventurerName = adventurer.AdventurerName,
                    OrderCount = repo.ReadAll().Count(order => order.AdventurerId == adventurer.AdventurerId)
                });
        }
        public IEnumerable<object> GetAdventurersWithOrders()
        {
            return repo.ReadAll()
                .Where(adventurer => adventurer.Orders.Any())
                .Select(adventurer => new
                {
                    AdventurerName = adventurer.AdventurerName,
                    Orders = adventurer.Orders.Select(order => new
                    {
                        OrderId = order.OrderId,
                        ItemName = order.Item.ItemName
                    })
                });
        }

    }
}
