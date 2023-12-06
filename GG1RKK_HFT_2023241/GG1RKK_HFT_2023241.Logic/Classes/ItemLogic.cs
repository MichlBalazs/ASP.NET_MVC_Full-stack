using Castle.DynamicProxy;
using GG1RKK_HFT_202324.Models;
using GG1RKK_HFT_2023241.Logic.Interfaces;
using GG1RKK_HFT_2023241.Repository.Database;
using GG1RKK_HFT_2023241.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
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
            if (item.ItemName.Length < 3)
            {
                throw new ArgumentException("Name is too short");
            }
            repo.Create(item);
        }

        public void Delete(int id)
        {
            repo.Delete(id);
        }

        public Item Read(int id)
        {
            var item = this.repo.Read(id);
            if (item == null)
            {
                throw new ArgumentException("Item does not exist");
            }
            return item;
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
