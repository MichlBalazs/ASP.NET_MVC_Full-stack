using GG1RKK_HFT_202324.Models;
using GG1RKK_HFT_2023241.Logic.Interfaces;
using GG1RKK_HFT_2023241.Repository.Interface;
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
            if (order.CustomerName.Length < 3)
            {
                throw new ArgumentException("Name is too short");
            }
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
    }
}
