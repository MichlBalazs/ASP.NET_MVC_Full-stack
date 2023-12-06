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

        public IEnumerable<OrderDetails> GetOrdersWithDetails()
        {
            return repo.ReadAll()
                .Select(order => new OrderDetails
                {
                    AdventurerName = order.Adventurer.AdventurerName,
                    ItemName = order.Item.ItemName,
                    ItemPrice = order.Item.Price
                });
        }

    }

    public class OrderDetails
    {
        public string AdventurerName { get; set; }
        public string ItemName { get; set; }
        public int ItemPrice { get; set; }
        public override bool Equals(object obj)
        {
            OrderDetails o = obj as OrderDetails;
            return this.AdventurerName == o.AdventurerName && this.ItemName == o.AdventurerName && this.ItemPrice == o.ItemPrice;
        }
    }
}
