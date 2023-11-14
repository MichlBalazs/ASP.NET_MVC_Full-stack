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
    internal class OrderLogic : IOrderLogic
    {
        IRepository<Order> repo;
        public OrderLogic(IRepository<Order> repo)
        {
            this.repo = repo;
        }

        public void Create(Order item)
        {
            repo.Create(item);
        }

        public void Delete(int id)
        {
            repo.Delete(id);
        }

        public Order Read(int id)
        {
            return repo.Read(id);
        }

        public IQueryable<Order> ReadAll()
        {
            return repo.ReadAll();
        }

        public void Update(Order item)
        {
            repo.Update(item);
        }
    }
}
