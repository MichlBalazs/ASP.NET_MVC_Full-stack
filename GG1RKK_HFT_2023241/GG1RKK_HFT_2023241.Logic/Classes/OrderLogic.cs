using GG1RKK_HFT_202324.Models;
using GG1RKK_HFT_2023241.Logic.Interfaces;
using GG1RKK_HFT_2023241.Repository.Database;
using GG1RKK_HFT_2023241.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GG1RKK_HFT_2023241.Logic.Classes
{
    public class OrderLogic : IOrderLogic
    {
        IRepository<Order> repo;
        public OrderLogic(IRepository<Order> repo)
        {
            this.repo = repo;
        }

        public void Create(Order order)
        {
            repo.Create(order);
        }

        public void Delete(int id)
        {
            repo.Delete(id);
        }

        public Order Read(int id)
        {
            var order = this.repo.Read(id);
            if (order == null)
            {
                throw new ArgumentException("Order does not exist");
            }
            return order;
        }

        public IQueryable<Order> ReadAll()
        {
            return repo.ReadAll();
        }

        public void Update(Order order)
        {
            repo.Update(order);
        }
        public int OrderCount(int AdventurerId)
        {
            return this.repo.ReadAll().Where(x => x.AdventurerId == AdventurerId).Count();
        }
        public int OrderedItemsCategory(int OrderId)
        {
            return this.repo.ReadAll().FirstOrDefault(x => x.OrderId == OrderId).Item.CategoryId;
        }
        public double OrderedItemsAvgPrice()
        {
            return this.repo.ReadAll().Average(x => x.Item.Price);
        }
        public string WhoBoughtThisItem(int itemId)
        {
            var result = this.repo.ReadAll().Where(x => x.Item.ItemId == itemId).Select(y => y.Adventurer.AdventurerName).FirstOrDefault();
            return result;
        }
    }
}
