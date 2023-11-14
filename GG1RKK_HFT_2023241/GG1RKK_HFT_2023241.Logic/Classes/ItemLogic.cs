using GG1RKK_HFT_202324.Models;
using GG1RKK_HFT_2023241.Logic.Interfaces;
using GG1RKK_HFT_2023241.Repository.Interface;
using System;
using System.Linq;

namespace GG1RKK_HFT_2023241.Logic.Classes
{
    public class ItemLogic : IItemLogic
    {
        IRepository<Item> repo;
        public ItemLogic(IRepository<Item> repo)
        {
            this.repo = repo;
        }
        public void Create(Item item)
        {
            repo.Create(item);
        }

        public void Delete(int id)
        {
            repo.Delete(id);
        }

        public Item Read(int id)
        {
            return repo.Read(id);
        }

        public IQueryable<Item> ReadAll()
        {
            return repo.ReadAll();
        }

        public void Update(Item item)
        {
            repo.Update(item);
        }
    }
}
